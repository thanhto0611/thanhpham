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

namespace Presentation
{
    public partial class frmChiTietDonHangNew2 : Form
    {
        DataTable dt = new DataTable();

        private int _imageSize = 100;
        private int _rowHeight = 110;
        private int _colWidth = 110;
        private bool fromFormat = false;
        private int _gSL = 0;
        private string _gMaSP;
        public static int gMaDH;
        public bool _firstLoad = true;
        private int _curTrangThai;
        private int _maDH = frmQuanLyDonHang.gMaDH;
        private bool _fromTxtMaSpTextChange = false;
        private bool _changed = false;

        DonHangDTO dhDto = new DonHangDTO();

        public frmChiTietDonHangNew2()
        {
            InitializeComponent();
        }

        private void frmChiTietDonHangNew2_Load(object sender, EventArgs e)
        {
            int maDH = frmQuanLyDonHang.gMaDH;

            KhachHangBUS khBus = new KhachHangBUS();
            KhachHangDTO khDto = new KhachHangDTO();

            DonHangBUS dhBus = new DonHangBUS();

            ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();

            khDto = khBus.LayThongTinKhachHangTuMaDonHang(maDH);
            dhDto = dhBus.LayBangMaDonHang(maDH);
            _curTrangThai = dhDto.TrangThai;

            cbmTrangThai_Them.DataSource = TrangThaiDonHangBUS.GetList();
            cbmTrangThai_Them.DisplayMember = "TrangThai";
            cbmTrangThai_Them.ValueMember = "MaTrangThai";
            cbmTrangThai_Them.SelectedValue = dhDto.TrangThai;

            txtMaKH_Them.Text = khDto.MaKhachHang.ToString();
            txtTenKH_Them.Text = khDto.HoTen;
            txtDiaChi_Them.Text = khDto.DiaChi;
            txtDienThoai_Them.Text = khDto.DienThoai;
            txtEmail_Them.Text = khDto.Email;
            txtFacebook_Them.Text = khDto.Facebook;
            txtTKNganHang_Them.Text = khDto.TKNganHang;

            lbSoLuong.Text = dhDto.SoLuongSanPham.ToString();
            lbTongTien.Text = dhDto.TongTien.ToString("n0");
            txtPhiVanChuyen_Them.Text = dhDto.PhiVanChuyen.ToString();

            if (dhDto.HinhThucMua == 0)
            {
                rdGiaSi.Checked = true;
                rdGiaLe.Checked = false;
            }
            else
            {
                rdGiaLe.Checked = true;
                rdGiaSi.Checked = false;
            }

            dt = ctdhBus.LayDanhSachSanPham(maDH);
            dtgvDanhSachSanPham.DataSource = dt;

            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Name = "img";
            imageCol.HeaderText = "Hinh Anh";
            imageCol.Width = _colWidth;
            dtgvDanhSachSanPham.Columns.Insert(2, imageCol);

            DataGridViewComboBoxColumn soLuongCol = new DataGridViewComboBoxColumn();
            soLuongCol.Name = "CmbSoLuong";
            soLuongCol.HeaderText = "SoLuong";
            soLuongCol.ValueType = typeof(int);
            dtgvDanhSachSanPham.Columns.Insert(dtgvDanhSachSanPham.Columns["SoLuongDatMua"].Index + 1, soLuongCol);

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "Xoa";
            btnColumn.HeaderText = "";
            btnColumn.Text = "Xóa";
            btnColumn.UseColumnTextForButtonValue = true;
            dtgvDanhSachSanPham.Columns.Add(btnColumn);
            dtgvDanhSachSanPham.Visible = true;
            formatData();
            lbMaDonHang.Text = maDH.ToString();
            //_firstLoad = false;
        }

