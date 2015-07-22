using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using System.IO;

namespace Presentation
{
    public partial class frmSyncAPI : Form
    {
        string apiUrl = "http://localhost/ella/api/xmlrpc";
        string apiUser = "ellaxmlrpc";
        string apiPass = "nguoicodoc";
        string sessionId;

        public DataTable resultTable = new DataTable();

        public frmSyncAPI()
        {
            InitializeComponent();

            resultTable.Columns.Add("Mã SP", typeof(string));
            resultTable.Columns.Add("Giá Sỉ", typeof(string));
            resultTable.Columns.Add("Giá Lẻ", typeof(string));
            resultTable.Columns.Add("Số Lượng", typeof(string));
            resultTable.Columns.Add("Còn/Hết Hàng", typeof(string));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // login (make sure you have user and role assigned in magento admin)
                sessionId = Connection.Login(apiUrl, apiUser, apiPass);

                //string sessionId = Connection.Login(apiUrl, new object[] { apiUser, apiPass });
                MessageBox.Show("Authenticated with Session ID " + sessionId);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                return;
            }
        }

        private void btnGetProductList_Click(object sender, EventArgs e)
        {
            try
            {
                resultTable.Clear();
                // list all products
                XmlRpcStruct filterOn = new XmlRpcStruct();
                XmlRpcStruct filterParams = new XmlRpcStruct();
                filterParams.Add("like", "dc001%");
                filterOn.Add("sku", filterParams);
                Product[] myProducts = Product.List(apiUrl, sessionId, new object[] { filterOn });
                //Product[] myProducts = Product.List(apiUrl, sessionId);
                foreach (Product product in myProducts)
                {
                    DataRow dr = resultTable.NewRow();

                    dr[0] = product.sku;
                    dr[1] = product.gia_si;
                    dr[2] = product.price;
                    //dr[3] = product.qty;
                    //dr[4] = product.is_in_stock;

                    resultTable.Rows.Add(dr);
                }
                dataGridView1.DataSource = resultTable;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // update a product
                Product myProduct = new Product();
                myProduct.price = "95.0000";
                myProduct.gia_si = "40.0000";
                myProduct.sku = "DC001";
                //myProduct.is_in_stock = "1";
                //myProduct.qty = "25.0000";

                //Helper.APIUpdate(apiUrl, sessionId, myProduct);
                //MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void frmSyncAPI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmSyncAPI = null;
        }
    }
}
