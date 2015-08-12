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
    public partial class frmThemLop : Form
    {
        public DataTable dtDanhSachMon = new DataTable();
        public DataTable dtChiTietMon = new DataTable();

        public static bool isFrmThemMonClosed = false;

        public frmThemLop()
        {
            InitializeComponent();
        }

        private void frmThemLop_Load(object sender, EventArgs e)
        {
            dtDanhSachMon = MonBUS.GetTable();
            dtgvDSMon.DataSource = dtDanhSachMon;

            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 30;
            checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDSMon.Columns.Insert(0, checkboxColumn);

            // add checkbox header
            Rectangle rect = dtgvDSMon.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

            dtgvDSMon.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgvDSMon.RowCount; i++)
            {
                dtgvDSMon[0, i].Value = ((CheckBox)dtgvDSMon.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            dtgvDSMon.EndEdit();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                isFrmThemMonClosed = false;
                timer1.Start();
                frmThemMon frm = new frmThemMon();
                frm.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshData()
        {
            dtDanhSachMon = MonBUS.GetTable();
            dtgvDSMon.DataSource = dtDanhSachMon;
            ((CheckBox)dtgvDSMon.Controls.Find("checkboxHeader", true)[0]).Checked = false;
        }

        private void dtgvDSMon_DataSourceChanged(object sender, EventArgs e)
        {
            dtgvDSMon.Columns["MaMon"].Visible = false;
            dtgvDSMon.Columns["TenMon"].HeaderText = "Tên Môn";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isFrmThemMonClosed)
            {
                timer1.Stop();
                refreshData();
            }
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenLop.Text == "")
                {
                    MessageBox.Show("Phải nhập tên lớp");
                    return;
                }
                if (countSelectedRow() == 0)
                {
                    MessageBox.Show("Phải chọn ít nhất 1 môn học");
                    return;
                }

                DialogResult result = MessageBox.Show("Bạn có chắc muốn thêm lớp này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    LopDTO lopDTO = new LopDTO();
                    lopDTO.TenLop = txtTenLop.Text;
                    lopDTO.SoLuongSinhVien = Int32.Parse(txtSoLuongSinhVien.Text);
                    lopDTO.SoLuongTrongNganSach = Int32.Parse(txtSoLuongTrongNganSach.Text);
                    lopDTO.SoLuongNgoaiNganSach = Int32.Parse(txtSoLuongNgoaiNganSach.Text);
                    LopBUS.Insert(lopDTO);

                    foreach (DataGridViewRow row in dtgvDSMon.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            LopMonDTO lopMonDTO = new LopMonDTO();
                            lopMonDTO.MaLop = lopDTO.MaLop;
                            lopMonDTO.MaMon = Int32.Parse(row.Cells["MaMon"].Value.ToString());
                            LopMonBUS.Insert(lopMonDTO);

                            ChiTietMonDTO chiTietMonDTO = new ChiTietMonDTO();
                            chiTietMonDTO.MaLopMon = lopMonDTO.MaLopMon;
                            ChiTietMonBUS.Insert(chiTietMonDTO);
                        }
                    }

                    MessageBox.Show("Thêm lớp thành công");

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

        public int countSelectedRow()
        {
            int count = 0;

            foreach (DataGridViewRow row in dtgvDSMon.Rows)
            {
                if (row.Cells[0].Value != null)
                    count++;
            }

            return count;
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

        private void frmThemLop_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.frmThemLop = null;
        }
    }
}
