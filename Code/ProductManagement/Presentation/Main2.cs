﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CookComputing.XmlRpc;
using Ez.Newsletter.MagentoApi;
using DTO;
using BUS;

namespace Presentation
{
    public partial class Main2 : Form
    {
        public static frmQuanLySanPham frmQLSP = null;
        public static frmThemSanPham frmThemSP = null;
        public static frmQuanLyDonHang frmQLDH = null;
        public static frmXuatKhoHang frmXKH = null;
        public static frmImportProducts frmIP = null;
        public static frmQuanLyKhachHang frmQLKH = null;
        public static frmConfig frmCfg = null;
        public static frmFbFindAndJoinGroups frmFbFindJoinGroups = null;
        public static frmFbPostToGroups frmFbPostToGroups = null;
        public static frmFbPostImageToFanpage frmFbPostImageToFanpage = null;
        public static frmCronJob frmCronJob = null;
        public static frmSyncToWeb frmSyncToWeb = null;
        public static frmFacebookMe frmFacebookMe = null;
        public static frmSyncAPI frmSyncAPI = null;
        public static frmConvertImageFileName frmConvertImageFileName = null;

        //public static string apiUrl = "http://localhost/ella/api/xmlrpc";
        public static string apiUrl;
        public static string apiUser = "ellaxmlrpc";
        public static string apiPass = "nguoicodoc";
        public static string sessionId = "";
        public static ConfigDTO _cfgDto = new ConfigDTO();

        public Main2()
        {
            InitializeComponent();
        }

        private void TimKiemCapNhatSanPham_Click(object sender, EventArgs e)
        {
            if (frmQLSP == null)
            {
                frmQLSP = new frmQuanLySanPham();
                frmQLSP.MdiParent = this;
                frmQLSP.Dock = DockStyle.Fill;
                frmQLSP.WindowState = FormWindowState.Maximized;
                frmQLSP.Show();
            }
            else
            {
                frmQLSP.BringToFront();
            }
            
            //this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ThemSanPham_Click(object sender, EventArgs e)
        {
            if (frmThemSP == null)
            {
                frmThemSP = new frmThemSanPham();
                frmThemSP.MdiParent = this;
                frmThemSP.Dock = DockStyle.Fill;
                frmThemSP.WindowState = FormWindowState.Maximized;
                frmThemSP.Show();
            }
            else
            {
                frmThemSP.BringToFront();
            }
            //this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void QuanLyDonHang_Click(object sender, EventArgs e)
        {
            if (frmQLDH == null)
            {
                frmQLDH = new frmQuanLyDonHang();
                frmQLDH.MdiParent = this;
                frmQLDH.Dock = DockStyle.Fill;
                frmQLDH.WindowState = FormWindowState.Maximized;
                frmQLDH.Show();
            }
            else
            {
                frmQLDH.BringToFront();
            }
            //this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void Main2_Load(object sender, EventArgs e)
        {
            getSessionId();

            // kiem tra dang nhap
            if (frmDangNhap.kiemTraDangNhap == false)
            {
                frmDangNhap frm = new frmDangNhap();
                frm.ShowDialog();
            }
        }

        public static void getSessionId()
        {
            try
            {
                // login (make sure you have user and role assigned in magento admin)
                _cfgDto = ConfigBUS.GetConfig();
                apiUrl = _cfgDto.SoapAddress;

                sessionId = Connection.Login(apiUrl, apiUser, apiPass);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Không thể kết nối tới web, sử dụng OFFLINE MODE");
                _cfgDto.UseAPISycn = false;
            }
        }

        private void XuatKhoHang_Click(object sender, EventArgs e)
        {
            if (frmXKH == null)
            {
                frmXKH = new frmXuatKhoHang();
                frmXKH.MdiParent = this;
                frmXKH.Dock = DockStyle.Fill;
                frmXKH.WindowState = FormWindowState.Maximized;
                frmXKH.Show();
            }
            else
            {
                frmXKH.BringToFront();
            }
        }

        private void ImportProductFromImages_Click(object sender, EventArgs e)
        {
            if (frmIP == null)
            {
                frmIP = new frmImportProducts();
                frmIP.MdiParent = this;
                frmIP.Dock = DockStyle.Fill;
                frmIP.WindowState = FormWindowState.Maximized;
                frmIP.Show();
            }
            else
            {
                frmIP.BringToFront();
            }
        }

        private void QuanLyKhachHang_Click(object sender, EventArgs e)
        {
            if (frmQLKH == null)
            {
                frmQLKH = new frmQuanLyKhachHang();
                frmQLKH.MdiParent = this;
                frmQLKH.Dock = DockStyle.Fill;
                frmQLKH.WindowState = FormWindowState.Maximized;
                frmQLKH.Show();
            }
            else
            {
                frmQLKH.BringToFront();
            }
        }

        private void applicationConfigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCfg == null)
            {
                frmCfg = new frmConfig();
                frmCfg.MdiParent = this;
                frmCfg.Dock = DockStyle.Fill;
                frmCfg.WindowState = FormWindowState.Maximized;
                frmCfg.Show();
            }
            else
            {
                frmCfg.BringToFront();
            }
        }

        private void facebookToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmFacebookMe == null)
            {
                frmFacebookMe = new frmFacebookMe();
                frmFacebookMe.MdiParent = this;
                frmFacebookMe.Dock = DockStyle.Fill;
                frmFacebookMe.WindowState = FormWindowState.Maximized;
                frmFacebookMe.Show();
            }
            else
            {
                frmFacebookMe.BringToFront();
            }
        }

