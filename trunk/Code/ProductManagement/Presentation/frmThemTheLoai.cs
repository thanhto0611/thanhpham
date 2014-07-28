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
    public partial class frmThemTheLoai : Form
    {
        public frmThemTheLoai()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtThemTenLoaiSach.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Thể Loại!", "Cảnh báo!");
            }
            else
            {
                TheLoaiDTO theLoai = new TheLoaiDTO();
                theLoai.TenTheLoai = txtThemTenLoaiSach.Text;
                TheLoaiBUS.Insert(theLoai);
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