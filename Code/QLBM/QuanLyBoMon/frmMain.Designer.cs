namespace QuanLyBoMon
{
    partial class frmMain
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.quanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLơpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmLơpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.timKiêmLơpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyGiangVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyMonHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyNamHocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngKêLơpCuaGiangViênToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Window = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanToolStripMenuItem,
            this.toolStripMenuItem1,
            this.Window});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.MdiWindowListItem = this.Window;
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1068, 24);
            this.menuMain.TabIndex = 1;
            this.menuMain.Text = "menuStrip1";
            // 
            // quanToolStripMenuItem
            // 
            this.quanToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmLơpToolStripMenuItem,
            this.quanLyGiangVienToolStripMenuItem,
            this.quanLyMonHocToolStripMenuItem,
            this.quanLyNamHocToolStripMenuItem});
            this.quanToolStripMenuItem.Name = "quanToolStripMenuItem";
            this.quanToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.quanToolStripMenuItem.Text = "Quản Lý";
            // 
            // thêmLơpToolStripMenuItem
            // 
            this.thêmLơpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmLơpToolStripMenuItem1,
            this.timKiêmLơpToolStripMenuItem});
            this.thêmLơpToolStripMenuItem.Name = "thêmLơpToolStripMenuItem";
            this.thêmLơpToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.thêmLơpToolStripMenuItem.Text = "Quản Lý Lớp";
            // 
            // thêmLơpToolStripMenuItem1
            // 
            this.thêmLơpToolStripMenuItem1.Name = "thêmLơpToolStripMenuItem1";
            this.thêmLơpToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.thêmLơpToolStripMenuItem1.Text = "Thêm Lớp";
            this.thêmLơpToolStripMenuItem1.Click += new System.EventHandler(this.thêmLơpToolStripMenuItem_Click);
            // 
            // timKiêmLơpToolStripMenuItem
            // 
            this.timKiêmLơpToolStripMenuItem.Name = "timKiêmLơpToolStripMenuItem";
            this.timKiêmLơpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.timKiêmLơpToolStripMenuItem.Text = "Tìm Kiếm Lớp";
            this.timKiêmLơpToolStripMenuItem.Click += new System.EventHandler(this.timKiêmLơpToolStripMenuItem_Click);
            // 
            // quanLyGiangVienToolStripMenuItem
            // 
            this.quanLyGiangVienToolStripMenuItem.Name = "quanLyGiangVienToolStripMenuItem";
            this.quanLyGiangVienToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.quanLyGiangVienToolStripMenuItem.Text = "Quản Lý Giảng Viên";
            this.quanLyGiangVienToolStripMenuItem.Click += new System.EventHandler(this.quanLyGiangVienToolStripMenuItem_Click);
            // 
            // quanLyMonHocToolStripMenuItem
            // 
            this.quanLyMonHocToolStripMenuItem.Name = "quanLyMonHocToolStripMenuItem";
            this.quanLyMonHocToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.quanLyMonHocToolStripMenuItem.Text = "Quản Lý Môn Học";
            this.quanLyMonHocToolStripMenuItem.Click += new System.EventHandler(this.quanLyMonHocToolStripMenuItem_Click);
            // 
            // quanLyNamHocToolStripMenuItem
            // 
            this.quanLyNamHocToolStripMenuItem.Name = "quanLyNamHocToolStripMenuItem";
            this.quanLyNamHocToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.quanLyNamHocToolStripMenuItem.Text = "Quản Lý Năm Học";
            this.quanLyNamHocToolStripMenuItem.Click += new System.EventHandler(this.quanLyNamHocToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngKêLơpCuaGiangViênToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(70, 20);
            this.toolStripMenuItem1.Text = "Thống Kê";
            // 
            // thôngKêLơpCuaGiangViênToolStripMenuItem
            // 
            this.thôngKêLơpCuaGiangViênToolStripMenuItem.Name = "thôngKêLơpCuaGiangViênToolStripMenuItem";
            this.thôngKêLơpCuaGiangViênToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.thôngKêLơpCuaGiangViênToolStripMenuItem.Text = "Thống Kê Lớp Của Giảng Viên";
            this.thôngKêLơpCuaGiangViênToolStripMenuItem.Click += new System.EventHandler(this.thôngKêLơpCuaGiangViênToolStripMenuItem_Click);
            // 
            // Window
            // 
            this.Window.Name = "Window";
            this.Window.Size = new System.Drawing.Size(106, 20);
            this.Window.Text = "Cửa sổ đang mở";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 514);
            this.Controls.Add(this.menuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "frmMain";
            this.Text = "PHẦN MỀM QUẢN LÝ BỘ MÔN";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem quanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmLơpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyGiangVienToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Window;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thôngKêLơpCuaGiangViênToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmLơpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem timKiêmLơpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyMonHocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quanLyNamHocToolStripMenuItem;

    }
}

