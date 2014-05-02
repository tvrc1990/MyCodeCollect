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
    public class TaoBaoPage
    {
        public void GetQzoneUserIno()
        {
            List<IHtmlElement> tempList = new List<IHtmlElement>();
            //获取页面HTML
            string url = "http://s.taobao.com/search?q=%CF%E3%B9%BD&tab=all&promote=0&bcoffset=-8&s=1600#J_relative";
            string htmlContent = WebHelper.GetHttpWebRequest(url);

            //加载HTML DOM 到 解析器
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(htmlContent);
            var document = htmlDocument.AsDocument();
            //查询HTML中的指定条件的DOM
            var links = document.Find("div[class=item-box]");

            foreach (IHtmlElement linkElement in links)
            {
                ProductInfo(linkElement);
            }
            Console.ReadKey();
        }

        public void ProductInfo(IHtmlElement element)
        {
            string title = GetTitle(element);
            Console.WriteLine("标题：{0}", title);

            string price = GetPrice(element);
            Console.WriteLine("价格：{0}", price);

            string postage = GetPostage(element);
            Console.WriteLine("邮费：{0}", postage);

            string shopName = GetShopName(element);
            Console.WriteLine("店铺：{0}", shopName);

            string address = GetAddress(element);
            Console.WriteLine("地址：{0}", address);

            string salesVolume = GetSalesVolume(element);
            Console.WriteLine("销量：{0}\r\n", salesVolume);

            string uid = GetUid(element);
        }

        public string GetTitle(IHtmlElement element)
        {
            try
            {
                return element.Find("a[trace=auction]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string GetPrice(IHtmlElement element)
        {
            try
            {
                return element.Find("div[class=col price]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string GetPostage(IHtmlElement element)
        {
            try
            {
                return element.Find("div[class=col end shipping]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();

            }
            catch (Exception)
            {
                return "";
            }
        }

        public string GetShopName(IHtmlElement element)
        {
            try
            {
                return element.Find("a[trace=srpwwnick]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string GetAddress(IHtmlElement element)
        {
            try
            {
                return element.Find("div[class=col end loc]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string GetSalesVolume(IHtmlElement element)
        {
            try
            {
                return element.Find("div[class=col dealing]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
            }
            catch (Exception)
            {
                return "";
            }

        }

        public string GetUid(IHtmlElement element)
        {
            try
            {
                string itemUrl = element.Find("a[trace=auction]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).Attribute("href").Value();
                int index = itemUrl.LastIndexOf("id") + 3;
                string itemId = itemUrl.Substring(index, itemUrl.Length - index);
                return itemId;
            }
            catch (Exception)
            {
                return "";
            }
        }

    }
}
