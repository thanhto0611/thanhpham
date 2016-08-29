namespace Presentation
{
    partial class frmChiTietDonHang
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
            this.tabDonHang = new System.Windows.Forms.TabControl();
            this.tabThemDonHang = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbmTrangThai = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPhiVanChuyen = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.rdGiaLe = new System.Windows.Forms.RadioButton();
            this.label16 = new System.Windows.Forms.Label();
            this.rdGiaSi = new System.Windows.Forms.RadioButton();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnCapNhatDonHang = new System.Windows.Forms.Button();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTKNganHang = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFacebook = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDienThoai = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tabDonHang.SuspendLayout();
            this.tabThemDonHang.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachSanPham)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDonHang
            // 
            this.tabDonHang.Controls.Add(this.tabThemDonHang);
            this.tabDonHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDonHang.Location = new System.Drawing.Point(0, 0);
            this.tabDonHang.Name = "tabDonHang";
            this.tabDonHang.SelectedIndex = 0;
            this.tabDonHang.Size = new System.Drawing.Size(1158, 548);
            this.tabDonHang.TabIndex = 1;
            // 
            // tabThemDonHang
            // 
            this.tabThemDonHang.BackColor = System.Drawing.Color.Transparent;
            this.tabThemDonHang.Controls.Add(this.groupBox3);
            this.tabThemDonHang.Controls.Add(this.groupBox2);
            this.tabThemDonHang.Location = new System.Drawing.Point(4, 22);
            this.tabThemDonHang.Name = "tabThemDonHang";
            this.tabThemDonHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabThemDonHang.Size = new System.Drawing.Size(1150, 522);
            this.tabThemDonHang.TabIndex = 1;
            this.tabThemDonHang.Text = "Chi Tiết Đơn Hàng";
            this.tabThemDonHang.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 101);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1144, 418);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtgvDanhSachSanPham);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 93);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1138, 322);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Danh sách sản phẩm của đơn hàng:";
            // 
            // dtgvDanhSachSanPham
            // 
            this.dtgvDanhSachSanPham.AllowUserToAddRows = false;
            this.dtgvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDanhSachSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvDanhSachSanPham.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgvDanhSachSanPham.Location = new System.Drawing.Point(3, 16);
            this.dtgvDanhSachSanPham.Name = "dtgvDanhSachSanPham";
            this.dtgvDanhSachSanPham.Size = new System.Drawing.Size(1132, 303);
            this.dtgvDanhSachSanPham.TabIndex = 0;
            this.dtgvDanhSachSanPham.Sorted += new System.EventHandler(this.dtgvDanhSachSanPham_Sorted);
            this.dtgvDanhSachSanPham.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSachSanPham_CellMouseLeave);
            this.dtgvDanhSachSanPham.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSachSanPham_CellMouseEnter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbmTrangThai);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.txtPhiVanChuyen);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.rdGiaLe);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.rdGiaSi);
            this.groupBox4.Controls.Add(this.lbTongTien);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.lbSoLuong);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.btnCapNhatDonHang);
            this.groupBox4.Controls.Add(this.txtMaSanPham);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1138, 77);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông tin đơn hàng:";
            // 
            // cbmTrangThai
            // 
            this.cbmTrangThai.FormattingEnabled = true;
            this.cbmTrangThai.Items.AddRange(new object[] {
            "Mới đặt",
            "Hoàn tất"});
            this.cbmTrangThai.Location = new System.Drawing.Point(809, 44);
            this.cbmTrangThai.Name = "cbmTrangThai";
            this.cbmTrangThai.Size = new System.Drawing.Size(99, 21);
            this.cbmTrangThai.TabIndex = 15;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(745, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Trạng thái:";
            // 
            // txtPhiVanChuyen
            // 
            this.txtPhiVanChuyen.Location = new System.Drawing.Point(809, 18);
            this.txtPhiVanChuyen.Name = "txtPhiVanChuyen";
            this.txtPhiVanChuyen.Size = new System.Drawing.Size(99, 20);
            this.txtPhiVanChuyen.TabIndex = 13;
            this.txtPhiVanChuyen.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(717, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Phí vận chuyển:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(638, 30);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 20);
            this.label17.TabIndex = 11;
            this.label17.Text = "VNĐ";
            // 
            // rdGiaLe
            // 
            this.rdGiaLe.AutoSize = true;
            this.rdGiaLe.Checked = true;
            this.rdGiaLe.Location = new System.Drawing.Point(101, 48);
            this.rdGiaLe.Name = "rdGiaLe";
            this.rdGiaLe.Size = new System.Drawing.Size(52, 17);
            this.rdGiaLe.TabIndex = 10;
            this.rdGiaLe.TabStop = true;
            this.rdGiaLe.Text = "Giá lẻ";
            this.rdGiaLe.UseVisualStyleBackColor = true;
            this.rdGiaLe.CheckedChanged += new System.EventHandler(this.rdGiaLe_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(33, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(57, 13);
            this.label16.TabIndex = 9;
            this.label16.Text = "Tính theo:";
            // 
            // rdGiaSi
            // 
            this.rdGiaSi.AutoSize = true;
            this.rdGiaSi.Location = new System.Drawing.Point(177, 48);
            this.rdGiaSi.Name = "rdGiaSi";
            this.rdGiaSi.Size = new System.Drawing.Size(51, 17);
            this.rdGiaSi.TabIndex = 8;
            this.rdGiaSi.Text = "Giá sỉ";
            this.rdGiaSi.UseVisualStyleBackColor = true;
            this.rdGiaSi.CheckedChanged += new System.EventHandler(this.rdGiaSi_CheckedChanged);
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.Color.Red;
            this.lbTongTien.Location = new System.Drawing.Point(550, 27);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(70, 24);
            this.lbTongTien.TabIndex = 7;
            this.lbTongTien.Text = "label16";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(489, 35);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(55, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Tổng tiền:";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.ForeColor = System.Drawing.Color.Red;
            this.lbSoLuong.Location = new System.Drawing.Point(393, 27);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(44, 24);
            this.lbSoLuong.TabIndex = 5;
            this.lbSoLuong.Text = "asdf";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(286, 35);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 4;
            this.label14.Text = "Số lượng sản phẩm:";
            // 
            // btnCapNhatDonHang
            // 
            this.btnCapNhatDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatDonHang.ForeColor = System.Drawing.Color.Blue;
            this.btnCapNhatDonHang.Location = new System.Drawing.Point(936, 11);
            this.btnCapNhatDonHang.Name = "btnCapNhatDonHang";
            this.btnCapNhatDonHang.Size = new System.Drawing.Size(184, 59);
            this.btnCapNhatDonHang.TabIndex = 3;
            this.btnCapNhatDonHang.Text = "Cập Nhật Đơn Hàng";
            this.btnCapNhatDonHang.UseVisualStyleBackColor = true;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Location = new System.Drawing.Point(101, 22);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(115, 20);
            this.txtMaSanPham.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Mã sản phẩm:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTKNganHang);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtFacebook);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtEmail);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDienThoai);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDiaChi);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMaKH);
            this.groupBox2.Controls.Add(this.txtTenKH);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1144, 98);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng:";
            // 
            // txtTKNganHang
            // 
            this.txtTKNganHang.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTKNganHang.Location = new System.Drawing.Point(576, 63);
            this.txtTKNganHang.Name = "txtTKNganHang";
            this.txtTKNganHang.ReadOnly = true;
            this.txtTKNganHang.Size = new System.Drawing.Size(350, 20);
            this.txtTKNganHang.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(491, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "TK Ngân Hàng";
            // 
            // txtFacebook
            // 
            this.txtFacebook.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFacebook.Location = new System.Drawing.Point(576, 41);
            this.txtFacebook.Name = "txtFacebook";
            this.txtFacebook.ReadOnly = true;
            this.txtFacebook.Size = new System.Drawing.Size(350, 20);
            this.txtFacebook.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(515, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Facebook";
            // 
            // txtEmail
            // 
            this.txtEmail.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEmail.Location = new System.Drawing.Point(576, 19);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Size = new System.Drawing.Size(350, 20);
            this.txtEmail.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(538, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Email";
            // 
            // txtDienThoai
            // 
            this.txtDienThoai.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDienThoai.Location = new System.Drawing.Point(104, 62);
            this.txtDienThoai.Name = "txtDienThoai";
            this.txtDienThoai.ReadOnly = true;
            this.txtDienThoai.Size = new System.Drawing.Size(350, 20);
            this.txtDienThoai.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 65);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Điện Thoại";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDiaChi.Location = new System.Drawing.Point(104, 40);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.ReadOnly = true;
            this.txtDiaChi.Size = new System.Drawing.Size(350, 20);
            this.txtDiaChi.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(57, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Địa Chỉ";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(460, 19);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(18, 20);
            this.txtMaKH.TabIndex = 4;
            this.txtMaKH.Visible = false;
            // 
            // txtTenKH
            // 
            this.txtTenKH.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTenKH.Location = new System.Drawing.Point(104, 19);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.ReadOnly = true;
            this.txtTenKH.Size = new System.Drawing.Size(350, 20);
            this.txtTenKH.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tên Khách Hàng";
            // 
            // frmChiTietDonHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 548);
            this.Controls.Add(this.tabDonHang);
            this.Name = "frmChiTietDonHang";
            this.Text = "Chi Tiết Đơn Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChiTietDonHang_Load);
            this.tabDonHang.ResumeLayout(false);
            this.tabThemDonHang.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachSanPham)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDonHang;
        private System.Windows.Forms.TabPage tabThemDonHang;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtgvDanhSachSanPham;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbmTrangThai;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtPhiVanChuyen;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton rdGiaLe;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rdGiaSi;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnCapNhatDonHang;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTKNganHang;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFacebook;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDienThoai;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label6;


    }
}