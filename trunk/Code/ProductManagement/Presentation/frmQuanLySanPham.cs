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
    public partial class frmQuanLySanPham : Form
    {
        private int _imageSize = 150;
        private int _rowHeight = 160;
        private int _colWidth = 160;

        public frmQuanLySanPham()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void frmQuanLySanPham_Load(object sender, EventArgs e)
        {
            cmbDanhMuc.DataSource = DanhMucBUS.GetList();
            cmbDanhMuc.DisplayMember = "TenDanhMuc";
            cmbDanhMuc.ValueMember = "MaDanhMuc";

            cmbTrangThai.Text = "Tất cả trạng thái";
        }

        private void btnThemDanhMuc_Click(object sender, EventArgs e)
        {
            frmThemDanhMuc frm = new frmThemDanhMuc();
            frm.ShowDialog();
            this.frmQuanLySanPham_Load(sender, e);
        }

        private void txtMaSanPham_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void TimKiem()
        {
            try
            {
                dtgvSanPham.Columns.Clear();

                if (cmbDanhMuc.Text == "Tất Cả Danh Mục" && cmbTrangThai.Text == "Tất cả trạng thái")
                {
                    SanPhamBUS sb = new SanPhamBUS();
                    DataTable dt = sb.LayBangMaSanPham(txtMaSanPham.Text);
                    if (dt != null)
                        dtgvSanPham.DataSource = dt;
                }
                if (cmbDanhMuc.Text == "Tất Cả Danh Mục" && cmbTrangThai.Text != "Tất cả trạng thái")
                {
                    int trangthai;
                    if (cmbTrangThai.Text == "Còn hàng")
                    {
                        trangthai = 1;
                    }
                    else
                    {
                        trangthai = 0;
                    }
                    SanPhamBUS sb = new SanPhamBUS();
                    DataTable dt = sb.LayBangMaSanPhamTrangThai(txtMaSanPham.Text, trangthai);
                    if (dt != null)
                        dtgvSanPham.DataSource = dt;

                }
                if (cmbDanhMuc.Text != "Tất Cả Danh Mục" && cmbTrangThai.Text == "Tất cả trạng thái")
                {
                    SanPhamBUS sb = new SanPhamBUS();
                    DataTable dt = sb.LayBangMaSanPhamMaDanhMuc(txtMaSanPham.Text, (cmbDanhMuc.SelectedItem as DanhMucDTO).MaDanhMuc);
                    if (dt != null)
                        dtgvSanPham.DataSource = dt;
                }
                if (cmbDanhMuc.Text != "Tất Cả Danh Mục" && cmbTrangThai.Text != "Tất cả trạng thái")
                {
                    int trangthai;
                    if (cmbTrangThai.Text == "Còn hàng")
                    {
                        trangthai = 1;
                    }
                    else
                    {
                        trangthai = 0;
                    }
                    SanPhamBUS sb = new SanPhamBUS();
                    DataTable dt = sb.LayBangMaSanPhamMaDanhMucTrangThai(txtMaSanPham.Text, (cmbDanhMuc.SelectedItem as DanhMucDTO).MaDanhMuc, trangthai);
                    if (dt != null)
                        dtgvSanPham.DataSource = dt;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtgvSanPham_DataSourceChanged(object sender, EventArgs e)
        {
            dtgvSanPham.Refresh();
            this.dtgvSanPham.Columns["HinhAnh"].Visible = false;
            this.dtgvSanPham.Columns["TrangThai"].Visible = false;
            this.dtgvSanPham.Columns["GiaBan"].Visible = false;

            this.dtgvSanPham.Columns["GiaSi"].DefaultCellStyle.Format = "#,0";
            this.dtgvSanPham.Columns["GiaLe"].DefaultCellStyle.Format = "#,0";
            this.dtgvSanPham.Columns["GiaGoc"].DefaultCellStyle.Format = "#,0";

            this.dtgvSanPham.Columns["NgayNhap"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            this.dtgvSanPham.Columns["NgayCapNhat"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            this.dtgvSanPham.Columns["NgayCapNhat"].ReadOnly = true;
            this.dtgvSanPham.Columns["NgayNhap"].ReadOnly = true;
            this.dtgvSanPham.Columns["MaSanPham"].ReadOnly = true;
            this.dtgvSanPham.Columns["NguoiNhap"].ReadOnly = true;
            this.dtgvSanPham.Columns["NguoiCapNhat"].ReadOnly = true;


            //DataGridViewCheckBoxColumn CBColumn = new DataGridViewCheckBoxColumn();
            //CBColumn.HeaderText = "Chọn";
            //CBColumn.FalseValue = "0";
            //CBColumn.TrueValue = "1";
            //dtgvSanPham.Columns.Insert(0, CBColumn);

            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Name = "img";
            imageCol.HeaderText = "Hinh Anh";
            imageCol.Width = _colWidth;
            dtgvSanPham.Columns.Insert(2, imageCol);


            foreach (DataGridViewRow row in this.dtgvSanPham.Rows)
            {
                row.Height = _rowHeight;

                string checkImgPath = Directory.GetCurrentDirectory();
                string imgPath = Directory.GetCurrentDirectory();
                //if (row.Cells["HinhAnh"].Value.ToString() != "")
                //{
                    
                //}
                //else
                //{
                //    imgPath = imgPath + @"\Hinh\NoImage.jpg";
                //}
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
                    //row.DefaultCellStyle.Font = new Font("Tahoma", 8, FontStyle.Bold);
                }
            }
        }

        private void btnCapNhatSanPham_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn cập nhật thông tin sản phẩm không?",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                SanPhamBUS spBus = new SanPhamBUS();
                foreach (DataGridViewRow row in this.dtgvSanPham.Rows)
                {
                    SanPhamDTO sp = new SanPhamDTO();
                    sp.MaSanPham = row.Cells["MaSanPham"].Value.ToString();
                    sp.MauSac = row.Cells["MauSac"].Value.ToString();
                    sp.TrongLuong = Int32.Parse(row.Cells["TrongLuong"].Value.ToString());
                    sp.SoLuong = Int32.Parse(row.Cells["SoLuong"].Value.ToString());
                    if (sp.SoLuong > 0)
                    {
                        sp.TrangThai = 1;
                    } 
                    else
                    {
                        sp.TrangThai = 0;
                    }
                    //sp.TrangThai = Int32.Parse(row.Cells["TrangThai"].Value.ToString());
                    sp.GiaGoc = long.Parse(row.Cells["GiaGoc"].Value.ToString());
                    sp.GiaSi = long.Parse(row.Cells["GiaSi"].Value.ToString());
                    sp.GiaLe = long.Parse(row.Cells["GiaLe"].Value.ToString());
                    sp.NgayCapNhat = System.DateTime.Now;
                    sp.NguoiCapNhat = frmDangNhap.gUserName;

                    spBus.Update(sp);
                }
                MessageBox.Show("Cập nhật thành công!", "Thông báo!");
                TimKiem();
            }
        }

        

        private void btnThemSanPham_Click(object sender, EventArgs e)
        {
            frmThemSanPham frm = new frmThemSanPham();
            frm.MdiParent = this.MdiParent;
            frm.Dock = DockStyle.Fill;
            frm.Show();
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void dtgvSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtMaSanPham_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TimKiem();
            }
        }

        frmShowPicture HoverZoom = new frmShowPicture();

        private void dtgvSanPham_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvSanPham.Columns["img"].Index && e.RowIndex >= 0)
            {
                DataGridView dgv_sender = sender as DataGridView;
                DataGridViewCell dgv_MouseOverCell = dgv_sender.Rows[e.RowIndex].Cells[e.ColumnIndex];

                //Get FilePath from dgv_MouseOverCell content

                //Get x, y based on position relative to edge of screen
                //x, y = top left point of HoverZoom form

                string checkImgPath = Directory.GetCurrentDirectory();
                string imgPath = Directory.GetCurrentDirectory();

                checkImgPath = checkImgPath + @"\Hinh\" + dtgvSanPham.Rows[e.RowIndex].Cells["HinhAnh"].Value.ToString();
                if (File.Exists(checkImgPath) == true)
                {
                    imgPath = checkImgPath;
                }
                else
                {
                    imgPath = imgPath + @"\Hinh\NoImage.jpg";
                }

                HoverZoom.LoadPicture(imgPath, dtgvSanPham.Rows[e.RowIndex].Cells["MaSanPham"].Value.ToString());
                HoverZoom.Location = new System.Drawing.Point(500, 100);
                HoverZoom.Show();
            }
        }

        private void dtgvSanPham_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            HoverZoom.Hide();
            HoverZoom.ClearPicture();
        }

        private void dtgvSanPham_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void frmQuanLySanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmQLSP = null;
        }
    }
}
