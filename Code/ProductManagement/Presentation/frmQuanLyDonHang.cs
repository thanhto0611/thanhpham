using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using DTO;
using BUS;
using System.Globalization;
using OfficeOpenXml.Drawing;
using System.Diagnostics;
using OfficeOpenXml;
using Microsoft.Office.Core;
using Excel = Microsoft.Office.Interop.Excel;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using System.Threading;

namespace Presentation
{
    public partial class frmQuanLyDonHang : Form
    {
        private int _imageSize = 100;
        private int _rowHeight = 110;
        private int _colWidth = 110;
        private bool fromFormat = false;
        private int _gSL = 0;
        private string _gMaSP;
        public static int gMaDH;
        private int _maDH = 0;
        private int _curTrangThai;
        private bool _changed = false; // define if have any change in this form, ask to save before close
        private bool _changedByWeb = false;
        public static bool _readFromWebDone = false;

        public static DataTable dt = new DataTable();
        DataTable dtTimKiem = new DataTable();
        public static DataTable dtWeb = new DataTable();

        public class inventor
        {
            public string masp;
            public int soluong;
            public int trangthai;
        }

        DonHangDTO dhDto = new DonHangDTO();
        KhachHangDTO khDto = new KhachHangDTO();

        public frmQuanLyDonHang()
        {
            InitializeComponent();
        }

