namespace Presentation
{
    partial class frmSuaLoaiSach
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
            this.grbThongTinLoaiSach = new System.Windows.Forms.GroupBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtMaLoaiSach = new System.Windows.Forms.TextBox();
            this.txtLoaiSach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbLoaiSach = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.grbThongTinLoaiSach.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Arial", 9F);
            this.btnThoat.Location = new System.Drawing.Point(231, 96);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 27;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Arial", 9F);
            this.btnXem.Location = new System.Drawing.Point(231, 52);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(77, 21);
            this.btnXem.TabIndex = 25;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // grbThongTinLoaiSach
            // 
            this.grbThongTinLoaiSach.AutoSize = true;
            this.grbThongTinLoaiSach.Controls.Add(this.btnThoat);
            this.grbThongTinLoaiSach.Controls.Add(this.btnCapNhat);
            this.grbThongTinLoaiSach.Controls.Add(this.txtMaLoaiSach);
            this.grbThongTinLoaiSach.Controls.Add(this.txtLoaiSach);
            this.grbThongTinLoaiSach.Controls.Add(this.label4);
            this.grbThongTinLoaiSach.Controls.Add(this.label3);
            this.grbThongTinLoaiSach.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbThongTinLoaiSach.Location = new System.Drawing.Point(0, 75);
            this.grbThongTinLoaiSach.Name = "grbThongTinLoaiSach";
            this.grbThongTinLoaiSach.Size = new System.Drawing.Size(312, 139);
            this.grbThongTinLoaiSach.TabIndex = 24;
            this.grbThongTinLoaiSach.TabStop = false;
            this.grbThongTinLoaiSach.Text = "Thông tin Loại Sách";
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Arial", 9F);
            this.btnCapNhat.Location = new System.Drawing.Point(150, 96);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(75, 23);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtMaLoaiSach
            // 
            this.txtMaLoaiSach.Font = new System.Drawing.Font("Arial", 9F);
            this.txtMaLoaiSach.Location = new System.Drawing.Point(96, 33);
            this.txtMaLoaiSach.Name = "txtMaLoaiSach";
            this.txtMaLoaiSach.ReadOnly = true;
            this.txtMaLoaiSach.Size = new System.Drawing.Size(210, 21);
            this.txtMaLoaiSach.TabIndex = 5;
            // 
            // txtLoaiSach
            // 
            this.txtLoaiSach.Font = new System.Drawing.Font("Arial", 9F);
            this.txtLoaiSach.Location = new System.Drawing.Point(96, 69);
            this.txtLoaiSach.Name = "txtLoaiSach";
            this.txtLoaiSach.Size = new System.Drawing.Size(210, 21);
            this.txtLoaiSach.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên Loại Sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(6, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Loại Sách:";
            // 
            // cmbLoaiSach
            // 
            this.cmbLoaiSach.FormattingEnabled = true;
            this.cmbLoaiSach.Location = new System.Drawing.Point(82, 24);
            this.cmbLoaiSach.Name = "cmbLoaiSach";
            this.cmbLoaiSach.Size = new System.Drawing.Size(226, 23);
            this.cmbLoaiSach.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(10, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Loại Sách:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbLoaiSach);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.grbThongTinLoaiSach);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 9F);
            this.groupBox1.Location = new System.Drawing.Point(0, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 223);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cập Nhật Loại Sách";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 45);
            this.panel1.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(60, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cập nhật Loại Sách";
            // 
            // frmSuaLoaiSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(316, 273);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSuaLoaiSach";
            this.Text = "Sửa Loại Sách";
            this.Load += new System.EventHandler(this.QuanLyLoaiSach_Load);
            this.grbThongTinLoaiSach.ResumeLayout(false);
            this.grbThongTinLoaiSach.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.GroupBox grbThongTinLoaiSach;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtMaLoaiSach;
        private System.Windows.Forms.TextBox txtLoaiSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbLoaiSach;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}