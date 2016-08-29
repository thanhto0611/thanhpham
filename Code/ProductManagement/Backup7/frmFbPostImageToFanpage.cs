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
    public partial class frmFbPostImageToFanpage : Form
    {
        private int arrAlbumListIndex = -1;
        private int rowAlbumImgIdx = -1;
        private int _step = 0;
        private string[] imagesFileName;
        private bool showWbPostToFanpage = false;

        ArrayList arrAlbumList = new ArrayList();
        DataTable dtAlbumImages = new DataTable();

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

        public frmFbPostImageToFanpage()
        {
            InitializeComponent();
        }

        private void frmFbPostImageToFanpage_Load(object sender, EventArgs e)
        {
            dtAlbumImages.Columns.Add("ImageName");
        }

        private void timeCheck_Tick(object sender, EventArgs e)
        {
            if (wbPostToFanpage.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timeCheck.Stop();
                switch (_step)
                {
                    case 1:
                        getAlbumList();
                        break;
                    case 2:
                        postImageToAlbum();
                        break;
                    default:
                        break;
                }

            }
        }

        private void btnGetAlbumList_Click(object sender, EventArgs e)
        {
            //wbPostToFanpage.Navigate("https://m.facebook.com/thoitrangella?v=photos");
            wbPostToFanpage.Navigate("https://m.facebook.com/thoitrangella/photos/albums/?owner_id=323527981089854&refid=17");
            _step = 1;
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
                if (_step == 1)
                {
                    cbxAlbumList.DataSource = arrAlbumList;
                    cbxAlbumList.DisplayMember = "name";
                    cbxAlbumList.ValueMember = "url";
                    MessageBox.Show("Get album list done");
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

        private void btnShowHideWbPostToFanpage_Click(object sender, EventArgs e)
        {
            if (showWbPostToFanpage)
                showWbPostToFanpage = false;
            else
                showWbPostToFanpage = true;

            wbPostToFanpage.Visible = showWbPostToFanpage;
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
            _step = 2;
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
            _step = 2;
            timeCheck.Start();
        }

        private void frmFbPostImageToFanpage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmFbPostImageToFanpage = null;
        }
    }
}
