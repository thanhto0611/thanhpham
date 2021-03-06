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
    public partial class frmThemDocGia : Form
    {
        public frmThemDocGia()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                
                    if (txtHoTen.Text == "")
                    {
                        MessageBox.Show("Chưa nhập họ tên độc giả");
                        return;
                    }
                    if (txtDiaChi.Text == "")
                    {
                        MessageBox.Show("Chưa nhập địa chỉ của độc giả");
                        return;
                    }
                    if (txtDienThoai.Text == "")
                    {
                        MessageBox.Show("Chưa nhập số điên thoại của độc giả");
                        return;
                    }
                    DialogResult result = MessageBox.Show("Bạn có chắc là muốn thực hiện tác vụ này không",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                    if (result == DialogResult.Yes)
                    {
                        DocGiaBUS docgiaBUS = new DocGiaBUS();
                        DocGiaDTO docgiaDTO = new DocGiaDTO();
                        docgiaDTO.HoTen = txtHoTen.Text;
                        docgiaDTO.DiaChi = txtDiaChi.Text;
                        docgiaDTO.DienThoai = txtDienThoai.Text;
                        if (docgiaDTO.DiaChi != "" && docgiaDTO.DienThoai != "" && docgiaDTO.HoTen != "")
                        {
                            DocGiaBUS.Insert(docgiaDTO);
                            MessageBox.Show("Bạn đã thêm vào thành công!");
                        }
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
            Close();
        }
    }
}