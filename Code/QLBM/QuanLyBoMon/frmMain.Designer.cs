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
            this.timLopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quanLyGiangVien = new System.Windows.Forms.ToolStripMenuItem();
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
            this.quanLyGiangVien,
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
            this.timLopToolStripMenuItem});
            this.quanToolStripMenuItem.Name = "quanToolStripMenuItem";
            this.quanToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.quanToolStripMenuItem.Text = "Quản Lý Lớp";
            // 
            // thêmLơpToolStripMenuItem
            // 
            this.thêmLơpToolStripMenuItem.Name = "thêmLơpToolStripMenuItem";
            this.thêmLơpToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.thêmLơpToolStripMenuItem.Text = "Thêm Lớp";
            this.thêmLơpToolStripMenuItem.Click += new System.EventHandler(this.thêmLơpToolStripMenuItem_Click);
            // 
            // timLopToolStripMenuItem
            // 
            this.timLopToolStripMenuItem.Name = "timLopToolStripMenuItem";
            this.timLopToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.timLopToolStripMenuItem.Text = "Tim Kiếm Lớp";
            this.timLopToolStripMenuItem.Click += new System.EventHandler(this.timLopToolStripMenuItem_Click);
            // 
            // quanLyGiangVien
            // 
            this.quanLyGiangVien.Name = "quanLyGiangVien";
            this.quanLyGiangVien.Size = new System.Drawing.Size(123, 20);
            this.quanLyGiangVien.Text = "Quản Lý Giảng Viên";
            this.quanLyGiangVien.Click += new System.EventHandler(this.quanLyGiangVien_Click);
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
        private System.Windows.Forms.ToolStripMenuItem timLopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Window;
        private System.Windows.Forms.ToolStripMenuItem quanLyGiangVien;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem thôngKêLơpCuaGiangViênToolStripMenuItem;

    }
}

