namespace QuanLyBoMon
{
    partial class frmThemGiangVienVaoMon
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
            this.listGiangVien = new System.Windows.Forms.ListBox();
            this.txtThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listGiangVienMon = new System.Windows.Forms.ListBox();
            this.btnChon = new System.Windows.Forms.Button();
            this.btnBoChon = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listGiangVien
            // 
            this.listGiangVien.FormattingEnabled = true;
            this.listGiangVien.Location = new System.Drawing.Point(27, 55);
            this.listGiangVien.Name = "listGiangVien";
            this.listGiangVien.Size = new System.Drawing.Size(399, 290);
            this.listGiangVien.TabIndex = 13;
            // 
            // txtThongTinTimKiem
            // 
            this.txtThongTinTimKiem.Location = new System.Drawing.Point(112, 29);
            this.txtThongTinTimKiem.Name = "txtThongTinTimKiem";
            this.txtThongTinTimKiem.Size = new System.Drawing.Size(314, 20);
            this.txtThongTinTimKiem.TabIndex = 12;
            this.txtThongTinTimKiem.TextChanged += new System.EventHandler(this.txtThongTinTimKiem_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tìm Giảng Viên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(527, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Giảng Viên Của Môn Học:";
            // 
            // listGiangVienMon
            // 
            this.listGiangVienMon.FormattingEnabled = true;
            this.listGiangVienMon.Location = new System.Drawing.Point(530, 55);
            this.listGiangVienMon.Name = "listGiangVienMon";
            this.listGiangVienMon.Size = new System.Drawing.Size(335, 290);
            this.listGiangVienMon.TabIndex = 15;
            // 
            // btnChon
            // 
            this.btnChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnChon.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnChon.Location = new System.Drawing.Point(432, 149);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(87, 23);
            this.btnChon.TabIndex = 16;
            this.btnChon.Text = "Chọn >>";
            this.btnChon.UseVisualStyleBackColor = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnBoChon
            // 
            this.btnBoChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBoChon.ForeColor = System.Drawing.Color.Red;
            this.btnBoChon.Location = new System.Drawing.Point(432, 189);
            this.btnBoChon.Name = "btnBoChon";
            this.btnBoChon.Size = new System.Drawing.Size(87, 23);
            this.btnBoChon.TabIndex = 17;
            this.btnBoChon.Text = "<< Bỏ Chọn";
            this.btnBoChon.UseVisualStyleBackColor = true;
            this.btnBoChon.Click += new System.EventHandler(this.btnBoChon_Click);
            // 
            // btnDong
            // 
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.Red;
            this.btnDong.Location = new System.Drawing.Point(871, 114);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 93);
            this.btnDong.TabIndex = 18;
            this.btnDong.Text = "Thoát";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // frmThemGiangVienVaoMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 409);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnBoChon);
            this.Controls.Add(this.btnChon);
            this.Controls.Add(this.listGiangVienMon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listGiangVien);
            this.Controls.Add(this.txtThongTinTimKiem);
            this.Controls.Add(this.label5);
            this.Name = "frmThemGiangVienVaoMon";
            this.Text = "Chọn Giảng Viên Cho Môn Học";
            this.Load += new System.EventHandler(this.frmThemGiangVienVaoMon_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmThemGiangVienVaoMon_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listGiangVien;
        private System.Windows.Forms.TextBox txtThongTinTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listGiangVienMon;
        private System.Windows.Forms.Button btnChon;
        private System.Windows.Forms.Button btnBoChon;
        private System.Windows.Forms.Button btnDong;
    }
}