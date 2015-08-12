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
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void layDanhSachLop()
        {

            try
            {
                if (cbxTatCaNamHoc.Checked)
                {
                    if (rdTenLop.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoTenLop(txtSearchInfo.Text);
                    }
                    if (rdGiangDuong.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangDuong(txtSearchInfo.Text);
                    }
                    if (rdGiangVien.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangVien(txtSearchInfo.Text);
                    }
                    if (rdGiangDuongThiLan1.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangDuongThiL1(txtSearchInfo.Text);
                    }
                    if (rdGiangDuongThiLan2.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangDuongThiL2(txtSearchInfo.Text);
                    }
                    if (rdCanBoCoiThiLan1.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoCanBoCoiThiL1(txtSearchInfo.Text);
                    }
                    if (rdCanBoCoiThiLan2.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoCanBoCoiThiL2(txtSearchInfo.Text);
                    }
                }
                else
                {
                    int maNamHoc = (cmbNamHoc.SelectedItem as NamHocDTO).MaNamHoc;

                    if (rdTenLop.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoTenLop(txtSearchInfo.Text, maNamHoc);
                    }
                    if (rdGiangDuong.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangDuong(txtSearchInfo.Text, maNamHoc);
                    }
                    if (rdGiangVien.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangVien(txtSearchInfo.Text, maNamHoc);
                    }
                    if (rdGiangDuongThiLan1.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangDuongThiL1(txtSearchInfo.Text, maNamHoc);
                    }
                    if (rdGiangDuongThiLan2.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoGiangDuongThiL2(txtSearchInfo.Text, maNamHoc);
                    }
                    if (rdCanBoCoiThiLan1.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoCanBoCoiThiL1(txtSearchInfo.Text, maNamHoc);
                    }
                    if (rdCanBoCoiThiLan2.Checked)
                    {
                        listLop.DataSource = LopBUS.TimLopTheoCanBoCoiThiL2(txtSearchInfo.Text, maNamHoc);
                    }
                }

                if (listLop.Items.Count == 0)
                {
                    txtTenLop.Text = "";
                    txtSoLuongSinhVien.Text = "";
                    txtSoLuongNgoaiNganSach.Text = "";
                    txtSoLuongTrongNganSach.Text = "";
                    cmbNamHocCuaLop.DataSource = null;
                    groupBox2.Visible = false;
                }
                listLop.DisplayMember = "TenLop";
                listLop.ValueMember = "MaLop";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTimKiemLop_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.frmTimLop = null;
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
                    dtgvChiTietMon.Columns["NgayThiLan1"].HeaderText = "Ngày Thi L1";
                    dtgvChiTietMon.Columns["GioThiLan1"].HeaderText = "Giờ Thi L1";
                    dtgvChiTietMon.Columns["GiangDuongThiLan1"].HeaderText = "Giảng Đường Thi L1";
                    dtgvChiTietMon.Columns["CanBoCoiThiLan1"].HeaderText = "Cán Bộ Coi Thi L1";
                    dtgvChiTietMon.Columns["SoBaiThiLan1"].HeaderText = "Số Bài Thi L1";
                    dtgvChiTietMon.Columns["NgayThiLan2"].HeaderText = "Ngày Thi L2";
                    dtgvChiTietMon.Columns["GioThiLan2"].HeaderText = "Giờ Thi L2";
                    dtgvChiTietMon.Columns["GiangDuongThiLan2"].HeaderText = "Giảng Đường Thi L2";
                    dtgvChiTietMon.Columns["CanBoCoiThiLan2"].HeaderText = "Cán Bộ Coi Thi L2";
                    dtgvChiTietMon.Columns["SoBaiThiLan2"].HeaderText = "Số Bài Thi L2";
                    dtgvChiTietMon.Columns["GhiChu"].HeaderText = "Ghi Chú";

                    dtgvChiTietMon.Columns["MaChiTietMon"].Visible = false;
                    dtgvChiTietMon.Columns["TenMon"].ReadOnly = true;
                    btnCapNhatChiTietMon.Visible = true;
                    dtgvChiTietMon.Visible = true;
                    groupBox2.Visible = true;

                    cmbNamHocCuaLop.DataSource = NamHocBUS.GetList();
                    cmbNamHocCuaLop.DisplayMember = "TenNamHoc";
                    cmbNamHocCuaLop.ValueMember = "MaNamHoc";
                    cmbNamHocCuaLop.SelectedValue = lopDTO.MaNamHoc;
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
                    lopDTO.MaNamHoc = (cmbNamHocCuaLop.SelectedItem as NamHocDTO).MaNamHoc;

                    LopBUS.UpdateRecord(lopDTO);
                    MessageBox.Show("Cập nhật thông tin lớp thành công");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbxTatCaNamHoc_CheckedChanged(object sender, EventArgs e)
        {
            cmbNamHoc.Enabled = !cbxTatCaNamHoc.Checked;
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmTimKiemLop_Load(object sender, EventArgs e)
        {
            try
            {
                cmbNamHoc.DataSource = NamHocBUS.GetList();
                cmbNamHoc.DisplayMember = "TenNamHoc";
                cmbNamHoc.ValueMember = "MaNamHoc";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdTenLop_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdGiangDuong_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdGiangVien_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdGiangDuongThiLan1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdCanBoCoiThiLan1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdGiangDuongThiLan2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdCanBoCoiThiLan2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachLop();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
