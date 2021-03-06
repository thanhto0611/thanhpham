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
    public partial class frmSuaDocGia : Form
    {
        public frmSuaDocGia()
        {
            InitializeComponent();
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
                    DocGiaDTO DOCGIADTO = new DocGiaDTO();
                    DocGiaBUS DOCGIABUS = new DocGiaBUS();
                    DOCGIADTO.MaDocGia = Int32.Parse(txtMaDocGiaKQ.Text);
                    DOCGIADTO.HoTen = txtHoTen.Text;
                    DOCGIADTO.DienThoai = txtDienThoai.Text;
                    DOCGIADTO.DiaChi = txtDiaChi.Text;
                    DOCGIABUS.Update(DOCGIADTO);
                    MessageBox.Show("Bạn đã cập nhật thành công độc giả có mã:" + DOCGIADTO.MaDocGia.ToString());
                }
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaDocGia.Text=="")
                {
                    MessageBox.Show("Chưa nhập mã độc giả");
                    return;
                }
                DocGiaDTO docgiaDTO = new DocGiaDTO();
                DocGiaBUS docgiaBUS = new DocGiaBUS();
                docgiaDTO.MaDocGia = Int32.Parse(txtMaDocGia.Text);
                if (docgiaDTO.MaDocGia.ToString() != "")
                    docgiaBUS.GetDocGia(docgiaDTO);
                else
                    MessageBox.Show("Mời bạn nhập vào mã độc giả.");
                if (docgiaDTO.MaDocGia.ToString() == "")
                    MessageBox.Show("Không tìm thấy độc giả có mã:" + txtMaDocGia.Text);
                else
                {
                    txtMaDocGiaKQ.Text = docgiaDTO.MaDocGia.ToString();
                    txtHoTen.Text = docgiaDTO.HoTen;
                    txtDiaChi.Text = docgiaDTO.DiaChi;
                    txtDienThoai.Text = docgiaDTO.DienThoai;
                    btnCapNhat.Enabled = true;
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