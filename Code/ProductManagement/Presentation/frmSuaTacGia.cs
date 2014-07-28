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
    public partial class frmSuaTacGia : Form
    {
        public frmSuaTacGia()
        {
            InitializeComponent();
        }

        private void QuanLyTacGia_Load(object sender, EventArgs e)
        {
            cmbTacGia.DataSource = TacGiaBUS.GetList();
            cmbTacGia.ValueMember = "MaTG";
            cmbTacGia.DisplayMember = "TenTG";
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            txtMaDocGia.Text = ((TacGiaDTO)cmbTacGia.SelectedItem).MaTG.ToString();
            txtTacGia.Text = ((TacGiaDTO)cmbTacGia.SelectedItem).TenTG.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemTacGia frmThemTacGia = new frmThemTacGia();
            frmThemTacGia.ShowDialog();
            QuanLyTacGia_Load(sender, e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            TacGiaDTO tacGia = new TacGiaDTO();
            tacGia.MaTG = ((TacGiaDTO)cmbTacGia.SelectedItem).MaTG;
            tacGia.TenTG = txtTacGia.Text;
            TacGiaBUS tacgiaBUS = new TacGiaBUS();
           // TacGiaBUS.Modify(tacGia);
            QuanLyTacGia_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}