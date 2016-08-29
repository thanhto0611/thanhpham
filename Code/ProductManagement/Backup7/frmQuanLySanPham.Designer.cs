namespace Presentation
{
    partial class frmQuanLySanPham
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuanLySanPham));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvSanPham = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.btnCapNhatSanPham = new System.Windows.Forms.Button();
            this.cmbTrangThai = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnThemDanhMuc = new System.Windows.Forms.Button();
            this.cmbDanhMuc = new System.Windows.Forms.ComboBox();
            this.txtMaSanPham = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.bgw1 = new System.ComponentModel.BackgroundWorker();
            this.bgw2 = new System.ComponentModel.BackgroundWorker();
            this.lbSyncing = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSanPham)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimKiem.Location = new System.Drawing.Point(777, 25);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(112, 65);
            this.btnTimKiem.TabIndex = 8;
            this.btnTimKiem.Text = "Tìm Kiếm";
            this.btnTimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvSanPham);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1362, 489);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách sản phẩm:";
            // 
            // dtgvSanPham
            // 
            this.dtgvSanPham.AllowUserToAddRows = false;
            this.dtgvSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgvSanPham.DefaultCellStyle = dataGridViewCellStyle2;
            this.dtgvSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvSanPham.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgvSanPham.Location = new System.Drawing.Point(3, 16);
            this.dtgvSanPham.Name = "dtgvSanPham";
            this.dtgvSanPham.Size = new System.Drawing.Size(1356, 470);
            this.dtgvSanPham.TabIndex = 0;
            this.dtgvSanPham.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvSanPham_CellMouseLeave);
            this.dtgvSanPham.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgvSanPham_RowPostPaint);
            this.dtgvSanPham.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvSanPham_CellMouseEnter);
            this.dtgvSanPham.DataSourceChanged += new System.EventHandler(this.dtgvSanPham_DataSourceChanged);
            this.dtgvSanPham.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvSanPham_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbSyncing);
            this.groupBox1.Controls.Add(this.btnThemSanPham);
            this.groupBox1.Controls.Add(this.btnCapNhatSanPham);
            this.groupBox1.Controls.Add(this.cmbTrangThai);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnThemDanhMuc);
            this.groupBox1.Controls.Add(this.btnTimKiem);
            this.groupBox1.Controls.Add(this.cmbDanhMuc);
            this.groupBox1.Controls.Add(this.txtMaSanPham);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1362, 106);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tìm kiếm:";
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSanPham.Image = ((System.Drawing.Image)(resources.GetObject("btnThemSanPham.Image")));
            this.btnThemSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemSanPham.Location = new System.Drawing.Point(1041, 25);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(140, 65);
            this.btnThemSanPham.TabIndex = 13;
            this.btnThemSanPham.Text = "Thêm Sản Phẩm";
            this.btnThemSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemSanPham.UseVisualStyleBackColor = true;
            this.btnThemSanPham.Click += new System.EventHandler(this.btnThemSanPham_Click);
            // 
            // btnCapNhatSanPham
            // 
            this.btnCapNhatSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatSanPham.ForeColor = System.Drawing.Color.Blue;
            this.btnCapNhatSanPham.Image = ((System.Drawing.Image)(resources.GetObject("btnCapNhatSanPham.Image")));
            this.btnCapNhatSanPham.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCapNhatSanPham.Location = new System.Drawing.Point(1187, 25);
            this.btnCapNhatSanPham.Name = "btnCapNhatSanPham";
            this.btnCapNhatSanPham.Size = new System.Drawing.Size(160, 65);
            this.btnCapNhatSanPham.TabIndex = 11;
            this.btnCapNhatSanPham.Text = "Cập Nhật Sản Phẩm";
            this.btnCapNhatSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCapNhatSanPham.UseVisualStyleBackColor = true;
            this.btnCapNhatSanPham.Click += new System.EventHandler(this.btnCapNhatSanPham_Click);
            // 
            // cmbTrangThai
            // 
            this.cmbTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTrangThai.FormattingEnabled = true;
            this.cmbTrangThai.Items.AddRange(new object[] {
            "Tất cả trạng thái",
            "Còn hàng",
            "Hết hàng"});
            this.cmbTrangThai.Location = new System.Drawing.Point(104, 41);
            this.cmbTrangThai.Name = "cmbTrangThai";
            this.cmbTrangThai.Size = new System.Drawing.Size(269, 21);
            this.cmbTrangThai.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Trạng thái:";
            // 
            // btnThemDanhMuc
            // 
            this.btnThemDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemDanhMuc.Image = ((System.Drawing.Image)(resources.GetObject("btnThemDanhMuc.Image")));
            this.btnThemDanhMuc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemDanhMuc.Location = new System.Drawing.Point(895, 25);
            this.btnThemDanhMuc.Name = "btnThemDanhMuc";
            this.btnThemDanhMuc.Size = new System.Drawing.Size(140, 65);
            this.btnThemDanhMuc.TabIndex = 8;
            this.btnThemDanhMuc.Text = "Thêm Danh Mục";
            this.btnThemDanhMuc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemDanhMuc.UseVisualStyleBackColor = true;
            this.btnThemDanhMuc.Click += new System.EventHandler(this.btnThemDanhMuc_Click);
            // 
            // cmbDanhMuc
            // 
            this.cmbDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDanhMuc.FormattingEnabled = true;
            this.cmbDanhMuc.Location = new System.Drawing.Point(456, 16);
            this.cmbDanhMuc.Name = "cmbDanhMuc";
            this.cmbDanhMuc.Size = new System.Drawing.Size(269, 21);
            this.cmbDanhMuc.TabIndex = 1;
            // 
            // txtMaSanPham
            // 
            this.txtMaSanPham.Location = new System.Drawing.Point(104, 17);
            this.txtMaSanPham.Name = "txtMaSanPham";
            this.txtMaSanPham.Size = new System.Drawing.Size(269, 20);
            this.txtMaSanPham.TabIndex = 3;
            this.txtMaSanPham.TextChanged += new System.EventHandler(this.txtMaSanPham_TextChanged);
            this.txtMaSanPham.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaSanPham_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(391, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Danh mục:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Mã sản phẩm:";
            // 
            // timerSync
            // 
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // bgw1
            // 
            this.bgw1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // bgw2
            // 
            this.bgw2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // lbSyncing
            // 
            this.lbSyncing.AutoSize = true;
            this.lbSyncing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lbSyncing.ForeColor = System.Drawing.Color.Red;
            this.lbSyncing.Location = new System.Drawing.Point(187, 70);
            this.lbSyncing.Name = "lbSyncing";
            this.lbSyncing.Size = new System.Drawing.Size(527, 20);
            this.lbSyncing.TabIndex = 14;
            this.lbSyncing.Text = "Đang đồng bộ kho hàng với web. Vui lòng không đóng phần mềm";
            this.lbSyncing.Visible = false;
            // 
            // frmQuanLySanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1362, 595);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmQuanLySanPham";
            this.ShowIcon = false;
            this.Text = "Tìm Kiếm - Cập Nhật Sản Phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmQuanLySanPham_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuanLySanPham_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmQuanLySanPham_FormClosing);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvSanPham)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvSanPham;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbDanhMuc;
        private System.Windows.Forms.TextBox txtMaSanPham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemDanhMuc;
        private System.Windows.Forms.ComboBox cmbTrangThai;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCapNhatSanPham;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.Timer timerSync;
        private System.ComponentModel.BackgroundWorker bgw1;
        private System.ComponentModel.BackgroundWorker bgw2;
        private System.Windows.Forms.Label lbSyncing;
    }
}