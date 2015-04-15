using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using DTO;
using BUS;
using System.Globalization;
using OfficeOpenXml.Drawing;
using System.Diagnostics;
using OfficeOpenXml;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace Presentation
{
    public partial class frmSyncToWeb : Form
    {
        public DataTable resultTable = new DataTable();

        public frmSyncToWeb()
        {
            InitializeComponent();
            //webSync.Navigate("http://localhost:8080/ella/magmi/web/magmi.php");

            resultTable.Columns.Add("store", typeof(string));
            resultTable.Columns.Add("sku", typeof(string));
            resultTable.Columns.Add("qty", typeof(string));
            resultTable.Columns.Add("is_in_stock", typeof(string));
            resultTable.Columns.Add("gia_si", typeof(string));
            resultTable.Columns.Add("price", typeof(string));
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                ftp ftpClient = new ftp(@"ftp://115.84.181.41", "thoitra", "Pnht!)!!**");

                ftpClient.upload("public_html/var/import/test.txt", @"D:\test.txt");

                ftpClient = null;
                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSetSyncTime_Click(object sender, EventArgs e)
        {
            timerSync.Interval = Int32.Parse(txtTimeBetweenSync.Text);
        }

        private void timerSync_Tick(object sender, EventArgs e)
        {
            try
            {
                timerSync.Stop();

                string outFileName = "syncToWeb.csv";
                string exportFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\Export\", outFileName);
                if (File.Exists(exportFilePath))
                {
                    File.Delete(exportFilePath);
                }

                DataTable dt = new DataTable();
                dt = SanPhamBUS.XuatKhoHang();
                string store = "admin";
                string sku = "";
                string qty = "";
                string is_in_stock = "";
                string gia_si = "";
                string price = "";

                foreach (DataRow row in dt.Rows)
                {
                    sku = row.ItemArray.GetValue(0).ToString();
                    qty = row.ItemArray.GetValue(1).ToString() + ".0000";
                    is_in_stock = row.ItemArray.GetValue(2).ToString();
                    gia_si = row.ItemArray.GetValue(3).ToString() + ".0000";
                    price = row.ItemArray.GetValue(4).ToString() + ".0000";

                    DataRow dr = resultTable.NewRow();
                    dr[0] = store;
                    dr[1] = sku;
                    dr[2] = qty;
                    dr[3] = is_in_stock;
                    dr[4] = gia_si;
                    dr[5] = price;


                    resultTable.Rows.Add(dr);
                }

                StringBuilder sb = new StringBuilder();

                var columnNames = resultTable.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in resultTable.Rows)
                {
                    var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }

                File.WriteAllText(exportFilePath, sb.ToString(), Encoding.UTF8);

                // Upload to FTP
                ftp ftpClient = new ftp(@"ftp://115.84.181.41", "thoitra", "Pnht!)!!**");

                ftpClient.upload("public_html/var/import/syncToWeb.csv", exportFilePath);

                ftpClient = null;

                navigateToMagmiPage();

                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void navigateToMagmiPage()
        {
            webSync.Navigate("http://localhost:8080/ella/magmi/web/magmi.php");
            //step = 1;
            timerCheck.Start();
        }

        private void btnStartSync_Click(object sender, EventArgs e)
        {
            timerSync.Start();
        }

        private void timerCheck_Tick(object sender, EventArgs e)
        {
            if (webSync.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timerCheck.Stop();
                runImport();
            }
        }

        private void runImport()
        {
            HtmlElement csvFile = webSync.Document.GetElementById("csvfile");
            HtmlElementCollection options = csvFile.GetElementsByTagName("option");

            foreach (HtmlElement option in options)
            {
                if (option.GetAttribute("value").Contains("syncToWeb.csv"))
                {
                    option.SetAttribute("selected", "selected");
                    break;
                }
            }

            HtmlElement mode = webSync.Document.GetElementById("mode");
            HtmlElementCollection modeOptions = mode.GetElementsByTagName("option");

            foreach (HtmlElement modeOption in modeOptions)
            {
                if (modeOption.GetAttribute("value").Contains("update"))
                {
                    modeOption.SetAttribute("selected", "selected");
                    break;
                }
            }

            HtmlElement directRun = webSync.Document.GetElementById("directrun");
            HtmlElementCollection inputs = directRun.Document.GetElementsByTagName("input");

            foreach (HtmlElement input in inputs)
            {
                if (input.GetAttribute("value").Contains("Run Import"))
                {
                    input.InvokeMember("click");
                    break;
                }
            }
        }
    }
}
