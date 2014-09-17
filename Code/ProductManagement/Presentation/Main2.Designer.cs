namespace Presentation
{
    partial class Main2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.TimKiemCapNhatSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.ThemSanPham = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyDonHang = new System.Windows.Forms.ToolStripMenuItem();
            this.QuanLyKhachHang = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XuatKhoHang = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportProductFromImages = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Window = new System.Windows.Forms.ToolStripMenuItem();
            this.facebookToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.QuanLyDonHang,
            this.QuanLyKhachHang,
            this.adminToolStripMenuItem,
            this.Window});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.Window;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1299, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TimKiemCapNhatSanPham,
            this.ThemSanPham});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(119, 20);
            this.toolStripMenuItem1.Text = "Quản Lý Sản Phẩm";
            // 
            // TimKiemCapNhatSanPham
            // 
            this.TimKiemCapNhatSanPham.Name = "TimKiemCapNhatSanPham";
            this.TimKiemCapNhatSanPham.Size = new System.Drawing.Size(242, 22);
            this.TimKiemCapNhatSanPham.Text = "Tìm Kiếm - Cập Nhật Sản Phẩm";
            this.TimKiemCapNhatSanPham.Click += new System.EventHandler(this.TimKiemCapNhatSanPham_Click);
            // 
            // ThemSanPham
            // 
            this.ThemSanPham.Name = "ThemSanPham";
            this.ThemSanPham.Size = new System.Drawing.Size(242, 22);
            this.ThemSanPham.Text = "Thêm Sản Phẩm";
            this.ThemSanPham.Click += new System.EventHandler(this.ThemSanPham_Click);
            // 
            // QuanLyDonHang
            // 
            this.QuanLyDonHang.Name = "QuanLyDonHang";
            this.QuanLyDonHang.Size = new System.Drawing.Size(120, 20);
            this.QuanLyDonHang.Text = "Quản Lý Đơn Hàng";
            this.QuanLyDonHang.Click += new System.EventHandler(this.QuanLyDonHang_Click);
            // 
            // QuanLyKhachHang
            // 
            this.QuanLyKhachHang.Name = "QuanLyKhachHang";
            this.QuanLyKhachHang.Size = new System.Drawing.Size(131, 20);
            this.QuanLyKhachHang.Text = "Quản Lý Khách Hàng";
            this.QuanLyKhachHang.Click += new System.EventHandler(this.QuanLyKhachHang_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XuatKhoHang,
            this.ImportProductFromImages,
            this.applicationConfigToolStripMenuItem,
            this.facebookToolsToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // XuatKhoHang
            // 
            this.XuatKhoHang.Name = "XuatKhoHang";
            this.XuatKhoHang.Size = new System.Drawing.Size(227, 22);
            this.XuatKhoHang.Text = "Xuất Kho Hàng";
            this.XuatKhoHang.Click += new System.EventHandler(this.XuatKhoHang_Click);
            // 
            // ImportProductFromImages
            // 
            this.ImportProductFromImages.Name = "ImportProductFromImages";
            this.ImportProductFromImages.Size = new System.Drawing.Size(227, 22);
            this.ImportProductFromImages.Text = "Import Product From Images";
            this.ImportProductFromImages.Click += new System.EventHandler(this.ImportProductFromImages_Click);
            // 
            // applicationConfigToolStripMenuItem
            // 
            this.applicationConfigToolStripMenuItem.Name = "applicationConfigToolStripMenuItem";
            this.applicationConfigToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.applicationConfigToolStripMenuItem.Text = "Application Config";
            this.applicationConfigToolStripMenuItem.Click += new System.EventHandler(this.applicationConfigToolStripMenuItem_Click);
            // 
            // Window
            // 
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(108, 20);
            this.Window.Text = "Cửa Sổ Đang Mở";
            // 
            // facebookToolsToolStripMenuItem
            // 
            this.facebookToolsToolStripMenuItem.Name = "facebookToolsToolStripMenuItem";
            this.facebookToolsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.facebookToolsToolStripMenuItem.Text = "Facebook Tools";
            this.facebookToolsToolStripMenuItem.Click += new System.EventHandler(this.facebookToolsToolStripMenuItem_Click);
            // 
            // Main2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 742);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main2";
            this.Text = "ELLA SHOP - Trang Sức - Phụ Kiện Giá Rẻ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem TimKiemCapNhatSanPham;
        private System.Windows.Forms.ToolStripMenuItem ThemSanPham;
        private System.Windows.Forms.ToolStripMenuItem Window;
        private System.Windows.Forms.ToolStripMenuItem QuanLyDonHang;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XuatKhoHang;
        private System.Windows.Forms.ToolStripMenuItem ImportProductFromImages;
        private System.Windows.Forms.ToolStripMenuItem QuanLyKhachHang;
        private System.Windows.Forms.ToolStripMenuItem applicationConfigToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facebookToolsToolStripMenuItem;
    }
}