        private void FindAndJoinGroups_Click(object sender, EventArgs e)
        {
            if (frmFbFindJoinGroups == null)
            {
                frmFbFindJoinGroups = new frmFbFindAndJoinGroups();
                frmFbFindJoinGroups.MdiParent = this;
                frmFbFindJoinGroups.Dock = DockStyle.Fill;
                frmFbFindJoinGroups.WindowState = FormWindowState.Maximized;
                frmFbFindJoinGroups.Show();
            }
            else
            {
                frmFbFindJoinGroups.BringToFront();
            }
        }

        private void PostToGroup_Click(object sender, EventArgs e)
        {
            if (frmFbPostToGroups == null)
            {
                frmFbPostToGroups = new frmFbPostToGroups();
                frmFbPostToGroups.MdiParent = this;
                frmFbPostToGroups.Dock = DockStyle.Fill;
                frmFbPostToGroups.WindowState = FormWindowState.Maximized;
                frmFbPostToGroups.Show();
            }
            else
            {
                frmFbPostToGroups.BringToFront();
            }
        }

        private void PostImageToFanpage_Click(object sender, EventArgs e)
        {
            if (frmFbPostImageToFanpage == null)
            {
                frmFbPostImageToFanpage = new frmFbPostImageToFanpage();
                frmFbPostImageToFanpage.MdiParent = this;
                frmFbPostImageToFanpage.Dock = DockStyle.Fill;
                frmFbPostImageToFanpage.WindowState = FormWindowState.Maximized;
                frmFbPostImageToFanpage.Show();
            }
            else
            {
                frmFbPostImageToFanpage.BringToFront();
            }
        }

        private void syncToWEBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmSyncToWeb == null)
            {
                frmSyncToWeb = new frmSyncToWeb();
                frmSyncToWeb.MdiParent = this;
                frmSyncToWeb.Dock = DockStyle.Fill;
                frmSyncToWeb.WindowState = FormWindowState.Maximized;
                frmSyncToWeb.Show();
            }
            else
            {
                frmSyncToWeb.BringToFront();
            }
        }

        private void cronJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmCronJob == null)
            {
                frmCronJob = new frmCronJob();
                frmCronJob.MdiParent = this;
                frmCronJob.Dock = DockStyle.Fill;
                frmCronJob.WindowState = FormWindowState.Maximized;
                frmCronJob.Show();
            }
            else
            {
                frmCronJob.BringToFront();
            }
        }

        private void syncAPI_Click(object sender, EventArgs e)
        {
            if (frmSyncAPI == null)
            {
                frmSyncAPI = new frmSyncAPI();
                frmSyncAPI.MdiParent = this;
                frmSyncAPI.Dock = DockStyle.Fill;
                frmSyncAPI.WindowState = FormWindowState.Maximized;
                frmSyncAPI.Show();
            }
            else
            {
                frmSyncAPI.BringToFront();
            }
        }

        private void convertImageFileNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmConvertImageFileName == null)
            {
                frmConvertImageFileName = new frmConvertImageFileName();
                frmConvertImageFileName.MdiParent = this;
                frmConvertImageFileName.Dock = DockStyle.Fill;
                frmConvertImageFileName.WindowState = FormWindowState.Maximized;
                frmConvertImageFileName.Show();
            }
            else
            {
                frmConvertImageFileName.BringToFront();
            }
        }
    }
}
