using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class UIPluginController : Controller
    {
        //
        // GET: /UIPlug/

        public ActionResult FileUpLoad()
        {
            switch (Request["T"])
            {
                case "plupload": Plupload(); break;
            }
            return View();
        }

        /// <summary>
        /// Plupload File Upload 
        /// </summary>
        private void Plupload()
        {
            int chunk = Request.Params["chunk"] != null ? int.Parse(Request.Params["chunk"]) : 0;
            string fileName = Request.Params["name"] != null ? Request.Params["name"] : Guid.NewGuid().ToString();
            //open a file, if our chunk is 1 or more, we should be appending to an existing file, otherwise create a new file
            FileStream fs = new FileStream(Server.MapPath("/FileDirectory/UpLoadFile/" + fileName), FileMode.Create, FileAccess.ReadWrite);

            //write our input stream to a buffer
            Byte[] buffer = null;
            if (Request.ContentType == "application/octet-stream" && Request.ContentLength > 0)
            {
                buffer = new Byte[Request.InputStream.Length];
                Request.InputStream.Read(buffer, 0, buffer.Length);
            }
            else if (Request.ContentType.Contains("multipart/form-data") && Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
            {
                buffer = new Byte[Request.Files[0].InputStream.Length];
                Request.Files[0].InputStream.Read(buffer, 0, buffer.Length);
            }

            //write the buffer to a file.
            fs.Write(buffer, 0, buffer.Length);
            fs.Close();
        }

    }
}
