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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSMon)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
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
            this.groupBox1.Size = new System.Drawing.Size(1174, 260);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhập thông tin lớp:";
            // 
            // btnThemLop
            // 
            this.btnThemLop.Location = new System.Drawing.Point(175, 175);
            this.btnThemLop.Name = "btnThemLop";
            this.btnThemLop.Size = new System.Drawing.Size(75, 53);
            this.btnThemLop.TabIndex = 11;
            this.btnThemLop.Text = "Thêm Lớp";
            this.btnThemLop.UseVisualStyleBackColor = true;
            this.btnThemLop.Click += new System.EventHandler(this.btnThemLop_Click);
            // 
            // btnThemMon
            // 
            this.btnThemMon.Location = new System.Drawing.Point(1037, 120);
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
            this.dtgvDSMon.Location = new System.Drawing.Point(648, 40);
            this.dtgvDSMon.Name = "dtgvDSMon";
            this.dtgvDSMon.Size = new System.Drawing.Size(373, 203);
            this.dtgvDSMon.TabIndex = 9;
            this.dtgvDSMon.DataSourceChanged += new System.EventHandler(this.dtgvDSMon_DataSourceChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(557, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Danh Sách Môn:";
            // 
            // txtSoLuongNgoaiNganSach
            // 
            this.txtSoLuongNgoaiNganSach.Location = new System.Drawing.Point(175, 139);
            this.txtSoLuongNgoaiNganSach.Name = "txtSoLuongNgoaiNganSach";
            this.txtSoLuongNgoaiNganSach.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongNgoaiNganSach.TabIndex = 7;
            // 
            // txtSoLuongTrongNganSach
            // 
            this.txtSoLuongTrongNganSach.Location = new System.Drawing.Point(175, 105);
            this.txtSoLuongTrongNganSach.Name = "txtSoLuongTrongNganSach";
            this.txtSoLuongTrongNganSach.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongTrongNganSach.TabIndex = 6;
            // 
            // txtSoLuongSinhVien
            // 
            this.txtSoLuongSinhVien.Location = new System.Drawing.Point(175, 72);
            this.txtSoLuongSinhVien.Name = "txtSoLuongSinhVien";
            this.txtSoLuongSinhVien.Size = new System.Drawing.Size(155, 20);
            this.txtSoLuongSinhVien.TabIndex = 5;
            // 
            // txtTenLop
            // 
            this.txtTenLop.Location = new System.Drawing.Point(175, 37);
            this.txtTenLop.Name = "txtTenLop";
            this.txtTenLop.Size = new System.Drawing.Size(258, 20);
            this.txtTenLop.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số Lượng Ngoài Ngân Sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Số Lượng Trong Ngân Sách:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Số Lượng Sinh Viên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 40);
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
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 260);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1174, 361);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Môn học của lớp:";
            // 
            // frmThemLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1174, 621);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmThemLop";
            this.Text = "Thêm Lớp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThemLop_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDSMon)).EndInit();
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
    }
}