        public void formatData()
        {
            try
            {
                //dtgvDanhSachSanPham.Refresh();
                this.dtgvDanhSachSanPham.Columns["HinhAnh"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["MaChiTietDonHang"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["TrangThai"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["SoLuongDatMua"].Visible = false;

                this.dtgvDanhSachSanPham.Columns["GiaSi"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaLe"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "#,0";

                this.dtgvDanhSachSanPham.Columns["MaSanPham"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaLe"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaSi"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaBan"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["TrangThai"].ReadOnly = true;

                int tongTien = 0;
                int soLuong = 0;

                //DonHangDTO dhDto = new DonHangDTO();
                //DonHangBUS dhBus = new DonHangBUS();
                //dhDto = dhBus.LayBangMaDonHang(_maDH);

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

                    //if (Int32.Parse(row.Cells["SoLuongTrongKho"].Value.ToString()) <= 0 && _firstLoad == false)
                    //{
                    //    row.DefaultCellStyle.BackColor = Color.Yellow;
                    //    //row.Cells["MauSac"].ReadOnly = true;
                    //}

                    //int sl;
                    //SanPhamDTO spDto = SanPhamBUS.LaySanPham(row.Cells["MaSanPham"].Value.ToString());

                    if (_fromTxtMaSpTextChange == true)
                    {
                        SanPhamDTO spDto = SanPhamBUS.LaySanPham(row.Cells["MaSanPham"].Value.ToString());
                        if (spDto.TrangThai == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                        _fromTxtMaSpTextChange = false;
                    }
                    else
                    {
                        if (row.Cells["TrangThai"].Value.ToString() == "0")
                        {
                            row.DefaultCellStyle.BackColor = Color.Yellow;
                        }
                    }
                    

                    //ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                    //ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(_maDH, row.Cells["MaSanPham"].Value.ToString());

                    //if ((dhDto.TrangThai == 2 || dhDto.TrangThai == 5) && ctdhDto.MaChiTietDonHang != 0)
                    //{
                    //    //sl = Int32.Parse(row.Cells["SoLuongDatMua"].Value.ToString()) + spDto.SoLuong;
                    //    sl = ctdhDto.SoLuong + spDto.SoLuong;
                    //}
                    //else
                    //{
                    //    sl = spDto.SoLuong;
                    //}

                    //sl = ctdhDto.SoLuong + spDto.SoLuong;

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

                        if (_firstLoad == true)
                        {
                            ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                            ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(_maDH, row.Cells["MaSanPham"].Value.ToString());
                            row.Cells["CmbSoLuong"].Value = ctdhDto.SoLuong;
                        }
                        else
                        {
                            row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[1];
                        }
                    }

                    //if (_firstLoad == true)
                    //{
                    //    row.Cells["CmbSoLuong"].Value = Int32.Parse(row.Cells["SoLuongDatMua"].Value.ToString());
                    //}
                    //else
                    //{
                    //    if (_gMaSP == row.Cells["MaSanPham"].Value.ToString())
                    //    {
                    //        row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[_gSL - 1];
                    //    }
                    //}

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

        private void txtMaSanPham_Them_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _gSL = 0;
                _gMaSP = "";

                SanPhamBUS sb = new SanPhamBUS();
                ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                DataTable dt1 = sb.LayBangMaSanPham_ChiTietDonHang(txtMaSanPham_Them.Text);
                
                if (dt1.Rows.Count == 1)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = dt1.Rows[0].ItemArray.Clone() as object[];

                    for (int i = 0; i < dtgvDanhSachSanPham.Rows.Count; i++)
                    {
                        if (dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString() == dr.ItemArray.GetValue(1).ToString())
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
                                    if (_gSL > Int32.Parse(dr.ItemArray.GetValue(5).ToString()))
                                    {
                                        MessageBox.Show("Số lượng sản phẩm  '" + dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + dr.ItemArray.GetValue(5).ToString());
                                        return;
                                    }
                                    _gMaSP = dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString();
                                    dt.Rows.RemoveAt(i);
                                    break;
                                }
                            }
                            else
                            {
                                if (_gSL > Int32.Parse(dr.ItemArray.GetValue(5).ToString()))
                                {
                                    MessageBox.Show("Số lượng sản phẩm  '" + dtgvDanhSachSanPham.Rows[i].Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + dr.ItemArray.GetValue(5).ToString());
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

                    _fromTxtMaSpTextChange = true;
                    formatData();
                    _changed = true;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPhiVanChuyen_Them_TextChanged(object sender, EventArgs e)
        {
            if (_firstLoad == false)
            {
                formatData();
                _changed = true;
            }
        }

        private void rdGiaLe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaLe.Checked == true)
            {
                rdGiaSi.Checked = false;
                if (_firstLoad == false)
                {
                    formatData();
                    _changed = true;
                }
            }
        }

        private void rdGiaSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaSi.Checked == true)
            {
                rdGiaLe.Checked = false;
                if (_firstLoad == false)
                {
                    formatData();
                    _changed = true;
                }
            }
        }

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

                //if ((_curTrangThai == 2 || _curTrangThai == 5) && (newTrangThai == 2 || newTrangThai == 5))
                //{
                //    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                //    {
                //        ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(_maDH, row.Cells["MaSanPham"].Value.ToString());
                //        if (ctdhDto.MaChiTietDonHang != 0) // Sản phẩm đã có trong đơn hàng
                //        {
                //            if (Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) > ctdhDto.SoLuong)
                //            {
                //                int soLgDatThem = Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()) - ctdhDto.SoLuong;
                //                int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), soLgDatThem);
                //                if (kq > -1)
                //                {
                //                    MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt thêm lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng đặt thêm là: " + soLgDatThem.ToString() + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                //                    dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = row.Index;
                //                    return;
                //                }
                //            }
                //        }
                //        else // Sản phẩm chưa có trong đơn hàng
                //        {
                //            int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                //            if (kq > -1)
                //            {
                //                MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                //                dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = row.Index;
                //                return;
                //            }
                //        }
                //    }
                //}

                //if ((_curTrangThai == 1 || _curTrangThai == 3 || _curTrangThai == 4) && (newTrangThai == 2 || newTrangThai == 5))
                //{
                //    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
                //    {
                //        int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                //        if (kq > -1)
                //        {
                //            MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                //            dtgvDanhSachSanPham.FirstDisplayedScrollingRowIndex = row.Index;
                //            return;
                //        }
                //    }
                //}

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
                        }
                    }
                }

                MessageBox.Show("Đơn hàng đã được cập nhật thành công");
                btnCapNhat.Visible = true;
                _curTrangThai = dhDto.TrangThai;
                _changed = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        private void dtgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //lbSoLuong.Text = e.ColumnIndex.ToString();
                if (e.ColumnIndex == dtgvDanhSachSanPham.Columns["Xoa"].Index && e.RowIndex >= 0)
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
                    formatData();
                    _changed = true;
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
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
                    dtgvDanhSachSanPham.CurrentCell.Value = ((ComboBox)sender).SelectedItem;
                    formatData();
                    _changed = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
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
            if (_firstLoad == false)
            {
                _changed = true;
            }
        }

        private void dtgvDanhSachSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_firstLoad == false)
            {
                _changed = true;
            }
        }

        private void dtgvDanhSachSanPham_DataSourceChanged(object sender, EventArgs e)
        {
            if (_firstLoad == false)
            {
                _changed = true;
            }
        }

        private void frmChiTietDonHangNew2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changed == true)
            {
                DialogResult result = MessageBox.Show("Đơn hàng chưa được lưu. Vui lòng lưu lại trước khi đóng phần mềm",
                    "Cảnh báo",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    e.Cancel = true;
                    CapNhatDonHang();
                }
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
