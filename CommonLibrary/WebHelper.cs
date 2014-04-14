using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibrary
{
    public class WebHelper
    {
        public static string GetHttpWebRequest(string url)
        {
            Uri uri = new Uri(url);
            Uri urlqq = new Uri("http://www.qq.com");
            Uri urlqz = new Uri("http://www.qzone.qq.com");

            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(uri);
            myReq.CookieContainer = new CookieContainer();
            CookieContainer cookie = myReq.CookieContainer;

            cookie.Add(urlqz, new Cookie("Loading", "Yes"));
            cookie.Add(urlqz, new Cookie("QZ_FE_WEBP_SUPPORT", "1"));
            cookie.Add(urlqq, new Cookie("RK", "pVuzR5qx3q"));
            cookie.Add(urlqz, new Cookie("__Q_w_s__appDataSeed", "1"));
            cookie.Add(urlqz, new Cookie("__Q_w_s__QZN_TodoMsgCnt", "1"));
            
            cookie.Add(urlqz, new Cookie("cpu_performance", "48"));
            cookie.Add(urlqq, new Cookie("o_cookie", "442539908"));
            cookie.Add(urlqz, new Cookie("p_skey", "lF12IqAEr7letAt7kY7vp9E72nzeyKWQTBRjAUsMaiE_"));
            cookie.Add(urlqq, new Cookie("pgv_info", "ssid=s4545402786"));
            cookie.Add(urlqq, new Cookie("pgv_pvi", "6548152320"));

            cookie.Add(urlqq, new Cookie("pgv_pvid", "8654600"));
            cookie.Add(urlqq, new Cookie("pt2gguin", "o2201208782"));
            cookie.Add(urlqz, new Cookie("pt4_token", "HabaTRstsL*CbWgtrsAGMg__"));
            cookie.Add(urlqq, new Cookie("ptcz", "d7e6047e2b711814d45fc3a11892c46189ed5a606e15f67ed5ee63f808ad16ca"));
            cookie.Add(urlqq, new Cookie("ptisp", "ctc"));

            cookie.Add(urlqz, new Cookie("qzspeedup", "sdch"));
            cookie.Add(urlqq, new Cookie("skey", "@7MsdX1upP"));
            cookie.Add(urlqq, new Cookie("uin", "o2201208782"));


            myReq.UserAgent = "User-Agent:Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705";
            myReq.Accept = "*/*";
            myReq.KeepAlive = true;
            myReq.Headers.Add("Accept-Language", "zh-cn,en-us;q=0.5");
            HttpWebResponse result = (HttpWebResponse)myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
            string strHTML = readerOfStream.ReadToEnd();
            readerOfStream.Close();
            receviceStream.Close();
            result.Close();
            return strHTML;
        }

        public static string GetWebRequest(string url)
        {
            Uri uri = new Uri(url);
            WebRequest myReq = WebRequest.Create(uri);
            WebResponse result = myReq.GetResponse();
            Stream receviceStream = result.GetResponseStream();
            StreamReader readerOfStream = new StreamReader(receviceStream, System.Text.Encoding.GetEncoding("utf-8"));
            string strHTML = readerOfStream.ReadToEnd();
            readerOfStream.Close();
            receviceStream.Close();
            result.Close();
            return strHTML;
        }

        public static string GetWebClient(string url)
        {
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, System.Text.Encoding.GetEncoding("utf-8"));
            strHTML = sr.ReadToEnd();
            myStream.Close();
            return strHTML;
        }


        /// <summary>
        /// 获取对应的URL的COOKIE
        /// </summary>
        /// <param name="pchURL"></param>
        /// <param name="pchCookieName"></param>
        /// <param name="pchCookieData"></param>
        /// <param name="pcchCookieData"></param>
        /// <param name="dwFlags"></param>
        /// <param name="lpReserved"></param>
        /// <returns></returns>
        [DllImport("wininet.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool InternetGetCookieEx(string pchURL, string pchCookieName, StringBuilder pchCookieData, ref int pcchCookieData, int dwFlags, object lpReserved);
        private static string GetCookieString(string url)
        {
            // Determine the size of the cookie     
            int datasize = 256;
            StringBuilder cookieData = new StringBuilder(datasize);

            if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
            {
                if (datasize < 0)
                    return null;

                // Allocate stringbuilder large enough to hold the cookie     
                cookieData = new StringBuilder(datasize);
                if (!InternetGetCookieEx(url, null, cookieData, ref datasize, 0x00002000, null))
                    return null;
            }
            return cookieData.ToString();
        }

    }
}
