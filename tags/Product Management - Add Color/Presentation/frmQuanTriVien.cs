using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using DTO;
using BUS;
using System.IO;

namespace Presentation
{
    public partial class frmQuanTriVien : Form
    {
        public frmQuanTriVien()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTaoTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "")
                {
                    MessageBox.Show("Chưa nhập Username");
                    return;
                }
                if (txtPass.Text == "")
                {
                    MessageBox.Show("Chưa nhập Password");
                    return;
                }
                if (txtRePass.Text == "")
                {
                    MessageBox.Show("Chưa nhập lại Password");
                    return;
                }
                if (txtHoTen.Text == "")
                {
                    MessageBox.Show("Chưa nhập họ tên");
                    return;
                }
                if (txtDiaChi.Text == "")
                {
                    MessageBox.Show("Chưa nhập địa chỉ");
                    return;
                }
                if (txtDienThoai.Text == "")
                {
                    MessageBox.Show("Chưa nhập số điện thoại");
                    return;
                }
                if (txtEmail.Text == "")
                {
                    MessageBox.Show("Chưa nhập email");
                    return;
                }
                if (txtPass.Text != txtRePass.Text)
                {
                    MessageBox.Show("Password chưa khớp");
                    return;
                }

                byte[] plainTextBytes = ASCIIEncoding.ASCII.GetBytes(txtPass.Text.ToString());
                
                MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
                byte[] byteHash = myMD5.ComputeHash(plainTextBytes);

                StringBuilder sOutput = new StringBuilder(byteHash.Length);
                for (int i = 0; i < byteHash.Length; i++)
                {
                    sOutput.Append(byteHash[i].ToString("X2"));  // X2 formats to hexadecimal
                }

                
                NhanVienBUS nhanvientBUS = new NhanVienBUS();
                NhanVienDTO nhanvienDTO = new NhanVienDTO() ;

                nhanvienDTO.Username = txtUsername.Text;
                nhanvienDTO.Password = sOutput.ToString();
                nhanvienDTO.DiaChi = txtDiaChi.Text;
                nhanvienDTO.Email = txtDiaChi.Text;
                nhanvienDTO.DienThoai = txtDienThoai.Text;
                nhanvienDTO.HoTen = txtHoTen.Text;
                nhanvienDTO.Loai = 1;

                nhanvientBUS.Insert(nhanvienDTO);
                MessageBox.Show("Tài khoản đã được tạo");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPass.Text = "";
            txtRePass.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFileDes.Text=="")
                {
                    MessageBox.Show("Chưa chọn nơi lưu trữ");
                    return;
                }
                string filename = txtFileDes.Text + "\\" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-" + DateTime.Now.Year + "_QLTV.mdb";
                File.Copy(@"QLTV.mdb", filename);
                MessageBox.Show("Backup thành công");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            folderBrowserBackup.ShowDialog();
            txtFileDes.Text = folderBrowserBackup.SelectedPath;
        }

        private void rdbMaSo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaSo.Checked==true)
            {
                txtTimUsername.Enabled = false;
                rdbUsername.Checked = false;
                txtTimMaSo.Enabled = true;
            }
            if (rdbMaSo.Checked==false)
            {
                txtTimUsername.Enabled = true;
                rdbUsername.Checked = true;
            }
        }

        private void rdbUsername_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbUsername.Checked == true)
            {
                txtTimMaSo.Enabled = false;
                rdbMaSo.Checked = false;
                txtTimUsername.Enabled = true;
            }
            if (rdbUsername.Checked == false)
            {
                txtTimMaSo.Enabled = true;
                rdbMaSo.Checked = true;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTimMaSo.Text == "" && txtTimUsername.Text == "")
                {
                    MessageBox.Show("Chưa nhập thông tin về quản thư cần tìm");
                    return;
                }
                if (rdbUsername.Checked == true)
                {
                    NhanVienBUS nhanvientBUS = new NhanVienBUS();
                    NhanVienDTO nhanvienDTO = null;
                    nhanvienDTO = nhanvientBUS.Search(txtTimUsername.Text.ToString());
                    if (nhanvienDTO == null) 
                    {
                        MessageBox.Show("Không tìm thấy thông tin");
                        return;
                    }
                    else
                    {
                        txtUsername.Text = nhanvienDTO.Username;
                        txtHoTen.Text = nhanvienDTO.HoTen;
                        txtDiaChi.Text = nhanvienDTO.DiaChi;
                        txtDienThoai.Text = nhanvienDTO.DienThoai;
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void frmQuanTriVien_Load(object sender, EventArgs e)
        {
            txtTimUsername.Enabled = false;
            txtTimMaSo.Enabled = false;
        }
    }
}