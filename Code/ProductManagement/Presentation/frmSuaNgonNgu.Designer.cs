namespace Presentation
{
    partial class frmSuaNgonNgu
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
            this.grbThongTinNXB = new System.Windows.Forms.GroupBox();
            this.txtMaNgonNgu = new System.Windows.Forms.TextBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.txtNgonNgu = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNgonNgu = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbThongTinNXB.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(221, 100);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(65, 21);
            this.btnThoat.TabIndex = 20;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnXem
            // 
            this.btnXem.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.Location = new System.Drawing.Point(227, 52);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(65, 21);
            this.btnXem.TabIndex = 18;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            this.btnXem.Click += new System.EventHandler(this.btnXem_Click);
            // 
            // grbThongTinNXB
            // 
            this.grbThongTinNXB.AutoSize = true;
            this.grbThongTinNXB.Controls.Add(this.txtMaNgonNgu);
            this.grbThongTinNXB.Controls.Add(this.btnThoat);
            this.grbThongTinNXB.Controls.Add(this.btnCapNhat);
            this.grbThongTinNXB.Controls.Add(this.txtNgonNgu);
            this.grbThongTinNXB.Controls.Add(this.label4);
            this.grbThongTinNXB.Controls.Add(this.label3);
            this.grbThongTinNXB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbThongTinNXB.Font = new System.Drawing.Font("Arial", 9F);
            this.grbThongTinNXB.Location = new System.Drawing.Point(6, 79);
            this.grbThongTinNXB.Name = "grbThongTinNXB";
            this.grbThongTinNXB.Size = new System.Drawing.Size(292, 141);
            this.grbThongTinNXB.TabIndex = 17;
            this.grbThongTinNXB.TabStop = false;
            this.grbThongTinNXB.Text = "Thông tin Ngôn ngữ";
            // 
            // txtMaNgonNgu
            // 
            this.txtMaNgonNgu.Location = new System.Drawing.Point(118, 33);
            this.txtMaNgonNgu.Name = "txtMaNgonNgu";
            this.txtMaNgonNgu.ReadOnly = true;
            this.txtMaNgonNgu.Size = new System.Drawing.Size(168, 21);
            this.txtMaNgonNgu.TabIndex = 5;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.Location = new System.Drawing.Point(145, 100);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(65, 21);
            this.btnCapNhat.TabIndex = 4;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
            // 
            // txtNgonNgu
            // 
            this.txtNgonNgu.Location = new System.Drawing.Point(118, 73);
            this.txtNgonNgu.Name = "txtNgonNgu";
            this.txtNgonNgu.Size = new System.Drawing.Size(168, 21);
            this.txtNgonNgu.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên Ngôn ngữ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Ngôn ngữ:";
            // 
            // cmbNgonNgu
            // 
            this.cmbNgonNgu.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbNgonNgu.FormattingEnabled = true;
            this.cmbNgonNgu.Location = new System.Drawing.Point(124, 24);
            this.cmbNgonNgu.Name = "cmbNgonNgu";
            this.cmbNgonNgu.Size = new System.Drawing.Size(168, 23);
            this.cmbNgonNgu.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "Chọn Ngôn ngữ:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(305, 43);
            this.panel1.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cập nhật Ngôn Ngữ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbNgonNgu);
            this.groupBox1.Controls.Add(this.btnXem);
            this.groupBox1.Controls.Add(this.grbThongTinNXB);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 43);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 209);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // frmSuaNgonNgu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(305, 252);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "frmSuaNgonNgu";
            this.Text = "Cập nhật Ngôn ngữ";
            this.Load += new System.EventHandler(this.QuanLyNgonNgu_Load);
            this.grbThongTinNXB.ResumeLayout(false);
            this.grbThongTinNXB.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.GroupBox grbThongTinNXB;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.TextBox txtMaNgonNgu;
        private System.Windows.Forms.TextBox txtNgonNgu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNgonNgu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}