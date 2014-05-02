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
using DBHelperLibrary.ORM;
namespace PageSpider.TaoBao
{
    public class TaoBao : ISpider
    {
        private string SearchPath = "http://s.taobao.com/search?q={0}&tab=all&promote=0&bcoffset=-8&s={1}#J_relative";
        private MyEntities entity = null;

        public void Main(string key, int type)
        {


            try
            {


                for (int i = 0; i < 50; i++)
                {
                    int index = i * 80;
                    string _searchPath = string.Format(SearchPath, key, index);

                    string htmlContent = WebHelper.GetHttpWebRequest(_searchPath);

                    //加载HTML DOM 到 解析器
                    var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                    htmlDocument.LoadHtml(htmlContent);
                    var document = htmlDocument.AsDocument();
                    //查询HTML中的指定条件的DOM
                    var links = document.Find("div[class=item-box]");

                    using (entity = new MyEntities())
                    {
                        foreach (IHtmlElement element in links)
                        {
                            Products pro = new TBPageAnalysis(element).ProductInfo();
                            if (!string.IsNullOrEmpty(pro.Uid))
                            {
                                Products _pro = entity.Products.FirstOrDefault(n => n.Uid == pro.Uid);
                                if (_pro == null)
                                {
                                    pro.TypeId = type;
                                    entity.Products.AddObject(pro);
                                }
                            }
                        }
                       entity.SaveChanges();
                    }
                }


            }
            catch (Exception e)
            {
                throw e.InnerException;
            }




        }

    }
}
