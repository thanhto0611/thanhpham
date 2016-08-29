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
    public partial class frmFbFindAndJoinGroups : Form
    {
        private int _step = 0;
        private int rowSearchIdx = -1;
        private int numGroupJoined = 0;
        private bool showWbFindJoinGroups = false;

        DataTable dtSearchGroup = new DataTable();

        public frmFbFindAndJoinGroups()
        {
            InitializeComponent();
        }

        private void frmFbFindAndJoinGroups_Load(object sender, EventArgs e)
        {
            dtSearchGroup.Columns.Add("GroupId");
            dtSearchGroup.Columns.Add("GroupName");
            dtSearchGroup.Columns.Add("GroupMember", typeof(int));
        }

        private void timeCheck_Tick(object sender, EventArgs e)
        {
            if (wbFindAndJoinGroups.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timeCheck.Stop();
                switch (_step)
                {
                    case 1:
                        searchGroup();
                        break;
                    case 2:
                        goToGroupPage();
                        break;
                    case 3:
                        getSearchGroupList();
                        break;
                    case 4:
                        requestJoinGroup();
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnSearchGroup_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
            {
                MessageBox.Show("Please input the group name");
                return;
            }

            wbFindAndJoinGroups.Navigate("https://m.facebook.com/search/");
            _step = 1;
            timeCheck.Start();
        }

        private void searchGroup()
        {

            HtmlElementCollection inputColec = wbFindAndJoinGroups.Document.GetElementsByTagName("input");

            foreach (HtmlElement input in inputColec)
            {
                if (input.GetAttribute("name") == "query")
                {
                    input.SetAttribute("value", txtGroupName.Text);
                }
                if (input.GetAttribute("type") == "submit")
                {
                    input.InvokeMember("click");
                    break;
                }
            }
            _step = 2;
            timerTemp.Start();
        }

        private void goToGroupPage()
        {
            string url = "";
            HtmlElementCollection aColec = wbFindAndJoinGroups.Document.GetElementsByTagName("a");
            foreach (HtmlElement a in aColec)
            {
                if (a.GetAttribute("href").Contains("search=group"))
                {
                    url += a.GetAttribute("href");
                    break;
                }
            }

            wbFindAndJoinGroups.Navigate(url);
            _step = 3;
            timeCheck.Start();
        }

        private void getSearchGroupList()
        {
            HtmlElementCollection tableColec = wbFindAndJoinGroups.Document.GetElementsByTagName("table");

            //HtmlElementCollection tdColec = tableColec[2].GetElementsByTagName("td");

            HtmlElementCollection tdColec = null;

            string html = "";

            Regex reg = new Regex("/groups/([0-9]{6,30})[^>]+>([^<]+)");

            foreach (HtmlElement table in tableColec)
            {
                html = table.InnerHtml;
                html = html.Replace(@"\/", "/");
                html = html.Replace(@"\u0025", "%");
                html = html.Replace("&amp;", "&");
                html = html.Replace("&quot;", "\"");


                MatchCollection mc = reg.Matches(html);

                if (mc.Count > 0)
                {
                    tdColec = table.GetElementsByTagName("td");
                    break;
                }
            }

            foreach (HtmlElement td in tdColec)
            {
                html = td.InnerHtml;
                html = html.Replace(@"\/", "/");
                html = html.Replace(@"\u0025", "%");
                html = html.Replace("&amp;", "&");
                html = html.Replace("&quot;", "\"");

                MatchCollection mc1 = reg.Matches(html);

                if (mc1.Count > 0)
                {
                    DataRow dr = dtSearchGroup.NewRow();
                    dr[0] = mc1[0].Groups[1].Value;
                    dr[1] = td.GetElementsByTagName("a")[0].InnerText;
                    string numMember = Regex.Replace(td.GetElementsByTagName("div")[0].InnerText, @"[^\d]", String.Empty);
                    dr[2] = Int32.Parse(numMember);

                    dtSearchGroup.Rows.Add(dr);
                }
            }
            dtgvGroupSearchResult.DataSource = dtSearchGroup;
            string url = "";
            HtmlElementCollection aColec = wbFindAndJoinGroups.Document.GetElementsByTagName("a");
            foreach (HtmlElement a in aColec)
            {
                if (a.GetAttribute("href").Contains("search=group") && a.InnerText == "Xem thêm kết quả")
                {
                    url += a.GetAttribute("href");
                    break;
                }
            }

            if (url != "")
            {
                wbFindAndJoinGroups.Navigate(url);
                _step = 3;
                timeCheck.Start();
            }
            else
            {
                MessageBox.Show("Done");
            }
        }

        private void btnJoinGroup_Click(object sender, EventArgs e)
        {
            if (dtgvGroupSearchResult.Rows.Count == 0)
            {
                MessageBox.Show("Please search groups first");
                return;
            }

            timerJoin.Start();
        }

        private void timerJoin_Tick(object sender, EventArgs e)
        {
            timerJoin.Stop();

            rowSearchIdx++;
            if (txtNumOfGroup.Text != "")
            {
                if (numGroupJoined > Int32.Parse(txtNumOfGroup.Text))
                {
                    MessageBox.Show("Joined " + txtNumOfGroup.Text + " groups");
                    return;
                }
            }

            if (rowSearchIdx >= dtgvGroupSearchResult.Rows.Count)
            {
                MessageBox.Show("Joined all groups");
                return;
            }

            string url = "https://m.facebook.com/groups/" + dtgvGroupSearchResult.Rows[rowSearchIdx].Cells[0].Value.ToString();
            wbFindAndJoinGroups.Navigate(url);
            _step = 4;
            timeCheck.Start();
        }

        private void requestJoinGroup()
        {
            HtmlElementCollection inputColec = wbFindAndJoinGroups.Document.GetElementsByTagName("input");
            bool joinClick = false;

            foreach (HtmlElement input in inputColec)
            {
                if (input.GetAttribute("value") == "Tham gia nhóm")
                {
                    input.InvokeMember("click");
                    dtgvGroupSearchResult.Rows[rowSearchIdx].DefaultCellStyle.BackColor = Color.Yellow;
                    numGroupJoined++;
                    joinClick = true;
                    timerTemp.Start();
                    break;
                }
            }

            if (joinClick == false)
            {
                dtgvGroupSearchResult.Rows[rowSearchIdx].DefaultCellStyle.BackColor = Color.Green;
                timerJoin.Start();
            }
        }

        private void btnShowHideWbFindAndJoinGroups_Click(object sender, EventArgs e)
        {
            if (showWbFindJoinGroups)
                showWbFindJoinGroups = false;
            else
                showWbFindJoinGroups = true;

            wbFindAndJoinGroups.Visible = showWbFindJoinGroups;
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {
            timerTemp.Stop();
            if (_step == 4)
            {
                timerJoin.Start();
            }
            else
            {
                timeCheck.Start();
            }
        }

        private void frmFbFindAndJoinGroups_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmFbFindJoinGroups = null;
        }
    }
}
