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
    public partial class frmCapNhatSach : Form
    {
        public frmCapNhatSach()
        {
            InitializeComponent();
        }

        private void frmCapNhatSach_Load(object sender, EventArgs e)
        {
            try
            {
                cmbTenTG.DataSource = TacGiaBUS.GetList();
                cmbTenTG.DisplayMember = "TenTG";
                cmbTenTG.ValueMember = "MaTG";

                cmbNhaXuatBan.DataSource = NhaXuatBanBUS.GetList();
                cmbNhaXuatBan.DisplayMember = "TenNXB";
                cmbNhaXuatBan.ValueMember = "MaNXB";

                cmbLoaiSach.DataSource = TheLoaiBUS.GetList();
                cmbLoaiSach.DisplayMember = "TenTheLoai";
                cmbLoaiSach.ValueMember = "MaLoai";

                cmbNgonNgu.DataSource = NgonNguBUS.GetList();
                cmbNgonNgu.DisplayMember = "TenNgonNgu";
                cmbNgonNgu.ValueMember = "MaNgonNgu";

                int maSach = TimKiemSach.MaSach;
                SachBUS sachBUS = new SachBUS();
                SachDTO sachDTO = null;
                sachDTO = sachBUS.Search_MaSach(maSach);
                tbxTenSach.Text = sachDTO.TenSach;
                txtSoTrang.Text = sachDTO.SoTrang.ToString();

                TacGiaBUS tacgiaBUS = new TacGiaBUS();
                TacGiaDTO tacgiaDTO = null;
                tacgiaDTO = tacgiaBUS.LayTenTacGia(sachDTO.MaTacGia);
                cmbTenTG.Text = tacgiaDTO.TenTG;

                NhaXuatBanBUS nxbBUS = new NhaXuatBanBUS();
                NhaXuatBanDTO nxbDTO = null;
                nxbDTO = nxbBUS.LayTenNhaXuatBan(sachDTO.MaNXB);
                cmbNhaXuatBan.Text = nxbDTO.TenNXB;

                NgonNguBUS nnBUS = new NgonNguBUS();
                NgonNguDTO nnDTO = null;
                nnDTO = nnBUS.LayTenNgonNgu(sachDTO.MaNgonNgu);
                cmbNgonNgu.Text = nnDTO.TenNgonNgu;

                TheLoaiBUS tlBUS = new TheLoaiBUS();
                TheLoaiDTO tlDTO = null;
                tlDTO = tlBUS.LayTenTheLoai(sachDTO.MaTheLoai);
                cmbLoaiSach.Text = tlDTO.TenTheLoai;

                
                if (sachDTO.TrangThai==0)
                {
                    cmbTinhTrang.Text = "Chưa mượn";
                }
                else
                {
                    cmbTinhTrang.Text = "Đã mượn";
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

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            frmThemTacGia frm = new frmThemTacGia();
            frm.ShowDialog();
            this.frmCapNhatSach_Load(sender, e);
        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            frmQuanLyNXB frm = new frmQuanLyNXB();
            frm.ShowDialog();
            this.frmCapNhatSach_Load(sender, e);
        }

        private void btnThemLoaiSach_Click(object sender, EventArgs e)
        {
            frmThemTheLoaiSach frm = new frmThemTheLoaiSach();
            frm.ShowDialog();
            this.frmCapNhatSach_Load(sender, e);
        }

        private void btnThemNgonNgu_Click(object sender, EventArgs e)
        {
            frmThemNgonNgu frm = new frmThemNgonNgu();
            frm.ShowDialog();
            this.frmCapNhatSach_Load(sender, e);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn thực hiện tác vụ này không",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int matg;
                    int manxb;
                    int maloai;
                    int mann;
                    matg = (cmbTenTG.SelectedItem as TacGiaDTO).MaTG;
                    manxb = (cmbNhaXuatBan.SelectedItem as NhaXuatBanDTO).MaNXB;
                    maloai = (cmbLoaiSach.SelectedItem as TheLoaiDTO).MaLoai;
                    mann = (cmbNgonNgu.SelectedItem as NgonNguDTO).MaNgonNgu;

                    SachDTO sachDTO = new SachDTO();
                    sachDTO.TenSach = tbxTenSach.Text;
                    sachDTO.MaNgonNgu = mann;
                    sachDTO.MaNXB = manxb;
                    sachDTO.MaTacGia = matg;
                    sachDTO.MaTheLoai = maloai;
                    sachDTO.MaSach = TimKiemSach.MaSach;
                    sachDTO.SoTrang = int.Parse(txtSoTrang.Text);
                    if (cmbTinhTrang.SelectedItem == "Đã mượn")
                    {
                        sachDTO.TrangThai = 1;
                    }
                    else
                    {
                        sachDTO.TrangThai = 0;
                    }
                    SachBUS sachBUS = new SachBUS();
                    sachBUS.Update(sachDTO);
                    MessageBox.Show("Cập nhật thành công");
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc là muốn thực hiện tác vụ này không",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
            if (result == DialogResult.Yes)
            {
                SachBUS sachBUS = new SachBUS();
                sachBUS.Delete(TimKiemSach.MaSach);
                MessageBox.Show("Dữ liệu được xóa thành công");
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}