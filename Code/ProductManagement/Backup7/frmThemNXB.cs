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
    public partial class frmThemNXB : Form
    {
        public frmThemNXB()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtThemTenNXB.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Nhà Xuất Bản!", "Cảnh báo!");
            }
            else
            {
                NhaXuatBanDTO NXB = new NhaXuatBanDTO();
                NXB.TenNXB = txtThemTenNXB.Text;
                NhaXuatBanBUS.Insert(NXB);
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                this.Close();
            }
        }

        private void btnThoatThem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       
    }
}