using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmThongKeTL : Form
    {
        public frmThongKeTL()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            TKTheLoai Tk = new TKTheLoai();
            crystalReportViewer1.ReportSource = Tk;
        }
    }
}