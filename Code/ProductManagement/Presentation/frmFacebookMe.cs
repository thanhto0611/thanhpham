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
    public partial class frmFacebookMe : Form
    {
        private int _step = 0;
        // 1: load group list
        // 2: navigate to group page

        DataTable dt = new DataTable();
        DataTable dtSearchGroup = new DataTable();
        DataTable dtAlbumImages = new DataTable();
        DataTable dtAllAlbumImages = new DataTable();

        ArrayList arrAlbumList = new ArrayList();

        private string[] imagesFileName;

        private int rowIdx = -1;
        private int imgIdx = -1;

        private int rowSearchIdx = -1;
        private int rowAlbumImgIdx = -1;
        private int arrAlbumListIndex = -1;
        private int numGroupJoined = 0;

        private bool showWbPostToFanpage = false;

        public class album
        {
            public string _name;
            public string _url;
            public album(string Name, string Url)
            {
                this._name = Name;
                this._url = Url;
            }

            public string name
            {
                get { return _name; }
                set { _name = name; }
            }

            public string url
            {
                get { return _url; }
                set { _url = url; }
            }
        }


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
            dtSearchGroup.Columns.Add("GroupId");
            dtSearchGroup.Columns.Add("GroupName");
            dtSearchGroup.Columns.Add("GroupMember", typeof(int));

            dtAlbumImages.Columns.Add("ImageName");

            dtAllAlbumImages.Columns.Add("ImageURL");

            dt.Columns.Add("GroupId");
            dt.Columns.Add("GroupName");
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

            ////string html = ulColec[0].InnerHtml;
            //string html = contentTable.InnerHtml;
            //html = html.Replace(@"\/", "/");
            //html = html.Replace(@"\u0025", "%");
            //html = html.Replace("&amp;", "&");
            //html = html.Replace("&quot;", "\"");

            ////Regex reg = new Regex("/groups/([0-9]{6,30})[^>]+>([^<]+)");
            //MatchCollection mc = reg.Matches(html);

            //List<string> keys = new List<string>();
            //foreach (Match m in mc)
            //{
            //    if (!keys.Contains(m.Groups[1].Value))
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr[0] = m.Groups[1].Value;
            //        dr[1] = m.Groups[2].Value;
            //        //ids.Add(m.Groups[1].Value, m.Groups[2].Value);
            //        dt.Rows.Add(dr);
            //        keys.Add(m.Groups[1].Value);
            //    }
            //}
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

        private void timeCheck_Tick(object sender, EventArgs e)
        {
            if (webFB.ReadyState != WebBrowserReadyState.Complete || wbPostToFanpage.ReadyState != WebBrowserReadyState.Complete)
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
                        goToComposerForm();
                        break;
                    case 3:
                        postImage();
                        break;
                    case 4:
                        finish();
                        break;
                    case 5:
                        searchGroup();
                        break;
                    case 6:
                        goToGroupPage();
                        break;
                    case 7:
                        getSearchGroupList();
                        break;
                    case 8:
                        requestJoinGroup();
                        break;
                    case 9:
                        getAlbumList();
                        break;
                    case 10:
                        postImageToAlbum();
                        break;
                    case 11:
                        getAlbumList();
                        break;
                    case 12:
                        getImages();
                        break;
                    case 13:
                        goToPostImageForm();
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

        private void goToComposerForm()
        {
            //string url = "";

            HtmlElement input = webFB.Document.GetElementById("u_0_1");
            input.InvokeMember("click");

            //HtmlElementCollection aColec = webFB.Document.GetElementsByTagName("a");
            //foreach (HtmlElement a in aColec)
            //{
            //    if (a.GetAttribute("href").Contains("/composer/?tid="))
            //    {
            //        url += a.GetAttribute("href");
            //        break;
            //    }
            //}

            //fb.UploadPhotoNew(url);

            //webFB.Navigate(url);
            _step = 13;
            timerTemp.Start();
        }

        private void goToPostImageForm()
        {
            //string url = "";

            //HtmlElementCollection aColec = webFB.Document.GetElementsByTagName("a");
            //foreach (HtmlElement a in aColec)
            //{
            //    if (a.GetAttribute("href").Contains("/photos/upload/"))
            //    {
            //        url += a.GetAttribute("href");
            //        break;
            //    }
            //}

            ////fb.UploadPhotoNew(url);

            //webFB.Navigate(url);
            //_step = 3;
            //timeCheck.Start();

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

        private void btnSearchGroup_Click(object sender, EventArgs e)
        {
            if (txtGroupName.Text == "")
            {
                MessageBox.Show("Please input the group name");
                return;
            }

            webFB.Navigate("https://m.facebook.com/search/");
            _step = 5;
            timeCheck.Start();
        }

        private void searchGroup()
        {

            HtmlElementCollection inputColec = webFB.Document.GetElementsByTagName("input");

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
            _step = 6;
            timerTemp.Start();
        }

        private void goToGroupPage()
        {
            string url = "";
            HtmlElementCollection aColec = webFB.Document.GetElementsByTagName("a");
            foreach (HtmlElement a in aColec)
            {
                if (a.GetAttribute("href").Contains("search=group"))
                {
                    url += a.GetAttribute("href");
                    break;
                }
            }

            webFB.Navigate(url);
            _step = 7;
            timeCheck.Start();
        }

        private void getSearchGroupList()
        {
            HtmlElementCollection tableColec = webFB.Document.GetElementsByTagName("table");

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
            HtmlElementCollection aColec = webFB.Document.GetElementsByTagName("a");
            foreach (HtmlElement a in aColec)
            {
                if (a.GetAttribute("href").Contains("search=group") && a.InnerText == "Xem thêm kết quả")
                {
                    string temp = a.GetAttribute("href") + a.InnerText + "\n";
                    txtCaption.Text = temp;
                    url += a.GetAttribute("href");
                    break;
                }
            }

            if (url != "")
            {
                webFB.Navigate(url);
                _step = 7;
                timeCheck.Start();
            }
            else
            {
                MessageBox.Show("Done");
            }
        }

        private void timerTemp_Tick(object sender, EventArgs e)
        {
            timerTemp.Stop();
            if (_step == 8)
            {
                timerJoin.Start();
            } 
            else
            {
                timeCheck.Start();
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

        private void requestJoinGroup()
        {
            //HtmlElement joinButton = webFB.Document.GetElementById("groupJoinHeaderButton");
            
            //if (joinButton != null && joinButton.GetAttribute("value") == "Tham gia nhóm")
            //{
            //    joinButton.InvokeMember("click");
            //    dtgvGroupSearchResult.Rows[rowSearchIdx].DefaultCellStyle.BackColor = Color.Yellow;
            //    numGroupJoined++;
            //    timerTemp.Start();
            //}
            //else
            //{
            //    dtgvGroupSearchResult.Rows[rowSearchIdx].DefaultCellStyle.BackColor = Color.Green;
            //    timerJoin.Start();
            //}

            HtmlElementCollection inputColec = webFB.Document.GetElementsByTagName("input");
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
            webFB.Navigate(url);
            _step = 8;
            timeCheck.Start();
        }

        private void btnGetAlbumList_Click(object sender, EventArgs e)
        {
            //wbPostToFanpage.Navigate("https://m.facebook.com/thoitrangella?v=photos");
            wbPostToFanpage.Navigate("https://m.facebook.com/thoitrangella/photos/albums/?owner_id=323527981089854&refid=17");
            _step = 9;
            timeCheck.Start();
        }

        private void getAlbumList()
        {
            HtmlElement root = wbPostToFanpage.Document.GetElementById("root");

            HtmlElementCollection aColec = root.GetElementsByTagName("a");

            foreach (HtmlElement a in aColec)
            {
                if (a.GetAttribute("href").Contains("/thoitrangella/albums/"))
                {
                    string html = a.GetAttribute("href");
                    Regex reg = new Regex("/albums/([0-9]{6,30})");
                    MatchCollection mc = reg.Matches(html);

                    album ab = new album(a.InnerText, mc[0].Groups[1].Value.ToString());
                    
                    arrAlbumList.Add(ab);
                }
            }

            string url = "";

            foreach (HtmlElement a in aColec)
            {
                if (a.InnerText != null)
                {
                    if (a.GetAttribute("href").Contains("/photos/albums/") && a.InnerText.Contains("Xem thêm"))
                    {
                        url = a.GetAttribute("href");
                        break;
                    }
                }
            }

            if (url != "")
            {
                wbPostToFanpage.Navigate(url);
                timeCheck.Start();
            }
            else
            {
                if (_step == 9)
                {
                    cbxAlbumList.DataSource = arrAlbumList;
                    cbxAlbumList.DisplayMember = "name";
                    cbxAlbumList.ValueMember = "url";
                    MessageBox.Show("Get album list done");
                }
                else
                {
                    navigateToAlbum();
                }
            }
        }

        private void btnBrowseAlbumImages_Click(object sender, EventArgs e)
        {
            openAlbumImages.ShowDialog();
        }

        private void openAlbumImages_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            imagesFileName = openAlbumImages.FileNames;
            string fileNames = "";
            foreach (string filename in openAlbumImages.FileNames)
            {
                fileNames = fileNames + filename + ";";
                DataRow dr = dtAlbumImages.NewRow();
                dr[0] = filename;

                dtAlbumImages.Rows.Add(dr);
            }
            txtAlbumImages.Text = fileNames;
            dtgvAlbumImages.DataSource = dtAlbumImages;
        }

        private void btnPostToAlbum_Click(object sender, EventArgs e)
        {
            if (cbxAlbumList.Text == "")
            {
                MessageBox.Show("Please get album list first");
                return;
            }
            if (dtgvAlbumImages.Rows.Count == 0)
            {
                MessageBox.Show("Please select images to post");
                return;
            }

            string url = "https://m.facebook.com/photos/upload/?album_id=" + cbxAlbumList.SelectedValue.ToString() + "&upload_source=album";

            wbPostToFanpage.Navigate(url);
            _step = 10;
            timeCheck.Start();
        }

        private void postImageToAlbum()
        {
            rowAlbumImgIdx++;
            if (rowAlbumImgIdx > 0)
            {
                System.IO.File.Move(dtgvAlbumImages.Rows[rowAlbumImgIdx - 1].Cells[0].Value.ToString(), dtgvAlbumImages.Rows[rowAlbumImgIdx - 1].Cells[0].Value.ToString() + ".posted");
            }

            if (rowAlbumImgIdx == dtgvAlbumImages.Rows.Count)
            {
                MessageBox.Show("All images were posted");
                return;
            }

            HtmlElementCollection textareaColec = wbPostToFanpage.Document.GetElementsByTagName("textarea");

            foreach (HtmlElement textarea in textareaColec)
            {
                if (textarea.GetAttribute("name") == "caption")
                {
                    string caption = txtAlbumImageCaption.Text;

                    Uri uri = new Uri(dtgvAlbumImages.Rows[rowAlbumImgIdx].Cells[0].Value.ToString());
                    string filename = "";
                    if (uri.IsFile)
                    {
                        filename = System.IO.Path.GetFileName(uri.LocalPath);
                    }

                    string[] splitFileName = filename.Split('-');
                    string giaSi = splitFileName[2].Split('.')[0];

                    caption = caption + "\n" + splitFileName[0];
                    caption = caption + "\nGIÁ SỈ: " + giaSi + "K";
                    caption = caption + "\nGIÁ LẺ: " + splitFileName[1] + "K";
                    caption = caption + "\nWWW.THOITRANGELLA.COM";

                    textarea.SetAttribute("value", caption);
                    break;
                }
            }

            HtmlElementCollection inputColec = wbPostToFanpage.Document.GetElementsByTagName("input");
            foreach (HtmlElement input in inputColec)
            {
                if (input.GetAttribute("name") == "file1")
                {
                    input.Focus();
                    SendKeys.SendWait(dtgvAlbumImages.Rows[rowAlbumImgIdx].Cells[0].Value.ToString());
                }
                if (input.GetAttribute("type") == "submit")
                {
                    input.InvokeMember("click");
                    dtgvAlbumImages.Rows[rowAlbumImgIdx].DefaultCellStyle.BackColor = Color.Yellow;
                    
                    break;
                }
            }

            if (txtDelayAlbumPost.Text != "")
            {
                timerPostToAlbum.Interval = Int32.Parse(txtDelayAlbumPost.Text);
            }
            timerPostToAlbum.Start();
        }

        private void timerPostToAlbum_Tick(object sender, EventArgs e)
        {
            timerPostToAlbum.Stop();

            string url = "https://m.facebook.com/photos/upload/?album_id=" + cbxAlbumList.SelectedValue.ToString() + "&upload_source=album";

            wbPostToFanpage.Navigate(url);
            _step = 10;
            timeCheck.Start();
        }

        private void btnGetAllImages_Click(object sender, EventArgs e)
        {
            webFB.Navigate("https://m.facebook.com/thoitrangella?v=photos");
            _step = 11;
            timeCheck.Start();
        }

        private void navigateToAlbum()
        {
            arrAlbumListIndex++;
            if (arrAlbumListIndex >= arrAlbumList.Count)
            {
                MessageBox.Show("Get all images done");
                return;
            }
            album ab = (album)arrAlbumList[arrAlbumListIndex];
            string url = "https://m.facebook.com/thoitrangella/albums/" + ab._url;

            webFB.Navigate(url);
            _step = 12;
            timeCheck.Start();
        }

        private void getImages()
        {
            if (webFB.Document.Body.InnerHtml == "")
            {
                _step = 12;
                timeCheck.Start();
                return;
            }
            HtmlElement moreItems = webFB.Document.GetElementById("m_more_item");

            if (moreItems == null)
            {
                navigateToAlbum();
                return;
            }

            HtmlElement thumbnail_area = webFB.Document.GetElementById("thumbnail_area");
            HtmlElementCollection aColec = thumbnail_area.GetElementsByTagName("a");

            foreach (HtmlElement a in aColec)
            {
                DataRow dr = dtAllAlbumImages.NewRow();

                dr[0] = a.GetAttribute("href");

                dtAllAlbumImages.Rows.Add(dr);
            }

            dtgvImageList.DataSource = dtAllAlbumImages;

            webFB.Navigate(moreItems.GetElementsByTagName("a")[0].GetAttribute("href"));
            _step = 12;
            timeCheck.Start();
        }

        private void btnShowHideWbPostToFanpage_Click(object sender, EventArgs e)
        {
            if (showWbPostToFanpage)
                showWbPostToFanpage = false;
            else
                showWbPostToFanpage = true;

            wbPostToFanpage.Visible = showWbPostToFanpage;
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
            _step = 13;
            timeCheck.Start();
        }

        private void btnSaveGroups_Click(object sender, EventArgs e)
        {
            if (dtgvGroupList.Rows.Count == 0)
            {
                MessageBox.Show("Please load group list first");
                return;
            }

            foreach (DataGridViewRow row in this.dtgvGroupList.Rows)
            {
                FbGroupDTO groupDTO = new FbGroupDTO();
                groupDTO.GroupId = row.Cells["GroupId"].Value.ToString();
                groupDTO.GroupName = row.Cells["GroupName"].Value.ToString();
                //groupDTO.NumberOfMember = Int32.Parse(row.Cells["GroupMember"].Value.ToString());
                groupDTO.NguoiNhap = frmDangNhap.gUserName;
                groupDTO.NgayNhap = System.DateTime.Now;

                FbGroupBUS.Insert(groupDTO);
            }

            MessageBox.Show("Done");
        }

        private void btnUpdateGroups_Click(object sender, EventArgs e)
        {
            if (dtgvGroupSearchResult.Rows.Count == 0)
            {
                MessageBox.Show("Please load group list first");
                return;
            }

            foreach (DataGridViewRow row in this.dtgvGroupSearchResult.Rows)
            {
                FbGroupDTO groupDTO = new FbGroupDTO();
                groupDTO.GroupId = row.Cells["GroupId"].Value.ToString();
                groupDTO.GroupName = row.Cells["GroupName"].Value.ToString();
                groupDTO.NumberOfMember = Int32.Parse(row.Cells["GroupMember"].Value.ToString());
                groupDTO.NguoiCapNhat = frmDangNhap.gUserName;
                groupDTO.NgayCapNhat = System.DateTime.Now;

                FbGroupBUS.Update(groupDTO);
            }

            MessageBox.Show("Done");
        }

        private void btnGetAllData_Click(object sender, EventArgs e)
        {

        }
    }
}
