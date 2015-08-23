namespace QuanLyBoMon
{
    partial class frmThongKeLopCuaGiangVien
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.rtxtEmailContent = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmailSubject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFromEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listGiangVien = new System.Windows.Forms.ListBox();
            this.txtThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxTatCaNamHoc = new System.Windows.Forms.CheckBox();
            this.txtTenGiangVienUpdate = new System.Windows.Forms.TextBox();
            this.cmbNamHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEmailUpdate = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiaChiUpdate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSoDienThoaiUpdate = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvDachSachLopCuaGiangVien = new System.Windows.Forms.DataGridView();
            this.btnSendEmailToAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDachSachLopCuaGiangVien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1143, 247);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSendEmailToAll);
            this.groupBox4.Controls.Add(this.rtxtEmailContent);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtEmailSubject);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtPassword);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtFromEmail);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.btnSendEmail);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(576, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(564, 228);
            this.groupBox4.TabIndex = 40;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Gửi Email:";
            // 
            // rtxtEmailContent
            // 
            this.rtxtEmailContent.Location = new System.Drawing.Point(23, 113);
            this.rtxtEmailContent.Name = "rtxtEmailContent";
            this.rtxtEmailContent.Size = new System.Drawing.Size(391, 104);
            this.rtxtEmailContent.TabIndex = 46;
            this.rtxtEmailContent.Text = "Kính gửi quý thầy cô lịch giảng dạy xxx. Nếu có gì sai sót xin quý th" +
                "ầy cô phản ánh lại cho giáo vụ, để giáo vụ kiểm tra và chỉnh sửa ki" +
                "̣p thời.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 45;
            this.label10.Text = "Nội Dung Email:";
            // 
            // txtEmailSubject
            // 
            this.txtEmailSubject.Location = new System.Drawing.Point(102, 63);
            this.txtEmailSubject.Name = "txtEmailSubject";
            this.txtEmailSubject.Size = new System.Drawing.Size(312, 20);
            this.txtEmailSubject.TabIndex = 44;
            this.txtEmailSubject.Text = "LỊCH GIẢNG DẠY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Tiêu Đề Email:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(404, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(142, 20);
            this.txtPassword.TabIndex = 42;
            this.txtPassword.Text = "Pnht!01188";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Password:";
            // 
            // txtFromEmail
            // 
            this.txtFromEmail.Location = new System.Drawing.Point(78, 21);
            this.txtFromEmail.Name = "txtFromEmail";
            this.txtFromEmail.Size = new System.Drawing.Size(221, 20);
            this.txtFromEmail.TabIndex = 40;
            this.txtFromEmail.Text = "thanh.pham611@gmail.com";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 39;
            this.label2.Text = "Email gửi:";
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Enabled = false;
            this.btnSendEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmail.ForeColor = System.Drawing.Color.Blue;
            this.btnSendEmail.Location = new System.Drawing.Point(433, 63);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(125, 73);
            this.btnSendEmail.TabIndex = 38;
            this.btnSendEmail.Text = "Gửi Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.listGiangVien);
            this.groupBox3.Controls.Add(this.txtThongTinTimKiem);
            this.groupBox3.Controls.Add(this.btnXuatExcel);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.cbxTatCaNamHoc);
            this.groupBox3.Controls.Add(this.txtTenGiangVienUpdate);
            this.groupBox3.Controls.Add(this.cmbNamHoc);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtEmailUpdate);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtDiaChiUpdate);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtSoDienThoaiUpdate);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(573, 228);
            this.groupBox3.TabIndex = 39;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông Tin Giảng Viên:";
            // 
            // listGiangVien
            // 
            this.listGiangVien.FormattingEnabled = true;
            this.listGiangVien.Location = new System.Drawing.Point(9, 44);
            this.listGiangVien.Name = "listGiangVien";
            this.listGiangVien.Size = new System.Drawing.Size(246, 173);
            this.listGiangVien.TabIndex = 23;
            this.listGiangVien.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listGiangVien_MouseClick);
            // 
            // txtThongTinTimKiem
            // 
            this.txtThongTinTimKiem.Location = new System.Drawing.Point(94, 18);
            this.txtThongTinTimKiem.Name = "txtThongTinTimKiem";
            this.txtThongTinTimKiem.Size = new System.Drawing.Size(161, 20);
            this.txtThongTinTimKiem.TabIndex = 22;
            this.txtThongTinTimKiem.TextChanged += new System.EventHandler(this.txtThongTinTimKiem_TextChanged);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Enabled = false;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnXuatExcel.Location = new System.Drawing.Point(446, 129);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(118, 73);
            this.btnXuatExcel.TabIndex = 37;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tìm Giảng Viên:";
            // 
            // cbxTatCaNamHoc
            // 
            this.cbxTatCaNamHoc.AutoSize = true;
            this.cbxTatCaNamHoc.Location = new System.Drawing.Point(277, 154);
            this.cbxTatCaNamHoc.Name = "cbxTatCaNamHoc";
            this.cbxTatCaNamHoc.Size = new System.Drawing.Size(106, 17);
            this.cbxTatCaNamHoc.TabIndex = 36;
            this.cbxTatCaNamHoc.Text = "Tất Cả Năm Học";
            this.cbxTatCaNamHoc.UseVisualStyleBackColor = true;
            this.cbxTatCaNamHoc.CheckedChanged += new System.EventHandler(this.cbxTatCaNamHoc_CheckedChanged);
            // 
            // txtTenGiangVienUpdate
            // 
            this.txtTenGiangVienUpdate.Location = new System.Drawing.Point(373, 21);
            this.txtTenGiangVienUpdate.Name = "txtTenGiangVienUpdate";
            this.txtTenGiangVienUpdate.Size = new System.Drawing.Size(191, 20);
            this.txtTenGiangVienUpdate.TabIndex = 28;
            // 
            // cmbNamHoc
            // 
            this.cmbNamHoc.FormattingEnabled = true;
            this.cmbNamHoc.Location = new System.Drawing.Point(335, 129);
            this.cmbNamHoc.Name = "cmbNamHoc";
            this.cmbNamHoc.Size = new System.Drawing.Size(91, 21);
            this.cmbNamHoc.TabIndex = 35;
            this.cmbNamHoc.SelectedIndexChanged += new System.EventHandler(this.cmbNamHoc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Năm Học:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(283, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Tên Giảng Viên:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(289, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Số Điện Thoại:";
            // 
            // txtEmailUpdate
            // 
            this.txtEmailUpdate.Location = new System.Drawing.Point(373, 90);
            this.txtEmailUpdate.Name = "txtEmailUpdate";
            this.txtEmailUpdate.Size = new System.Drawing.Size(191, 20);
            this.txtEmailUpdate.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(323, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Địa Chỉ:";
            // 
            // txtDiaChiUpdate
            // 
            this.txtDiaChiUpdate.Location = new System.Drawing.Point(373, 66);
            this.txtDiaChiUpdate.Name = "txtDiaChiUpdate";
            this.txtDiaChiUpdate.Size = new System.Drawing.Size(191, 20);
            this.txtDiaChiUpdate.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(332, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Email:";
            // 
            // txtSoDienThoaiUpdate
            // 
            this.txtSoDienThoaiUpdate.Location = new System.Drawing.Point(373, 43);
            this.txtSoDienThoaiUpdate.Name = "txtSoDienThoaiUpdate";
            this.txtSoDienThoaiUpdate.Size = new System.Drawing.Size(191, 20);
            this.txtSoDienThoaiUpdate.TabIndex = 29;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvDachSachLopCuaGiangVien);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 247);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1143, 415);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh Sách Lớp Của Giảng Viên:";
            // 
            // dtgvDachSachLopCuaGiangVien
            // 
            this.dtgvDachSachLopCuaGiangVien.AllowUserToAddRows = false;
            this.dtgvDachSachLopCuaGiangVien.AllowUserToDeleteRows = false;
            this.dtgvDachSachLopCuaGiangVien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgvDachSachLopCuaGiangVien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvDachSachLopCuaGiangVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDachSachLopCuaGiangVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDachSachLopCuaGiangVien.Location = new System.Drawing.Point(3, 16);
            this.dtgvDachSachLopCuaGiangVien.Name = "dtgvDachSachLopCuaGiangVien";
            this.dtgvDachSachLopCuaGiangVien.ReadOnly = true;
            this.dtgvDachSachLopCuaGiangVien.Size = new System.Drawing.Size(1137, 396);
            this.dtgvDachSachLopCuaGiangVien.TabIndex = 0;
            this.dtgvDachSachLopCuaGiangVien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgvDachSachLopCuaGiangVien_CellFormatting);
            this.dtgvDachSachLopCuaGiangVien.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgvDachSachLopCuaGiangVien_CellPainting);
            // 
            // btnSendEmailToAll
            // 
            this.btnSendEmailToAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendEmailToAll.ForeColor = System.Drawing.Color.Red;
            this.btnSendEmailToAll.Location = new System.Drawing.Point(433, 144);
            this.btnSendEmailToAll.Name = "btnSendEmailToAll";
            this.btnSendEmailToAll.Size = new System.Drawing.Size(125, 73);
            this.btnSendEmailToAll.TabIndex = 47;
            this.btnSendEmailToAll.Text = "Gửi Email Cho Tất Cả Giảng Viên";
            this.btnSendEmailToAll.UseVisualStyleBackColor = true;
            this.btnSendEmailToAll.Click += new System.EventHandler(this.btnSendEmailToAll_Click);
            // 
            // frmThongKeLopCuaGiangVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 662);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmThongKeLopCuaGiangVien";
            this.Text = "Thống Kê Lớp Theo Giảng Viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmThongKeLopCuaGiangVien_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDachSachLopCuaGiangVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEmailUpdate;
        private System.Windows.Forms.TextBox txtDiaChiUpdate;
        private System.Windows.Forms.TextBox txtSoDienThoaiUpdate;
        private System.Windows.Forms.TextBox txtTenGiangVienUpdate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listGiangVien;
        private System.Windows.Forms.TextBox txtThongTinTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvDachSachLopCuaGiangVien;
        private System.Windows.Forms.CheckBox cbxTatCaNamHoc;
        private System.Windows.Forms.ComboBox cmbNamHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFromEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtxtEmailContent;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmailSubject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSendEmailToAll;

    }
}