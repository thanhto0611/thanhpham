using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DTO;
using BUS;
using System.Linq;

namespace Presentation
{
    public partial class frmXuatKhoHang : Form
    {
        public DataTable resultTable = new DataTable();

        public frmXuatKhoHang()
        {
            InitializeComponent();

            resultTable.Columns.Add("store", typeof(string));
            resultTable.Columns.Add("sku", typeof(string));
            resultTable.Columns.Add("qty", typeof(string));
            resultTable.Columns.Add("is_in_stock", typeof(string));
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserLocation.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtLocation.Text = folderBrowserLocation.SelectedPath;
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtLocation.Text == "")
                {
                    MessageBox.Show("Please select Output folder");
                    return;
                }

                string outFileName = txtLocation.Text + @"/import_product_stocks_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".csv";

                DataTable dt = SanPhamBUS.XuatKhoHang();

                string store = "admin";
                string sku = "";
                string qty = "";
                string is_in_stock = "";

                foreach (DataRow row in dt.Rows)
                {
                    sku = row.ItemArray.GetValue(0).ToString();
                    qty = row.ItemArray.GetValue(1).ToString() + ".0000";

                    if (Int32.Parse(row.ItemArray.GetValue(1).ToString()) <= 0)
                    {
                        is_in_stock = "0";
                    }
                    else
                    {
                        is_in_stock = "1";
                    }

                    DataRow dr = resultTable.NewRow();
                    dr[0] = store;
                    dr[1] = sku;
                    dr[2] = qty;
                    dr[3] = is_in_stock;

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

                File.WriteAllText(outFileName, sb.ToString(), Encoding.UTF8);


                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void frmXuatKhoHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmXKH = null;
        }
    }
}
