using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;

namespace Presentation
{
    public partial class frmNhapDonHangTuWeb : Form
    {
        public bool _isLogin = false;
        public DataTable dtDonHangWeb = new DataTable();

        public frmNhapDonHangTuWeb()
        {
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            if (!_isLogin)
            {
                HtmlElement username = webBrowser1.Document.GetElementById("username");
                if (username == null)
                {
                    _isLogin = true;
                    return;
                }
                username.SetAttribute("value", "admin");

                HtmlElement pass = webBrowser1.Document.GetElementById("login");
                pass.SetAttribute("value", "nguoicodoc1");

                foreach (HtmlElement form in webBrowser1.Document.Forms)
                    form.InvokeMember("submit");

                _isLogin = true;
            }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            SanPhamBUS spBus = new SanPhamBUS();
            frmQuanLyDonHang.dtWeb = spBus.GetNull();
            HtmlElementCollection tables = webBrowser1.Document.GetElementsByTagName("table");

            HtmlElementCollection tbodys = tables[2].GetElementsByTagName("tbody");
            foreach (HtmlElement tbody in tbodys)
            {
                HtmlElementCollection tds = tbody.GetElementsByTagName("tr")[0].GetElementsByTagName("td");
                DataRow dr = frmQuanLyDonHang.dtWeb.NewRow();

                if (tds[0].GetElementsByTagName("span").Count > 0)
                {
                    dr[0] = tds[0].GetElementsByTagName("span")[0].InnerText;
                    dr[4] = tds[4].GetElementsByTagName("strong")[0].InnerText;
                }

                dtDonHangWeb.Rows.Add(dr);
            }

            this.Close();
        }
    }
}
