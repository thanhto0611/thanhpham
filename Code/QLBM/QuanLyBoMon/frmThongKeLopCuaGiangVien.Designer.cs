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
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.cbxTatCaNamHoc = new System.Windows.Forms.CheckBox();
            this.cmbNamHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnXoaGiangVien = new System.Windows.Forms.Button();
            this.btnCapNhatGiangVien = new System.Windows.Forms.Button();
            this.txtEmailUpdate = new System.Windows.Forms.TextBox();
            this.txtDiaChiUpdate = new System.Windows.Forms.TextBox();
            this.txtSoDienThoaiUpdate = new System.Windows.Forms.TextBox();
            this.txtTenGiangVienUpdate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.listGiangVien = new System.Windows.Forms.ListBox();
            this.txtThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvDachSachLopCuaGiangVien = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDachSachLopCuaGiangVien)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnXuatExcel);
            this.groupBox1.Controls.Add(this.cbxTatCaNamHoc);
            this.groupBox1.Controls.Add(this.cmbNamHoc);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnXoaGiangVien);
            this.groupBox1.Controls.Add(this.btnCapNhatGiangVien);
            this.groupBox1.Controls.Add(this.txtEmailUpdate);
            this.groupBox1.Controls.Add(this.txtDiaChiUpdate);
            this.groupBox1.Controls.Add(this.txtSoDienThoaiUpdate);
            this.groupBox1.Controls.Add(this.txtTenGiangVienUpdate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.listGiangVien);
            this.groupBox1.Controls.Add(this.txtThongTinTimKiem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1143, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin Giảng Viên:";
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Enabled = false;
            this.btnXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcel.ForeColor = System.Drawing.Color.LimeGreen;
            this.btnXuatExcel.Location = new System.Drawing.Point(991, 128);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(118, 73);
            this.btnXuatExcel.TabIndex = 37;
            this.btnXuatExcel.Text = "Xuất Excel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // cbxTatCaNamHoc
            // 
            this.cbxTatCaNamHoc.AutoSize = true;
            this.cbxTatCaNamHoc.Location = new System.Drawing.Point(960, 44);
            this.cbxTatCaNamHoc.Name = "cbxTatCaNamHoc";
            this.cbxTatCaNamHoc.Size = new System.Drawing.Size(106, 17);
            this.cbxTatCaNamHoc.TabIndex = 36;
            this.cbxTatCaNamHoc.Text = "Tất Cả Năm Học";
            this.cbxTatCaNamHoc.UseVisualStyleBackColor = true;
            this.cbxTatCaNamHoc.CheckedChanged += new System.EventHandler(this.cbxTatCaNamHoc_CheckedChanged);
            // 
            // cmbNamHoc
            // 
            this.cmbNamHoc.FormattingEnabled = true;
            this.cmbNamHoc.Location = new System.Drawing.Point(1018, 19);
            this.cmbNamHoc.Name = "cmbNamHoc";
            this.cmbNamHoc.Size = new System.Drawing.Size(91, 21);
            this.cmbNamHoc.TabIndex = 35;
            this.cmbNamHoc.SelectedIndexChanged += new System.EventHandler(this.cmbNamHoc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(957, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Năm Học:";
            // 
            // btnXoaGiangVien
            // 
            this.btnXoaGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaGiangVien.ForeColor = System.Drawing.Color.Red;
            this.btnXoaGiangVien.Location = new System.Drawing.Point(811, 128);
            this.btnXoaGiangVien.Name = "btnXoaGiangVien";
            this.btnXoaGiangVien.Size = new System.Drawing.Size(154, 73);
            this.btnXoaGiangVien.TabIndex = 33;
            this.btnXoaGiangVien.Text = "Xóa Giảng Viên";
            this.btnXoaGiangVien.UseVisualStyleBackColor = true;
            // 
            // btnCapNhatGiangVien
            // 
            this.btnCapNhatGiangVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatGiangVien.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnCapNhatGiangVien.Location = new System.Drawing.Point(579, 128);
            this.btnCapNhatGiangVien.Name = "btnCapNhatGiangVien";
            this.btnCapNhatGiangVien.Size = new System.Drawing.Size(215, 73);
            this.btnCapNhatGiangVien.TabIndex = 32;
            this.btnCapNhatGiangVien.Text = "Cập Nhật Thông Tin Giảng Viên";
            this.btnCapNhatGiangVien.UseVisualStyleBackColor = true;
            // 
            // txtEmailUpdate
            // 
            this.txtEmailUpdate.Location = new System.Drawing.Point(579, 88);
            this.txtEmailUpdate.Name = "txtEmailUpdate";
            this.txtEmailUpdate.Size = new System.Drawing.Size(348, 20);
            this.txtEmailUpdate.TabIndex = 31;
            // 
            // txtDiaChiUpdate
            // 
            this.txtDiaChiUpdate.Location = new System.Drawing.Point(579, 64);
            this.txtDiaChiUpdate.Name = "txtDiaChiUpdate";
            this.txtDiaChiUpdate.Size = new System.Drawing.Size(348, 20);
            this.txtDiaChiUpdate.TabIndex = 30;
            // 
            // txtSoDienThoaiUpdate
            // 
            this.txtSoDienThoaiUpdate.Location = new System.Drawing.Point(579, 41);
            this.txtSoDienThoaiUpdate.Name = "txtSoDienThoaiUpdate";
            this.txtSoDienThoaiUpdate.Size = new System.Drawing.Size(348, 20);
            this.txtSoDienThoaiUpdate.TabIndex = 29;
            // 
            // txtTenGiangVienUpdate
            // 
            this.txtTenGiangVienUpdate.Location = new System.Drawing.Point(579, 19);
            this.txtTenGiangVienUpdate.Name = "txtTenGiangVienUpdate";
            this.txtTenGiangVienUpdate.Size = new System.Drawing.Size(348, 20);
            this.txtTenGiangVienUpdate.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(538, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Email:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(529, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Địa Chỉ:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(495, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Số Điện Thoại:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(489, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Tên Giảng Viên:";
            // 
            // listGiangVien
            // 
            this.listGiangVien.FormattingEnabled = true;
            this.listGiangVien.Location = new System.Drawing.Point(22, 45);
            this.listGiangVien.Name = "listGiangVien";
            this.listGiangVien.Size = new System.Drawing.Size(399, 173);
            this.listGiangVien.TabIndex = 23;
            this.listGiangVien.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listGiangVien_MouseClick);
            // 
            // txtThongTinTimKiem
            // 
            this.txtThongTinTimKiem.Location = new System.Drawing.Point(107, 19);
            this.txtThongTinTimKiem.Name = "txtThongTinTimKiem";
            this.txtThongTinTimKiem.Size = new System.Drawing.Size(314, 20);
            this.txtThongTinTimKiem.TabIndex = 22;
            this.txtThongTinTimKiem.TextChanged += new System.EventHandler(this.txtThongTinTimKiem_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Tìm Giảng Viên:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvDachSachLopCuaGiangVien);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 237);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1143, 425);
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
            this.dtgvDachSachLopCuaGiangVien.Size = new System.Drawing.Size(1137, 406);
            this.dtgvDachSachLopCuaGiangVien.TabIndex = 0;
            this.dtgvDachSachLopCuaGiangVien.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgvDachSachLopCuaGiangVien_CellFormatting);
            this.dtgvDachSachLopCuaGiangVien.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dtgvDachSachLopCuaGiangVien_CellPainting);
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
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDachSachLopCuaGiangVien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnXoaGiangVien;
        private System.Windows.Forms.Button btnCapNhatGiangVien;
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

    }
}