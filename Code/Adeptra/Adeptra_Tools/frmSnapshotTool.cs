using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Adeptra_Tools
{
    public partial class frmSnapshotTool : Form
    {
        public frmSnapshotTool()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\thanhpham.HARVEYNASH\Desktop\apm2_lloydsbgukfraudcredit_snapshot.sql");

            Regex reg = new Regex(@"<model>(.*?)<\/model>");

            MatchCollection mc = reg.Matches(text);

            textBox1.Text = mc[0].Value;
        }
    }
}
