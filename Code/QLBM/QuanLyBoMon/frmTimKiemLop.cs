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
    public partial class frmTimKiemLop : Form
    {
        public DataTable dtChiTietMon = new DataTable();
        public LopDTO lopDTO;

        public frmTimKiemLop()
        {
            InitializeComponent();
        }

        private void txtSearchTenLop_TextChanged(object sender, EventArgs e)
        {
            listLop.DataSource = LopBUS.TimLopTheoTenLop(txtSearchTenLop.Text);
            listLop.DisplayMember = "TenLop";
            listLop.ValueMember = "MaLop";
        }

        private void frmTimKiemLop_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.frmTimLop = null;
        }

        private void btnChonLop_Click(object sender, EventArgs e)
        {
            //if (listLop.SelectedIndex < 0)
            //{
            //    MessageBox.Show("Bạn phải chọn 1 lớp trong danh sách bên trái");
            //    return;
            //}

            //LopDTO lopDTO = LopBUS.TimLopTheoMaLop(Int32.Parse(listLop.SelectedValue.ToString()));

            //txtTenLop.Text = lopDTO.TenLop;
            //txtSoLuongSinhVien.Text = lopDTO.SoLuongSinhVien.ToString();
            //txtSoLuongNgoaiNganSach.Text = lopDTO.SoLuongNgoaiNganSach.ToString();
            //txtSoLuongTrongNganSach.Text = lopDTO.SoLuongTrongNganSach.ToString();

            //dtChiTietMon = ChiTietMonBUS.GetTable(lopDTO.MaLop);
            //dtgvChiTietMon.DataSource = dtChiTietMon;

            //dtgvChiTietMon.Columns["TenMon"].HeaderText = "Môn";
            //dtgvChiTietMon.Columns["ThoiGianHoc"].HeaderText = "Thời Gian Học";
            //dtgvChiTietMon.Columns["GioHoc"].HeaderText = "Giờ Học";
            //dtgvChiTietMon.Columns["GiangDuong"].HeaderText = "Giảng Đường";
            //dtgvChiTietMon.Columns["GiangVien"].HeaderText = "Giảng Viên";
            //dtgvChiTietMon.Columns["NgayThiLan1"].HeaderText = "Ngày Thi Lần 1";
            //dtgvChiTietMon.Columns["GioThiLan1"].HeaderText = "Giờ Thi";
            //dtgvChiTietMon.Columns["GiangDuongThiLan1"].HeaderText = "Giảng Đường";
            //dtgvChiTietMon.Columns["CanBoCoiThiLan1"].HeaderText = "Cán Bộ Coi Thi";
            //dtgvChiTietMon.Columns["SoBaiThiLan1"].HeaderText = "Số Bài";
            //dtgvChiTietMon.Columns["NgayThiLan2"].HeaderText = "Ngày Thi Lần 2";
            //dtgvChiTietMon.Columns["GioThiLan2"].HeaderText = "Giờ Thi";
            //dtgvChiTietMon.Columns["GiangDuongThiLan2"].HeaderText = "Giảng Đường";
            //dtgvChiTietMon.Columns["CanBoCoiThiLan2"].HeaderText = "Cán Bộ Coi Thi";
            //dtgvChiTietMon.Columns["SoBaiThiLan2"].HeaderText = "Số Bài";
            //dtgvChiTietMon.Columns["GhiChu"].HeaderText = "Ghi Chú";

            //dtgvChiTietMon.Columns["MaChiTietMon"].Visible = false;
            //dtgvChiTietMon.Columns["TenMon"].ReadOnly = true;
            //btnCapNhatChiTietMon.Visible = true;
            //dtgvChiTietMon.Visible = true;
        }

        private void btnCapNhatChiTietMon_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn cập nhật chi tiết môn học cho lớp này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dtgvChiTietMon.Rows)
                    {
                        ChiTietMonDTO chiTietMonDTO = new ChiTietMonDTO();

                        chiTietMonDTO.MaChiTietMon = Int32.Parse(row.Cells["MaChiTietMon"].Value.ToString());
                        chiTietMonDTO.ThoiGianHoc = row.Cells["ThoiGianHoc"].Value.ToString();
                        chiTietMonDTO.GioHoc = row.Cells["GioHoc"].Value.ToString();
                        chiTietMonDTO.GiangDuong = row.Cells["GiangDuong"].Value.ToString();
                        chiTietMonDTO.GiangVien = row.Cells["GiangVien"].Value.ToString();
                        chiTietMonDTO.NgayThiLan1 = row.Cells["NgayThiLan1"].Value.ToString();
                        chiTietMonDTO.GioThiLan1 = row.Cells["GioThiLan1"].Value.ToString();
                        chiTietMonDTO.GiangDuongThiLan1 = row.Cells["GiangDuongThiLan1"].Value.ToString();
                        chiTietMonDTO.CanBoCoiThiLan1 = row.Cells["CanBoCoiThiLan1"].Value.ToString();
                        chiTietMonDTO.SoBaiThiLan1 = Int32.Parse(row.Cells["SoBaiThiLan1"].Value.ToString());
                        chiTietMonDTO.NgayThiLan2 = row.Cells["NgayThiLan2"].Value.ToString();
                        chiTietMonDTO.GioThiLan2 = row.Cells["GioThiLan2"].Value.ToString();
                        chiTietMonDTO.GiangDuongThiLan2 = row.Cells["GiangDuongThiLan2"].Value.ToString();
                        chiTietMonDTO.CanBoCoiThiLan2 = row.Cells["CanBoCoiThiLan2"].Value.ToString();
                        chiTietMonDTO.SoBaiThiLan2 = Int32.Parse(row.Cells["SoBaiThiLan2"].Value.ToString());
                        chiTietMonDTO.GhiChu = row.Cells["GhiChu"].Value.ToString();

                        ChiTietMonBUS.UpdateRecord(chiTietMonDTO);
                    }

                    MessageBox.Show("Cập nhật chi tiết môn thành công");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listLop_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listLop.SelectedIndex >= 0)
                {
                    lopDTO = LopBUS.TimLopTheoMaLop(Int32.Parse(listLop.SelectedValue.ToString()));

                    txtTenLop.Text = lopDTO.TenLop;
                    txtSoLuongSinhVien.Text = lopDTO.SoLuongSinhVien.ToString();
                    txtSoLuongNgoaiNganSach.Text = lopDTO.SoLuongNgoaiNganSach.ToString();
                    txtSoLuongTrongNganSach.Text = lopDTO.SoLuongTrongNganSach.ToString();

                    dtChiTietMon = ChiTietMonBUS.GetTable(lopDTO.MaLop);
                    dtgvChiTietMon.DataSource = dtChiTietMon;

                    dtgvChiTietMon.Columns["TenMon"].HeaderText = "Môn";
                    dtgvChiTietMon.Columns["ThoiGianHoc"].HeaderText = "Thời Gian Học";
                    dtgvChiTietMon.Columns["GioHoc"].HeaderText = "Giờ Học";
                    dtgvChiTietMon.Columns["GiangDuong"].HeaderText = "Giảng Đường";
                    dtgvChiTietMon.Columns["GiangVien"].HeaderText = "Giảng Viên";
                    dtgvChiTietMon.Columns["NgayThiLan1"].HeaderText = "Ngày Thi Lần 1";
                    dtgvChiTietMon.Columns["GioThiLan1"].HeaderText = "Giờ Thi";
                    dtgvChiTietMon.Columns["GiangDuongThiLan1"].HeaderText = "Giảng Đường";
                    dtgvChiTietMon.Columns["CanBoCoiThiLan1"].HeaderText = "Cán Bộ Coi Thi";
                    dtgvChiTietMon.Columns["SoBaiThiLan1"].HeaderText = "Số Bài";
                    dtgvChiTietMon.Columns["NgayThiLan2"].HeaderText = "Ngày Thi Lần 2";
                    dtgvChiTietMon.Columns["GioThiLan2"].HeaderText = "Giờ Thi";
                    dtgvChiTietMon.Columns["GiangDuongThiLan2"].HeaderText = "Giảng Đường";
                    dtgvChiTietMon.Columns["CanBoCoiThiLan2"].HeaderText = "Cán Bộ Coi Thi";
                    dtgvChiTietMon.Columns["SoBaiThiLan2"].HeaderText = "Số Bài";
                    dtgvChiTietMon.Columns["GhiChu"].HeaderText = "Ghi Chú";

                    dtgvChiTietMon.Columns["MaChiTietMon"].Visible = false;
                    dtgvChiTietMon.Columns["TenMon"].ReadOnly = true;
                    btnCapNhatChiTietMon.Visible = true;
                    dtgvChiTietMon.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCapNhatLop_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn cập nhật thông tin của lớp này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    lopDTO.TenLop = txtTenLop.Text;
                    lopDTO.SoLuongSinhVien = Int32.Parse(txtSoLuongSinhVien.Text);
                    lopDTO.SoLuongNgoaiNganSach = Int32.Parse(txtSoLuongNgoaiNganSach.Text);
                    lopDTO.SoLuongTrongNganSach = Int32.Parse(txtSoLuongTrongNganSach.Text);

                    LopBUS.UpdateRecord(lopDTO);
                    MessageBox.Show("Cập nhật thông tin lớp thành công");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
