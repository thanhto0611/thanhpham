using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void themSachToolStripButton_Click(object sender, EventArgs e)
        {
            //QuanLyLoaiSach frmQL = new QuanLyLoaiSach();
            //frmQL.TopLevel = false;
            //frmQL.FormBorderStyle = FormBorderStyle.None;
            //frmQL.Dock = DockStyle.Fill;
            //panel1.Controls.Add(frmQL);
            //frmQL.Top = panel1.Top;
            //frmQL.Left = (panel1.Right - panel1.Left) / 2;
            //frmQL.Show();

            //QuanLyLoaiSach frmQLS = new QuanLyLoaiSach();
            //frmQLS.ShowDialog();

        //    TimKiemSach frmTimKiem = new TimKiemSach();
          //  frmTimKiem.ShowDialog();
            if (frmDangNhap.kiemTraDangNhap==true)
            {
                frmQuanLySach frm = new frmQuanLySach();
                frm.ShowDialog();
            }
            else
            {
                frmDangNhap frm = new frmDangNhap();
                frm.ShowDialog();
            }
            
        }

        private void xoaSachToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmDangNhap.kiemTraDangNhap == true)
            {
                frmQuanLyDocGia frm = new frmQuanLyDocGia();
                frm.ShowDialog();
            }
            else
            {
                frmDangNhap frm = new frmDangNhap();
                frm.ShowDialog();
            }

           
        }

        private void ThemsachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTheLoaiSach frm = new frmQuanLyTheLoaiSach();
            frm.ShowDialog();
        }

        private void theoTheLoaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNXB frmQLNXB = new frmQuanLyNXB();
            frmQLNXB.ShowDialog();
        }

        private void theoThangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyTacGia frmQLTG = new frmQuanLyTacGia();
            frmQLTG.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            int temp = label1.Right - label1.Left;
            int temp2 = label3.Right - label3.Left;

            label1.Left = Right / 2 - temp / 2;
            label3.Left = Right / 2 - temp2 / 2;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            MuonTraSach frmMuonTra = new MuonTraSach();
            frmMuonTra.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          frmThongKeTL frmThongKe = new frmThongKeTL();
          frmThongKe.ShowDialog();
        }

        private void logOutToolStripButton_Click(object sender, EventArgs e)
        {
            frmDangNhap.kiemTraDangNhap = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}