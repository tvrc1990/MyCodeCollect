using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonLibrary;
using Ivony.Fluent;
using Ivony.Web.Html;
using Ivony.Web.Html.Binding;
using Ivony.Web.Html.Parser;
using Ivony.Web.Html.HtmlAgilityPackAdaptor;
namespace QzoneSpider
{
    public class QzonePage
    {
        public void GetQzoneUserIno()
        {
            string url = "http://user.qzone.qq.com/2201208782/1";
            string htmlContent = WebHelper.GetHttpWebRequest(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);
            var document = htmlDocument.AsDocument();
            var links = document.Find("a[href]");
            foreach (IHtmlElement linkElement in links)
            {
                IHtmlElement element = linkElement;
            }
        }

    }
}
