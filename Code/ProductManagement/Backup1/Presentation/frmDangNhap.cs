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
        public static string gUserName = "";

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
            DangNhap();
        }

        private void frmDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void DangNhap()
        {
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Chưa nhập username");
                    return;
                }
                if (txtPassword.Text == "")
                {
                    MessageBox.Show("Chưa nhập password");
                    return;
                }
                NhanVienDTO nhanvienDTO = null;
                NhanVienBUS nhanvienBUS = new NhanVienBUS();
                string username = txtUsername.Text;
                nhanvienDTO = nhanvienBUS.Search(username);

                byte[] plainTextBytes = ASCIIEncoding.ASCII.GetBytes(txtPassword.Text.ToString());

                MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash = myMD5.ComputeHash(plainTextBytes);

                StringBuilder sOutput = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                {
                    sOutput.Append(byteHash[i].ToString("X2"));  // X2 formats to hexadecimal
                }

                if (nhanvienDTO == null)
                {
                    MessageBox.Show("Không tìm thấy nhân viên có username là : " + txtUsername.Text);
                    return;
                }
                else
                {
                    if (nhanvienDTO.Password == sOutput.ToString() && nhanvienDTO.Loai == 1)
                    {
                        //this.Visible = false;
                        kiemTraDangNhap = true;
                        gUserName = username;
                        this.Close();
                        //frmQuanLySach frm = new frmQuanLySach();
                        //frmQuanLySanPham frm = new frmQuanLySanPham();
                        //frm.ShowDialog();


                    }
                    else
                    {
                        if (nhanvienDTO.Password == sOutput.ToString() && nhanvienDTO.Loai == 2)
                        {
                            kiemTraDangNhap = true;
                            gUserName = username;
                            this.Close();
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

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DangNhap();
            }
        }
    }
}