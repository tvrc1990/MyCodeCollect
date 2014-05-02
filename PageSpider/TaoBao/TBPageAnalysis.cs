using Ivony.Web.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ivony.Web.Html.Binding;
using Ivony.Web.Html.Parser;
using Ivony.Web.Html.HtmlAgilityPackAdaptor;
using CommonLibrary;
using DBHelperLibrary.ORM;
namespace PageSpider.TaoBao
{

    public class TBPageAnalysis
    {
        private IHtmlElement element;
        public TBPageAnalysis(IHtmlElement element)
        {
            this.element = element;
        }

        public Products ProductInfo()
        {
            Products product = new Products();
            product.Title = GetTitle();
            product.Price = GetPrice();
            product.Postage = GetPostage();
            product.ShopName = GetShopName();
            product.Address = GetAddress();
            product.ItemUrl = GetUrl();
            product.SalesVolume = GetSalesVolume();
            product.Uid = GetUid(product.ItemUrl);
            return product;
        }

        private string GetTitle()
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

        private decimal GetPrice()
        {
            decimal price = 0;
            try
            {
                string _price = element.Find("div[class=col price]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
                _price = _price.Trim('￥').Trim();
                price=decimal.Parse(_price);
                return price;
            }
            catch (Exception)
            {
                return price;
            }

        }

        private decimal GetPostage()
        {
            decimal postage = 0;
            try
            {
                string _postage=element.Find("div[class=col end shipping]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
                _postage = _postage.Trim().Replace("运费：", "");
                postage=decimal.Parse(_postage);
                return postage;
            }
            catch (Exception)
            {
                return postage;
            }
        }

        private string GetShopName()
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

        private string GetAddress()
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

        private int GetSalesVolume()
        {
            int result = 0;
            try
            {
                string _result = element.Find("div[class=col dealing]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).InnerText().Trim();
                _result = _result.Replace("人付款", "");
                result = int.Parse(_result);
                return result;
            }
            catch (Exception)
            {
                return result;
            }

        }

        private string GetUrl()
        {
            try
            {
                return element.Find("a[trace=auction]").FirstOrDefault(n => !string.IsNullOrEmpty(n.InnerText().Trim())).Attribute("href").Value();
            }
            catch (Exception)
            {
                return "";
            }
        }

        private string GetUid(string url)
        {
            try
            {
                int index = url.LastIndexOf("id") + 3;
                string itemId = url.Substring(index, url.Length - index);
                return itemId;
            }
            catch (Exception)
            {
                return "";
            }
        }

    }

}
