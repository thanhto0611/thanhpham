using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using OfficeOpenXml.Drawing;
using System.Diagnostics;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;

namespace ExportJiraList
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        
        public Form1()
        {
            InitializeComponent();

            dt.Columns.Add("Number", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("AssignTo", typeof(string));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (txtUrl.Text == "")
            {
                MessageBox.Show("Please input URL");
                return;
            }

            webBrowser1.Navigate(txtUrl.Text);
            timerCheck.Start();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timerCheck.Stop();
                btnExport.Enabled = true;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFilePath.Text == "")
                {
                    MessageBox.Show("Please set Task List file path before using this tool");
                    return;
                }
                if (txtLastRowIndex.Text == "")
                {
                    MessageBox.Show("Please chose last row index");
                    return;
                }

                int startRow = Int32.Parse(txtLastRowIndex.Text) + 1;

                HtmlElement issueTable = webBrowser1.Document.GetElementById("issuetable");
                HtmlElementCollection rows = issueTable.GetElementsByTagName("tr");

                HtmlElement wbNum = webBrowser1.Document.GetElementById("key-val");
                HtmlElement wbTitle = webBrowser1.Document.GetElementById("summary-val");

                string exportFilePath = txtFilePath.Text;

                FileInfo newFile = new FileInfo(exportFilePath);
                ExcelPackage excelPkg = new ExcelPackage(newFile);
                excelPkg.Workbook.Worksheets["Open_Need Review"].View.TabSelected = true;

                ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets["Open_Need Review"];

                oSheet.InsertRow(startRow, 1, 4);
                oSheet.InsertRow(startRow + 1, rows.Count, 5);

                oSheet.Cells[startRow, 9].Value = wbNum.InnerText;
                oSheet.Cells[startRow, 15].Value = wbTitle.InnerText;

                foreach (HtmlElement row in rows)
                {
                    startRow++;
                    DataRow dr = dt.NewRow();
                    dr[0] = row.GetAttribute("data-issuekey").ToString();

                    HtmlElementCollection cols = row.GetElementsByTagName("td");
                    dr[1] = cols[1].GetElementsByTagName("a")[0].InnerText;
                    dr[2] = cols[3].InnerText;
                    //dr[3] = cols[4].GetElementsByTagName("a")[0].InnerText;
                    dr[3] = "";

                    dt.Rows.Add(dr);

                    oSheet.Cells[startRow, 4].Value = cols[2].GetElementsByTagName("img")[0].GetAttribute("alt");
                    oSheet.Cells[startRow, 10].Value = row.GetAttribute("data-issuekey").ToString();
                    Uri uri = new Uri("http://jira.adeptra.com/browse/" + row.GetAttribute("data-issuekey").ToString());
                    oSheet.Cells[startRow, 10].Hyperlink = uri;

                    oSheet.Cells[startRow, 14].Value = "";
                    oSheet.Cells[startRow, 15].Value = cols[1].GetElementsByTagName("a")[0].InnerText;
                    oSheet.Cells[startRow, 16].Value = cols[3].InnerText.Replace(" ", "");
                }

                excelPkg.Save();
                MessageBox.Show("Done");
                //System.Diagnostics.Process.Start(exportFilePath);

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFilePath.Text = openFileDialog1.FileName;
        }

        private void btnSetFilePath_Click(object sender, EventArgs e)
        {
            if (txtFilePath.Text == "")
            {
                MessageBox.Show("Please chose Task List file path");
                return;
            }

            string saveFile = Path.Combine(Directory.GetCurrentDirectory(), "FilePath.txt");
            StreamWriter wr = new StreamWriter(saveFile);
            wr.Write(txtFilePath.Text);
            wr.Close();
            MessageBox.Show("Done");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string saveFile = Path.Combine(Directory.GetCurrentDirectory(), "FilePath.txt");
            StreamReader rd = new StreamReader(saveFile);
            txtFilePath.Text = rd.ReadLine();
            rd.Close();
        }
    }
}
