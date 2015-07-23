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

namespace Presentation
{
    public partial class frmChiTietDonHangNew : Form
    {
        private int _imageSize = 100;
        private int _rowHeight = 110;
        private int _colWidth = 110;
        private bool fromFormat = false;
        private int _gSL = 0;
        private string _gMaSP;
        private int _maDH;
        private int _curTrangThai;
        private bool _firstLoad = true;

        DataTable dt = new DataTable();
        DataTable dtTimKiem = new DataTable();

        public frmChiTietDonHangNew()
        {
            InitializeComponent();
        }

        private void dtgvDanhSachSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void txtMaSanPham_Them_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //dtgvDanhSachSanPham.Columns.Clear();
                _gSL = 0;
                _gMaSP = "";

                SanPhamBUS sb = new SanPhamBUS();
                DataTable dt1 = sb.LayBangMaSanPham(txtMaSanPham_Them.Text);
                
                if (dt1.Rows.Count == 1)
                {
                    DataRow dr = dt.NewRow();
                    dr.ItemArray = dt1.Rows[0].ItemArray.Clone() as object[];

                    for (int i = 0; i < dtgvDanhSachSanPham_ChiTiet.Rows.Count; i++)
                    {
                        if (dtgvDanhSachSanPham_ChiTiet.Rows[i].Cells["MaSanPham"].Value.ToString() == dr.ItemArray.GetValue(0).ToString())
                        {
                            _gSL = Int32.Parse(dtgvDanhSachSanPham_ChiTiet.Rows[i].Cells["CmbSoLuong"].Value.ToString()) + 1;
                            if (_gSL > Int32.Parse(dr.ItemArray.GetValue(4).ToString()))
                            {
                                MessageBox.Show("Số lượng sản phẩm  '" + dtgvDanhSachSanPham_ChiTiet.Rows[i].Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + dr.ItemArray.GetValue(4).ToString());
                                return;
                            }
                            _gMaSP = dtgvDanhSachSanPham_ChiTiet.Rows[i].Cells["MaSanPham"].Value.ToString();
                            dt.Rows.RemoveAt(i);
                            break;
                        }
                    }
                    dt.Rows.InsertAt(dr, 0);
                    dtgvDanhSachSanPham_ChiTiet.DataSource = dt;
                    dtgvDanhSachSanPham_ChiTiet.FirstDisplayedScrollingRowIndex = 0;
                    
                    formatData();
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
                formatData();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rdGiaLe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaLe.Checked == true && _firstLoad == false)
            {
                rdGiaSi.Checked = false;
                dtgvDanhSachSanPham_DataSourceChanged(sender, e);
            }
        }

