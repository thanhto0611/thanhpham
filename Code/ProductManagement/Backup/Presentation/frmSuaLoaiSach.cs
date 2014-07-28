using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Data.OleDb;
using DTO;
using BUS;

namespace Presentation
{
    public partial class frmSuaLoaiSach : Form
    {
        public frmSuaLoaiSach()
        {
            InitializeComponent();
        }

        private void QuanLyLoaiSach_Load(object sender, EventArgs e)
        {
            cmbLoaiSach.DataSource = TheLoaiBUS.GetList();
            cmbLoaiSach.ValueMember = "MaLoai";
            cmbLoaiSach.DisplayMember = "TenTheLoai";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            txtMaLoaiSach.Text = ((TheLoaiDTO)cmbLoaiSach.SelectedItem).MaLoai.ToString();
            txtLoaiSach.Text = ((TheLoaiDTO)cmbLoaiSach.SelectedItem).TenTheLoai.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemTheLoaiSach frm = new frmThemTheLoaiSach();
            frm.ShowDialog();
            QuanLyLoaiSach_Load(sender,e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            TheLoaiDTO theLoai = new TheLoaiDTO();
            theLoai.MaLoai = ((TheLoaiDTO)cmbLoaiSach.SelectedItem).MaLoai;
            theLoai.TenTheLoai = txtLoaiSach.Text;
            TheLoaiBUS.Modify(theLoai);
            QuanLyLoaiSach_Load(sender, e);
        }
    }
}