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
    public partial class frmThemTheLoaiSach : Form
    {
        public frmThemTheLoaiSach()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenTheLoai.Text.Length == 0)
            {
                MessageBox.Show("Bạn Chưa Nhập Tên Thể Loại!", "Cảnh báo!");
            }
            else
            {
                TheLoaiDTO theloaiDTO = new TheLoaiDTO();
                TheLoaiBUS theloaiBUS = new TheLoaiBUS();
                theloaiDTO.TenTheLoai = txtTenTheLoai.Text;
                TheLoaiBUS.Insert(theloaiDTO);
                MessageBox.Show("Thêm thành công!", "Thông báo!");
                this.Close();
            }
        }
    }
}