        private void rdGiaSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaSi.Checked == true && _firstLoad == false)
            {
                rdGiaLe.Checked = false;
                dtgvDanhSachSanPham_DataSourceChanged(sender, e);
            }
        }

        private void dtgvDanhSachSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgvDanhSachSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //lbSoLuong.Text = e.ColumnIndex.ToString();
            if (e.ColumnIndex == 2 && e.RowIndex >= 0)
            {
                try
                {
                    ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
                    ChiTietDonHangDTO ctdhDto = ctdhBus.KiemTraTonTai(_maDH, dtgvDanhSachSanPham_ChiTiet.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString());
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
                            ctdhBus.Delete(ctdhDto.MaChiTietDonHang);
                        }
                    }
                    else
                    {
                        dt.Rows.Remove(dt.Rows[e.RowIndex]);
                    }
                    dtgvDanhSachSanPham_ChiTiet.DataSource = dt;
                    dtgvDanhSachSanPham_DataSourceChanged(sender, e);
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (e.ColumnIndex == dtgvDanhSachSanPham_ChiTiet.Columns["CmbSoLuong"].Index && e.RowIndex >= 0)
            {
                dtgvDanhSachSanPham_ChiTiet.BeginEdit(true);
                ComboBox comboBox = (ComboBox)dtgvDanhSachSanPham_ChiTiet.EditingControl;
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
                this.dtgvDanhSachSanPham_ChiTiet.Columns["HinhAnh"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["TrangThai"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["NgayNhap"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["NgayCapNhat"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["NguoiNhap"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["NguoiCapNhat"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaGoc"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["TrongLuong"].Visible = false;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["SoLuong"].Visible = false;

                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaSi"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaLe"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaGoc"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaBan"].DefaultCellStyle.Format = "#,0";

                //this.dtgvDanhSachSanPham.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
                //this.dtgvDanhSachSanPham.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

                this.dtgvDanhSachSanPham_ChiTiet.Columns["NgayCapNhat"].ReadOnly = true;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["NgayNhap"].ReadOnly = true;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["MaSanPham"].ReadOnly = true;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaLe"].ReadOnly = true;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaSi"].ReadOnly = true;
                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaBan"].ReadOnly = true;

                this.dtgvDanhSachSanPham_ChiTiet.Columns["GiaBan"].HeaderText = "TongTien";

                int tongTien = 0;
                int soLuong = 0;

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
                {
                    row.Height = _rowHeight;

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

                    if (row.Cells["TrangThai"].Value.ToString() == "0" || Int32.Parse(row.Cells["SoLuong"].Value.ToString()) <= 0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                        row.Cells["MauSac"].ReadOnly = true;
                    }

                    int sl = Int32.Parse(row.Cells["SoLuong"].Value.ToString());

                    if (((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Count == 0)
                    {
                        for (int i = 1; i <= sl; i++)
                        {
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Add(i);
                        }
                        if (((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Count == 0)
                        {
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items.Add(0);
                            ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).ReadOnly = true;
                        }
                        row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[0];
                    }

                    if (_gMaSP == row.Cells["MaSanPham"].Value.ToString())
                    {
                        row.Cells["CmbSoLuong"].Value = ((DataGridViewComboBoxCell)row.Cells["CmbSoLuong"]).Items[_gSL - 1];
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


        private void dtgvDanhSachSanPham_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
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

                e.CellStyle.BackColor = this.dtgvDanhSachSanPham_ChiTiet.DefaultCellStyle.BackColor;
            }
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fromFormat == false)
            {
                try
                {
                    dtgvDanhSachSanPham_ChiTiet.CurrentCell.Value = ((ComboBox)sender).SelectedItem;
                    formatData();
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
                if (dtgvDanhSachSanPham_ChiTiet.Rows.Count == 0)
                {
                    MessageBox.Show("Phải chọn ít nhất 1 sản phẩm");
                    return;
                }

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
                {
                    int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                    if (kq > -1)
                    {
                        MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                        dtgvDanhSachSanPham_ChiTiet.FirstDisplayedScrollingRowIndex = row.Index;
                        return;
                    }
                }

                DialogResult result = MessageBox.Show("Bạn có chắc là muốn thêm đơn hàng này không",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    DonHangBUS dhBus = new DonHangBUS();
                    DonHangDTO dhDto = new DonHangDTO();
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

                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
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
                            //spBus.CapNhatKhoHang(ctdhDto.MaSanPham, oldSl - newSl, trangthai);
                        }
                    }

                    MessageBox.Show("Đơn hàng đã được thêm thành công");
                    btnCapNhat.Visible = true;
                    _curTrangThai = dhDto.TrangThai;
                    cbmTrangThai_Them.DataSource = TrangThaiDonHangBUS.GetList();
                    cbmTrangThai_Them.DisplayMember = "TrangThai";
                    cbmTrangThai_Them.ValueMember = "MaTrangThai";
                    cbmTrangThai_Them.SelectedValue = dhDto.TrangThai;
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
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            dtgvDanhSachSanPham_ChiTiet.Columns.Clear();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearForm();
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

        frmShowPicture HoverZoom = new frmShowPicture();

        private void dtgvDanhSachSanPham_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvDanhSachSanPham_ChiTiet.Columns["img"].Index && e.RowIndex >= 0)
            {
                DataGridView dgv_sender = sender as DataGridView;
                DataGridViewCell dgv_MouseOverCell = dgv_sender.Rows[e.RowIndex].Cells[e.ColumnIndex];

                //Get FilePath from dgv_MouseOverCell content

                //Get x, y based on position relative to edge of screen
                //x, y = top left point of HoverZoom form

                string checkImgPath = Directory.GetCurrentDirectory();
                string imgPath = Directory.GetCurrentDirectory();

                checkImgPath = checkImgPath + @"\Hinh\" + dtgvDanhSachSanPham_ChiTiet.Rows[e.RowIndex].Cells["HinhAnh"].Value.ToString();
                if (File.Exists(checkImgPath) == true)
                {
                    imgPath = checkImgPath;
                }
                else
                {
                    imgPath = imgPath + @"\Hinh\NoImage.jpg";
                }

                HoverZoom.LoadPicture(imgPath, dtgvDanhSachSanPham_ChiTiet.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString());
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

                if ((_curTrangThai == 2 || _curTrangThai == 5) && (newTrangThai == 2 || newTrangThai ==5))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
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
                                    MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt thêm lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng đặt thêm là: " + soLgDatThem.ToString() + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                                    dtgvDanhSachSanPham_ChiTiet.FirstDisplayedScrollingRowIndex = row.Index;
                                    return;
                                }
                            }
                        }
                        else // Sản phẩm chưa có trong đơn hàng
                        {
                            int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                            if (kq > -1)
                            {
                                MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                                dtgvDanhSachSanPham_ChiTiet.FirstDisplayedScrollingRowIndex = row.Index;
                                return;
                            }
                        }
                    }
                }

                if ((_curTrangThai == 1 || _curTrangThai == 3 || _curTrangThai == 4) && (newTrangThai == 2 || newTrangThai == 5))
                {
                    foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
                    {
                        int kq = KiemTraConHang(row.Cells["MaSanPham"].Value.ToString(), Int32.Parse(row.Cells["CmbSoLuong"].Value.ToString()));
                        if (kq > -1)
                        {
                            MessageBox.Show("Số lượng sản phẩm  '" + row.Cells["MaSanPham"].Value.ToString() + "'  đặt mua lớn hơn số lượng hàng còn trong kho." + "\n\nSố lượng hàng còn trong kho là: " + kq.ToString());
                            dtgvDanhSachSanPham_ChiTiet.FirstDisplayedScrollingRowIndex = row.Index;
                            return;
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
                    DonHangBUS dhBus = new DonHangBUS();
                    DonHangDTO dhDto = new DonHangDTO();

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
                        foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
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
                        foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
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
                            //spBus.CapNhatKhoHang(ctdhDto.MaSanPham, oldSl - newSl, trangthai);
                        }
                    }

                    if ((_curTrangThai == 2 || _curTrangThai == 5) && (newTrangThai == 1 || newTrangThai == 3 || newTrangThai == 4))
                    {
                        foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
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
                                int sl = ctdhDto.SoLuong;
                                SanPhamDTO spDtoOld = SanPhamBUS.LaySanPham(maSp);
                                int trangThai = 0;
                                if ((sl + spDtoOld.SoLuong) > 0)
                                {
                                    trangThai = 1;
                                }
                                SanPhamBUS spBus = new SanPhamBUS();
                                //spBus.CapNhatKhoHang(maSp, sl + spDtoOld.SoLuong, trangThai);
                            }
                            else
                            {
                                ctdhBus.Insert(ctdhDto);
                            }
                        }
                    }

                    if ((_curTrangThai == 2 || _curTrangThai == 5) && (newTrangThai == 2 || newTrangThai == 5))
                    {
                        foreach (DataGridViewRow row in this.dtgvDanhSachSanPham_ChiTiet.Rows)
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

                                //spBus.CapNhatKhoHang(maSp, spDtoOld.SoLuong - diffSoLuong, trangThai);
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

                                //spBus.CapNhatKhoHang(maSp, spDtoOld.SoLuong - ctdhDto.SoLuong, trangThai);
                            }
                        }
                    }

                    MessageBox.Show("Đơn hàng đã được cập nhật thành công");
                    btnCapNhat.Visible = true;
                    _curTrangThai = dhDto.TrangThai;
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

        private void frmChiTietDonHangNew_Load(object sender, EventArgs e)
        {
            int maDH = frmQuanLyDonHang.gMaDH;

            KhachHangBUS khBus = new KhachHangBUS();
            KhachHangDTO khDto = new KhachHangDTO();

            DonHangBUS dhBus = new DonHangBUS();
            DonHangDTO dhDto = new DonHangDTO();

            ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();

            khDto = khBus.LayThongTinKhachHangTuMaDonHang(maDH);
            dhDto = dhBus.LayBangMaDonHang(maDH);

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
            txtPhiVanChuyen_Them.Text = dhDto.PhiVanChuyen.ToString("n0");

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
            dtgvDanhSachSanPham_ChiTiet.DataSource = dt;

            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Name = "img";
            imageCol.HeaderText = "Hinh Anh";
            imageCol.Width = _colWidth;
            dtgvDanhSachSanPham_ChiTiet.Columns.Insert(2, imageCol);

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "";
            btnColumn.Text = "Xóa";
            btnColumn.UseColumnTextForButtonValue = true;
            dtgvDanhSachSanPham_ChiTiet.Columns.Add(btnColumn);

            formatData();
            _firstLoad = false;
        }
    }
}
