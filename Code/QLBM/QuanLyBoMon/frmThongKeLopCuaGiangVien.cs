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
    public partial class frmThongKeLopCuaGiangVien : Form
    {
        public GiangVienDTO giangVienUpdateDTO;
        public DataTable dtDanhSachLop = new DataTable();

        public frmThongKeLopCuaGiangVien()
        {
            InitializeComponent();
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

                    layDanhSachMon();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void layDanhSachMon()
        {
            try
            {
                dtDanhSachLop = GiangVienBUS.LayDanhSachMonCuaGiangVien(giangVienUpdateDTO.MaGiangVien);

                foreach (DataRow dr in dtDanhSachLop.Rows)
                {
                    DataTable dtGiangVienMon = GiangVienBUS.LayDanhSachGiangVienCuaMon(Int32.Parse(dr["MaChiTietMon"].ToString()));
                    if (dtGiangVienMon.Rows.Count > 0)
                    {
                        string giangVien = "";

                        foreach (DataRow drGiangVienMon in dtGiangVienMon.Rows)
                        {
                            if (giangVien == "")
                            {
                                giangVien += drGiangVienMon["TenGiangVien"].ToString();
                            }
                            else
                            {
                                giangVien = giangVien + Environment.NewLine + drGiangVienMon["TenGiangVien"].ToString();
                            }
                        }
                        dr["GiangVien"] = giangVien;
                    }

                    DataTable dtCanBoCoiThiLan1 = GiangVienBUS.LayDanhSachCanBoCoiThiLan1CuaMon(Int32.Parse(dr["MaChiTietMon"].ToString()));
                    if (dtCanBoCoiThiLan1.Rows.Count > 0)
                    {
                        string canBoCoiThiLan1 = "";

                        foreach (DataRow drCanBoCoiThiLan1 in dtCanBoCoiThiLan1.Rows)
                        {
                            if (canBoCoiThiLan1 == "")
                            {
                                canBoCoiThiLan1 += drCanBoCoiThiLan1["TenGiangVien"].ToString();
                            }
                            else
                            {
                                canBoCoiThiLan1 = canBoCoiThiLan1 + Environment.NewLine + drCanBoCoiThiLan1["TenGiangVien"].ToString();
                            }
                        }
                        dr["CanBoCoiThiLan1"] = canBoCoiThiLan1;
                    }

                    DataTable dtCanBoCoiThiLan2 = GiangVienBUS.LayDanhSachCanBoCoiThiLan2CuaMon(Int32.Parse(dr["MaChiTietMon"].ToString()));
                    if (dtCanBoCoiThiLan2.Rows.Count > 0)
                    {
                        string canBoCoiThiLan2 = "";

                        foreach (DataRow drCanBoCoiThiLan2 in dtCanBoCoiThiLan2.Rows)
                        {
                            if (canBoCoiThiLan2 == "")
                            {
                                canBoCoiThiLan2 += drCanBoCoiThiLan2["TenGiangVien"].ToString();
                            }
                            else
                            {
                                canBoCoiThiLan2 = canBoCoiThiLan2 + Environment.NewLine + drCanBoCoiThiLan2["TenGiangVien"].ToString();
                            }
                        }
                        dr["CanBoCoiThiLan2"] = canBoCoiThiLan2;
                    }
                }

                dtgvDachSachLopCuaGiangVien.DataSource = dtDanhSachLop;

                dtgvDachSachLopCuaGiangVien.Columns["TenMon"].HeaderText = "Môn";
                dtgvDachSachLopCuaGiangVien.Columns["TenLop"].HeaderText = "Lớp";
                dtgvDachSachLopCuaGiangVien.Columns["ThoiGianHoc"].HeaderText = "Thời Gian Học";
                dtgvDachSachLopCuaGiangVien.Columns["GioHoc"].HeaderText = "Giờ Học";
                dtgvDachSachLopCuaGiangVien.Columns["GiangDuong"].HeaderText = "Giảng Đường";
                dtgvDachSachLopCuaGiangVien.Columns["GiangVien"].HeaderText = "Giảng Viên";
                dtgvDachSachLopCuaGiangVien.Columns["NgayThiLan1"].HeaderText = "Ngày Thi Lần 1";
                dtgvDachSachLopCuaGiangVien.Columns["GioThiLan1"].HeaderText = "Giờ Thi Lần 1";
                dtgvDachSachLopCuaGiangVien.Columns["GiangDuongThiLan1"].HeaderText = "Giảng Đường Thi Lần 1";
                dtgvDachSachLopCuaGiangVien.Columns["CanBoCoiThiLan1"].HeaderText = "Cán Bộ Coi Thi Lần 1";
                dtgvDachSachLopCuaGiangVien.Columns["SoBaiThiLan1"].HeaderText = "Số Bài Thi Lần 1";
                dtgvDachSachLopCuaGiangVien.Columns["NgayThiLan2"].HeaderText = "Ngày Thi Lần 2";
                dtgvDachSachLopCuaGiangVien.Columns["GioThiLan2"].HeaderText = "Giờ Thi Lần 2";
                dtgvDachSachLopCuaGiangVien.Columns["GiangDuongThiLan2"].HeaderText = "Giảng Đường Thi Lần 2";
                dtgvDachSachLopCuaGiangVien.Columns["CanBoCoiThiLan2"].HeaderText = "Cán Bộ Coi Thi Lần 2";
                dtgvDachSachLopCuaGiangVien.Columns["SoBaiThiLan2"].HeaderText = "Số Bài Thi Lần 2";
                dtgvDachSachLopCuaGiangVien.Columns["GhiChu"].HeaderText = "Ghi Chú";

                dtgvDachSachLopCuaGiangVien.Columns["TenMon"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["TenLop"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["ThoiGianHoc"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GioHoc"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GiangDuong"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GiangVien"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["NgayThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GioThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GiangDuongThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["CanBoCoiThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["SoBaiThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["NgayThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GioThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GiangDuongThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["CanBoCoiThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["SoBaiThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvDachSachLopCuaGiangVien.Columns["GhiChu"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtgvDachSachLopCuaGiangVien.Columns["MaChiTietMon"].Visible = false;
                dtgvDachSachLopCuaGiangVien.Columns["MaMon"].Visible = false;
                dtgvDachSachLopCuaGiangVien.Columns["MaLop"].Visible = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell cell1 = dtgvDachSachLopCuaGiangVien[column, row];
            DataGridViewCell cell2 = dtgvDachSachLopCuaGiangVien[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            if (cell1.Value.ToString() == cell2.Value.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void frmThongKeLopCuaGiangVien_Load(object sender, EventArgs e)
        {
            try
            {
                layDanhSachGiangVien();
                //dtgvDachSachLopCuaGiangVien.AutoGenerateColumns = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvDachSachLopCuaGiangVien_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && e.ColumnIndex == dtgvDachSachLopCuaGiangVien.Columns["TenLop"].Index)
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = dtgvDachSachLopCuaGiangVien.AdvancedCellBorderStyle.Top;
            }
        }

        private void dtgvDachSachLopCuaGiangVien_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex) && e.ColumnIndex == dtgvDachSachLopCuaGiangVien.Columns["TenLop"].Index)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
    }
}
