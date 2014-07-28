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
    public  partial class TimKiemSach : Form
    {
        private SachDTO sach;
        private bool theLoai_checked;
        private bool ngonNgu_Checked;

        public static int MaSach;

        public TimKiemSach()
        {
            InitializeComponent();
        }
        private void TheLoai_Load()
        {
            cbbTheLoai.DataSource = TheLoaiBUS.GetList();
            cbbTheLoai.ValueMember = "MaLoai";
            cbbTheLoai.DisplayMember = "TenTheLoai";
            cbbTheLoai.SelectedIndex = -1;
        }
        private void NgonNgu_Load ()
        {
            cbbNgonNgu.DataSource = NgonNguBUS.GetList();
            cbbNgonNgu.ValueMember = "MaNgonNgu";
            cbbNgonNgu.DisplayMember = "TenNgonNgu";
            cbbTheLoai.SelectedIndex = -1;
        }
        private void UpdateStandar(bool isUpdated)
        {
            if (isUpdated)
            {
                sach.MaSach = txtMaSach.Text.Length > 0 ? Int32.Parse(txtMaSach.Text) : 0;
                sach.MaTheLoai = (cbbTheLoai.SelectedItem as TheLoaiDTO).MaLoai;
                sach.MaNgonNgu = (cbbNgonNgu.SelectedItem as NgonNguDTO).MaNgonNgu;
                sach.TenSach = txtTenSach.Text;
                theLoai_checked = chkTheLoai.Checked;
                ngonNgu_Checked = chkNgonNgu.Checked;
            }
            else
            {
                if (sach.MaSach != 0)
                    txtMaSach.Text = sach.MaSach.ToString();

                cbbTheLoai.SelectedIndex = sach.MaTheLoai;
                cbbNgonNgu.SelectedIndex = sach.MaNgonNgu;
                txtTenSach.Text = sach.TenSach;
                chkTheLoai.Checked = theLoai_checked;
                chkNgonNgu.Checked = ngonNgu_Checked;
            }
        }
       
        private void TimKiemSach_Load(object sender, EventArgs e)
        {
            NgonNgu_Load();
            TheLoai_Load();

            sach = new SachDTO();
            UpdateStandar(false);

            DataTable dt = new DataTable();
            dtgvSach.DataSource = dt;
        }

        private void txtMaSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTenSach_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            UpdateStandar(true);
            SachBUS sb = new SachBUS();
            DataTable dt = sb.Search_DTO(sach,ngonNgu_Checked,theLoai_checked);
            if (dt != null)
                dtgvSach.DataSource = dt;
        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            btnTimKiem_Click(sender, e);
        }

        private void chkTheLoai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTheLoai.Checked)
                cbbTheLoai.Enabled = true;
            else
                cbbTheLoai.Enabled = false;
        }

        private void chkNgonNgu_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNgonNgu.Checked)
                cbbNgonNgu.Enabled = true;
            else
                cbbNgonNgu.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvSach_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            MaSach = (int)dtgvSach.CurrentRow.Cells[0].Value;
            frmCapNhatSach frm = new frmCapNhatSach();
            frm.ShowDialog();
            this.btnTimKiem_Click(sender, e);
        }
    }
}