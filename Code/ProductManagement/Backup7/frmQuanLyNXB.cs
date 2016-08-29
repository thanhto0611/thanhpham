using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmQuanLyNXB : Form
    {
        public frmQuanLyNXB()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemNXB frm = new frmThemNXB();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSuaNXB frm = new frmSuaNXB();
            frm.ShowDialog();
        }
    }
}