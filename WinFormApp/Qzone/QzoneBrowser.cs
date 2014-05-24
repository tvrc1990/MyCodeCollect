using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormApp.Qzone
{
    public partial class QzoneBrowser : Form
    {
        WebBrowser webBrowser;
        public QzoneBrowser()
        {
            InitializeComponent();
        }

        private void QzoneBrowser_Load(object sender, EventArgs e)
        {
            webBrowser = new WebBrowser();
            webBrowser.Url = new Uri("http://user.qzone.qq.com/2201208782/");
            webBrowser.Top = 0;
            webBrowser.Left = 0;
            webBrowser.Width = 500;
            webBrowser.Height = 500;
            this.Controls.Add(webBrowser);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string html = webBrowser.DocumentText;
        }
    }
}
