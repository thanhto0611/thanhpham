namespace Presentation
{
    partial class frmXuatKhoHang
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
            this.grbXuatKhoHang = new System.Windows.Forms.GroupBox();
            this.btnXuat = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.dtpLastUpdateDate = new System.Windows.Forms.DateTimePicker();
            this.cbxUseLastUpdateDate = new System.Windows.Forms.CheckBox();
            this.grbXuatKhoHang.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbXuatKhoHang
            // 
            this.grbXuatKhoHang.Controls.Add(this.cbxUseLastUpdateDate);
            this.grbXuatKhoHang.Controls.Add(this.dtpLastUpdateDate);
            this.grbXuatKhoHang.Controls.Add(this.btnXuat);
            this.grbXuatKhoHang.Controls.Add(this.btnBrowse);
            this.grbXuatKhoHang.Controls.Add(this.txtLocation);
            this.grbXuatKhoHang.Controls.Add(this.label1);
            this.grbXuatKhoHang.Location = new System.Drawing.Point(12, 12);
            this.grbXuatKhoHang.Name = "grbXuatKhoHang";
            this.grbXuatKhoHang.Size = new System.Drawing.Size(659, 250);
            this.grbXuatKhoHang.TabIndex = 0;
            this.grbXuatKhoHang.TabStop = false;
            this.grbXuatKhoHang.Text = "Xuất Kho Hàng:";
            // 
            // btnXuat
            // 
            this.btnXuat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.Red;
            this.btnXuat.Location = new System.Drawing.Point(213, 151);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(97, 78);
            this.btnXuat.TabIndex = 3;
            this.btnXuat.Text = "Xuất File";
            this.btnXuat.UseVisualStyleBackColor = true;
            this.btnXuat.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(530, 34);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(151, 36);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(359, 20);
            this.txtLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nơi Lưu Trữ:";
            // 
            // dtpLastUpdateDate
            // 
            this.dtpLastUpdateDate.Enabled = false;
            this.dtpLastUpdateDate.Location = new System.Drawing.Point(151, 73);
            this.dtpLastUpdateDate.Name = "dtpLastUpdateDate";
            this.dtpLastUpdateDate.Size = new System.Drawing.Size(200, 20);
            this.dtpLastUpdateDate.TabIndex = 5;
            // 
            // cbxUseLastUpdateDate
            // 
            this.cbxUseLastUpdateDate.AutoSize = true;
            this.cbxUseLastUpdateDate.Location = new System.Drawing.Point(20, 78);
            this.cbxUseLastUpdateDate.Name = "cbxUseLastUpdateDate";
            this.cbxUseLastUpdateDate.Size = new System.Drawing.Size(122, 17);
            this.cbxUseLastUpdateDate.TabIndex = 6;
            this.cbxUseLastUpdateDate.Text = "Ngày cập nhật cuối:";
            this.cbxUseLastUpdateDate.UseVisualStyleBackColor = true;
            this.cbxUseLastUpdateDate.CheckedChanged += new System.EventHandler(this.cbxUseLastUpdateDate_CheckedChanged);
            // 
            // frmXuatKhoHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 514);
            this.Controls.Add(this.grbXuatKhoHang);
            this.Name = "frmXuatKhoHang";
            this.Text = "Xuất Kho Hàng";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmXuatKhoHang_FormClosed);
            this.grbXuatKhoHang.ResumeLayout(false);
            this.grbXuatKhoHang.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbXuatKhoHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserLocation;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.DateTimePicker dtpLastUpdateDate;
        private System.Windows.Forms.CheckBox cbxUseLastUpdateDate;
    }
}