using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;
using System.Security.Cryptography;
using System.IO;

namespace Presentation
{
    public partial class frmDangNhap : Form
    {
        public static bool kiemTraDangNhap = false;

        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void txtUsername_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text=="")
                {
                    MessageBox.Show("Chưa nhập username");
                    return;
                }
                if (txtPassword.Text=="")
                {
                    MessageBox.Show("Chưa nhập password");
                    return;
                }
                QuanThuDTO quanthuDTO = null;
                QuanThuBUS quanthuBUS = new QuanThuBUS();
                string username = txtUsername.Text;
                quanthuDTO = quanthuBUS.Search(username);

                byte[] plainTextBytes = ASCIIEncoding.ASCII.GetBytes(txtPassword.Text.ToString());

                MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash = myMD5.ComputeHash(plainTextBytes);

                StringBuilder sOutput = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                {
                    sOutput.Append(byteHash[i].ToString("X2"));  // X2 formats to hexadecimal
                }

                if (quanthuDTO == null)
                {
                    MessageBox.Show("Không tìm thấy quản thư có username là : " + txtUsername.Text);
                    return;
                }
                else
                {
                    if (quanthuDTO.Password == sOutput.ToString() && quanthuDTO.Loai == 1)
                    {
                        //this.Visible = false;
                        kiemTraDangNhap = true;
                        this.Close();
                        frmQuanLySach frm = new frmQuanLySach();
                        frm.ShowDialog();
                        
                        
                    }
                    else
                    {
                        if (quanthuDTO.Password == sOutput.ToString() && quanthuDTO.Loai == 2)
                        {
                            kiemTraDangNhap = true;
                            frmQuanTriVien frm = new frmQuanTriVien();
                            frm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Password không hợp lệ");
                            return; 
                        }
                    }
                    
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}