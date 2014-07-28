using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void TraCuuSachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTraCuuSach frm = new frmTraCuuSach();
            frm.ShowDialog();
        }
		private void themSachToolStripButton_Click(object sender, EventArgs e)
        {
            //QuanLyLoaiSach frmQL = new QuanLyLoaiSach();
            //frmQL.TopLevel = false;
            //frmQL.FormBorderStyle = FormBorderStyle.None;
            //frmQL.Dock = DockStyle.Fill;
            //panel1.Controls.Add(frmQL);
            //frmQL.Top = panel1.Top;
            //frmQL.Left = (panel1.Right - panel1.Left) / 2;
            //frmQL.Show();

            frmSuaLoaiSach frmQLS = new frmSuaLoaiSach();
            frmQLS.ShowDialog();
        }

        private void xoaSachToolStripButton_Click(object sender, EventArgs e)
        {
            frmSuaNgonNgu frmQLNN = new frmSuaNgonNgu();
            frmQLNN.ShowDialog();
        }
		private void ThemsachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuaLoaiSach frm = new frmSuaLoaiSach();
            frm.ShowDialog();
        }
        private void CapNhatDGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSuaDocGia frm = new frmSuaDocGia();
            frm.ShowDialog();

        }

        private void ThemDGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThemDocGia frm = new frmThemDocGia();
            frm.ShowDialog();
        }
    }
}