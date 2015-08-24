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
    public partial class frmQuanLyGiangVien : Form
    {
        public GiangVienDTO giangVienUpdateDTO;

        public frmQuanLyGiangVien()
        {
            InitializeComponent();
        }

        private void btnThemGiangVien_Click(object sender, EventArgs e)
        {
            if (txtTenGiangVienThem.Text == "")
            {
                MessageBox.Show("Phải nhập tên Giảng Viên");
                return;
            }
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm Giảng Viên này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    GiangVienDTO giangVienDTO = new GiangVienDTO();
                    giangVienDTO.TenGiangVien = txtTenGiangVienThem.Text;
                    giangVienDTO.SoDienThoai = txtSoDienThoaiThem.Text;
                    giangVienDTO.DiaChi = txtDiaChiThem.Text;
                    giangVienDTO.Email = txtEmailThem.Text;

                    GiangVienBUS.Insert(giangVienDTO);

                    MessageBox.Show("Thêm Giảng Viên thành công");

                    txtTenGiangVienThem.Text = "";
                    txtSoDienThoaiThem.Text = "";
                    txtDiaChiThem.Text = "";
                    txtEmailThem.Text = "";

                    layDanhSachGiangVien();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLyGiangVien_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.frmQLGV = null;
        }

        private void txtThongTinTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachGiangVien();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void layDanhSachGiangVien()
        {
            try
            {
                listGiangVien.DataSource = GiangVienBUS.GetTable(txtThongTinTimKiem.Text);
                listGiangVien.DisplayMember = "TenGiangVien";
                listGiangVien.ValueMember = "MaGiangVien";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listGiangVien_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listGiangVien.SelectedIndex >= 0)
                {
                    giangVienUpdateDTO = GiangVienBUS.TimTheoMaGiangVien(Int32.Parse(listGiangVien.SelectedValue.ToString()));

                    txtTenGiangVienUpdate.Text = giangVienUpdateDTO.TenGiangVien;
                    txtSoDienThoaiUpdate.Text = giangVienUpdateDTO.SoDienThoai;
                    txtDiaChiUpdate.Text = giangVienUpdateDTO.DiaChi;
                    txtEmailUpdate.Text = giangVienUpdateDTO.Email;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhatGiangVien_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn cập nhật thông tin của Giảng Viên này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    giangVienUpdateDTO.TenGiangVien = txtTenGiangVienUpdate.Text;
                    giangVienUpdateDTO.SoDienThoai = txtSoDienThoaiUpdate.Text;
                    giangVienUpdateDTO.DiaChi = txtDiaChiUpdate.Text;
                    giangVienUpdateDTO.Email = txtEmailUpdate.Text;

                    GiangVienBUS.UpdateRecord(giangVienUpdateDTO);
                    MessageBox.Show("Cập nhật thông tin Giảng Viên thành công");
                    layDanhSachGiangVien();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaGiangVien_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa Giảng Viên này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    GiangVienBUS.Delete(giangVienUpdateDTO.MaGiangVien);
                    MessageBox.Show("Xóa Giảng Viên thành công");
                    layDanhSachGiangVien();

                    txtTenGiangVienUpdate.Text = "";
                    txtSoDienThoaiUpdate.Text = "";
                    txtDiaChiUpdate.Text = "";
                    txtEmailUpdate.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLyGiangVien_Load(object sender, EventArgs e)
        {
            try
            {
                layDanhSachGiangVien();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
