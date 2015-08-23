namespace QuanLyBoMon
{
    partial class frmQuanLyNamHoc
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
            this.btnXoaNamHoc = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtTenNamHocThem = new System.Windows.Forms.TextBox();
            this.btnCapNhatNamHoc = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnThemNamHoc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTenNamHocUpdate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listNamHoc = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXoaNamHoc
            // 
            this.btnXoaNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNamHoc.ForeColor = System.Drawing.Color.Red;
            this.btnXoaNamHoc.Location = new System.Drawing.Point(750, 78);
            this.btnXoaNamHoc.Name = "btnXoaNamHoc";
            this.btnXoaNamHoc.Size = new System.Drawing.Size(154, 73);
            this.btnXoaNamHoc.TabIndex = 20;
            this.btnXoaNamHoc.Text = "Xóa Năm Học";
            this.btnXoaNamHoc.UseVisualStyleBackColor = true;
            this.btnXoaNamHoc.Click += new System.EventHandler(this.btnXoaNamHoc_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(520, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(596, 119);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // txtTenNamHocThem
            // 
            this.txtTenNamHocThem.Location = new System.Drawing.Point(82, 27);
            this.txtTenNamHocThem.Name = "txtTenNamHocThem";
            this.txtTenNamHocThem.Size = new System.Drawing.Size(354, 20);
            this.txtTenNamHocThem.TabIndex = 4;
            // 
            // btnCapNhatNamHoc
            // 
            this.btnCapNhatNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatNamHoc.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnCapNhatNamHoc.Location = new System.Drawing.Point(520, 78);
            this.btnCapNhatNamHoc.Name = "btnCapNhatNamHoc";
            this.btnCapNhatNamHoc.Size = new System.Drawing.Size(215, 73);
            this.btnCapNhatNamHoc.TabIndex = 19;
            this.btnCapNhatNamHoc.Text = "Cập Nhật Năm Học";
            this.btnCapNhatNamHoc.UseVisualStyleBackColor = true;
            this.btnCapNhatNamHoc.Click += new System.EventHandler(this.btnCapNhatNamHoc_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnThemNamHoc);
            this.groupBox3.Controls.Add(this.txtTenNamHocThem);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(517, 119);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thêm Năm Học:";
            // 
            // btnThemNamHoc
            // 
            this.btnThemNamHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNamHoc.ForeColor = System.Drawing.Color.Blue;
            this.btnThemNamHoc.Location = new System.Drawing.Point(125, 53);
            this.btnThemNamHoc.Name = "btnThemNamHoc";
            this.btnThemNamHoc.Size = new System.Drawing.Size(161, 51);
            this.btnThemNamHoc.TabIndex = 8;
            this.btnThemNamHoc.Text = "Thêm Năm Học";
            this.btnThemNamHoc.UseVisualStyleBackColor = true;
            this.btnThemNamHoc.Click += new System.EventHandler(this.btnThemNamHoc_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Năm Học:";
            // 
            // txtTenNamHocUpdate
            // 
            this.txtTenNamHocUpdate.Location = new System.Drawing.Point(555, 29);
            this.txtTenNamHocUpdate.Name = "txtTenNamHocUpdate";
            this.txtTenNamHocUpdate.Size = new System.Drawing.Size(369, 20);
            this.txtTenNamHocUpdate.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(494, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Năm Học:";
            // 
            // listNamHoc
            // 
            this.listNamHoc.FormattingEnabled = true;
            this.listNamHoc.Location = new System.Drawing.Point(27, 55);
            this.listNamHoc.Name = "listNamHoc";
            this.listNamHoc.Size = new System.Drawing.Size(399, 290);
            this.listNamHoc.TabIndex = 10;
            this.listNamHoc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listNamHoc_MouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoaNamHoc);
            this.groupBox2.Controls.Add(this.btnCapNhatNamHoc);
            this.groupBox2.Controls.Add(this.txtTenNamHocUpdate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.listNamHoc);
            this.groupBox2.Controls.Add(this.txtThongTinTimKiem);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1119, 426);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cập nhật / Xóa Năm Học";
            // 
            // txtThongTinTimKiem
            // 
            this.txtThongTinTimKiem.Location = new System.Drawing.Point(144, 29);
            this.txtThongTinTimKiem.Name = "txtThongTinTimKiem";
            this.txtThongTinTimKiem.Size = new System.Drawing.Size(282, 20);
            this.txtThongTinTimKiem.TabIndex = 9;
            this.txtThongTinTimKiem.TextChanged += new System.EventHandler(this.txtThongTinTimKiem_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thông Tin Năm Học:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1119, 138);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // frmQuanLyNamHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 564);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyNamHoc";
            this.ShowIcon = false;
            this.Text = "Quản Lý Năm Học";
            this.Load += new System.EventHandler(this.frmQuanLyNamHoc_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuanLyNamHoc_FormClosed);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXoaNamHoc;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtTenNamHocThem;
        private System.Windows.Forms.Button btnCapNhatNamHoc;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnThemNamHoc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTenNamHocUpdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listNamHoc;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtThongTinTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}