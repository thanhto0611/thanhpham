namespace QuanLyBoMon
{
    partial class frmTimKiemLop
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChonLop = new System.Windows.Forms.Button();
            this.txtSoLuongNgoaiNganSach = new System.Windows.Forms.TextBox();
            this.txtSoLuongTrongNganSach = new System.Windows.Forms.TextBox();
            this.txtSoLuongSinhVien = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.listLop = new System.Windows.Forms.ListBox();
            this.txtSearchTenLop = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtgvChiTietMon = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCapNhatChiTietMon = new System.Windows.Forms.Button();
            this.btnCapNhatLop = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietMon)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCapNhatLop);
            this.groupBox1.Controls.Add(this.btnChonLop);
            this.groupBox1.Controls.Add(this.txtSoLuongNgoaiNganSach);
            this.groupBox1.Controls.Add(this.txtSoLuongTrongNganSach);
            this.groupBox1.Controls.Add(this.txtSoLuongSinhVien);
            this.groupBox1.Controls.Add(this.txtTenLop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.listLop);
            this.groupBox1.Controls.Add(this.txtSearchTenLop);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1172, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm Kiếm";
            // 
            // btnChonLop
            // 
            this.btnChonLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChonLop.ForeColor = System.Drawing.Color.Red;
            this.btnChonLop.Location = new System.Drawing.Point(310, 24);
            this.btnChonLop.Name = "btnChonLop";
            this.btnChonLop.Size = new System.Drawing.Size(99, 55);
            this.btnChonLop.TabIndex = 16;
            this.btnChonLop.Text = "Chọn Lớp";
            this.btnChonLop.UseVisualStyleBackColor = true;
            this.btnChonLop.Visible = false;
            this.btnChonLop.Click += new System.EventHandler(this.btnChonLop_Click);
            // 
            // txtSoLuongNgoaiNganSach
            // 
            this.txtSoLuongNgoaiNganSach.Location = new System.Drawing.Point(602, 130);
            this.txtSoLuongNgoaiNganSach.Name = "txtSoLuongNgoaiNganSach";
            this.txtSoLuongNgoaiNganSach.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongNgoaiNganSach.TabIndex = 15;
            // 
            // txtSoLuongTrongNganSach
            // 
            this.txtSoLuongTrongNganSach.Location = new System.Drawing.Point(602, 96);
            this.txtSoLuongTrongNganSach.Name = "txtSoLuongTrongNganSach";
            this.txtSoLuongTrongNganSach.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongTrongNganSach.TabIndex = 14;
            // 
            // txtSoLuongSinhVien
            // 
            this.txtSoLuongSinhVien.Location = new System.Drawing.Point(602, 63);
            this.txtSoLuongSinhVien.Name = "txtSoLuongSinhVien";
            this.txtSoLuongSinhVien.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongSinhVien.TabIndex = 13;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(602, 28);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(258, 20);
            this.txtTenLop.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(452, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Số Lượng Ngoài Ngân Sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(452, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Số Lượng Trong Ngân Sách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(492, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Số Lượng Sinh Viên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(546, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tên Lớp:";
            // 
            // listLop
            // 
            this.listLop.FormattingEnabled = true;
            this.listLop.Location = new System.Drawing.Point(36, 50);
            this.listLop.Name = "listLop";
            this.listLop.Size = new System.Drawing.Size(257, 95);
            this.listLop.TabIndex = 2;
            this.listLop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listLop_MouseClick);
            // 
            // txtSearchTenLop
            // 
            this.txtSearchTenLop.Location = new System.Drawing.Point(89, 24);
            this.txtSearchTenLop.Name = "txtSearchTenLop";
            this.txtSearchTenLop.Size = new System.Drawing.Size(204, 20);
            this.txtSearchTenLop.TabIndex = 1;
            this.txtSearchTenLop.TextChanged += new System.EventHandler(this.txtSearchTenLop_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Lớp:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 172);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1172, 417);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Môn học của lớp:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtgvChiTietMon);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1166, 319);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Danh sách môn học của lớp:";
            // 
            // dtgvChiTietMon
            // 
            this.dtgvChiTietMon.AllowUserToAddRows = false;
            this.dtgvChiTietMon.AllowUserToDeleteRows = false;
            this.dtgvChiTietMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgvChiTietMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChiTietMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChiTietMon.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgvChiTietMon.Location = new System.Drawing.Point(3, 16);
            this.dtgvChiTietMon.Name = "dtgvChiTietMon";
            this.dtgvChiTietMon.Size = new System.Drawing.Size(1160, 300);
            this.dtgvChiTietMon.TabIndex = 0;
            this.dtgvChiTietMon.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCapNhatChiTietMon);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1166, 79);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // btnCapNhatChiTietMon
            // 
            this.btnCapNhatChiTietMon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatChiTietMon.ForeColor = System.Drawing.Color.Red;
            this.btnCapNhatChiTietMon.Location = new System.Drawing.Point(468, 19);
            this.btnCapNhatChiTietMon.Name = "btnCapNhatChiTietMon";
            this.btnCapNhatChiTietMon.Size = new System.Drawing.Size(160, 49);
            this.btnCapNhatChiTietMon.TabIndex = 0;
            this.btnCapNhatChiTietMon.Text = "Cập Nhật Chi Tiết Môn";
            this.btnCapNhatChiTietMon.UseVisualStyleBackColor = true;
            this.btnCapNhatChiTietMon.Visible = false;
            this.btnCapNhatChiTietMon.Click += new System.EventHandler(this.btnCapNhatChiTietMon_Click);
            // 
            // btnCapNhatLop
            // 
            this.btnCapNhatLop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatLop.ForeColor = System.Drawing.Color.Red;
            this.btnCapNhatLop.Location = new System.Drawing.Point(885, 25);
            this.btnCapNhatLop.Name = "btnCapNhatLop";
            this.btnCapNhatLop.Size = new System.Drawing.Size(138, 52);
            this.btnCapNhatLop.TabIndex = 17;
            this.btnCapNhatLop.Text = "Cập Nhật Lớp";
            this.btnCapNhatLop.UseVisualStyleBackColor = true;
            this.btnCapNhatLop.Click += new System.EventHandler(this.btnCapNhatLop_Click);
            // 
            // frmTimKiemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1172, 589);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTimKiemLop";
            this.Text = "Tìm Kiếm Lớp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmTimKiemLop_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietMon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtSearchTenLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listLop;
        private System.Windows.Forms.TextBox txtSoLuongNgoaiNganSach;
        private System.Windows.Forms.TextBox txtSoLuongTrongNganSach;
        private System.Windows.Forms.TextBox txtSoLuongSinhVien;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnChonLop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dtgvChiTietMon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCapNhatChiTietMon;
        private System.Windows.Forms.Button btnCapNhatLop;
    }
}