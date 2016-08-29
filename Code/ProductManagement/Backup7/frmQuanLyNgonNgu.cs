using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmQuanLyNgonNgu : Form
    {
        public frmQuanLyNgonNgu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemNgonNgu frm = new frmThemNgonNgu();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSuaNgonNgu frm = new frmSuaNgonNgu();
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}