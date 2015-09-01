using System;
using System.Collections.Generic;
using System.Collections;
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
        string apiUrl = Main2._cfgDto.SoapAddress;
        string apiUser = "ellaxmlrpc";
        string apiPass = "nguoicodoc";
        string sessionId = Main2.sessionId;

        public DataTable resultTable = new DataTable();

        public frmSyncAPI()
        {
            InitializeComponent();

            resultTable.Columns.Add("MaSP", typeof(string));
            resultTable.Columns.Add("GiaSi", typeof(string));
            resultTable.Columns.Add("GiaLe", typeof(string));
            resultTable.Columns.Add("SoLuong", typeof(string));
            resultTable.Columns.Add("ConHetHang", typeof(string));
        }

        private void btnGetProductList_Click(object sender, EventArgs e)
        {
            try
            {
                resultTable.Clear();
                // list all products
                XmlRpcStruct filterOn = new XmlRpcStruct();
                XmlRpcStruct filterParams = new XmlRpcStruct();
                filterParams.Add("like", "dc%");
                filterOn.Add("sku", filterParams);
                Product[] myProducts = Product.List(apiUrl, sessionId, new object[] { filterOn });
                //Product[] myProducts = Product.List(apiUrl, sessionId);

                foreach (Product p in myProducts)
                {
                    DataRow dr = resultTable.NewRow();

                    dr[0] = p.sku;
                    dr[1] = p.gia_si;
                    dr[2] = p.price;
                    dr[3] = p.qty;
                    dr[4] = p.is_in_stock;

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

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This event handler is called when the background thread finishes. 
            // This method runs on the main thread. 
            if (e.Error != null)
                MessageBox.Show("Error: " + e.Error.Message);
            else if (e.Cancelled)
                MessageBox.Show("Word counting canceled.");
            else
                MessageBox.Show("Finished counting words.");
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This method runs on the main thread.
            Words.CurrentState state =
                (Words.CurrentState)e.UserState;
            this.LinesCounted.Text = state.LinesCounted.ToString();
            this.WordsCounted.Text = state.WordsMatched.ToString();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // This event handler is where the actual work is done. 
            // This method runs on the background thread. 

            // Get the BackgroundWorker object that raised this event.
            System.ComponentModel.BackgroundWorker worker;
            worker = (System.ComponentModel.BackgroundWorker)sender;

            // Get the Words object and call the main method.
            Words WC = (Words)e.Argument;
            WC.CountWords(worker, e);
        }

        private void StartThread()
        {
            // This method runs on the main thread. 
            this.WordsCounted.Text = "0";

            // Initialize the object that the background worker calls.
            Words WC = new Words();
            WC.CompareString = this.CompareString.Text;
            WC.SourceFile = this.SourceFile.Text;

            // Start the asynchronous operation.
            backgroundWorker1.RunWorkerAsync(WC);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            StartThread();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            // Cancel the asynchronous operation. 
            this.backgroundWorker1.CancelAsync();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataRow[] drs = resultTable.Select("MaSP = 'DC999'");
            MessageBox.Show(drs[0][3].ToString());
        }
    }
}
