using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;

namespace Presentation
{
    public partial class frmQuanLyKhachHang : Form
    {
        public frmQuanLyKhachHang()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtHoTen_Them.Text == "" && txtDienThoai_Them.Text == "" && txtEmail_Them.Text == "" && txtFacebook_Them.Text == "")
                {
                    MessageBox.Show("Bạn phải nhập một trong những thông tin sau: 'Họ tên' hoặc 'Điện thoại' hoặc 'Email' hoặc 'Facebook'");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn thêm mới khách hàng này không",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    KhachHangBUS khachhangBUS = new KhachHangBUS();
                    KhachHangDTO khachhangDTO = new KhachHangDTO();
                    khachhangDTO.HoTen = txtHoTen_Them.Text;
                    khachhangDTO.DiaChi = txtDiaChi_Them.Text;
                    khachhangDTO.DienThoai = txtDienThoai_Them.Text;
                    khachhangDTO.Email = txtEmail_Them.Text;
                    khachhangDTO.Facebook = txtFacebook_Them.Text;
                    khachhangDTO.TKNganHang = txtTKNganHang_Them.Text;
                    khachhangDTO.NgayThem = System.DateTime.Now;
                    khachhangDTO.NguoiThem = frmDangNhap.gUserName;

                    KhachHangBUS.Insert(khachhangDTO);
                    MessageBox.Show("Thêm khách hàng thành công!");
                }
                else
                {
                    return;
                }

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void dtgvTimKiemKhachHang_DataSourceChanged(object sender, EventArgs e)
        {
            dtgvTimKiemKhachHang.Columns["MaKhachHang"].Visible = false;
            dtgvTimKiemKhachHang.Columns["NgayThem"].ReadOnly = true;
            dtgvTimKiemKhachHang.Columns["NguoiThem"].ReadOnly = true;
            dtgvTimKiemKhachHang.Columns["NgayCapNhat"].ReadOnly = true;
            dtgvTimKiemKhachHang.Columns["NguoiCapNhat"].ReadOnly = true;

            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.HeaderText = "Edit";
            btnColumn.Text = "Edit";
            btnColumn.UseColumnTextForButtonValue = true;
            dtgvTimKiemKhachHang.Columns.Add(btnColumn);

        }

        private void txtData_TextChanged(object sender, EventArgs e)
        {
            TimKiem();
        }

        private void dtgvTimKiemKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvTimKiemKhachHang.Columns.Count - 1)
            {
                try
                {
                    DialogResult result = MessageBox.Show("Bạn có chắc là muốn chỉnh sửa thông tin khách hàng này không",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        KhachHangBUS khBus = new KhachHangBUS();
                        KhachHangDTO khDto = new KhachHangDTO();

                        khDto.MaKhachHang = Int32.Parse(dtgvTimKiemKhachHang.Rows[e.RowIndex].Cells["MaKhachHang"].Value.ToString());
                        khDto.HoTen = dtgvTimKiemKhachHang.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                        khDto.DiaChi = dtgvTimKiemKhachHang.Rows[e.RowIndex].Cells["DiaChi"].Value.ToString();
                        khDto.DienThoai = dtgvTimKiemKhachHang.Rows[e.RowIndex].Cells["DienThoai"].Value.ToString();
                        khDto.Email = dtgvTimKiemKhachHang.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                        khDto.Facebook = dtgvTimKiemKhachHang.Rows[e.RowIndex].Cells["Facebook"].Value.ToString();
                        khDto.TKNganHang = dtgvTimKiemKhachHang.Rows[e.RowIndex].Cells["TKNganHang"].Value.ToString();
                        khDto.NguoiCapNhat = frmDangNhap.gUserName;
                        khDto.NgayCapNhat = System.DateTime.Now;

                        khBus.Update(khDto);

                        MessageBox.Show("Cập nhật thông tin khách hàng thành công");
                        TimKiem();
                    }
                    else
                    {
                        return;
                    }

                }
                catch (System.Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void TimKiem()
        {
            try
            {
                dtgvTimKiemKhachHang.Columns.Clear();
                KhachHangBUS khachhangBUS = new KhachHangBUS();
                DataTable dt = khachhangBUS.TimKiem(txtData.Text);
                dtgvTimKiemKhachHang.DataSource = dt;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThoat_Sua_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgvTimKiemKhachHang_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
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

        private void frmQuanLyKhachHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmQLKH = null;
        }
    }
}
