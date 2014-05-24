using PageSpider.TaoBao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] keyArray = { "鼠标", "键盘", "兼容机", "笔记本电脑", "衬衫", "休闲裤", "" };
            List<KeyWord> keyArray = new List<KeyWord>();
            keyArray.Add(new KeyWord() { TypeId = 8, KeyString = "洁面" });
            keyArray.Add(new KeyWord() { TypeId = 8, KeyString = "美白" });
            keyArray.Add(new KeyWord() { TypeId = 7, KeyString = "板鞋" });
            keyArray.Add(new KeyWord() { TypeId = 6, KeyString = "休牛仔裤" });
            keyArray.Add(new KeyWord() { TypeId = 6, KeyString = "休闲裤" });
            keyArray.Add(new KeyWord() { TypeId = 5, KeyString = "衬衫" });
            keyArray.Add(new KeyWord() { TypeId = 5, KeyString = "t桖" });
            keyArray.Add(new KeyWord() { TypeId = 5, KeyString = "小西装" });
            keyArray.Add(new KeyWord() { TypeId = 4, KeyString = "手链" });
            keyArray.Add(new KeyWord() { TypeId = 4, KeyString = "项链" });
            keyArray.Add(new KeyWord() { TypeId = 3, KeyString = "游戏鼠标" });
            keyArray.Add(new KeyWord() { TypeId = 3, KeyString = "无线键盘" });
            keyArray.Add(new KeyWord() { TypeId = 3, KeyString = "华硕笔记本" });
            keyArray.Add(new KeyWord() { TypeId = 2, KeyString = "小巧盆景" });
            keyArray.Add(new KeyWord() { TypeId = 1, KeyString = "大枣" });
            foreach (KeyWord key in keyArray)
            {
                new TaoBao().Main(key.KeyString, key.TypeId);
            }

        }
    }
    public class KeyWord
    {
        public int TypeId
        {
            set;
            get;
        }

        public string KeyString
        {
            set;
            get;
        }
    }
}
