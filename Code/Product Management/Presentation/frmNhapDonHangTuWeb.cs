using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

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
            btnNhap.Enabled = true;
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                SanPhamBUS spBus = new SanPhamBUS();
                frmQuanLyDonHang.dt = spBus.GetNull();
                HtmlElementCollection tables = webBrowser1.Document.GetElementsByTagName("table");

                HtmlElementCollection tbodys = tables[2].GetElementsByTagName("tbody");
                foreach (HtmlElement tbody in tbodys)
                {
                    HtmlElementCollection tds = tbody.GetElementsByTagName("tr")[0].GetElementsByTagName("td");
                    DataRow dr = frmQuanLyDonHang.dt.NewRow();

                    if (tds[0].GetElementsByTagName("span").Count > 0 && tds[0].GetElementsByTagName("span")[0].InnerText != "")
                    {
                        SanPhamDTO spDto = SanPhamBUS.LaySanPham(tds[0].GetElementsByTagName("span")[0].InnerText);
                        dr[0] = tds[0].GetElementsByTagName("span")[0].InnerText;
                        dr[1] = spDto.HinhAnh;
                        dr[2] = spDto.MauSac;
                        dr[4] = tds[4].GetElementsByTagName("strong")[0].InnerText;
                        dr[5] = spDto.TrangThai;
                        dr[7] = spDto.GiaSi;
                        dr[8] = spDto.GiaLe;

                        frmQuanLyDonHang.dt.Rows.Add(dr);
                    }
                }

                frmQuanLyDonHang._readFromWebDone = true;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }
    }
}
