namespace VietjetAir
{
    partial class Form1
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
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtTest = new System.Windows.Forms.TextBox();
            this.timerChonNgayBay = new System.Windows.Forms.Timer(this.components);
            this.btnCheck = new System.Windows.Forms.Button();
            this.timerCheckRefresh = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtNgayBay = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cbBag = new System.Windows.Forms.ComboBox();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtGiaVe = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtThangBay = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDenGio = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTuGio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtDiDong = new System.Windows.Forms.TextBox();
            this.txtThanhPho = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtgvThongTinHanhKhach = new System.Windows.Forms.DataGridView();
            this.GioiTinh = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDemTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KemEmBe = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongTinHanhKhach)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(380, 32);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 6;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(48, 34);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(307, 20);
            this.txtUrl.TabIndex = 5;
            this.txtUrl.Text = "http://www.vietjetair.com/Sites/Web/vi-VN/Home";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "URL:";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 16);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1238, 384);
            this.webBrowser1.TabIndex = 7;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // txtTest
            // 
            this.txtTest.Location = new System.Drawing.Point(129, 60);
            this.txtTest.Name = "txtTest";
            this.txtTest.Size = new System.Drawing.Size(100, 20);
            this.txtTest.TabIndex = 8;
            // 
            // timerChonNgayBay
            // 
            this.timerChonNgayBay.Interval = 2000;
            this.timerChonNgayBay.Tick += new System.EventHandler(this.timerChonNgayBay_Tick);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(380, 60);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 9;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // timerCheckRefresh
            // 
            this.timerCheckRefresh.Tick += new System.EventHandler(this.timerCheckRefresh_Tick);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTest);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 108);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.dtgvThongTinHanhKhach);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1244, 317);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(503, 43);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 49);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtNgayBay);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.cbBag);
            this.groupBox5.Controls.Add(this.cbTo);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.cbFrom);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.txtGiaVe);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.txtThangBay);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.txtDenGio);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtTuGio);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Location = new System.Drawing.Point(585, 136);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(647, 175);
            this.groupBox5.TabIndex = 13;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông tin chuyến bay";
            // 
            // txtNgayBay
            // 
            this.txtNgayBay.Location = new System.Drawing.Point(50, 80);
            this.txtNgayBay.Name = "txtNgayBay";
            this.txtNgayBay.Size = new System.Drawing.Size(215, 20);
            this.txtNgayBay.TabIndex = 17;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(406, 116);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(50, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Hành Lý:";
            // 
            // cbBag
            // 
            this.cbBag.FormattingEnabled = true;
            this.cbBag.Items.AddRange(new object[] {
            "Không, Cảm ơn",
            "Gói (Bag) 15kgs",
            "Gói (Bag) 20kgs",
            "Gói (Bag) 25kgs",
            "Gói (Bag) 30kgs"});
            this.cbBag.Location = new System.Drawing.Point(476, 113);
            this.cbBag.Name = "cbBag";
            this.cbBag.Size = new System.Drawing.Size(152, 21);
            this.cbBag.TabIndex = 15;
            // 
            // cbTo
            // 
            this.cbTo.FormattingEnabled = true;
            this.cbTo.Items.AddRange(new object[] {
            "Tp. Hồ Chí Minh",
            "Hà Nội",
            "Đà Nẵng",
            "Nha Trang",
            "Hải Phòng",
            "Huế",
            "Vinh",
            "Phú Quốc",
            "Đà Lạt",
            "Bangkok",
            "Buôn Mê Thuột",
            "Quy Nhơn"});
            this.cbTo.Location = new System.Drawing.Point(476, 75);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(121, 21);
            this.cbTo.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(426, 78);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Đến:";
            // 
            // cbFrom
            // 
            this.cbFrom.FormattingEnabled = true;
            this.cbFrom.Items.AddRange(new object[] {
            "Tp. Hồ Chí Minh",
            "Hà Nội",
            "Đà Nẵng",
            "Nha Trang",
            "Hải Phòng",
            "Huế",
            "Vinh",
            "Phú Quốc",
            "Đà Lạt",
            "Bangkok",
            "Buôn Mê Thuột",
            "Quy Nhơn"});
            this.cbFrom.Location = new System.Drawing.Point(476, 22);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(121, 21);
            this.cbFrom.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(433, 25);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Từ:";
            // 
            // txtGiaVe
            // 
            this.txtGiaVe.Location = new System.Drawing.Point(50, 124);
            this.txtGiaVe.Name = "txtGiaVe";
            this.txtGiaVe.Size = new System.Drawing.Size(65, 20);
            this.txtGiaVe.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(31, 106);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Giá Vé:";
            // 
            // txtThangBay
            // 
            this.txtThangBay.Location = new System.Drawing.Point(50, 36);
            this.txtThangBay.Name = "txtThangBay";
            this.txtThangBay.Size = new System.Drawing.Size(65, 20);
            this.txtThangBay.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Tháng Bay:";
            // 
            // txtDenGio
            // 
            this.txtDenGio.Location = new System.Drawing.Point(329, 81);
            this.txtDenGio.Name = "txtDenGio";
            this.txtDenGio.Size = new System.Drawing.Size(59, 20);
            this.txtDenGio.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Đến:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(300, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Từ:";
            // 
            // txtTuGio
            // 
            this.txtTuGio.Location = new System.Drawing.Point(329, 42);
            this.txtTuGio.Name = "txtTuGio";
            this.txtTuGio.Size = new System.Drawing.Size(59, 20);
            this.txtTuGio.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(279, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Giờ Bay:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ngày Bay:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtDiDong);
            this.groupBox4.Controls.Add(this.txtThanhPho);
            this.groupBox4.Controls.Add(this.txtDiaChi);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Location = new System.Drawing.Point(585, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(628, 100);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin liên hệ";
            // 
            // txtDiDong
            // 
            this.txtDiDong.Location = new System.Drawing.Point(106, 60);
            this.txtDiDong.Name = "txtDiDong";
            this.txtDiDong.Size = new System.Drawing.Size(114, 20);
            this.txtDiDong.TabIndex = 5;
            // 
            // txtThanhPho
            // 
            this.txtThanhPho.Location = new System.Drawing.Point(106, 39);
            this.txtThanhPho.Name = "txtThanhPho";
            this.txtThanhPho.Size = new System.Drawing.Size(193, 20);
            this.txtThanhPho.TabIndex = 4;
            this.txtThanhPho.Text = "Ho Chi Minh";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(106, 18);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(323, 20);
            this.txtDiaChi.TabIndex = 3;
            this.txtDiaChi.Text = "790/100 Nguyen Kiem";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Di Động:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Thành Phố:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Địa Chỉ:";
            // 
            // dtgvThongTinHanhKhach
            // 
            this.dtgvThongTinHanhKhach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dtgvThongTinHanhKhach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvThongTinHanhKhach.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GioiTinh,
            this.Ho,
            this.TenDemTen,
            this.KemEmBe});
            this.dtgvThongTinHanhKhach.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgvThongTinHanhKhach.Location = new System.Drawing.Point(3, 126);
            this.dtgvThongTinHanhKhach.Name = "dtgvThongTinHanhKhach";
            this.dtgvThongTinHanhKhach.Size = new System.Drawing.Size(524, 150);
            this.dtgvThongTinHanhKhach.TabIndex = 11;
            this.dtgvThongTinHanhKhach.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgvThongTinHanhKhach_RowPostPaint);
            this.dtgvThongTinHanhKhach.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvThongTinHanhKhach_CellClick);
            // 
            // GioiTinh
            // 
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.Items.AddRange(new object[] {
            "Ông",
            "Bà/Cô"});
            this.GioiTinh.Name = "GioiTinh";
            this.GioiTinh.Width = 48;
            // 
            // Ho
            // 
            this.Ho.HeaderText = "Họ";
            this.Ho.Name = "Ho";
            this.Ho.Width = 46;
            // 
            // TenDemTen
            // 
            this.TenDemTen.HeaderText = "Tên Đệm và Tên";
            this.TenDemTen.Name = "TenDemTen";
            this.TenDemTen.Width = 87;
            // 
            // KemEmBe
            // 
            this.KemEmBe.HeaderText = "Kèm Em Bé";
            this.KemEmBe.Name = "KemEmBe";
            this.KemEmBe.Width = 50;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.webBrowser1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 317);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1244, 403);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Web";
            // 
            // timer2
            // 
            this.timer2.Interval = 8000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 720);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvThongTinHanhKhach)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtTest;
        private System.Windows.Forms.Timer timerChonNgayBay;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Timer timerCheckRefresh;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dtgvThongTinHanhKhach;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtDiDong;
        private System.Windows.Forms.TextBox txtThanhPho;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDenGio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTuGio;
        private System.Windows.Forms.TextBox txtThangBay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGiaVe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbFrom;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbTo;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataGridViewComboBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ho;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDemTen;
        private System.Windows.Forms.DataGridViewCheckBoxColumn KemEmBe;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbBag;
        private System.Windows.Forms.TextBox txtNgayBay;
        private System.Windows.Forms.Timer timer2;
    }
}

