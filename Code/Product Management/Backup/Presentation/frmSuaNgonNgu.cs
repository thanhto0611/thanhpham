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
    public partial class frmSuaNgonNgu : Form
    {
        public frmSuaNgonNgu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuanLyNgonNgu_Load(object sender, EventArgs e)
        {
            cmbNgonNgu.DataSource = NgonNguBUS.GetList();
            cmbNgonNgu.ValueMember = "MaNgonNgu";
            cmbNgonNgu.DisplayMember = "TenNgonNgu";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            txtMaNgonNgu.Text = ((NgonNguDTO)cmbNgonNgu.SelectedItem).MaNgonNgu.ToString();
            txtNgonNgu.Text = ((NgonNguDTO)cmbNgonNgu.SelectedItem).TenNgonNgu.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            NgonNguDTO ngonNgu = new NgonNguDTO();
            ngonNgu.MaNgonNgu = ((NgonNguDTO)cmbNgonNgu.SelectedItem).MaNgonNgu;
            ngonNgu.TenNgonNgu = txtNgonNgu.Text;

            NgonNguBUS.Modify(ngonNgu);
            QuanLyNgonNgu_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNgonNgu frmThemNgonNgu = new frmThemNgonNgu();
            frmThemNgonNgu.ShowDialog();
            QuanLyNgonNgu_Load(sender, e);
        }
    }
}