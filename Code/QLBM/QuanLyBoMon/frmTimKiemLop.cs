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
    public partial class frmTimKiemLop : Form
    {
        public DataTable dtChiTietMon = new DataTable();
        public LopDTO lopDTO;

        public static bool isFrmThemGiangVienClosed = false;
        public static bool isFrmThemCanBoCoiThiLan1Closed = false;
        public static bool isFrmThemCanBoCoiThiLan2Closed = false;
        public static bool isFrmThemNamHocVaoChiTietMonClosed = false;
        public static bool isFirstTimeRenderDTGV = true;

        public static int gMaChiTietMon;
        public static int gMaNamHoc;

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

                    LayDanhSachChiTietMon();

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

        public void LayDanhSachChiTietMon()
        {
            try
            {
                dtChiTietMon = ChiTietMonBUS.GetTable(lopDTO.MaLop);
                foreach (DataRow dr in dtChiTietMon.Rows)
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

                dtgvChiTietMon.DataSource = dtChiTietMon;

                //if (isFirstTimeRenderDTGV)
                //{
                //    DataGridViewComboBoxColumn namHocCol = new DataGridViewComboBoxColumn();
                //    namHocCol.Name = "CmbNamHoc";
                //    namHocCol.HeaderText = "CmbNamHoc";
                //    namHocCol.ValueType = typeof(int);
                //    dtgvChiTietMon.Columns.Insert(dtgvChiTietMon.Columns["TenMon"].Index + 1, namHocCol);

                //    isFirstTimeRenderDTGV = false;
                //}

                dtgvChiTietMon.Columns["TenMon"].HeaderText = "Môn";
                dtgvChiTietMon.Columns["TenNamHoc"].HeaderText = "Năm Học";
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
                dtgvChiTietMon.Columns["MaNamHoc"].Visible = false;

                dtgvChiTietMon.Columns["TenMon"].ReadOnly = true;
                dtgvChiTietMon.Columns["TenNamHoc"].ReadOnly = true;
                dtgvChiTietMon.Columns["GiangVien"].ReadOnly = true;
                dtgvChiTietMon.Columns["CanBoCoiThiLan1"].ReadOnly = true;
                dtgvChiTietMon.Columns["CanBoCoiThiLan2"].ReadOnly = true;
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
                    //lopDTO.MaNamHoc = (cmbNamHocCuaLop.SelectedItem as NamHocDTO).MaNamHoc;

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

        private void dtgvChiTietMon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgvChiTietMon.Columns[e.ColumnIndex].Name == "GiangVien" && e.RowIndex >= 0)
                {
                    isFrmThemGiangVienClosed = false;
                    gMaChiTietMon = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaChiTietMon"].Value.ToString());

                    frmThemGiangVienVaoMonTimKiem frm = new frmThemGiangVienVaoMonTimKiem();
                    frm.ShowDialog();
                    timer1.Start();
                }

                if (dtgvChiTietMon.Columns[e.ColumnIndex].Name == "CanBoCoiThiLan1" && e.RowIndex >= 0)
                {
                    isFrmThemCanBoCoiThiLan1Closed = false;
                    gMaChiTietMon = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaChiTietMon"].Value.ToString());

                    frmThemCanBoCoiThiLan1TimKiem frm = new frmThemCanBoCoiThiLan1TimKiem();
                    frm.ShowDialog();
                    timer1.Start();
                }

                if (dtgvChiTietMon.Columns[e.ColumnIndex].Name == "CanBoCoiThiLan2" && e.RowIndex >= 0)
                {
                    isFrmThemCanBoCoiThiLan1Closed = false;
                    gMaChiTietMon = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaChiTietMon"].Value.ToString());

                    frmThemCanBoCoiThiLan2TimKiem frm = new frmThemCanBoCoiThiLan2TimKiem();
                    frm.ShowDialog();
                    timer1.Start();
                }

                if (dtgvChiTietMon.Columns[e.ColumnIndex].Name == "TenNamHoc" && e.RowIndex >= 0)
                {
                    isFrmThemNamHocVaoChiTietMonClosed = false;
                    gMaChiTietMon = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaChiTietMon"].Value.ToString());
                    if (dtgvChiTietMon.Rows[e.RowIndex].Cells["MaNamHoc"].Value.ToString() != "")
                        gMaNamHoc = Int32.Parse(dtgvChiTietMon.Rows[e.RowIndex].Cells["MaNamHoc"].Value.ToString());
                    else
                        gMaNamHoc = 0;

                    frmThemNamHocVaoChiTietMonTimKiem frm = new frmThemNamHocVaoChiTietMonTimKiem();
                    frm.ShowDialog();
                    timer1.Start();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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

            if (isFrmThemNamHocVaoChiTietMonClosed)
            {
                isFrmThemNamHocVaoChiTietMonClosed = false;
                timer1.Stop();
                LayDanhSachChiTietMon();
            }
        }

        private void dtgvChiTietMon_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //try
            //{
            //    if (!isFirstTimeRenderDTGV)
            //    {
            //        IList listNamHoc = NamHocBUS.GetList();

            //        foreach (DataGridViewRow row in dtgvChiTietMon.Rows)
            //        {
            //            ((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).DataSource = listNamHoc;
            //            ((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).DisplayMember = "TenNamHoc";
            //            ((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).ValueMember = "MaNamHoc";
            //            if (row.Cells["MaNamHoc"].Value.ToString() != "")
            //            {
            //                for (int i = 0; i < ((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).Items.Count; i++)
            //                {
            //                    if (((NamHocDTO)(((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).Items[i])).MaNamHoc == Int32.Parse(row.Cells["MaNamHoc"].Value.ToString()))
            //                    {
            //                        ((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).Value = ((NamHocDTO)(((DataGridViewComboBoxCell)row.Cells["CmbNamHoc"]).Items[i])).MaNamHoc;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
