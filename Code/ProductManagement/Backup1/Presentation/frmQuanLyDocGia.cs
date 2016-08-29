using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmQuanLyDocGia : Form
    {
        public frmQuanLyDocGia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemDocGia frm = new frmThemDocGia();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSuaDocGia frm = new frmSuaDocGia();
            frm.ShowDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}