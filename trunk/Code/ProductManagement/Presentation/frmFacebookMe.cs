using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using mfb;

namespace Presentation
{
    public partial class frmFacebookMe : Form
    {
        private int _step = 0;
        // 1: load group list
        // 2: navigate to group page

        DataTable dt = new DataTable();

        private string[] imagesFileName;

        private int rowIdx = -1;
        private int imgIdx = -1;


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
                    case 4:
                        finish();
                        break;
                    default:
                        break;
                }
                
            }
        }

        private void btnPostToGroup_Click(object sender, EventArgs e)
        {
            if (dtgvGroupList.Rows.Count == 0)
            {
                MessageBox.Show("Please get group list");
                return;
            }
            if (txtCaption.Text == "")
            {
                MessageBox.Show("Please put the caption");
                return;
            }
            if (txtImages.Text == "")
            {
                MessageBox.Show("Please select Images to post");
                return;
            }

            timerDelayBetweenPost.Interval = Int32.Parse(txtTimeBetweenPost.Text);
            timerDelayBetweenPost.Start();


            //string url = "https://m.facebook.com/groups/288036308032487";
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

            //fb.UploadPhotoNew(url);

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
                    //textarea.SetAttribute("value", "ELLA SHOP - TRANG SỨC PHỤ KIỆN GIÁ RẺ\nWWW.THOITRANGELLA.COM\nhttps://www.facebook.com/thoitrangella\n\n--------------\n\nChuyên cung cấp sỉ và lẻ trang sức phụ kiện giá rẻ, đẹp, phù hợp với mọi lứa tuổi");
                    textarea.SetAttribute("value", txtCaption.Text);
                    break;
                }
            }

            HtmlElementCollection inputColec = webFB.Document.GetElementsByTagName("input");
            foreach (HtmlElement input in inputColec)
            {
                if (input.GetAttribute("name") == "file1")
                {
                    input.Focus();
                    SendKeys.SendWait(imagesFileName[imgIdx]);
                }
                if (input.GetAttribute("type") == "submit")
                {
                    input.InvokeMember("click");
                    break;
                }
            }
            _step = 4;
            timeCheck.Start();
        }

        private void finish()
        {
            if (dtgvGroupList.Rows[rowIdx].DefaultCellStyle.BackColor == Color.Yellow)
                dtgvGroupList.Rows[rowIdx].DefaultCellStyle.BackColor = Color.Green;
            else
                dtgvGroupList.Rows[rowIdx].DefaultCellStyle.BackColor = Color.Yellow;

            timerDelayBetweenPost.Interval = Int32.Parse(txtTimeBetweenPost.Text);
            timerDelayBetweenPost.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timerDelayBetweenPost.Stop();

            rowIdx++;
            imgIdx++;

            if (rowIdx >= dtgvGroupList.Rows.Count)
            {
                rowIdx = 0;
            }
            if (imgIdx >= imagesFileName.Length)
            {
                imgIdx = 0;
            }
            string url = "https://m.facebook.com/groups/" + dtgvGroupList.Rows[rowIdx].Cells[0].Value.ToString();
            webFB.Navigate(url);
            _step = 2;
            timeCheck.Start();
        }

        private void btnBrowseImages_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            imagesFileName = openFileDialog1.FileNames;
            string fileNames = "";
            foreach (string filename in openFileDialog1.FileNames)
            {
                fileNames = fileNames + filename + ";";
            }
            txtImages.Text = fileNames;
        }
    }
}
