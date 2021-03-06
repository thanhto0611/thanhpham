using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

namespace Presentation
{
    public partial class frmThemNgonNgu : Form
    {
        public frmThemNgonNgu()
        {
            InitializeComponent();
        }

        

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtThemTenNgonNgu.Text.Length == 0)
                {
                    MessageBox.Show("Bạn Chưa Nhập Tên Ngôn Ngữ!", "Cảnh báo!");
                }
                else
                {
                    NgonNguDTO ngonNgu = new NgonNguDTO();
                    ngonNgu.TenNgonNgu = txtThemTenNgonNgu.Text;
                    NgonNguBUS.Insert(ngonNgu);
                    MessageBox.Show("Thêm thành công!", "Thông báo!");
                    this.Close();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

    }
}