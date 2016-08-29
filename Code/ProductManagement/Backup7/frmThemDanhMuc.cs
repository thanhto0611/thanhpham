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
    public partial class frmThemDanhMuc : Form
    {
        public frmThemDanhMuc()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDanhMuc.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Danh Mục!", "Cảnh báo!");
            }
            else
            {
                DanhMucDTO danhMuc = new DanhMucDTO();
                danhMuc.TenDanhMuc = txtTenDanhMuc.Text;
                DanhMucBUS.Insert(danhMuc);
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                this.Refresh();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
