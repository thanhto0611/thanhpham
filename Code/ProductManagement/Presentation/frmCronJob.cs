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
    public partial class frmCronJob : Form
    {
        public bool _isLogin = false;
        string cacheUri = "";

        public frmCronJob()
        {
            InitializeComponent();
        }

        private void wbCron_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            if (!_isLogin)
            {
                HtmlElement username = wbCron.Document.GetElementById("username");
                if (username == null)
                {
                    _isLogin = true;
                    return;
                }
                username.SetAttribute("value", "admin");

                HtmlElement pass = wbCron.Document.GetElementById("login");
                pass.SetAttribute("value", "nguoicodoc1");

                foreach (HtmlElement form in wbCron.Document.Forms)
                    form.InvokeMember("submit");

                _isLogin = true;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                HtmlElementCollection aColec = wbCron.Document.GetElementsByTagName("a");

                foreach (HtmlElement a in aColec)
                {
                    if (a.GetAttribute("href").Contains("http://www.thoitrangella.com/index.php/admin/cache/index/key/"))
                    {
                        cacheUri = a.GetAttribute("href");
                        break;
                    }
                }

                wbCron.Navigate(cacheUri);
                txtUri.Text = cacheUri;

                timerCron.Interval = Int32.Parse(txtDelayTime.Text);
                timerRefresh.Interval = Int32.Parse(txtRefreshTime.Text);

                timerRefresh.Start();
                timerCron.Start();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (wbCron.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timerRefresh.Stop();
                wbCron.Navigate(cacheUri);
                timerRefresh.Start();
            }
        }

        private void timerCron_Tick(object sender, EventArgs e)
        {
            if (wbCron.ReadyState != WebBrowserReadyState.Complete)
            {
                timerTemp.Start();
                return;
            }
            else
            {
                timerRefresh.Stop();
                timerCron.Stop();
                timerTemp.Stop();

                HtmlElementCollection buttonColec = wbCron.Document.GetElementsByTagName("button");

                foreach (HtmlElement button in buttonColec)
                {
                    if (button.InnerText == "Flush Catalog Images Cache")
                    {
                        button.InvokeMember("click");
                        break;
                    }
                }

                timerRefresh.Start();
                timerCron.Start();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timerRefresh.Stop();
            timerCron.Stop();

            HtmlElementCollection buttonColec = wbCron.Document.GetElementsByTagName("button");

            foreach (HtmlElement button in buttonColec)
            {
                if (button.InnerText == "Flush Catalog Images Cache")
                {
                    button.InvokeMember("click");
                    break;
                }
            }

            
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {
            if (wbCron.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timerRefresh.Stop();
                timerCron.Stop();
                timerTemp.Stop();

                HtmlElementCollection buttonColec = wbCron.Document.GetElementsByTagName("button");

                foreach (HtmlElement button in buttonColec)
                {
                    if (button.InnerText == "Flush Catalog Images Cache")
                    {
                        button.InvokeMember("click");
                        break;
                    }
                }

                timerRefresh.Start();
                timerCron.Start();
            }
        }
    }
}
