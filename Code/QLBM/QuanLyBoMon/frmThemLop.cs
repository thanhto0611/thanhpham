using System;
using System.Collections;
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
        public DataTable dtNamHoc = new DataTable();

        public static bool isFrmThemMonClosed = false;
        public static bool isFrmThemNamHocClosed = false;
        public static bool isFrmThemGiangVienClosed = false;
        public static bool isFrmThemCanBoCoiThiLan1Closed = false;
        public static bool isFrmThemCanBoCoiThiLan2Closed = false;

        public static int gMaChiTietMon;

        public LopDTO lopDTO = new LopDTO();

        public frmThemLop()
        {
            InitializeComponent();
        }

        private void frmThemLop_Load(object sender, EventArgs e)
        {
            try
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

                cmbNamHoc.DataSource = NamHocBUS.GetList();
                cmbNamHoc.DisplayMember = "TenNamHoc";
                cmbNamHoc.ValueMember = "MaNamHoc";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        public void refreshMonData()
        {
            dtDanhSachMon = MonBUS.GetTable();
            dtgvDSMon.DataSource = dtDanhSachMon;
            ((CheckBox)dtgvDSMon.Controls.Find("checkboxHeader", true)[0]).Checked = false;
        }

        public void refreshNamHocData()
        {
            cmbNamHoc.DataSource = NamHocBUS.GetList();
            cmbNamHoc.DisplayMember = "TenNamHoc";
            cmbNamHoc.ValueMember = "MaNamHoc";
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
                isFrmThemMonClosed = false;
                timer1.Stop();
                refreshMonData();
            }

            if (isFrmThemNamHocClosed)
            {
                isFrmThemNamHocClosed = false;
                timer1.Stop();
                refreshNamHocData();
            }

            if (isFrmThemGiangVienClosed)
            {
                isFrmThemGiangVienClosed = false;
                timer1.Stop();
                LayDanhSachChiTietMon();
            }

            if (isFrmThemCanBoCoiThiLan1Closed)
            {
                isFrmThemCanBoCoiThiLan1Closed = false;
                timer1.Stop();
                LayDanhSachChiTietMon();
            }

            if (isFrmThemCanBoCoiThiLan2Closed)
            {
                isFrmThemCanBoCoiThiLan2Closed = false;
                timer1.Stop();
                LayDanhSachChiTietMon();
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
                    lopDTO.TenLop = txtTenLop.Text;

                    if (txtSoLuongSinhVien.Text == "")
                        lopDTO.SoLuongSinhVien = 0;
                    else
                        lopDTO.SoLuongSinhVien = Int32.Parse(txtSoLuongSinhVien.Text);

                    if (txtSoLuongTrongNganSach.Text == "")
                        lopDTO.SoLuongTrongNganSach = 0;
                    else
                        lopDTO.SoLuongTrongNganSach = Int32.Parse(txtSoLuongTrongNganSach.Text);

                    if (txtSoLuongNgoaiNganSach.Text == "")
                        lopDTO.SoLuongNgoaiNganSach = 0;
                    else
                        lopDTO.SoLuongNgoaiNganSach = Int32.Parse(txtSoLuongNgoaiNganSach.Text);

                    lopDTO.MaNamHoc = (cmbNamHoc.SelectedItem as NamHocDTO).MaNamHoc;
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

                    LayDanhSachChiTietMon();
                    
                    btnCapNhatChiTietMon.Visible = true;
                    dtgvChiTietMon.Visible = true;
                    btnThemLop.Enabled = false;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void LayDanhSachChiTietMon()
        {
            try
            {
                dtChiTietMon = ChiTietMonBUS.GetTable(lopDTO.MaLop);
                foreach (DataRow dr in dtChiTietMon.Rows)
                {
                    DataTable dtGiangVienMon = GiangVienBUS.LayDanhSachGiangVienCuaMon(Int32.Parse(dr["MaChiTietMon"].ToString()));
                    if (dtChiTietMon.Rows.Count > 0)
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

                dtgvChiTietMon.DataSource = dtChiTietMon;

                DataGridViewComboBoxColumn namHocCol = new DataGridViewComboBoxColumn();
                namHocCol.Name = "CmbNamHoc";
                namHocCol.HeaderText = "Năm Học";
                namHocCol.ValueType = typeof(int);
                dtgvChiTietMon.Columns.Insert(dtgvChiTietMon.Columns["TenMon"].Index + 1, namHocCol);

                IList listNamHoc = NamHocBUS.GetList();

                foreach (DataGridViewRow row in this.dtgvChiTietMon.Rows)
                {
                    ((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).DataSource = listNamHoc;
                    row.Cells["CmbNamHoc"].Value = row.Cells["TenNamHoc"].Value;
                }

                dtgvChiTietMon.Columns["TenMon"].HeaderText = "Môn";
                dtgvChiTietMon.Columns["ThoiGianHoc"].HeaderText = "Thời Gian Học";
                dtgvChiTietMon.Columns["GioHoc"].HeaderText = "Giờ Học";
                dtgvChiTietMon.Columns["GiangDuong"].HeaderText = "Giảng Đường";
                dtgvChiTietMon.Columns["GiangVien"].HeaderText = "Giảng Viên";
                dtgvChiTietMon.Columns["NgayThiLan1"].HeaderText = "Ngày Thi Lần 1";
                dtgvChiTietMon.Columns["GioThiLan1"].HeaderText = "Giờ Thi Lần 1";
                dtgvChiTietMon.Columns["GiangDuongThiLan1"].HeaderText = "Giảng Đường Thi Lần 1";
                dtgvChiTietMon.Columns["CanBoCoiThiLan1"].HeaderText = "Cán Bộ Coi Thi Lần 1";
                dtgvChiTietMon.Columns["SoBaiThiLan1"].HeaderText = "Số Bài Thi Lần 1";
                dtgvChiTietMon.Columns["NgayThiLan2"].HeaderText = "Ngày Thi Lần 2";
                dtgvChiTietMon.Columns["GioThiLan2"].HeaderText = "Giờ Thi Lần 2";
                dtgvChiTietMon.Columns["GiangDuongThiLan2"].HeaderText = "Giảng Đường Thi Lần 2";
                dtgvChiTietMon.Columns["CanBoCoiThiLan2"].HeaderText = "Cán Bộ Coi Thi Lần 2";
                dtgvChiTietMon.Columns["SoBaiThiLan2"].HeaderText = "Số Bài Thi Lần 2";
                dtgvChiTietMon.Columns["GhiChu"].HeaderText = "Ghi Chú";

                dtgvChiTietMon.Columns["TenMon"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["ThoiGianHoc"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GioHoc"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GiangDuong"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GiangVien"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["NgayThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GioThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GiangDuongThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["CanBoCoiThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["SoBaiThiLan1"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["NgayThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GioThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GiangDuongThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["CanBoCoiThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["SoBaiThiLan2"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgvChiTietMon.Columns["GhiChu"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtgvChiTietMon.Columns["MaChiTietMon"].Visible = false;
                dtgvChiTietMon.Columns["MaMon"].Visible = false;
                dtgvChiTietMon.Columns["TenMon"].ReadOnly = true;
                dtgvChiTietMon.Columns["GiangVien"].ReadOnly = true;
                dtgvChiTietMon.Columns["CanBoCoiThiLan1"].ReadOnly = true;
                dtgvChiTietMon.Columns["CanBoCoiThiLan2"].ReadOnly = true;
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
                        //chiTietMonDTO.GiangVien = row.Cells["GiangVien"].Value.ToString();
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

        private void btnThemNamHoc_Click(object sender, EventArgs e)
        {
            try
            {
                isFrmThemNamHocClosed = false;
                timer1.Start();
                frmThemNamHoc frm = new frmThemNamHoc();
                frm.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvChiTietMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgvChiTietMon.Columns[e.ColumnIndex].Name == "GiangVien" && e.RowIndex >= 0)
                {
                    isFrmThemGiangVienClosed = false;
                    gMaChiTietMon = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaChiTietMon"].Value.ToString());

                    frmThemGiangVienVaoMon frm = new frmThemGiangVienVaoMon();
                    frm.ShowDialog();
                    timer1.Start();
                }

                if (dtgvChiTietMon.Columns[e.ColumnIndex].Name == "CanBoCoiThiLan1" && e.RowIndex >= 0)
                {
                    isFrmThemCanBoCoiThiLan1Closed = false;
                    gMaChiTietMon = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaChiTietMon"].Value.ToString());

                    frmThemCanBoCoiThiLan1 frm = new frmThemCanBoCoiThiLan1();
                    frm.ShowDialog();
                    timer1.Start();
                }

                if (dtgvChiTietMon.Columns[e.ColumnIndex].Name == "CanBoCoiThiLan2" && e.RowIndex >= 0)
                {
                    isFrmThemCanBoCoiThiLan1Closed = false;
                    gMaChiTietMon = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaChiTietMon"].Value.ToString());

                    frmThemCanBoCoiThiLan2 frm = new frmThemCanBoCoiThiLan2();
                    frm.ShowDialog();
                    timer1.Start();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
