using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;

namespace Presentation
{
    public partial class frmSuaNXB : Form
    {
        public frmSuaNXB()
        {
            InitializeComponent();
        }

        private void QuanLyNXB_Load(object sender, EventArgs e)
        {
            cmbNXB.DataSource = NhaXuatBanBUS.GetList();
            cmbNXB.ValueMember = "MaNXB";
            cmbNXB.DisplayMember = "TenNXB";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            txtMaNXB.Text = ((NhaXuatBanDTO)cmbNXB.SelectedItem).MaNXB.ToString();
            txtNXB.Text = ((NhaXuatBanDTO)cmbNXB.SelectedItem).TenNXB.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNXB frmThemNXB = new frmThemNXB();
            frmThemNXB.ShowDialog();
            QuanLyNXB_Load(sender, e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NhaXuatBanDTO NXB = new NhaXuatBanDTO();
            NXB.MaNXB = ((NhaXuatBanDTO)cmbNXB.SelectedItem).MaNXB;
            NXB.TenNXB = txtNXB.Text;

            NhaXuatBanBUS.Modify(NXB);
            QuanLyNXB_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}