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
using System.Globalization;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Style;
using System.Diagnostics;
using OfficeOpenXml;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using System.Net.Mail;
using System.Threading;

namespace QuanLyBoMon
{
    public partial class frmThongKeLopCuaGiangVien : Form
    {
        public GiangVienDTO giangVienUpdateDTO = new GiangVienDTO();
        public DataTable dtDanhSachLop = new DataTable();

        public bool isFormLoadCompleted = false;


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

                    layDanhSachMon(giangVienUpdateDTO.MaGiangVien);
                    formatData();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void layDanhSachMon(int maGiangVien)
        {
            try
            {
                if (maGiangVien > 0)
                {
                    if (cbxTatCaNamHoc.Checked)
                    {
                        dtDanhSachLop = GiangVienBUS.LayDanhSachMonCuaGiangVien(maGiangVien);
                    }
                    else
                    {
                        int maNamHoc = (cmbNamHoc.SelectedItem as NamHocDTO).MaNamHoc;
                        dtDanhSachLop = GiangVienBUS.LayDanhSachMonCuaGiangVien(maGiangVien, maNamHoc);
                    }
                        

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

                    
                }
                else
                {
                    //groupBox2.Visible = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatData()
        {
            dtgvDachSachLopCuaGiangVien.DataSource = dtDanhSachLop;

            dtgvDachSachLopCuaGiangVien.Columns["TenMon"].HeaderText = "Môn";
            dtgvDachSachLopCuaGiangVien.Columns["TenNamHoc"].HeaderText = "Năm Học";
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
            dtgvDachSachLopCuaGiangVien.Columns["TenNamHoc"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
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
            dtgvDachSachLopCuaGiangVien.Columns["MaNamHoc"].Visible = false;
            dtgvDachSachLopCuaGiangVien.Columns["MaMon"].Visible = false;
            dtgvDachSachLopCuaGiangVien.Columns["MaLop"].Visible = false;

            if (dtDanhSachLop.Rows.Count > 0)
            {
                //groupBox2.Visible = true;
                btnXuatExcel.Enabled = true;
                btnSendEmail.Enabled = true;
            }
            else
            {
                //groupBox2.Visible = false;
                btnXuatExcel.Enabled = false;
                btnSendEmail.Enabled = false;
                //MessageBox.Show("Không tìm thấy lớp cho giảng viên này");
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

                cmbNamHoc.DataSource = NamHocBUS.GetList();
                cmbNamHoc.DisplayMember = "TenNamHoc";
                cmbNamHoc.ValueMember = "MaNamHoc";

                isFormLoadCompleted = true;
                if (cbxTatCaNamHoc.Checked)
                {
                    rtxtEmailContent.Text = "Kính gửi quý thầy cô lịch giảng dạy. Nếu có gì sai sót xin quý thầy cô phản ánh lại cho giáo vụ, để giáo vụ kiểm tra và chỉnh sửa kịp thời.\n\nXin cảm ơn quý thầy cô.";
                    txtEmailSubject.Text = "LỊCH GIẢNG DẠY";
                }
                else
                {
                    rtxtEmailContent.Text = "Kính gửi quý thầy cô lịch giảng dạy năm học " + (cmbNamHoc.SelectedItem as NamHocDTO).TenNamHoc  + ". Nếu có gì sai sót xin quý thầy cô phản ánh lại cho giáo vụ, để giáo vụ kiểm tra và chỉnh sửa kịp thời.\n\nXin cảm ơn quý thầy cô.";
                    txtEmailSubject.Text = "LỊCH GIẢNG DẠY NĂM HỌC " + (cmbNamHoc.SelectedItem as NamHocDTO).TenNamHoc;
                }
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

        private void cbxTatCaNamHoc_CheckedChanged(object sender, EventArgs e)
        {
            cmbNamHoc.Enabled = !cbxTatCaNamHoc.Checked;
            if (cbxTatCaNamHoc.Checked)
            {
                rtxtEmailContent.Text = "Kính gửi quý thầy cô lịch giảng dạy. Nếu có gì sai sót xin quý thầy cô phản ánh lại cho giáo vụ, để giáo vụ kiểm tra và chỉnh sửa kịp thời.\n\nXin cảm ơn quý thầy cô.";
                txtEmailSubject.Text = "LỊCH GIẢNG DẠY";
            }
            else
            {
                rtxtEmailContent.Text = "Kính gửi quý thầy cô lịch giảng dạy năm học " + (cmbNamHoc.SelectedItem as NamHocDTO).TenNamHoc + ". Nếu có gì sai sót xin quý thầy cô phản ánh lại cho giáo vụ, để giáo vụ kiểm tra và chỉnh sửa kịp thời.\n\nXin cảm ơn quý thầy cô.";
                txtEmailSubject.Text = "LỊCH GIẢNG DẠY NĂM HỌC " + (cmbNamHoc.SelectedItem as NamHocDTO).TenNamHoc;
            }
            try
            {
                layDanhSachMon(giangVienUpdateDTO.MaGiangVien);
                formatData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbNamHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxTatCaNamHoc.Checked)
            {
                rtxtEmailContent.Text = "Kính gửi quý thầy cô lịch giảng dạy. Nếu có gì sai sót xin quý thầy cô phản ánh lại cho giáo vụ, để giáo vụ kiểm tra và chỉnh sửa kịp thời.\n\nXin cảm ơn quý thầy cô.";
                txtEmailSubject.Text = "LỊCH GIẢNG DẠY";
            }
            else
            {
                rtxtEmailContent.Text = "Kính gửi quý thầy cô lịch giảng dạy năm học " + (cmbNamHoc.SelectedItem as NamHocDTO).TenNamHoc + ". Nếu có gì sai sót xin quý thầy cô phản ánh lại cho giáo vụ, để giáo vụ kiểm tra và chỉnh sửa kịp thời.\n\nXin cảm ơn quý thầy cô.";
                txtEmailSubject.Text = "LỊCH GIẢNG DẠY NĂM HỌC " + (cmbNamHoc.SelectedItem as NamHocDTO).TenNamHoc;
            }

            try
            {
                if (isFormLoadCompleted)
                {
                    layDanhSachMon(giangVienUpdateDTO.MaGiangVien);
                    formatData();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {

                string exportFileName = "GiangVien_" + txtTenGiangVienUpdate.Text.Replace(@" ", "-").ToUpper() + "_LichGiangDay.xlsx";
                string exportFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\LichGiangDay\", exportFileName);

                xuatExcel(exportFilePath);
                //MessageBox.Show("Xuất Excel Thành Công");
                System.Diagnostics.Process.Start(exportFilePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xuatExcel(string exportFilePath)
        {
            try
            {
                string templateFileName = "ExportGiangVien.xlsx";
                string templateFilePath = Path.Combine(Directory.GetCurrentDirectory(), templateFileName);

                if (File.Exists(exportFilePath))
                {
                    File.Delete(exportFilePath);
                }
                File.Copy(templateFilePath, exportFilePath);

                FileInfo newFile = new FileInfo(exportFilePath);
                ExcelPackage excelPkg = new ExcelPackage(newFile);
                excelPkg.Workbook.Worksheets["Sheet1"].View.TabSelected = true;

                ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets["Sheet1"];

                oSheet.Cells["F4"].Value = txtTenGiangVienUpdate.Text;
                if (cbxTatCaNamHoc.Checked)
                {
                    oSheet.Cells["N4"].Value = "Tất cả năm học";
                }
                else
                {
                    oSheet.Cells["N4"].Value = (cmbNamHoc.SelectedItem as NamHocDTO).TenNamHoc;
                }

                int startRowIndex = 7;

                foreach (DataGridViewRow row in dtgvDachSachLopCuaGiangVien.Rows)
                {
                    string checkImgPath = Directory.GetCurrentDirectory();
                    string imgPath = Directory.GetCurrentDirectory();

                    if (oSheet.Cells[startRowIndex - 1, 1].Value.ToString() == row.Cells["TenLop"].Value.ToString())
                    {
                        oSheet.Cells[startRowIndex - 1, 1, startRowIndex, 1].Merge = true;
                    }
                    oSheet.Cells[startRowIndex, 1].Value = row.Cells["TenLop"].Value.ToString();
                    oSheet.Cells[startRowIndex, 2].Value = row.Cells["TenMon"].Value.ToString();
                    oSheet.Cells[startRowIndex, 3].Value = row.Cells["ThoiGianHoc"].Value.ToString();
                    oSheet.Cells[startRowIndex, 4].Value = row.Cells["GioHoc"].Value.ToString();
                    oSheet.Cells[startRowIndex, 5].Value = row.Cells["GiangDuong"].Value.ToString();
                    oSheet.Cells[startRowIndex, 6].Value = row.Cells["NgayThiLan1"].Value.ToString();
                    oSheet.Cells[startRowIndex, 7].Value = row.Cells["GioThiLan1"].Value.ToString();
                    oSheet.Cells[startRowIndex, 8].Value = row.Cells["GiangDuongThiLan1"].Value.ToString();
                    oSheet.Cells[startRowIndex, 9].Value = row.Cells["CanBoCoiThiLan1"].Value.ToString();
                    if (row.Cells["SoBaiThiLan1"].Value.ToString() != "0")
                    {
                        oSheet.Cells[startRowIndex, 10].Value = row.Cells["SoBaiThiLan1"].Value.ToString();
                    }
                    oSheet.Cells[startRowIndex, 11].Value = row.Cells["NgayThiLan2"].Value.ToString();
                    oSheet.Cells[startRowIndex, 12].Value = row.Cells["GioThiLan2"].Value.ToString();
                    oSheet.Cells[startRowIndex, 13].Value = row.Cells["GiangDuongThiLan2"].Value.ToString();
                    oSheet.Cells[startRowIndex, 14].Value = row.Cells["CanBoCoiThiLan2"].Value.ToString();
                    if (row.Cells["SoBaiThiLan2"].Value.ToString() != "0")
                    {
                        oSheet.Cells[startRowIndex, 10].Value = row.Cells["SoBaiThiLan2"].Value.ToString();
                    }
                    oSheet.Cells[startRowIndex, 16].Value = row.Cells["GhiChu"].Value.ToString();

                    oSheet.Cells[startRowIndex, 1].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 1].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 1].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 1].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 2].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 2].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 2].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 3].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 3].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 3].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 3].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 4].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 4].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 4].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 4].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 5].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 5].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 5].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 5].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 6].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 6].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 6].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 6].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 7].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 7].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 7].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 7].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 8].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 8].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 8].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 8].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 9].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 9].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 9].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 9].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 10].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 10].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 10].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 10].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 11].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 11].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 11].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 11].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 12].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 12].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 12].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 12].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 13].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 13].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 13].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 13].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 14].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 14].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 14].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 14].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 15].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 15].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 15].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 15].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 16].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 16].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 16].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    oSheet.Cells[startRowIndex, 16].Style.Border.Right.Style = ExcelBorderStyle.Thin;

                    startRowIndex++;
                }

                excelPkg.Save();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn gửi email LỊCH GIẢNG DẠY cho giảng viên này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                string your_id = txtFromEmail.Text;
                string your_password = txtPassword.Text;
                try
                {
                    SmtpClient client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new System.Net.NetworkCredential(your_id, your_password),
                        Timeout = 10000,
                    };
                    MailMessage mm = new MailMessage(your_id, txtEmailUpdate.Text, txtEmailSubject.Text, rtxtEmailContent.Text);

                    string exportFileName = "GiangVien_" + txtTenGiangVienUpdate.Text.Replace(@" ", "-").ToUpper() + "_LichGiangDay.xlsx";
                    string exportFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\LichGiangDay\", exportFileName);
                    xuatExcel(exportFilePath);
                    Attachment data = new Attachment(exportFilePath);
                    mm.Attachments.Add(data);
                    client.Send(mm);
                    MessageBox.Show("Email đã được gửi thành công");
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Không gửi được email!");
                }
            }
        }

        private void btnSendEmailToAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn gửi email LỊCH GIẢNG DẠY cho tất cả giảng viên không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                DataTable gv = GiangVienBUS.GetTable();

                foreach (DataRow dr in gv.Rows)
                {
                    
                }
            }
        }
    }
}