        private void cbxMaDonHang_TimKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMaDonHang_TimKiem.Checked == true)
            {
                txtMaDonHang_TimKiem.Enabled = true;
                txtMaDonHang_TimKiem.BackColor = Color.Yellow;
                cbxNgayDatHang_TimKiem.Checked = false;
                cbxThongTinKH_TimKiem.Checked = false;
                cbxMaSP_TimKiem.Checked = false;
                cmbSoLuongHienThi.Enabled = false;
            }
            else
            {
                txtMaDonHang_TimKiem.Enabled = false;
                txtMaDonHang_TimKiem.BackColor = Color.White;
                cmbSoLuongHienThi.Enabled = true;
            }
        }

        private void cbxEmail_TimKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxThongTinKH_TimKiem.Checked == true)
            {
                txtThongTinKH_TimKiem.Enabled = true;
                txtThongTinKH_TimKiem.BackColor = Color.Yellow;
                cbxNgayDatHang_TimKiem.Checked = false;
                cbxMaDonHang_TimKiem.Checked = false;
                cbxMaSP_TimKiem.Checked = false;
                cmbSoLuongHienThi.Enabled = false;
            }
            else
            {
                txtThongTinKH_TimKiem.Enabled = false;
                txtThongTinKH_TimKiem.BackColor = Color.White;
                cmbSoLuongHienThi.Enabled = true;
            }
        }

        private void cbxFacebook_TimKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMaSP_TimKiem.Checked == true)
            {
                txtMaSP_TimKiem.Enabled = true;
                txtMaSP_TimKiem.BackColor = Color.Yellow;
                cbxNgayDatHang_TimKiem.Checked = false;
                cbxMaDonHang_TimKiem.Checked = false;
                cbxThongTinKH_TimKiem.Checked = false;
                cmbSoLuongHienThi.Enabled = false;
            }
            else
            {
                txtMaSP_TimKiem.Enabled = false;
                txtMaSP_TimKiem.BackColor = Color.White;
                cmbSoLuongHienThi.Enabled = true;
            }
        }

        private void cbxNgayDatHang_TimKiem_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNgayDatHang_TimKiem.Checked == true)
            {
                dtpNgayDatHang_TimKiem.Enabled = true;
                cbxMaDonHang_TimKiem.Checked = false;
                cbxThongTinKH_TimKiem.Checked = false;
                cbxMaSP_TimKiem.Checked = false;
                cmbSoLuongHienThi.Enabled = false;
            }
            else
            {
                dtpNgayDatHang_TimKiem.Enabled = false;
                cmbSoLuongHienThi.Enabled = true;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                TimKiemDonHang();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void TimKiemDonHang()
        {
            try
            {
                DonHangBUS dhBus = new DonHangBUS();
                if (cbxMaDonHang_TimKiem.Checked == true)
                {
                    dtTimKiem = dhBus.TimKiemTheoMaDonHang(Int32.Parse(txtMaDonHang_TimKiem.Text.ToString()));
                }
                else if (cbxThongTinKH_TimKiem.Checked == true)
                {
                    dtTimKiem = dhBus.TimKiemTheoThongTinKhachHang(txtThongTinKH_TimKiem.Text);
                }
                else if (cbxMaSP_TimKiem.Checked == true)
                {
                    dtTimKiem = dhBus.TimKiemTheoMaSanPham(txtMaSP_TimKiem.Text);
                }
                else if (cbxNgayDatHang_TimKiem.Checked == true)
                {
                    dtTimKiem = dhBus.TimKiemTheoNgayDatHang(dtpNgayDatHang_TimKiem.Value.ToString("dd/MM/yyyy"));
                }
                else
                {
                    string numOfOrder = cmbSoLuongHienThi.SelectedItem.ToString();
                    if (numOfOrder != "Tất cả")
                        dtTimKiem = dhBus.GetTableWithLimitOrder(numOfOrder);
                    else
                        dtTimKiem = dhBus.GetTable();
                }
                dtgvTimKiemDonHang.DataSource = dtTimKiem;
                formatDataTimKiem();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void txtData_Them_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void TimKiem()
        {
            try
            {
                KhachHangBUS khachhangBUS = new KhachHangBUS();
                listKhachHang.DataSource = khachhangBUS.TimKiem(txtData_Them.Text);
                listKhachHang.DisplayMember = "HoTen";
                listKhachHang.ValueMember = "MaKhachHang";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTransport_Click(object sender, EventArgs e)
        {
            if(listKhachHang.SelectedIndex < 0)
            {
                MessageBox.Show("Bạn phải chọn 1 khách hàng trong danh sách bên trái");
                return;
            }

            KhachHangBUS khBus = new KhachHangBUS();
            khDto.MaKhachHang = Int32.Parse(listKhachHang.SelectedValue.ToString());

            khBus.GetKhachHang(khDto);

            //txtTenKH_Them.Text = listKhachHang.GetItemText(listKhachHang.SelectedItem);
            txtTenKH_Them.Text = khDto.HoTen;
            txtDiaChi_Them.Text = khDto.DiaChi;
            txtDienThoai_Them.Text = khDto.DienThoai;
            txtEmail_Them.Text = khDto.Email;
            txtFacebook_Them.Text = khDto.Facebook;
            txtTKNganHang_Them.Text = khDto.TKNganHang;
            txtMaKH_Them.Text = listKhachHang.SelectedValue.ToString();
            lbTongDiemTichLuy.Text = khDto.DiemTichLuy.ToString("n0");

            btnTaoDonHang.Visible = true;
            btnTaoDonHang.Enabled = true;
            btnNhapDonHang.Visible = true;
            btnNhapDonHang.Enabled = true;
            lbSoLuong.Text = "0";
            lbTongTien.Text = "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                btnNhapDonHang.Enabled = false;
                btnTransport.Enabled = false;
                SanPhamBUS spBus = new SanPhamBUS();
                dt = spBus.GetNull();
                dtgvDanhSachSanPham.DataSource = dt;
                dtgvDanhSachSanPham.Visible = true;

                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.Name = "img";
                imageCol.HeaderText = "Hinh Anh";
                imageCol.Width = _colWidth;
                dtgvDanhSachSanPham.Columns.Insert(1, imageCol);

                DataGridViewComboBoxColumn soLuongCol = new DataGridViewComboBoxColumn();
                soLuongCol.Name = "CmbSoLuong";
                soLuongCol.HeaderText = "SoLuong";
                soLuongCol.ValueType = typeof(int);
                dtgvDanhSachSanPham.Columns.Insert(dtgvDanhSachSanPham.Columns["SoLuong"].Index + 1, soLuongCol);

                //DataGridViewTextBoxColumn txtSoLuongCol = new DataGridViewTextBoxColumn();
                //txtSoLuongCol.Name = "TxtSoLuong";
                //txtSoLuongCol.HeaderText = "SoLuong";
                //txtSoLuongCol.ValueType = typeof(int);
                //dtgvDanhSachSanPham.Columns.Insert(dtgvDanhSachSanPham.Columns["CmbSoLuong"].Index + 1, txtSoLuongCol);

                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.HeaderText = "";
                btnColumn.Text = "Xóa";
                btnColumn.UseColumnTextForButtonValue = true;
                dtgvDanhSachSanPham.Columns.Add(btnColumn);

                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox8.Visible = true;
                

                //DataGridViewColumn giaBanCol = new DataGridViewColumn();
                //giaBanCol.Name = "GiaBan";
                //giaBanCol.HeaderText = "GiaBan";
                //dtgvDanhSachSanPham.Columns.Insert(dtgvDanhSachSanPham.Columns["GiaSi"].Index + 1, giaBanCol);
                btnTaoDonHang.Enabled = false;
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvDanhSachSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //formatData();
            _changed = true;
        }

        private void txtTenKH_Them_TextChanged(object sender, EventArgs e)
        {
            if (txtTenKH_Them.Text != "")
            {
                btnTaoDonHang.Enabled = true;
            }
            else
            {
                btnTaoDonHang.Enabled = false;
            }
        }

        private void txtMaSanPham_Them_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //dtgvDanhSachSanPham.Columns.Clear();
                _gSL = 0;
                _gMaSP = "";

                SanPhamBUS sb = new SanPhamBUS();
                ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                DataTable dt1 = sb.LayBangMaSanPham(txtMaSanPham_Them.Text);
                
                if (dt1.Rows.Count == 1)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = dt1.Rows[0].ItemArray.Clone() as object[];

                    for (int i = 0; i < dtgvDanhSachSanPham.Rows.Count; i++)
                    {
                        if (dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString() == dr.ItemArray.GetValue(0).ToString())
                        {
                            _gSL = Int32.Parse(dtgvDanhSachSanPham.Rows[i].Cells["CmbSoLuong"].Value.ToString()) + 1;
                            if (dhDto.TrangThai == 2 || dhDto.TrangThai == 5)
                            {
                                ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(_maDH, dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString());
                                if (ctdhDto.MaChiTietDonHang != 0) // Sản phẩm đã có trong đơn hàng
                                {
                                    if (_gSL > ctdhDto.SoLuong)
                                    {
                                        int soLgDatThem = _gSL - ctdhDto.SoLuong;
                                        int kq = KiemTraConHang(dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString(), soLgDatThem);
                                        if (kq > -1)
                                        {
                                            MessageBox.Show("Số lượng sản phẩm  '" + dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString() + "'  đặt thêm lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng đặt thêm là: " + soLgDatThem.ToString() + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                                            return;
                                        }
                                    }
                                    _gMaSP = dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString();
                                    dt.Rows.RemoveAt(i);
                                    break;
                                }
                                else
                                {
                                    if (_gSL > Int32.Parse(dr.ItemArray.GetValue(4).ToString()))
                                    {
                                        MessageBox.Show("Số lượng sản phẩm  '" + dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + dr.ItemArray.GetValue(4).ToString());
                                        return;
                                    }
                                    _gMaSP = dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString();
                                    dt.Rows.RemoveAt(i);
                                    break;
                                }
                            }
                            else
                            {
                                if (_gSL > Int32.Parse(dr.ItemArray.GetValue(4).ToString()))
                                {
                                    MessageBox.Show("Số lượng sản phẩm  '" + dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + dr.ItemArray.GetValue(4).ToString());
                                    return;
                                }
                                _gMaSP = dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString();
                                dt.Rows.RemoveAt(i);
                                break;
                            }
                        }
                    }
                    //dt.ImportRow(dt1.Rows[0]);
                    //DataRow dr = dt1.Rows[0];
                    dt.Rows.InsertAt(dr, 0);
                    dtgvDanhSachSanPham.DataSource = dt;
                    dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = 0;
                    //dtgvDanhSachSanPham.FirstDisplayedCell = dtgvDanhSachSanPham.Rows[dtgvDanhSachSanPham.RowCount - 1].Cells["MaSanPham"];
                    
                    formatData();
                    _changed = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvDanhSachSanPham_DataSourceChanged(object sender, EventArgs e)
        {
            try
            {
                if (_changedByWeb == false)
                {
                    formatData();
                    _changed = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdGiaLe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaLe.Checked == true)
            {
                rdGiaSi.Checked = false;
                dtgvDanhSachSanPham_DataSourceChanged(sender, e);
                _changed = true;
            }
        }

        private void rdGiaSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaSi.Checked == true)
            {
                rdGiaLe.Checked = false;
                dtgvDanhSachSanPham_DataSourceChanged(sender, e);
                _changed = true;
            }
        }

        private void dtgvDanhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //lbSoLuong.Text = e.ColumnIndex.ToString();
            //if (e.ColumnIndex == dtgvDanhSachSanPham.Columns.Count - 1)
            //{
            //    try
            //    {
            //        dt.Rows.Remove(dt.Rows[e.RowIndex]);
            //        dtgvDanhSachSanPham.DataSource = dt;
            //    }
            //    catch (System.Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
        }

        private void dtgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lbSoLuong.Text = e.ColumnIndex.ToString();
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                try
                {
                    ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                    ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(_maDH, dtgvDanhSachSanPham.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString());
                    if (ctdhDto.MaChiTietDonHang != 0)
                    {
                        DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này khỏi đơn hàng hay ko",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                        if (result == DialogResult.Yes)
                        {
                            dt.Rows.Remove(dt.Rows[e.RowIndex]);
                            if (dhDto.TrangThai == 2 || dhDto.TrangThai == 5)
                            {
                                string maSp = ctdhDto.MaSanPham;
                                int sl = ctdhDto.SoLuong;
                                SanPhamDTO spDto = SanPhamBUS.LaySanPham(maSp);
                                int trangThai = 0;
                                if ((sl + spDto.SoLuong) > 0)
                                {
                                    trangThai = 1;
                                }
                                SanPhamBUS spBus = new SanPhamBUS();
                                spBus.CapNhatKhoHang(maSp, sl + spDto.SoLuong, trangThai);
                                startThread(maSp, sl + spDto.SoLuong, trangThai);
                            }

                            if (dhDto.MaDonHang != 0)
                            {
                                DonHangBUS dhBus = new DonHangBUS();

                                dhDto.NguoiCapNhat = frmDangNhap.gUserName;
                                dhDto.PhiVanChuyen = Int32.Parse(txtPhiVanChuyen_Them.Text);
                                dhDto.TongTien = Int32.Parse(lbTongTien.Text.Replace(@",", "")) - ctdhDto.GiaBan;
                                dhDto.SoLuongSanPham = Int32.Parse(lbSoLuong.Text) - ctdhDto.SoLuong;
                                if (rdGiaSi.Checked == true)
                                {
                                    dhDto.HinhThucMua = 0; //Gia Si
                                }
                                else
                                {
                                    dhDto.HinhThucMua = 1; //Gia Le
                                }
                                dhBus.Update(dhDto);
                            }
                            ctdhBus.Delete(ctdhDto.MaChiTietDonHang);
                        }
                    }
                    else
                    {
                        dt.Rows.Remove(dt.Rows[e.RowIndex]);
                    }
                    dtgvDanhSachSanPham.DataSource = dt;
                    dtgvDanhSachSanPham_DataSourceChanged(sender, e);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.ColumnIndex == dtgvDanhSachSanPham.Columns["CmbSoLuong"].Index && e.RowIndex >= 0)
            {
                dtgvDanhSachSanPham.BeginEdit(true);
                ComboBox comboBox = (ComboBox)dtgvDanhSachSanPham.EditingControl;
                if (comboBox != null)
                {
                    comboBox.DroppedDown = true;
                }
            }
        }

        private void formatData()
        {
            try
            {
                //dtgvDanhSachSanPham.Refresh();
                this.dtgvDanhSachSanPham.Columns["HinhAnh"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["TrangThai"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NgayNhap"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NgayCapNhat"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NguoiNhap"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NguoiCapNhat"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["GiaGoc"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["TrongLuong"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["SoLuong"].Visible = false;

                this.dtgvDanhSachSanPham.Columns["GiaSi"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaLe"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaGoc"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "#,0";

                //this.dtgvDanhSachSanPham.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                //this.dtgvDanhSachSanPham.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                this.dtgvDanhSachSanPham.Columns["NgayCapNhat"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["NgayNhap"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["MaSanPham"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaLe"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaSi"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaBan"].ReadOnly = true;

                this.dtgvDanhSachSanPham.Columns["GiaBan"].HeaderText = "TongTien";

                int tongTien = 0;
                int soLuong = 0;

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                {
                    row.Height = _rowHeight;

                    if (row.Cells["img"].Value == null)
                    {
                        string checkImgPath = Directory.GetCurrentDirectory();
                        string imgPath = Directory.GetCurrentDirectory();

                        checkImgPath = checkImgPath + @"\Hinh\" + row.Cells["HinhAnh"].Value.ToString();
                        if (File.Exists(checkImgPath) == true)
                        {
                            imgPath = checkImgPath;
                        }
                        else
                        {
                            imgPath = imgPath + @"\Hinh\NoImage.jpg";
                        }


                        Image image = Helper.ResizeImage(@imgPath, _imageSize, _imageSize, false);
                        row.Cells["img"].Value = image;
                    }
                    
                    if (row.Cells["TrangThai"].Value.ToString() == "0" || Int32.Parse(row.Cells["SoLuong"].Value.ToString()) <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        //row.Cells["MauSac"].ReadOnly = true;
                    }

                    //int sl;
                    //SanPhamDTO spDto = SanPhamBUS.LaySanPham(row.Cells["MaSanPham"].Value.ToString());
                    //ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                    //ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(dhDto.MaDonHang, row.Cells["MaSanPham"].Value.ToString());

                    //if ((dhDto.TrangThai == 2 || dhDto.TrangThai == 5) && ctdhDto.MaChiTietDonHang != 0)
                    //{
                    //    sl = Int32.Parse(row.Cells["SoLuong"].Value.ToString()) + spDto.SoLuong;
                    //}
                    //else
                    //{
                    //    sl = spDto.SoLuong;
                    //}

                    if (((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Count == 0)
                    {
                        for (int i = 0; i <= 30; i++)
                        {
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Add(i);
                        }
                        if (((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Count == 0)
                        {
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Add(0);
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).ReadOnly = true;
                        }
                        row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[1];
                    }

                    if (_gMaSP == row.Cells["MaSanPham"].Value.ToString())
                    {
                        row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[_gSL];
                    }

                    if (rdGiaLe.Checked == true)
                    {
                        fromFormat = true;
                        row.Cells["GiaBan"].Value = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) * Int32.Parse(row.Cells["GiaLe"].Value.ToString());
                    }
                    else
                    {
                        fromFormat = true;
                        row.Cells["GiaBan"].Value = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) * Int32.Parse(row.Cells["GiaSi"].Value.ToString());
                    }

                    

                    soLuong += Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                    tongTien += Int32.Parse(row.Cells["GiaBan"].Value.ToString());
                }

                if (txtPhiVanChuyen_Them.Text != "")
                {
                    tongTien += Int32.Parse(txtPhiVanChuyen_Them.Text.ToString());
                }
                
                lbSoLuong.Text = soLuong.ToString();
                lbTongTien.Text = (tongTien - dhDto.DiemTichLuySuDung).ToString("n0");
                fromFormat = false;
                _gMaSP = "";
                _gSL = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatDataWeb()
        {
            try
            {
                //dtgvDanhSachSanPham.Refresh();
                this.dtgvDanhSachSanPham.Columns["HinhAnh"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["TrangThai"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NgayNhap"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NgayCapNhat"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NguoiNhap"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["NguoiCapNhat"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["GiaGoc"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["TrongLuong"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["SoLuong"].Visible = false;

                this.dtgvDanhSachSanPham.Columns["GiaSi"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaLe"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaGoc"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "#,0";

                //this.dtgvDanhSachSanPham.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                //this.dtgvDanhSachSanPham.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                this.dtgvDanhSachSanPham.Columns["NgayCapNhat"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["NgayNhap"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["MaSanPham"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaLe"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaSi"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaBan"].ReadOnly = true;

                this.dtgvDanhSachSanPham.Columns["GiaBan"].HeaderText = "TongTien";

                int tongTien = 0;
                int soLuong = 0;

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                {
                    row.Height = _rowHeight;

                    if (row.Cells["img"].Value == null)
                    {
                        string checkImgPath = Directory.GetCurrentDirectory();
                        string imgPath = Directory.GetCurrentDirectory();

                        checkImgPath = checkImgPath + @"\Hinh\" + row.Cells["HinhAnh"].Value.ToString();
                        if (File.Exists(checkImgPath) == true)
                        {
                            imgPath = checkImgPath;
                        }
                        else
                        {
                            imgPath = imgPath + @"\Hinh\NoImage.jpg";
                        }


                        Image image = Helper.ResizeImage(@imgPath, _imageSize, _imageSize, false);
                        row.Cells["img"].Value = image;
                    }

                    if (row.Cells["TrangThai"].Value.ToString() == "0" || Int32.Parse(row.Cells["SoLuong"].Value.ToString()) <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        //row.Cells["MauSac"].ReadOnly = true;
                    }

                    //int sl;
                    //SanPhamDTO spDto = SanPhamBUS.LaySanPham(row.Cells["MaSanPham"].Value.ToString());
                    //ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                    //ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(dhDto.MaDonHang, row.Cells["MaSanPham"].Value.ToString());

                    //if ((dhDto.TrangThai == 2 || dhDto.TrangThai == 5) && ctdhDto.MaChiTietDonHang != 0)
                    //{
                    //    sl = Int32.Parse(row.Cells["SoLuong"].Value.ToString()) + spDto.SoLuong;
                    //}
                    //else
                    //{
                    //    sl = spDto.SoLuong;
                    //}

                    if (((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Count == 0)
                    {
                        for (int i = 0; i <= 30; i++)
                        {
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Add(i);
                        }
                        if (((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Count == 0)
                        {
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Add(0);
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).ReadOnly = true;
                        }
                        row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[Int32.Parse(row.Cells["SoLuong"].Value.ToString())];
                    }

                    //if (_gMaSP == row.Cells["MaSanPham"].Value.ToString())
                    //{
                    //    row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[_gSL];
                    //}

                    if (rdGiaLe.Checked == true)
                    {
                        fromFormat = true;
                        row.Cells["GiaBan"].Value = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) * Int32.Parse(row.Cells["GiaLe"].Value.ToString());
                    }
                    else
                    {
                        fromFormat = true;
                        row.Cells["GiaBan"].Value = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) * Int32.Parse(row.Cells["GiaSi"].Value.ToString());
                    }



                    soLuong += Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                    tongTien += Int32.Parse(row.Cells["GiaBan"].Value.ToString());
                }

                if (txtPhiVanChuyen_Them.Text != "")
                {
                    tongTien += Int32.Parse(txtPhiVanChuyen_Them.Text.ToString());
                }

                lbSoLuong.Text = soLuong.ToString();
                lbTongTien.Text = tongTien.ToString("n0");
                fromFormat = false;
                _gMaSP = "";
                _gSL = 0;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formatDataTimKiem()
        {
            try
            {
                //dtgvDanhSachSanPham.Refresh();
                this.dtgvTimKiemDonHang.Columns["TrangThai"].Visible = false;

                this.dtgvTimKiemDonHang.Columns["PhiVanChuyen"].DefaultCellStyle.Format = "#,0";
                this.dtgvTimKiemDonHang.Columns["TongTien"].DefaultCellStyle.Format = "#,0";

                this.dtgvTimKiemDonHang.Columns["NgayDatHang"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                this.dtgvTimKiemDonHang.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                this.dtgvTimKiemDonHang.Columns["MaDH"].ReadOnly = true;
                this.dtgvTimKiemDonHang.Columns["HoTen"].ReadOnly = true;
                this.dtgvTimKiemDonHang.Columns["SoLuongSanPham"].ReadOnly = true;
                this.dtgvTimKiemDonHang.Columns["TongTien"].ReadOnly = true;
                this.dtgvTimKiemDonHang.Columns["NgayDatHang"].ReadOnly = true;
                this.dtgvTimKiemDonHang.Columns["NguoiNhap"].ReadOnly = true;
                this.dtgvTimKiemDonHang.Columns["NgayCapNhat"].ReadOnly = true;
                this.dtgvTimKiemDonHang.Columns["NguoiCapNhat"].ReadOnly = true;

                foreach (DataGridViewRow row in this.dtgvTimKiemDonHang.Rows)
                {
                    row.Cells["CmbTrangThai"].Value = row.Cells["TrangThai"].Value;
                    if (row.Index % 2 == 1)
                    {
                        row.DefaultCellStyle.BackColor = Color.PowderBlue;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvDanhSachSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    formatData();
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void dtgvDanhSachSanPham_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                // Remove an existing event-handler, if present, to avoid  
                // adding multiple handlers when the editing control is reused.
                combo.SelectedIndexChanged -=
                    new EventHandler(ComboBox_SelectedIndexChanged);

                // Add the event handler. 
                combo.SelectedIndexChanged +=
                    new EventHandler(ComboBox_SelectedIndexChanged);

                e.CellStyle.BackColor = this.dtgvDanhSachSanPham.DefaultCellStyle.BackColor;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromFormat == false)
            {
                try
                {
                    if (_changedByWeb == false)
                    {
                        dtgvDanhSachSanPham.CurrentCell.Value = ((ComboBox)sender).SelectedItem;
                        formatData();
                        _changed = true;
                    }
                    
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnThemDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPhiVanChuyen_Them.Text == "")
                {
                    MessageBox.Show("Phải nhập phí vận chuyển");
                    return;
                }
                if (cbmTrangThai_Them.Text == "")
                {
                    MessageBox.Show("Phải chọn trạng thái đơn hàng");
                    return;
                }
                if (dtgvDanhSachSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("Phải chọn ít nhất 1 sản phẩm");
                    return;
                }

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                {
                    int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                    if (kq > -1)
                    {
                        DialogResult result1 = MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString() + "\n\nBạn có muốn lưu sản phẩm này không?",
                            "Lưu ý",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1);
                        if (result1 == DialogResult.No)
                        {
                            dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = row.Index;
                            return;
                        }
                    }
                }

                DialogResult result = MessageBox.Show("Bạn có chắc là muốn thêm đơn hàng này không",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    ThemDonHang();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPhiVanChuyen_Them_TextChanged(object sender, EventArgs e)
        {
            formatData();
            _changed = true;
        }

        private void ThemDonHang()
        {
            try
            {
                if (txtPhiVanChuyen_Them.Text == "")
                {
                    MessageBox.Show("Phải nhập phí vận chuyển");
                    return;
                }
                if (cbmTrangThai_Them.Text == "")
                {
                    MessageBox.Show("Phải chọn trạng thái đơn hàng");
                    return;
                }
                if (dtgvDanhSachSanPham.Rows.Count == 0)
                {
                    MessageBox.Show("Phải chọn ít nhất 1 sản phẩm");
                    return;
                }
                DonHangBUS dhBus = new DonHangBUS();
                //DonHangDTO dhDto = new DonHangDTO();
                ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();


                dhDto.MaKhachHang = Int32.Parse(txtMaKH_Them.Text);
                if (cbmTrangThai_Them.Text == "Mới đặt")
                {
                    dhDto.TrangThai = 1;
                }
                else
                {
                    dhDto.TrangThai = 2;
                }
                dhDto.NguoiNhap = frmDangNhap.gUserName;
                dhDto.PhiVanChuyen = Int32.Parse(txtPhiVanChuyen_Them.Text);
                dhDto.TongTien = Int32.Parse(lbTongTien.Text.Replace(@",",""));
                dhDto.SoLuongSanPham = Int32.Parse(lbSoLuong.Text);
                if (rdGiaSi.Checked == true)
                {
                    dhDto.HinhThucMua = 0; //Gia Si
                }
                else
                {
                    dhDto.HinhThucMua = 1; //Gia Le
                }
                dhBus.Insert(dhDto);
                _maDH = dhDto.MaDonHang;

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                {
                    ChiTietDonHangDTO ctdhDto = new ChiTietDonHangDTO();
                    ctdhDto.MaDonHang = dhDto.MaDonHang;
                    ctdhDto.MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                    ctdhDto.MauSac = row.Cells["MauSac"].Value.ToString();
                    ctdhDto.SoLuong = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                    ctdhDto.GiaBan = Int32.Parse(row.Cells["GiaBan"].Value.ToString().Replace(@",", ""));
                    ctdhBus.Insert(ctdhDto);

                    if (cbmTrangThai_Them.Text == "Hoàn tất")
                    {
                        int newSl = ctdhDto.SoLuong;
                        int oldSl = Int32.Parse(row.Cells["SoLuong"].Value.ToString());
                        int trangthai;
                        if (newSl == oldSl)
                        {
                            trangthai = 0;
                        } 
                        else
                        {
                            trangthai = 1;
                        }
                        SanPhamBUS spBus = new SanPhamBUS();
                        spBus.CapNhatKhoHang(ctdhDto.MaSanPham, oldSl - newSl, trangthai);
                        startThread(ctdhDto.MaSanPham, oldSl - newSl, trangthai);
                    }
                }

                MessageBox.Show("Đơn hàng đã được thêm thành công");
                btnThemDonHang.Visible = false;
                btnExport.Visible = true;
                btnCapNhat.Visible = true;
                _curTrangThai = dhDto.TrangThai;
                cbmTrangThai_Them.DataSource = TrangThaiDonHangBUS.GetList();
                cbmTrangThai_Them.DisplayMember = "TrangThai";
                cbmTrangThai_Them.ValueMember = "MaTrangThai";
                cbmTrangThai_Them.SelectedValue = dhDto.TrangThai;
                lbMaDonHang.Text = _maDH.ToString();
                _changed = false;
                chbxSuDungDTL.Enabled = true;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CapNhatDonHang()
        {
            try
            {
                if (txtPhiVanChuyen_Them.Text == "")
                {
                    MessageBox.Show("Phải nhập phí vận chuyển");
                    return;
                }
                if (cbmTrangThai_Them.Text == "")
                {
                    MessageBox.Show("Phải chọn trạng thái đơn hàng");
                    return;
                }

                int newTrangThai = Int32.Parse(cbmTrangThai_Them.SelectedValue.ToString());
                ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();

                DonHangBUS dhBus = new DonHangBUS();
                //DonHangDTO dhDto = new DonHangDTO();

                dhDto.MaDonHang = _maDH;
                dhDto.MaKhachHang = Int32.Parse(txtMaKH_Them.Text);
                dhDto.TrangThai = Int32.Parse(cbmTrangThai_Them.SelectedValue.ToString());
                dhDto.NguoiCapNhat = frmDangNhap.gUserName;
                dhDto.PhiVanChuyen = Int32.Parse(txtPhiVanChuyen_Them.Text);
                dhDto.TongTien = Int32.Parse(lbTongTien.Text.Replace(@",", ""));
                dhDto.SoLuongSanPham = Int32.Parse(lbSoLuong.Text);
                if (rdGiaSi.Checked == true)
                {
                    dhDto.HinhThucMua = 0; //Gia Si
                }
                else
                {
                    dhDto.HinhThucMua = 1; //Gia Le
                }
                dhBus.Update(dhDto);

                if ((_curTrangThai == 1 || _curTrangThai == 3 || _curTrangThai == 4) && (newTrangThai == 1 || newTrangThai == 3 || newTrangThai == 4))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                    {
                        ChiTietDonHangDTO ctdhDto = new ChiTietDonHangDTO();
                        ctdhDto.MaDonHang = dhDto.MaDonHang;
                        ctdhDto.MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                        ctdhDto.MauSac = row.Cells["MauSac"].Value.ToString();
                        ctdhDto.SoLuong = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                        ctdhDto.GiaBan = Int32.Parse(row.Cells["GiaBan"].Value.ToString().Replace(@",", ""));
                        if (ctdhBus.KiemTraTonTai(_maDH, ctdhDto.MaSanPham).MaChiTietDonHang != 0)
                        {
                            ctdhDto.MaChiTietDonHang = ctdhBus.KiemTraTonTai(_maDH, ctdhDto.MaSanPham).MaChiTietDonHang;
                            ctdhBus.Update(ctdhDto);
                        }
                        else
                        {
                            ctdhBus.Insert(ctdhDto);
                        }
                    }
                }

                if ((_curTrangThai == 1 || _curTrangThai == 3 || _curTrangThai == 4) && (newTrangThai == 2 || newTrangThai == 5))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                    {
                        ChiTietDonHangDTO ctdhDto = new ChiTietDonHangDTO();
                        ctdhDto.MaDonHang = dhDto.MaDonHang;
                        ctdhDto.MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                        ctdhDto.MauSac = row.Cells["MauSac"].Value.ToString();
                        ctdhDto.SoLuong = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                        ctdhDto.GiaBan = Int32.Parse(row.Cells["GiaBan"].Value.ToString().Replace(@",", ""));
                        if (ctdhBus.KiemTraTonTai(_maDH, ctdhDto.MaSanPham).MaChiTietDonHang != 0)
                        {
                            ctdhDto.MaChiTietDonHang = ctdhBus.KiemTraTonTai(_maDH, ctdhDto.MaSanPham).MaChiTietDonHang;
                            ctdhBus.Update(ctdhDto);
                        }
                        else
                        {
                            ctdhBus.Insert(ctdhDto);
                        }

                        int newSl = ctdhDto.SoLuong;
                        //int oldSl = Int32.Parse(row.Cells["SoLuong"].Value.ToString());
                        SanPhamDTO spDtoOld = SanPhamBUS.LaySanPham(ctdhDto.MaSanPham);
                        int oldSl = spDtoOld.SoLuong;
                        int trangthai;
                        if (newSl == oldSl)
                        {
                            trangthai = 0;
                        }
                        else
                        {
                            trangthai = 1;
                        }
                        SanPhamBUS spBus = new SanPhamBUS();
                        spBus.CapNhatKhoHang(ctdhDto.MaSanPham, oldSl - newSl, trangthai);
                        startThread(ctdhDto.MaSanPham, oldSl - newSl, trangthai);
                    }
                }

                if ((_curTrangThai == 2 || _curTrangThai == 5) && (newTrangThai == 1 || newTrangThai == 3 || newTrangThai == 4))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                    {
                        ChiTietDonHangDTO ctdhDto = new ChiTietDonHangDTO();
                        ChiTietDonHangDTO ctdhDtoOld = ctdhBus.KiemTraTonTai(_maDH, row.Cells["MaSanPham"].Value.ToString());
                        ctdhDto.MaDonHang = dhDto.MaDonHang;
                        ctdhDto.MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                        ctdhDto.MauSac = row.Cells["MauSac"].Value.ToString();
                        ctdhDto.SoLuong = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                        ctdhDto.GiaBan = Int32.Parse(row.Cells["GiaBan"].Value.ToString().Replace(@",", ""));
                        ctdhDto.MaChiTietDonHang = ctdhDtoOld.MaChiTietDonHang;
                        if (ctdhDtoOld.MaChiTietDonHang != 0)
                        {
                            ctdhBus.Update(ctdhDto);
                            string maSp = ctdhDto.MaSanPham;
                            int sl = ctdhDtoOld.SoLuong;
                            SanPhamDTO spDtoOld = SanPhamBUS.LaySanPham(maSp);
                            int trangThai = 0;
                            if ((sl + spDtoOld.SoLuong) > 0)
                            {
                                trangThai = 1;
                            }
                            SanPhamBUS spBus = new SanPhamBUS();
                            spBus.CapNhatKhoHang(maSp, sl + spDtoOld.SoLuong, trangThai);
                            startThread(maSp, sl + spDtoOld.SoLuong, trangThai);
                        }
                        else
                        {
                            ctdhBus.Insert(ctdhDto);
                        }
                    }
                }

                if ((_curTrangThai == 2 || _curTrangThai == 5) && (newTrangThai == 2 || newTrangThai == 5))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                    {
                        ChiTietDonHangDTO ctdhDto = new ChiTietDonHangDTO();
                        ChiTietDonHangDTO ctdhDtoOld = ctdhBus.KiemTraTonTai(_maDH, row.Cells["MaSanPham"].Value.ToString());
                        ctdhDto.MaDonHang = dhDto.MaDonHang;
                        ctdhDto.MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                        ctdhDto.MauSac = row.Cells["MauSac"].Value.ToString();
                        ctdhDto.SoLuong = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                        ctdhDto.GiaBan = Int32.Parse(row.Cells["GiaBan"].Value.ToString().Replace(@",", ""));
                        ctdhDto.MaChiTietDonHang = ctdhDtoOld.MaChiTietDonHang;
                        if (ctdhDtoOld.MaChiTietDonHang != 0)
                        {
                            ctdhBus.Update(ctdhDto);
                            string maSp = ctdhDto.MaSanPham;
                            SanPhamDTO spDtoOld = SanPhamBUS.LaySanPham(maSp);
                            int diffSoLuong = ctdhDto.SoLuong - ctdhDtoOld.SoLuong;
                            int trangThai = 0;
                            SanPhamBUS spBus = new SanPhamBUS();
                            if (diffSoLuong > 0)
                            {
                                if (spDtoOld.SoLuong - diffSoLuong > 0)
                                {
                                    trangThai = 1;
                                }
                            }
                            else
                            {
                                trangThai = 1;
                            }

                            spBus.CapNhatKhoHang(maSp, spDtoOld.SoLuong - diffSoLuong, trangThai);
                            startThread(maSp, spDtoOld.SoLuong - diffSoLuong, trangThai);
                        }
                        else
                        {
                            ctdhBus.Insert(ctdhDto);
                            string maSp = ctdhDto.MaSanPham;
                            SanPhamDTO spDtoOld = SanPhamBUS.LaySanPham(maSp);
                            int trangThai = 0;
                            SanPhamBUS spBus = new SanPhamBUS();

                            if (spDtoOld.SoLuong - ctdhDto.SoLuong > 0)
                            {
                                trangThai = 1;
                            }

                            spBus.CapNhatKhoHang(maSp, spDtoOld.SoLuong - ctdhDto.SoLuong, trangThai);
                            startThread(maSp, spDtoOld.SoLuong - ctdhDto.SoLuong, trangThai);
                        }
                    }
                }

                MessageBox.Show("Đơn hàng đã được cập nhật thành công");
                btnThemDonHang.Visible = false;
                btnCapNhat.Visible = true;
                _curTrangThai = dhDto.TrangThai;
                _changed = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            txtTenKH_Them.Text = "";
            txtMaKH_Them.Text = "";
            txtDiaChi_Them.Text = "";
            txtPhiVanChuyen_Them.Text = "0";
            txtDienThoai_Them.Text = "";
            txtFacebook_Them.Text = "";
            txtTKNganHang_Them.Text = "";
            txtEmail_Them.Text = "";
            txtMaSanPham_Them.Text = "";
            lbSoLuong.Text = "0";
            lbTongTien.Text = "0";
            txtData_Them.Text = "";
            listKhachHang.DataSource = null;
            btnTaoDonHang.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            dtgvDanhSachSanPham.Columns.Clear();
        }

        private int KiemTraConHang(string masp, int sl)
        {
            SanPhamBUS spBus = new SanPhamBUS();
            DataTable spTb = spBus.LayBangMaSanPham(masp);
            DataRow dr = spTb.Rows[0];
            if (Int32.Parse(dr.ItemArray.GetValue(4).ToString()) < sl)
            {
                return Int32.Parse(dr.ItemArray.GetValue(4).ToString());
            }
            return -1;
        }

        private void dtgvTimKiemDonHang_DataSourceChanged(object sender, EventArgs e)
        {
            //formatDataTimKiem();
        }

        private void dtgvTimKiemDonHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvTimKiemDonHang.Columns["CmbTrangThai"].Index && e.RowIndex >= 0)
            {
                dtgvTimKiemDonHang.BeginEdit(true);
                ComboBox comboBox = (ComboBox)dtgvTimKiemDonHang.EditingControl;
                comboBox.DroppedDown = true;
            }

            if (e.ColumnIndex == dtgvTimKiemDonHang.Columns["CapNhat"].Index && e.RowIndex >= 0)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn cập nhật đơn hàng này không?",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    //DonHangDTO dhDto_TimKiem = new DonHangDTO();
                    DonHangBUS dhBus = new DonHangBUS();
                    SanPhamBUS spBus = new SanPhamBUS();
                    ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                    DataTable dtCtdh = new DataTable();
                    DataTable dhTemp = new DataTable();

                    DonHangDTO dhDto_TimKiem = dhBus.LayBangMaDonHang(Int32.Parse(dtgvTimKiemDonHang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString()));

                    int ttHienTai = dhDto_TimKiem.TrangThai;
                    long pvcHienTai = dhDto_TimKiem.PhiVanChuyen;
                    long tongtienHienTai = dhDto_TimKiem.TongTien;
                    int ttdh = Int32.Parse(dtgvTimKiemDonHang.Rows[e.RowIndex].Cells["CmbTrangThai"].Value.ToString());

                    dhDto_TimKiem.TrangThai = ttdh;

                    if (dtgvTimKiemDonHang.Rows[e.RowIndex].Cells["PhiVanChuyen"].Value.ToString() == "")
                    {
                        dhDto_TimKiem.PhiVanChuyen = 0;
                    }
                    else
                    {
                        dhDto_TimKiem.PhiVanChuyen = Int32.Parse(dtgvTimKiemDonHang.Rows[e.RowIndex].Cells["PhiVanChuyen"].Value.ToString());
                    }
                    dhDto_TimKiem.TongTien = tongtienHienTai - pvcHienTai + dhDto_TimKiem.PhiVanChuyen;
                    dhDto_TimKiem.NguoiCapNhat = frmDangNhap.gUserName;

                    dtCtdh = ctdhBus.TimKiemTheoMaDonHang(Int32.Parse(dtgvTimKiemDonHang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString()));

                    if (ttdh == 1 || ttdh == 3 || ttdh == 4)
                    {
                        if (ttHienTai == 2 || ttHienTai ==5)
                        {
                            foreach (DataRow dr in dtCtdh.Rows)
                            {
                                string maSp = dr.ItemArray.GetValue(1).ToString();
                                int sl = Int32.Parse(dr.ItemArray.GetValue(2).ToString());
                                SanPhamDTO spDtoOld = SanPhamBUS.LaySanPham(maSp);
                                int trangThai = 0;
                                if ((sl + spDtoOld.SoLuong) > 0)
                                {
                                    trangThai = 1;
                                }
                                spBus.CapNhatKhoHang(maSp, sl + spDtoOld.SoLuong, trangThai);
                                startThread(maSp, sl + spDtoOld.SoLuong, trangThai);
                            }
                        }
                        dhBus.Update(dhDto_TimKiem);
                    }
                    if (ttdh == 2 || ttdh == 5)
                    {
                        if (ttHienTai == 1 || ttHienTai == 3 || ttHienTai ==4)
                        {
                            foreach (DataRow dr in dtCtdh.Rows)
                            {
                                string maSp = dr.ItemArray.GetValue(1).ToString();
                                int sl = Int32.Parse(dr.ItemArray.GetValue(2).ToString());
                                if (spBus.KiemTraKhoHang(maSp, sl) == false)
                                {
                                    MessageBox.Show("Số lượng sản phẩm  '" + maSp + "'  đặt mua lớn hơn số lượng hàng còn trong kho.\nVui lòng bấm vào CHI TIẾT ĐƠN HÀNG để cập nhật số lượng sản phẩm");
                                    return;
                                }
                            }

                            foreach (DataRow dr in dtCtdh.Rows)
                            {
                                string maSp = dr.ItemArray.GetValue(1).ToString();
                                int sl = Int32.Parse(dr.ItemArray.GetValue(2).ToString());
                                int trangthai = 1;
                                DataTable spTemp = spBus.LayBangMaSanPham(maSp);
                                int slTonKho = Int32.Parse(spTemp.Rows[0].ItemArray.GetValue(4).ToString());

                                if ((slTonKho - sl) == 0)
                                {
                                    trangthai = 0;
                                }
                                spBus.CapNhatKhoHang(maSp, slTonKho - sl, trangthai);
                                startThread(maSp, slTonKho - sl, trangthai);
                            }
                        }
                        dhBus.Update(dhDto_TimKiem);
                    }
                    MessageBox.Show("Cập nhật đơn hàng thành công");
                    TimKiemDonHang();
                }
            }
            if (e.ColumnIndex == dtgvTimKiemDonHang.Columns["ChiTiet"].Index && e.RowIndex >= 0)
            {
                try
                {
                    gMaDH = Int32.Parse(dtgvTimKiemDonHang.Rows[e.RowIndex].Cells["MaDH"].Value.ToString());
                    //frmChiTietDonHang frm = new frmChiTietDonHang();
                    //frmChiTietDonHangNew frm = new frmChiTietDonHangNew();
                    frmChiTietDonHangNew2 frm = new frmChiTietDonHangNew2();
                    frm.MdiParent = this.MdiParent;
                    frm.Dock = DockStyle.Fill;
                    frm.WindowState = FormWindowState.Maximized;
                    frm.Show();
                    frm.formatData();
                    frm._firstLoad = false;
                    //this.LayoutMdi(MdiLayout.TileHorizontal);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void frmQuanLyDonHang_Load(object sender, EventArgs e)
        {
            DonHangBUS dhBus = new DonHangBUS();
            dtTimKiem = dhBus.GetNull();
            dtgvTimKiemDonHang.DataSource = dtTimKiem;

            DataGridViewComboBoxColumn trangThaiCol = new DataGridViewComboBoxColumn();
            trangThaiCol.Name = "CmbTrangThai";
            trangThaiCol.HeaderText = "TrangThai";
            trangThaiCol.ValueType = typeof(int);
            trangThaiCol.DataSource = TrangThaiDonHangBUS.GetList();
            trangThaiCol.DisplayMember = "TrangThai";
            trangThaiCol.ValueMember = "MaTrangThai";

            dtgvTimKiemDonHang.Columns.Insert(dtgvTimKiemDonHang.Columns["TrangThai"].Index + 1, trangThaiCol);

            DataGridViewButtonColumn btnEditColumn = new DataGridViewButtonColumn();
            btnEditColumn.Name = "CapNhat";
            btnEditColumn.HeaderText = "";
            btnEditColumn.Text = "Cập nhật đơn hàng";
            btnEditColumn.UseColumnTextForButtonValue = true;
            dtgvTimKiemDonHang.Columns.Add(btnEditColumn);

            DataGridViewButtonColumn btnChiTietColumn = new DataGridViewButtonColumn();
            btnChiTietColumn.HeaderText = "";
            btnChiTietColumn.Name = "ChiTiet";
            btnChiTietColumn.Text = "Chi tiết đơn hàng";
            btnChiTietColumn.UseColumnTextForButtonValue = true;
            dtgvTimKiemDonHang.Columns.Add(btnChiTietColumn);

            formatDataTimKiem();

            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            // Set up the ToolTip text for the Button and Checkbox.
            toolTip1.SetToolTip(this.chbxSuDungDTL, "Điểm tích lũy chỉ sử dụng được sau khi đơn hàng được lưu");
        }

        private void txtMaDonHang_TimKiem_TextChanged(object sender, EventArgs e)
        {
            DonHangBUS dhBus = new DonHangBUS();

            string maDH = txtMaDonHang_TimKiem.Text.ToString();
            if (maDH == "")
            {
                dtTimKiem = dhBus.TimKiemTheoMaDonHang(-1);
            }
            else
            {
                dtTimKiem = dhBus.TimKiemTheoMaDonHang(Int32.Parse(maDH));
            }
            
            dtgvTimKiemDonHang.DataSource = dtTimKiem;
            formatDataTimKiem();
        }

        private void txtThongTinKH_TimKiem_TextChanged(object sender, EventArgs e)
        {
            //DonHangBUS dhBus = new DonHangBUS();

            //dtTimKiem = dhBus.TimKiemTheoThongTinKhachHang(txtThongTinKH_TimKiem.Text);
            //dtgvTimKiemDonHang.DataSource = dtTimKiem;
            //formatDataTimKiem();
        }

        private void txtMaSP_TimKiem_TextChanged(object sender, EventArgs e)
        {
            //DonHangBUS dhBus = new DonHangBUS();

            //dtTimKiem = dhBus.TimKiemTheoMaSanPham(txtMaSP_TimKiem.Text);
            //dtgvTimKiemDonHang.DataSource = dtTimKiem;
            //formatDataTimKiem();
        }

        frmShowPicture HoverZoom = new frmShowPicture();

        private void dtgvDanhSachSanPham_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvDanhSachSanPham.Columns["img"].Index && e.RowIndex >= 0)
            {
                DataGridView dgv_sender = sender as DataGridView;
                DataGridViewCell dgv_MouseOverCell = dgv_sender.Rows[e.RowIndex].Cells[e.ColumnIndex];

                //Get FilePath from dgv_MouseOverCell content

                //Get x, y based on position relative to edge of screen
                //x, y = top left point of HoverZoom form

                string checkImgPath = Directory.GetCurrentDirectory();
                string imgPath = Directory.GetCurrentDirectory();

                checkImgPath = checkImgPath + @"\Hinh\" + dtgvDanhSachSanPham.Rows[e.RowIndex].Cells["HinhAnh"].Value.ToString();
                if (File.Exists(checkImgPath) == true)
                {
                    imgPath = checkImgPath;
                }
                else
                {
                    imgPath = imgPath + @"\Hinh\NoImage.jpg";
                }

                HoverZoom.LoadPicture(imgPath, dtgvDanhSachSanPham.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString());
                HoverZoom.Location = new System.Drawing.Point(0, 0);
                HoverZoom.Show();
            }
        }

        private void dtgvDanhSachSanPham_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            HoverZoom.Hide();
            HoverZoom.ClearPicture();
        }

        // Cập nhật đơn hàng
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPhiVanChuyen_Them.Text == "")
                {
                    MessageBox.Show("Phải nhập phí vận chuyển");
                    return;
                }
                if (cbmTrangThai_Them.Text == "")
                {
                    MessageBox.Show("Phải chọn trạng thái đơn hàng");
                    return;
                }

                int newTrangThai = Int32.Parse(cbmTrangThai_Them.SelectedValue.ToString());
                ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();

                if ((_curTrangThai == 2 || _curTrangThai == 5) && (newTrangThai == 2 || newTrangThai == 5))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                    {
                        ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(_maDH, row.Cells["MaSanPham"].Value.ToString());
                        if (ctdhDto.MaChiTietDonHang != 0) // Sản phẩm đã có trong đơn hàng
                        {
                            if (Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) > ctdhDto.SoLuong)
                            {
                                int soLgDatThem = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) - ctdhDto.SoLuong;
                                int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), soLgDatThem);
                                if (kq > -1)
                                {
                                    DialogResult result1 = MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt thêm lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng đặt thêm là: " + soLgDatThem.ToString() + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString() + "\n\nBạn có muốn lưu sản phẩm này không?",
                                        "Lưu ý",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                    if (result1 == DialogResult.No)
                                    {
                                        dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = row.Index;
                                        return;
                                    }
                                }
                            }
                        }
                        else // Sản phẩm chưa có trong đơn hàng
                        {
                            int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                            if (kq > -1)
                            {
                                DialogResult result2 = MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString() + "\n\nBạn có muốn lưu sản phẩm này không?",
                                        "Lưu ý",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning,
                                        MessageBoxDefaultButton.Button1);
                                if (result2 == DialogResult.No)
                                {
                                    dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = row.Index;
                                    return;
                                }
                            }
                        }
                    }
                }

                if ((_curTrangThai == 1 || _curTrangThai == 3 || _curTrangThai == 4) && (newTrangThai == 2 || newTrangThai == 5))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                    {
                        int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                        if (kq > -1)
                        {
                            DialogResult result3 = MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString() + "\n\nBạn có muốn lưu sản phẩm này không?",
                                    "Lưu ý",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning,
                                    MessageBoxDefaultButton.Button1);
                            if (result3 == DialogResult.No)
                            {
                                dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = row.Index;
                                return;
                            }
                        }
                    }
                }

                DialogResult result = MessageBox.Show("Bạn có chắc là muốn cập nhật đơn hàng này không",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    CapNhatDonHang();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThemKhachHang_Click(object sender, EventArgs e)
        {
            frmQuanLyKhachHang frm = new frmQuanLyKhachHang();
            frm.Show();
        }

        private void dtgvDanhSachSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dtgvDanhSachSanPham_Sorted(object sender, EventArgs e)
        {
            formatData();
        }

        private void dtgvTimKiemDonHang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dtgvTimKiemDonHang_Sorted(object sender, EventArgs e)
        {
            formatDataTimKiem();
        }

        private void frmQuanLyDonHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmQLDH = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string templateFileName = "ExportTemplate.xlsx";
                string templateFilePath = Path.Combine(Directory.GetCurrentDirectory(), templateFileName);

                string exportFileName = lbMaDonHang.Text + "_" + txtTenKH_Them.Text.Replace(@" ", "").ToUpper() + "_" + String.Format("{0:dd_MM_yyyy}", DateTime.Today) + ".xlsx";
                string exportFilePath = Path.Combine(Directory.GetCurrentDirectory() + @"\Don Hang\", exportFileName);
                if (File.Exists(exportFilePath))
                {
                    File.Delete(exportFilePath);
                }
                File.Copy(templateFilePath, exportFilePath);

                FileInfo newFile = new FileInfo(exportFilePath);
                ExcelPackage excelPkg = new ExcelPackage(newFile);
                excelPkg.Workbook.Worksheets["Sheet1"].View.TabSelected = true;

                ExcelWorksheet oSheet = excelPkg.Workbook.Worksheets["Sheet1"];

                oSheet.Cells["G2"].Value = oSheet.Cells["G2"].Value + txtTenKH_Them.Text;
                oSheet.Cells["G3"].Value = oSheet.Cells["G3"].Value + txtDienThoai_Them.Text;
                oSheet.Cells["G4"].Value = oSheet.Cells["G4"].Value + txtDiaChi_Them.Text;
                oSheet.Cells["G6"].Value = oSheet.Cells["G6"].Value + txtEmail_Them.Text;
                oSheet.Cells["F15"].Value = Int32.Parse(txtPhiVanChuyen_Them.Text);

                int startRowIndex = 20;

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                {
                    string checkImgPath = Directory.GetCurrentDirectory();
                    string imgPath = Directory.GetCurrentDirectory();

                    checkImgPath = checkImgPath + @"\Hinh\" + row.Cells["HinhAnh"].Value.ToString();
                    if (File.Exists(checkImgPath) == true)
                    {
                        imgPath = checkImgPath;
                    }
                    else
                    {
                        imgPath = imgPath + @"\Hinh\NoImage.jpg";
                    }

                    Bitmap image = new Bitmap(imgPath);
                    ExcelPicture excelImage = null;
                    if (image != null)
                    {
                        excelImage = oSheet.Drawings.AddPicture(row.Cells["MaSanPham"].Value.ToString(), image);
                        excelImage.From.Column = 0;
                        excelImage.From.Row = startRowIndex - 1;
                        excelImage.SetSize(185, 185);
                        // 2x2 px space for better alignment
                        excelImage.From.ColumnOff = Pixel2MTU(2);
                        excelImage.From.RowOff = Pixel2MTU(8);
                    }

                    oSheet.Cells[startRowIndex, 2].Value = row.Cells["MaSanPham"].Value.ToString();
                    oSheet.Cells[startRowIndex, 3].Value = row.Cells["MauSac"].Value.ToString();
                    oSheet.Cells[startRowIndex, 5].Value = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString());
                    if (rdGiaLe.Checked)
                    {
                        oSheet.Cells[startRowIndex, 6].Value = Int32.Parse(row.Cells["GiaLe"].Value.ToString());
                    }
                    else
                    {
                        oSheet.Cells[startRowIndex, 6].Value = Int32.Parse(row.Cells["GiaSi"].Value.ToString());
                    }

                    startRowIndex++;
                }

                excelPkg.Save();
                //MessageBox.Show("Xuất Excel Thành Công");
                System.Diagnostics.Process.Start(exportFilePath);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int Pixel2MTU(int pixels)
        {
            int mtus = pixels * 9525;
            return mtus;
        }

        private void cbmTrangThai_Them_SelectedIndexChanged(object sender, EventArgs e)
        {
            _changed = true;
        }

        private void frmQuanLyDonHang_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changed == true)
            {
                DialogResult result = MessageBox.Show("Đơn hàng chưa được lưu. Vui lòng lưu lại trước khi đóng phần mềm",
                    "Question",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                    if (_maDH == 0)
                    {
                        ThemDonHang();
                    }
                    else
                    {
                        CapNhatDonHang();
                    }
                }
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnNhapDonHang_Click(object sender, EventArgs e)
        {
            try
            {
                dt.Clear();
                btnTransport.Enabled = false;
                btnTaoDonHang.Enabled = false;
                frmNhapDonHangTuWeb frm = new frmNhapDonHangTuWeb();
                timer1.Start();
                frm.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void createDataAfterReadFromWeb()
        {
            try
            {
                _changedByWeb = true;
                dtgvDanhSachSanPham.DataSource = dt;
                dtgvDanhSachSanPham.Visible = true;

                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                imageCol.Name = "img";
                imageCol.HeaderText = "Hinh Anh";
                imageCol.Width = _colWidth;
                dtgvDanhSachSanPham.Columns.Insert(1, imageCol);

                DataGridViewComboBoxColumn soLuongCol = new DataGridViewComboBoxColumn();
                soLuongCol.Name = "CmbSoLuong";
                soLuongCol.HeaderText = "SoLuong";
                soLuongCol.ValueType = typeof(int);
                dtgvDanhSachSanPham.Columns.Insert(dtgvDanhSachSanPham.Columns["SoLuong"].Index + 1, soLuongCol);

                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
                btnColumn.HeaderText = "";
                btnColumn.Text = "Xóa";
                btnColumn.UseColumnTextForButtonValue = true;
                dtgvDanhSachSanPham.Columns.Add(btnColumn);

                groupBox4.Visible = true;
                groupBox5.Visible = true;
                groupBox8.Visible = true;

                btnTaoDonHang.Enabled = false;
                formatDataWeb();
                _changedByWeb = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_readFromWebDone)
            {
                timer1.Stop();
                createDataAfterReadFromWeb();
                btnNhapDonHang.Enabled = false;
            }
        }

        private void chbxSuDungDTL_CheckedChanged(object sender, EventArgs e)
        {
            txtDiemTichLuyUsed.Enabled = chbxSuDungDTL.Checked;
            btnDungDiemTichLuy.Enabled = chbxSuDungDTL.Checked;
        }

        private void btnDungDiemTichLuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (Int32.Parse(txtDiemTichLuyUsed.Text.ToString()) > khDto.DiemTichLuy)
                {
                    MessageBox.Show("Điểm tích lũy sử dụng lớn hơn điểm tích lũy đang có");
                    return;
                }
                if (Int32.Parse(txtDiemTichLuyUsed.Text.ToString()) > dhDto.TongTien)
                {
                    MessageBox.Show("Điểm tích lũy sử dụng lớn hơn giá trị đơn hàng");
                    return;
                }
                if (_changed == true)
                {
                    MessageBox.Show("Đơn hàng chưa được lưu. Vui lòng lưu lại đơn hàng trước khi sử dụng điểm tích lũy");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc muốn dùng điểm tích lũy cho đơn hàng này không?",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dhDto.TongTien = dhDto.TongTien - Int32.Parse(txtDiemTichLuyUsed.Text.ToString());
                    dhDto.DiemTichLuySuDung += Int32.Parse(txtDiemTichLuyUsed.Text.ToString());
                    DonHangBUS dhBus = new DonHangBUS();
                    dhBus.Update(dhDto);
                    lbTongTien.Text = dhDto.TongTien.ToString("n0");

                    khDto.DiemTichLuy = khDto.DiemTichLuy - Int32.Parse(txtDiemTichLuyUsed.Text.ToString());
                    KhachHangBUS khBus = new KhachHangBUS();
                    khBus.Update(khDto);

                    lbTongDiemTichLuy.Text = khDto.DiemTichLuy.ToString("n0");
                    txtDiemTichLuyUsed.Text = "0";
                    lbDiemTichLuyUsed.Text = dhDto.DiemTichLuySuDung.ToString("n0");

                    MessageBox.Show("Điểm tích lũy đã được sử dụng thành công");

                    btnHuyDiemTichLuy.Enabled = true;
                    
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDiemTichLuyUsed_TextChanged(object sender, EventArgs e)
        {
            //_changed = true;
        }

        private void btnHuyDiemTichLuy_Click(object sender, EventArgs e)
        {
            try
            {
                if (_changed == true)
                {
                    MessageBox.Show("Đơn hàng chưa được lưu. Vui lòng lưu lại đơn hàng trước khi hủy sử dụng điểm tích lũy");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc muốn hủy điểm tích lũy của đơn hàng này không?",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    dhDto.TongTien += dhDto.DiemTichLuySuDung;
                    khDto.DiemTichLuy += dhDto.DiemTichLuySuDung;
                    dhDto.DiemTichLuySuDung = 0;

                    DonHangBUS dhBus = new DonHangBUS();
                    dhBus.Update(dhDto);

                    KhachHangBUS khBus = new KhachHangBUS();
                    khBus.Update(khDto);

                    lbDiemTichLuyUsed.Text = "0";
                    lbTongDiemTichLuy.Text = khDto.DiemTichLuy.ToString("n0");
                    lbTongTien.Text = dhDto.TongTien.ToString("n0");

                    MessageBox.Show("Hủy sử dụng điểm tích lũy thành công");

                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvTimKiemDonHang_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                dtgvTimKiemDonHang.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
        }

        private void dtgvTimKiemDonHang_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex % 2 == 1)
                    dtgvTimKiemDonHang.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PowderBlue;
                else
                    dtgvTimKiemDonHang.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        public void updateWebInventor(Object threadContext)
        {
            inventor iv = (inventor)threadContext;
            Inventory myInventoryUpdate = new Inventory();
            myInventoryUpdate.sku = iv.masp;
            myInventoryUpdate.qty = iv.soluong.ToString() + ".0000";
            myInventoryUpdate.is_in_stock = iv.trangthai.ToString();
            bool wasUpdated = Helper.APIUpdateInventor(myInventoryUpdate);
        }

        public void startThread(string masp, int soluong, int trangthai)
        {
            if (Main2._cfgDto.UseAPISycn)
            {
                inventor iv = new inventor();
                iv.masp = masp;
                iv.soluong = soluong;
                iv.trangthai = trangthai;

                ThreadPool.QueueUserWorkItem(updateWebInventor, iv);
            }
        }
    }
}
