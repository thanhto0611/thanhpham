using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Runtime.InteropServices;
using mfb;
using Microsoft.VisualBasic.FileIO;
using DTO;
using BUS;

namespace Presentation
{
    public partial class frmFbPostToGroups : Form
    {
        DataTable dt = new DataTable();

        private string[] imagesFileName;
        private int rowIdx = -1;
        private int imgIdx = -1;
        private int _step = 0;
        private bool showWbPostToFanpage = false;

        public frmFbPostToGroups()
        {
            InitializeComponent();
        }

        private void frmFbPostToGroups_Load(object sender, EventArgs e)
        {
            dt.Columns.Add("GroupId");
            dt.Columns.Add("GroupName");
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

        private void btnLoadGroup_Click(object sender, EventArgs e)
        {
            webFB.Navigate("https://m.facebook.com/browsegroups/?seemore");
            _step = 1;
            timeCheck.Start();
        }

        private void getGroupList()
        {
            HtmlElement root = webFB.Document.GetElementById("root");
            HtmlElementCollection divColec = root.GetElementsByTagName("div");
            HtmlElementCollection aColec = divColec[1].GetElementsByTagName("a");

            Regex reg = new Regex("/groups/([0-9]{6,30})");
            List<string> keys = new List<string>();

            foreach (HtmlElement a in aColec)
            {
                if (reg.IsMatch(a.GetAttribute("href")))
                {
                    string href = a.GetAttribute("href").Replace("https://m.facebook.com/groups/", "");
                    if (!keys.Contains(href))
                    {
                        DataRow dr = dt.NewRow();
                        dr[0] = href;
                        dr[1] = a.InnerText;

                        dt.Rows.Add(dr);
                        keys.Add(href);
                    }
                }
            }

            dtgvGroupList.DataSource = dt;

            HtmlElement seeMore = webFB.Document.GetElementById("m_more_item");
            if (seeMore != null)
            {
                webFB.Navigate(seeMore.GetElementsByTagName("a")[0].GetAttribute("href"));
                _step = 1;
                timeCheck.Start();
            }
            else
            {
                MessageBox.Show("List groups done");
            }
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

        private void timerDelayBetweenPost_Tick(object sender, EventArgs e)
        {
            timerDelayBetweenPost.Stop();

            rowIdx++;
            imgIdx += 3;

            if (rowIdx >= dtgvGroupList.Rows.Count)
            {
                rowIdx = 0;
            }
            if ((imagesFileName.Length - imgIdx) < 3)
            {
                imgIdx = 0;
            }
            string url = "https://m.facebook.com/groups/" + dtgvGroupList.Rows[rowIdx].Cells[0].Value.ToString();
            webFB.Navigate(url);
            _step = 2;
            timeCheck.Start();
        }

        private void goToPostImageForm()
        {
            HtmlElement input = webFB.Document.GetElementById("u_0_1");
            if (input != null)
            {
                input.InvokeMember("click");
            }

            _step = 3;
            timerTemp.Start();
        }

        private void postImage()
        {
            HtmlElementCollection textareaColec = webFB.Document.GetElementsByTagName("textarea");
            foreach (HtmlElement textarea in textareaColec)
            {
                if (textarea.GetAttribute("name") == "xc_message")
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
                if (input.GetAttribute("name") == "file2")
                {
                    input.Focus();
                    SendKeys.SendWait(imagesFileName[imgIdx + 1]);
                }
                if (input.GetAttribute("name") == "file3")
                {
                    input.Focus();
                    SendKeys.SendWait(imagesFileName[imgIdx + 2]);
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

        private void btnShowHideWbPostToGroups_Click(object sender, EventArgs e)
        {
            if (showWbPostToFanpage)
                showWbPostToFanpage = false;
            else
                showWbPostToFanpage = true;

            webFB.Visible = showWbPostToFanpage;
        }

        private void frmFbPostToGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmFbPostToGroups = null;
        }
    }
}
