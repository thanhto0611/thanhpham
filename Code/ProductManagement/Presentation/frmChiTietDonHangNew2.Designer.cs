namespace Presentation
{
    partial class frmChiTietDonHangNew2
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
            this.tabDonHang = new System.Windows.Forms.TabControl();
            this.tabThemDonHang = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.dtgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.rdGiaLe = new System.Windows.Forms.RadioButton();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.rdGiaSi = new System.Windows.Forms.RadioButton();
            this.txtMaSanPham_Them = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPhiVanChuyen_Them = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.cbmTrangThai_Them = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lbMaDonHang = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbSoLuong = new System.Windows.Forms.Label();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTKNganHang_Them = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtFacebook_Them = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail_Them = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDienThoai_Them = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiaChi_Them = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMaKH_Them = new System.Windows.Forms.TextBox();
            this.txtTenKH_Them = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.tabDonHang.SuspendLayout();
            this.tabThemDonHang.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachSanPham)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
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
            this.tabDonHang.Size = new System.Drawing.Size(1327, 741);
            this.tabDonHang.TabIndex = 1;
            // 
            // tabThemDonHang
            // 
            this.tabThemDonHang.BackColor = System.Drawing.Color.Transparent;
            this.tabThemDonHang.Controls.Add(this.groupBox6);
            this.tabThemDonHang.Controls.Add(this.groupBox3);
            this.tabThemDonHang.Location = new System.Drawing.Point(4, 22);
            this.tabThemDonHang.Name = "tabThemDonHang";
            this.tabThemDonHang.Padding = new System.Windows.Forms.Padding(3);
            this.tabThemDonHang.Size = new System.Drawing.Size(1319, 715);
            this.tabThemDonHang.TabIndex = 1;
            this.tabThemDonHang.Text = "Chi Tiết Đơn Hàng";
            this.tabThemDonHang.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(496, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(820, 709);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Thông tin đơn hàng";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.dtgvDanhSachSanPham);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(3, 91);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(814, 615);
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
            this.dtgvDanhSachSanPham.Size = new System.Drawing.Size(808, 596);
            this.dtgvDanhSachSanPham.TabIndex = 0;
            this.dtgvDanhSachSanPham.Visible = false;
            this.dtgvDanhSachSanPham.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSachSanPham_CellValueChanged);
            this.dtgvDanhSachSanPham.Sorted += new System.EventHandler(this.dtgvDanhSachSanPham_Sorted);
            this.dtgvDanhSachSanPham.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSachSanPham_CellMouseLeave);
            this.dtgvDanhSachSanPham.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgvDanhSachSanPham_RowPostPaint);
            this.dtgvDanhSachSanPham.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSachSanPham_CellMouseEnter);
            this.dtgvDanhSachSanPham.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvDanhSachSanPham_CellClick);
            this.dtgvDanhSachSanPham.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dtgvDanhSachSanPham_EditingControlShowing);
            this.dtgvDanhSachSanPham.DataSourceChanged += new System.EventHandler(this.dtgvDanhSachSanPham_DataSourceChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnExport);
            this.groupBox4.Controls.Add(this.rdGiaLe);
            this.groupBox4.Controls.Add(this.btnCapNhat);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.rdGiaSi);
            this.groupBox4.Controls.Add(this.txtMaSanPham_Them);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtPhiVanChuyen_Them);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.cbmTrangThai_Them);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(814, 75);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thêm sản phẩm vào đơn hàng:";
            // 
            // btnExport
            // 
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.ForeColor = System.Drawing.Color.Blue;
            this.btnExport.Location = new System.Drawing.Point(676, 17);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(120, 49);
            this.btnExport.TabIndex = 18;
            this.btnExport.Text = "Xuất Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
            // btnCapNhat
            // 
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.Blue;
            this.btnCapNhat.Location = new System.Drawing.Point(476, 16);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(184, 50);
            this.btnCapNhat.TabIndex = 16;
            this.btnCapNhat.Text = "Cập Nhật Đơn Hàng";
            this.btnCapNhat.UseVisualStyleBackColor = true;
            this.btnCapNhat.Click += new System.EventHandler(this.btnCapNhat_Click);
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
            // txtMaSanPham_Them
            // 
            this.txtMaSanPham_Them.Location = new System.Drawing.Point(101, 22);
            this.txtMaSanPham_Them.Name = "txtMaSanPham_Them";
            this.txtMaSanPham_Them.Size = new System.Drawing.Size(115, 20);
            this.txtMaSanPham_Them.TabIndex = 2;
            this.txtMaSanPham_Them.TextChanged += new System.EventHandler(this.txtMaSanPham_Them_TextChanged);
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
            // txtPhiVanChuyen_Them
            // 
            this.txtPhiVanChuyen_Them.Location = new System.Drawing.Point(333, 19);
            this.txtPhiVanChuyen_Them.Name = "txtPhiVanChuyen_Them";
            this.txtPhiVanChuyen_Them.Size = new System.Drawing.Size(99, 20);
            this.txtPhiVanChuyen_Them.TabIndex = 13;
            this.txtPhiVanChuyen_Them.Text = "0";
            this.txtPhiVanChuyen_Them.TextChanged += new System.EventHandler(this.txtPhiVanChuyen_Them_TextChanged);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(269, 49);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 14;
            this.label19.Text = "Trạng thái:";
            // 
            // cbmTrangThai_Them
            // 
            this.cbmTrangThai_Them.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmTrangThai_Them.FormattingEnabled = true;
            this.cbmTrangThai_Them.Items.AddRange(new object[] {
            "Mới đặt",
            "Hoàn tất"});
            this.cbmTrangThai_Them.Location = new System.Drawing.Point(333, 45);
            this.cbmTrangThai_Them.Name = "cbmTrangThai_Them";
            this.cbmTrangThai_Them.Size = new System.Drawing.Size(99, 21);
            this.cbmTrangThai_Them.TabIndex = 15;
            this.cbmTrangThai_Them.SelectedIndexChanged += new System.EventHandler(this.cbmTrangThai_Them_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(241, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(86, 13);
            this.label18.TabIndex = 12;
            this.label18.Text = "Phí vận chuyển:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(493, 709);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lbMaDonHang);
            this.groupBox8.Controls.Add(this.label1);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.lbSoLuong);
            this.groupBox8.Controls.Add(this.lbTongTien);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.label17);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 221);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(487, 485);
            this.groupBox8.TabIndex = 23;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Số lượng và Tổng tiền:";
            // 
            // lbMaDonHang
            // 
            this.lbMaDonHang.AutoSize = true;
            this.lbMaDonHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMaDonHang.ForeColor = System.Drawing.Color.Blue;
            this.lbMaDonHang.Location = new System.Drawing.Point(149, 44);
            this.lbMaDonHang.Name = "lbMaDonHang";
            this.lbMaDonHang.Size = new System.Drawing.Size(0, 46);
            this.lbMaDonHang.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Mã Đơn Hàng:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(43, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 24);
            this.label14.TabIndex = 4;
            this.label14.Text = "Số lượng:";
            // 
            // lbSoLuong
            // 
            this.lbSoLuong.AutoSize = true;
            this.lbSoLuong.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSoLuong.ForeColor = System.Drawing.Color.Red;
            this.lbSoLuong.Location = new System.Drawing.Point(145, 164);
            this.lbSoLuong.Name = "lbSoLuong";
            this.lbSoLuong.Size = new System.Drawing.Size(43, 46);
            this.lbSoLuong.TabIndex = 5;
            this.lbSoLuong.Text = "0";
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.ForeColor = System.Drawing.Color.Red;
            this.lbTongTien.Location = new System.Drawing.Point(145, 249);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(43, 46);
            this.lbTongTien.TabIndex = 7;
            this.lbTongTien.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(38, 267);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(105, 24);
            this.label15.TabIndex = 6;
            this.label15.Text = "Tổng tiền:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(350, 249);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 46);
            this.label17.TabIndex = 11;
            this.label17.Text = "VNĐ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTKNganHang_Them);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtFacebook_Them);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtEmail_Them);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtDienThoai_Them);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtDiaChi_Them);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtMaKH_Them);
            this.groupBox2.Controls.Add(this.txtTenKH_Them);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(487, 205);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin khách hàng:";
            // 
            // txtTKNganHang_Them
            // 
            this.txtTKNganHang_Them.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTKNganHang_Them.Location = new System.Drawing.Point(105, 152);
            this.txtTKNganHang_Them.Name = "txtTKNganHang_Them";
            this.txtTKNganHang_Them.ReadOnly = true;
            this.txtTKNganHang_Them.Size = new System.Drawing.Size(350, 20);
            this.txtTKNganHang_Them.TabIndex = 20;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "TK Ngân Hàng";
            // 
            // txtFacebook_Them
            // 
            this.txtFacebook_Them.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtFacebook_Them.Location = new System.Drawing.Point(105, 130);
            this.txtFacebook_Them.Name = "txtFacebook_Them";
            this.txtFacebook_Them.ReadOnly = true;
            this.txtFacebook_Them.Size = new System.Drawing.Size(350, 20);
            this.txtFacebook_Them.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(44, 133);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 17;
            this.label11.Text = "Facebook";
            // 
            // txtEmail_Them
            // 
            this.txtEmail_Them.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEmail_Them.Location = new System.Drawing.Point(105, 108);
            this.txtEmail_Them.Name = "txtEmail_Them";
            this.txtEmail_Them.ReadOnly = true;
            this.txtEmail_Them.Size = new System.Drawing.Size(350, 20);
            this.txtEmail_Them.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(67, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 15;
            this.label10.Text = "Email";
            // 
            // txtDienThoai_Them
            // 
            this.txtDienThoai_Them.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDienThoai_Them.Location = new System.Drawing.Point(105, 85);
            this.txtDienThoai_Them.Name = "txtDienThoai_Them";
            this.txtDienThoai_Them.ReadOnly = true;
            this.txtDienThoai_Them.Size = new System.Drawing.Size(350, 20);
            this.txtDienThoai_Them.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Điện Thoại";
            // 
            // txtDiaChi_Them
            // 
            this.txtDiaChi_Them.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDiaChi_Them.Location = new System.Drawing.Point(105, 63);
            this.txtDiaChi_Them.Name = "txtDiaChi_Them";
            this.txtDiaChi_Them.ReadOnly = true;
            this.txtDiaChi_Them.Size = new System.Drawing.Size(350, 20);
            this.txtDiaChi_Them.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(58, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Địa Chỉ";
            // 
            // txtMaKH_Them
            // 
            this.txtMaKH_Them.Location = new System.Drawing.Point(461, 42);
            this.txtMaKH_Them.Name = "txtMaKH_Them";
            this.txtMaKH_Them.Size = new System.Drawing.Size(18, 20);
            this.txtMaKH_Them.TabIndex = 4;
            this.txtMaKH_Them.Visible = false;
            // 
            // txtTenKH_Them
            // 
            this.txtTenKH_Them.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtTenKH_Them.Location = new System.Drawing.Point(105, 42);
            this.txtTenKH_Them.Name = "txtTenKH_Them";
            this.txtTenKH_Them.ReadOnly = true;
            this.txtTenKH_Them.Size = new System.Drawing.Size(350, 20);
            this.txtTenKH_Them.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 45);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tên Khách Hàng";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // timerSync
            // 
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // frmChiTietDonHangNew2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 741);
            this.Controls.Add(this.tabDonHang);
            this.Name = "frmChiTietDonHangNew2";
            this.ShowIcon = false;
            this.Text = "Chi Tiết Đơn Hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChiTietDonHangNew2_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChiTietDonHangNew2_FormClosing);
            this.tabDonHang.ResumeLayout(false);
            this.tabThemDonHang.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDanhSachSanPham)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDonHang;
        private System.Windows.Forms.TabPage tabThemDonHang;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtgvDanhSachSanPham;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RadioButton rdGiaLe;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton rdGiaSi;
        private System.Windows.Forms.TextBox txtMaSanPham_Them;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPhiVanChuyen_Them;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cbmTrangThai_Them;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbSoLuong;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTKNganHang_Them;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtFacebook_Them;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEmail_Them;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDienThoai_Them;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiaChi_Them;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMaKH_Them;
        private System.Windows.Forms.TextBox txtTenKH_Them;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbMaDonHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timerSync;
    }
}