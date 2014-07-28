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
    public partial class frmChiTietDonHang : Form
    {
        DataTable dt = new DataTable();

        private int _imageSize = 100;
        private int _rowHeight = 110;
        private int _colWidth = 110;
        private bool fromFormat = false;
        private int _gSL = 0;
        private string _gMaSP;
        public static int gMaDH;
        private bool _firstLoad = true;

        public frmChiTietDonHang()
        {
            InitializeComponent();
        }

        private void frmChiTietDonHang_Load(object sender, EventArgs e)
        {
            int maDH = frmQuanLyDonHang.gMaDH;

            KhachHangBUS khBus = new KhachHangBUS();
            KhachHangDTO khDto = new KhachHangDTO();

            DonHangBUS dhBus = new DonHangBUS();
            DonHangDTO dhDto = new DonHangDTO();

            ChiTietDonHangBUS ctdhBus = new ChiTietDonHangBUS();
            
            khDto = khBus.LayThongTinKhachHangTuMaDonHang(maDH);
            dhDto = dhBus.LayBangMaDonHang(maDH);

            cbmTrangThai.DataSource = TrangThaiDonHangBUS.GetList();
            cbmTrangThai.DisplayMember = "TrangThai";
            cbmTrangThai.ValueMember = "MaTrangThai";
            cbmTrangThai.SelectedValue = dhDto.TrangThai;

            txtMaKH.Text = khDto.MaKhachHang.ToString();
            txtTenKH.Text = khDto.HoTen;
            txtDiaChi.Text = khDto.DiaChi;
            txtDienThoai.Text = khDto.DienThoai;
            txtEmail.Text = khDto.Email;
            txtFacebook.Text = khDto.Facebook;
            txtTKNganHang.Text = khDto.TKNganHang;

            lbSoLuong.Text = dhDto.SoLuongSanPham.ToString();
            lbTongTien.Text = dhDto.TongTien.ToString("n0");
            txtPhiVanChuyen.Text = dhDto.PhiVanChuyen.ToString("n0");

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

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "";
            btnColumn.Text = "Xóa";
            btnColumn.UseColumnTextForButtonValue = true;
            dtgvDanhSachSanPham.Columns.Add(btnColumn);

            formatData();
            _firstLoad = false;
        }

        private void formatData()
        {
            try
            {
                //dtgvDanhSachSanPham.Refresh();
                this.dtgvDanhSachSanPham.Columns["HinhAnh"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["MaChiTietDonHang"].Visible = false;
                this.dtgvDanhSachSanPham.Columns["SoLuongTrongKho"].Visible = false;

                this.dtgvDanhSachSanPham.Columns["GiaSi"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaLe"].DefaultCellStyle.Format = "#,0";
                this.dtgvDanhSachSanPham.Columns["GiaBan"].DefaultCellStyle.Format = "#,0";

                this.dtgvDanhSachSanPham.Columns["MaSanPham"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaLe"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaSi"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["GiaBan"].ReadOnly = true;
                this.dtgvDanhSachSanPham.Columns["SoLuongTrongKho"].ReadOnly = true;

                int tongTien = 0;
                int soLuong = 0;

                foreach (DataGridViewRow row in this.dtgvDanhSachSanPham.Rows)
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
                    

                    if (rdGiaLe.Checked == true)
                    {
                        fromFormat = true;
                        row.Cells["GiaBan"].Value = Int32.Parse(row.Cells["SoLuongDatMua"].Value.ToString()) * Int32.Parse(row.Cells["GiaLe"].Value.ToString());
                    }
                    else
                    {
                        fromFormat = true;
                        row.Cells["GiaBan"].Value = Int32.Parse(row.Cells["SoLuongDatMua"].Value.ToString()) * Int32.Parse(row.Cells["GiaSi"].Value.ToString());
                    }



                    soLuong += Int32.Parse(row.Cells["SoLuongDatMua"].Value.ToString());
                    tongTien += Int32.Parse(row.Cells["GiaBan"].Value.ToString());
                }

                if (txtPhiVanChuyen.Text != "")
                {
                    tongTien += Int32.Parse(txtPhiVanChuyen.Text.ToString());
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

        private void rdGiaLe_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaLe.Checked == true && _firstLoad == false)
            {
                rdGiaSi.Checked = false;
                formatData();
            }
        }

        private void rdGiaSi_CheckedChanged(object sender, EventArgs e)
        {
            if (rdGiaSi.Checked == true && _firstLoad == false)
            {
                rdGiaLe.Checked = false;
                formatData();
            }
        }

        private void dtgvDanhSachSanPham_Sorted(object sender, EventArgs e)
        {
            formatData();
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
                HoverZoom.Location = new System.Drawing.Point(500, 100);
                HoverZoom.Show();
            }
        }

        private void dtgvDanhSachSanPham_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            HoverZoom.Hide();
            HoverZoom.ClearPicture();
        }
    }
}
