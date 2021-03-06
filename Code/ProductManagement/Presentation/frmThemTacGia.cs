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
    public partial class frmThemTacGia : Form
    {
        public frmThemTacGia()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenTacGia.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Tác Giả!", "Cảnh báo!");
            }
            else
            {
                TacGiaDTO tacGia = new TacGiaDTO();
                tacGia.TenTG = txtTenTacGia.Text;
                TacGiaBUS.Insert(tacGia);
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                this.Close();
            }
        }

        private void frmThemTacGia_Load(object sender, EventArgs e)
        {

        }

       

       


       
    }
}