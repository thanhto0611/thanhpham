using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmQuanLyDanhMuc : Form
    {
        public frmQuanLyDanhMuc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemDanhMuc frm = new frmThemDanhMuc();
            frm.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }
    }
}
