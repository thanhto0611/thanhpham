using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DTO;
using BUS;

namespace QuanLyBoMon
{
    public partial class frmQuanLyNamHoc : Form
    {
        public NamHocDTO namHocDTO;

        public frmQuanLyNamHoc()
        {
            InitializeComponent();
        }

        private void frmQuanLyNamHoc_Load(object sender, EventArgs e)
        {
            try
            {
                layDanhSachNamHoc();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void layDanhSachNamHoc()
        {
            try
            {
                listNamHoc.DataSource = NamHocBUS.GetTable(txtThongTinTimKiem.Text);
                listNamHoc.DisplayMember = "TenNamHoc";
                listNamHoc.ValueMember = "MaNamHoc";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemNamHoc_Click(object sender, EventArgs e)
        {
            if (txtTenNamHocThem.Text == "")
            {
                MessageBox.Show("Phải nhập năm học");
                return;
            }
            try
            {
                NamHocDTO nhDTO = new NamHocDTO();
                nhDTO.TenNamHoc = txtTenNamHocThem.Text;
                NamHocBUS.Insert(nhDTO);
                MessageBox.Show("Thêm năm học thành công");
                layDanhSachNamHoc();
                txtTenNamHocThem.Text = "";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtThongTinTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachNamHoc();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listNamHoc_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listNamHoc.SelectedIndex >= 0)
                {
                    namHocDTO = NamHocBUS.GetRecord(Int32.Parse(listNamHoc.SelectedValue.ToString()));

                    txtTenNamHocUpdate.Text = namHocDTO.TenNamHoc;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhatNamHoc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn cập nhật năm học này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    namHocDTO.TenNamHoc = txtTenNamHocUpdate.Text;

                    NamHocBUS.UpdateRecord(namHocDTO);
                    MessageBox.Show("Cập nhật năm học thành công");
                    layDanhSachNamHoc();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaNamHoc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa năm học này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    NamHocBUS.Delete(namHocDTO.MaNamHoc);
                    MessageBox.Show("Xóa năm học thành công");
                    layDanhSachNamHoc();

                    txtTenNamHocUpdate.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLyNamHoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.frmQLNH = null;
        }
    }
}
