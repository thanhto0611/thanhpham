using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Presentation
{
    public partial class frmFacebookMe : Form
    {
        private int _step = 0;
        // 1: load group list
        // 2: navigate to group page
        public frmFacebookMe()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            logIn();
        }

        private void logIn()
        {
            string email = txtEmail.Text;
            string pass = txtPass.Text;

            HtmlElement logInForm = webFB.Document.GetElementById("login_form");
            HtmlElementCollection inputCol = logInForm.GetElementsByTagName("input");

            foreach (HtmlElement input in inputCol)
            {
                if(input.GetAttribute("name") == "email")
                {
                    input.SetAttribute("value", email);
                }
                if (input.GetAttribute("name") == "pass")
                {
                    input.SetAttribute("value", pass);
                }
            }

            logInForm.GetElementsByTagName("button")[0].InvokeMember("click");
        }

        private void frmFacebookMe_Load(object sender, EventArgs e)
        {
            
        }

        private void btnLoadGroup_Click(object sender, EventArgs e)
        {
            webFB.Navigate("https://m.facebook.com/browsegroups/?seemore");
            _step = 1;
            timeCheck.Start();
        }

        private void getGroupList()
        {
            HtmlElementCollection ulColec = webFB.Document.GetElementsByTagName("ul");

            DataTable dt = new DataTable();
            dt.Columns.Add("GroupId");
            dt.Columns.Add("GroupName");

            string html = ulColec[0].InnerHtml;
            html = html.Replace(@"\/", "/");
            html = html.Replace(@"\u0025", "%");
            html = html.Replace("&amp;", "&");
            html = html.Replace("&quot;", "\"");

            Regex reg = new Regex("/groups/([0-9]{6,30})[^>]+>([^<]+)");
            MatchCollection mc = reg.Matches(html);

            List<string> keys = new List<string>();
            foreach (Match m in mc)
            {
                if (!keys.Contains(m.Groups[1].Value))
                {
                    DataRow dr = dt.NewRow();
                    dr[0] = m.Groups[1].Value;
                    dr[1] = m.Groups[2].Value;
                    //ids.Add(m.Groups[1].Value, m.Groups[2].Value);
                    dt.Rows.Add(dr);
                    keys.Add(m.Groups[1].Value);
                }
            }
            dtgvGroupList.DataSource = dt;
        }

        private void timeCheck_Tick(object sender, EventArgs e)
        {
            if (webFB.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timeCheck.Stop();
                switch (_step)
                {
                    case 1:
                        getGroupList();
                        break;
                    case 2:
                        goToPostImageForm();
                        break;
                    case 3:
                        postImage();
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void btnPostToGroup_Click(object sender, EventArgs e)
        {
            string url = "https://m.facebook.com/groups/288036308032487";
            webFB.Navigate(url);
            _step = 2;
            timeCheck.Start();
        }

        private void goToPostImageForm()
        {
            string url = "";

            HtmlElementCollection aColec = webFB.Document.GetElementsByTagName("a");
            foreach (HtmlElement a in aColec)
            {
                if (a.GetAttribute("href").Contains("/photos/upload/"))
                {
                    url += a.GetAttribute("href");
                    break;
                }
            }

            webFB.Navigate(url);
            _step = 3;
            timeCheck.Start();
        }

        private void postImage()
        {
            HtmlElementCollection textareaColec = webFB.Document.GetElementsByTagName("textarea");
            foreach (HtmlElement textarea in textareaColec)
            {
                if (textarea.GetAttribute("name") == "caption")
                {
                    textarea.SetAttribute("value", "ELLA SHOP - TRANG SỨC PHỤ KIỆN GIÁ RẺ\nWWW.THOITRANGELLA.COM\nhttps://www.facebook.com/thoitrangella\n\n--------------\n\nChuyên cung cấp sỉ và lẻ trang sức phụ kiện giá rẻ, đẹp, phù hợp với mọi lứa tuổi");
                    break;
                }
            }

            HtmlElementCollection inputColec = webFB.Document.GetElementsByTagName("input");
            foreach (HtmlElement input in inputColec)
            {
                if (input.GetAttribute("name") == "file1")
                {
                    input.SetAttribute("value", @"D:\Temp\Phu Kien Toc\kt006-10k.jpg");
                    
                    break;
                }
                //if (input.GetAttribute("type") == "submit")
                //{
                //    input.InvokeMember("click");
                //    break;
                //}
            }
        }
    }
}
