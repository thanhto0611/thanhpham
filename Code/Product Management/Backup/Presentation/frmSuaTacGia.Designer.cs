namespace Presentation
{
    partial class frmSuaTacGia
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnXem = new System.Windows.Forms.Button();
            this.grbThongTinTacGia = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtMaDocGia = new System.Windows.Forms.TextBox();
            this.txtTacGia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTacGia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grbThongTinTacGia.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(262, 210);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(89, 29);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXem
            // 
            this.btnXem.Location = new System.Drawing.Point(262, 48);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(89, 31);
            this.btnXem.TabIndex = 11;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // grbThongTinTacGia
            // 
            this.grbThongTinTacGia.AutoSize = true;
            this.grbThongTinTacGia.Controls.Add(this.txtMaDocGia);
            this.grbThongTinTacGia.Controls.Add(this.txtTacGia);
            this.grbThongTinTacGia.Controls.Add(this.label4);
            this.grbThongTinTacGia.Controls.Add(this.label3);
            this.grbThongTinTacGia.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbThongTinTacGia.Location = new System.Drawing.Point(18, 85);
            this.grbThongTinTacGia.Name = "grbThongTinTacGia";
            this.grbThongTinTacGia.Size = new System.Drawing.Size(347, 119);
            this.grbThongTinTacGia.TabIndex = 10;
            this.grbThongTinTacGia.TabStop = false;
            this.grbThongTinTacGia.Text = "Thông tin Tác Giả";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(162, 210);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(94, 29);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtMaDocGia
            // 
            this.txtMaDocGia.Location = new System.Drawing.Point(118, 33);
            this.txtMaDocGia.Name = "txtMaDocGia";
            this.txtMaDocGia.ReadOnly = true;
            this.txtMaDocGia.Size = new System.Drawing.Size(222, 20);
            this.txtMaDocGia.TabIndex = 5;
            // 
            // txtTacGia
            // 
            this.txtTacGia.Location = new System.Drawing.Point(118, 73);
            this.txtTacGia.Name = "txtTacGia";
            this.txtTacGia.Size = new System.Drawing.Size(222, 20);
            this.txtTacGia.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên Tác Giả:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Tác Giả:";
            // 
            // cmbTacGia
            // 
            this.cmbTacGia.FormattingEnabled = true;
            this.cmbTacGia.Location = new System.Drawing.Point(135, 21);
            this.cmbTacGia.Name = "cmbTacGia";
            this.cmbTacGia.Size = new System.Drawing.Size(216, 21);
            this.cmbTacGia.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Chọn tên Tác Giả:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCapNhat);
            this.groupBox1.Controls.Add(this.cmbTacGia);
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.grbThongTinTacGia);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 251);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 39);
            this.panel1.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(-5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Cập nhật Tác Giả";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmQuanLyTacGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(374, 294);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmQuanLyTacGia";
            this.Text = "Cập nhật Tác Giả";
            this.Load += new System.EventHandler(this.QuanLyTacGia_Load);
            this.grbThongTinTacGia.ResumeLayout(false);
            this.grbThongTinTacGia.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.GroupBox grbThongTinTacGia;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtMaDocGia;
        private System.Windows.Forms.TextBox txtTacGia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTacGia;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}