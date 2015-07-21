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
        string apiUrl = "http://www.thoitrangella.com/api/xmlrpc";
        string apiUser = "ellaxmlrpc";
        string apiPass = "nguoicodoc";
        string sessionId;

        public frmSyncAPI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // login (make sure you have user and role assigned in magento admin)
            sessionId = Connection.Login(apiUrl, apiUser, apiPass);

            //string sessionId = Connection.Login(apiUrl, new object[] { apiUser, apiPass });
            MessageBox.Show("Authenticated with Session ID " + sessionId);
        }

        private void btnGetProductList_Click(object sender, EventArgs e)
        {
            // list all products
            XmlRpcStruct filterOn = new XmlRpcStruct();
            XmlRpcStruct filterParams = new XmlRpcStruct();
            filterParams.Add("like", "dc%");
            filterOn.Add("sku", filterParams);
            Product[] myProducts = Product.List(apiUrl, sessionId, new object[] { filterOn });
            MessageBox.Show("Done");
        }
    }
}
