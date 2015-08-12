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
            this.Window = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quanToolStripMenuItem,
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

    }
}

