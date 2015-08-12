namespace QuanLyBoMon
{
    partial class frmThemLop
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemLop = new System.Windows.Forms.Button();
            this.btnThemMon = new System.Windows.Forms.Button();
            this.dtgvDSMon = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSoLuongNgoaiNganSach = new System.Windows.Forms.TextBox();
            this.txtSoLuongTrongNganSach = new System.Windows.Forms.TextBox();
            this.txtSoLuongSinhVien = new System.Windows.Forms.TextBox();
            this.txtTenLop = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtgvChiTietMon = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnCapNhatChiTietMon = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbNamHoc = new System.Windows.Forms.ComboBox();
            this.btnThemNamHoc = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSMon)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietMon)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThemNamHoc);
            this.groupBox1.Controls.Add(this.cmbNamHoc);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnThemLop);
            this.groupBox1.Controls.Add(this.btnThemMon);
            this.groupBox1.Controls.Add(this.dtgvDSMon);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSoLuongNgoaiNganSach);
            this.groupBox1.Controls.Add(this.txtSoLuongTrongNganSach);
            this.groupBox1.Controls.Add(this.txtSoLuongSinhVien);
            this.groupBox1.Controls.Add(this.txtTenLop);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1174, 218);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin lớp:";
            // 
            // btnThemLop
            // 
            this.btnThemLop.Location = new System.Drawing.Point(175, 154);
            this.btnThemLop.Name = "btnThemLop";
            this.btnThemLop.Size = new System.Drawing.Size(75, 53);
            this.btnThemLop.TabIndex = 11;
            this.btnThemLop.Text = "Thêm Lớp";
            this.btnThemLop.UseVisualStyleBackColor = true;
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(1037, 99);
            this.btnThemMon.Name = "btnThemMon";
            this.btnThemMon.Size = new System.Drawing.Size(75, 23);
            this.btnThemMon.TabIndex = 10;
            this.btnThemMon.Text = "Thêm Môn";
            this.btnThemMon.UseVisualStyleBackColor = true;
            this.btnThemMon.Click += new System.EventHandler(this.btnThemMon_Click);
            // 
            // dtgvDSMon
            // 
            this.dtgvDSMon.AllowUserToAddRows = false;
            this.dtgvDSMon.AllowUserToDeleteRows = false;
            this.dtgvDSMon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgvDSMon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDSMon.Location = new System.Drawing.Point(648, 19);
            this.dtgvDSMon.Name = "dtgvDSMon";
            this.dtgvDSMon.Size = new System.Drawing.Size(373, 188);
            this.dtgvDSMon.TabIndex = 9;
            this.dtgvDSMon.DataSourceChanged += new System.EventHandler(this.dtgvDSMon_DataSourceChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Danh Sách Môn:";
            // 
            // txtSoLuongNgoaiNganSach
            // 
            this.txtSoLuongNgoaiNganSach.Location = new System.Drawing.Point(175, 118);
            this.txtSoLuongNgoaiNganSach.Name = "txtSoLuongNgoaiNganSach";
            this.txtSoLuongNgoaiNganSach.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongNgoaiNganSach.TabIndex = 7;
            // 
            // txtSoLuongTrongNganSach
            // 
            this.txtSoLuongTrongNganSach.Location = new System.Drawing.Point(175, 84);
            this.txtSoLuongTrongNganSach.Name = "txtSoLuongTrongNganSach";
            this.txtSoLuongTrongNganSach.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongTrongNganSach.TabIndex = 6;
            // 
            // txtSoLuongSinhVien
            // 
            this.txtSoLuongSinhVien.Location = new System.Drawing.Point(175, 51);
            this.txtSoLuongSinhVien.Name = "txtSoLuongSinhVien";
            this.txtSoLuongSinhVien.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongSinhVien.TabIndex = 5;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(175, 16);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(258, 20);
            this.txtTenLop.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số Lượng Ngoài Ngân Sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Lượng Trong Ngân Sách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Lượng Sinh Viên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Lớp:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1174, 506);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Môn học của lớp:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtgvChiTietMon);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1168, 408);
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
            this.dtgvChiTietMon.Size = new System.Drawing.Size(1162, 389);
            this.dtgvChiTietMon.TabIndex = 0;
            this.dtgvChiTietMon.Visible = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnCapNhatChiTietMon);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1168, 79);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(377, 54);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Năm học:";
            // 
            // cmbNamHoc
            // 
            this.cmbNamHoc.FormattingEnabled = true;
            this.cmbNamHoc.Location = new System.Drawing.Point(436, 51);
            this.cmbNamHoc.Name = "cmbNamHoc";
            this.cmbNamHoc.Size = new System.Drawing.Size(91, 21);
            this.cmbNamHoc.TabIndex = 13;
            // 
            // btnThemNamHoc
            // 
            this.btnThemNamHoc.Location = new System.Drawing.Point(422, 91);
            this.btnThemNamHoc.Name = "btnThemNamHoc";
            this.btnThemNamHoc.Size = new System.Drawing.Size(105, 23);
            this.btnThemNamHoc.TabIndex = 14;
            this.btnThemNamHoc.Text = "Thêm Năm Học";
            this.btnThemNamHoc.UseVisualStyleBackColor = true;
            this.btnThemNamHoc.Click += new System.EventHandler(this.btnThemNamHoc_Click);
            // 
            // frmThemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 724);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThemLop";
            this.Text = "Thêm Lớp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThemLop_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmThemLop_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSMon)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChiTietMon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSoLuongSinhVien;
        private System.Windows.Forms.TextBox txtTenLop;
        private System.Windows.Forms.TextBox txtSoLuongNgoaiNganSach;
        private System.Windows.Forms.TextBox txtSoLuongTrongNganSach;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dtgvDSMon;
        private System.Windows.Forms.Button btnThemMon;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnThemLop;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dtgvChiTietMon;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnCapNhatChiTietMon;
        private System.Windows.Forms.ComboBox cmbNamHoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnThemNamHoc;
    }
}