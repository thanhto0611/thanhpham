namespace QuanLyBoMon
{
    partial class frmQuanLyMonHoc
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnXoaMonHoc = new System.Windows.Forms.Button();
            this.btnCapNhatMonHoc = new System.Windows.Forms.Button();
            this.txtTenMonHocUpdate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.listMonHoc = new System.Windows.Forms.ListBox();
            this.txtThongTinTimKiem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnThemMonHoc = new System.Windows.Forms.Button();
            this.txtTenMonHocThem = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnXoaMonHoc);
            this.groupBox2.Controls.Add(this.btnCapNhatMonHoc);
            this.groupBox2.Controls.Add(this.txtTenMonHocUpdate);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.listMonHoc);
            this.groupBox2.Controls.Add(this.txtThongTinTimKiem);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1245, 547);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cập nhật / Xóa Môn Học";
            // 
            // btnXoaMonHoc
            // 
            this.btnXoaMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaMonHoc.ForeColor = System.Drawing.Color.Red;
            this.btnXoaMonHoc.Location = new System.Drawing.Point(750, 78);
            this.btnXoaMonHoc.Name = "btnXoaMonHoc";
            this.btnXoaMonHoc.Size = new System.Drawing.Size(154, 73);
            this.btnXoaMonHoc.TabIndex = 20;
            this.btnXoaMonHoc.Text = "Xóa Môn Học";
            this.btnXoaMonHoc.UseVisualStyleBackColor = true;
            this.btnXoaMonHoc.Click += new System.EventHandler(this.btnXoaMonHoc_Click);
            // 
            // btnCapNhatMonHoc
            // 
            this.btnCapNhatMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatMonHoc.ForeColor = System.Drawing.Color.MediumBlue;
            this.btnCapNhatMonHoc.Location = new System.Drawing.Point(520, 78);
            this.btnCapNhatMonHoc.Name = "btnCapNhatMonHoc";
            this.btnCapNhatMonHoc.Size = new System.Drawing.Size(215, 73);
            this.btnCapNhatMonHoc.TabIndex = 19;
            this.btnCapNhatMonHoc.Text = "Cập Nhật Môn Học";
            this.btnCapNhatMonHoc.UseVisualStyleBackColor = true;
            this.btnCapNhatMonHoc.Click += new System.EventHandler(this.btnCapNhatMonHoc_Click);
            // 
            // txtTenMonHocUpdate
            // 
            this.txtTenMonHocUpdate.Location = new System.Drawing.Point(576, 29);
            this.txtTenMonHocUpdate.Name = "txtTenMonHocUpdate";
            this.txtTenMonHocUpdate.Size = new System.Drawing.Size(348, 20);
            this.txtTenMonHocUpdate.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(494, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Tên Môn Học:";
            // 
            // listMonHoc
            // 
            this.listMonHoc.FormattingEnabled = true;
            this.listMonHoc.Location = new System.Drawing.Point(27, 55);
            this.listMonHoc.Name = "listMonHoc";
            this.listMonHoc.Size = new System.Drawing.Size(399, 290);
            this.listMonHoc.TabIndex = 10;
            this.listMonHoc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listMonHoc_MouseClick);
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
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Thông Tin Môn Học:";
            // 
            // btnThemMonHoc
            // 
            this.btnThemMonHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemMonHoc.ForeColor = System.Drawing.Color.Blue;
            this.btnThemMonHoc.Location = new System.Drawing.Point(125, 53);
            this.btnThemMonHoc.Name = "btnThemMonHoc";
            this.btnThemMonHoc.Size = new System.Drawing.Size(161, 51);
            this.btnThemMonHoc.TabIndex = 8;
            this.btnThemMonHoc.Text = "Thêm Môn Học";
            this.btnThemMonHoc.UseVisualStyleBackColor = true;
            this.btnThemMonHoc.Click += new System.EventHandler(this.btnThemMonHoc_Click);
            // 
            // txtTenMonHocThem
            // 
            this.txtTenMonHocThem.Location = new System.Drawing.Point(103, 27);
            this.txtTenMonHocThem.Name = "txtTenMonHocThem";
            this.txtTenMonHocThem.Size = new System.Drawing.Size(333, 20);
            this.txtTenMonHocThem.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(520, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(722, 119);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnThemMonHoc);
            this.groupBox3.Controls.Add(this.txtTenMonHocThem);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(517, 119);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thêm Môn Học:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên Môn Học:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1245, 138);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // frmQuanLyMonHoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 685);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQuanLyMonHoc";
            this.ShowIcon = false;
            this.Text = "Quản Lý Môn Học";
            this.Load += new System.EventHandler(this.frmQuanLyMonHoc_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmQuanLyMonHoc_FormClosed);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnXoaMonHoc;
        private System.Windows.Forms.Button btnCapNhatMonHoc;
        private System.Windows.Forms.TextBox txtTenMonHocUpdate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox listMonHoc;
        private System.Windows.Forms.TextBox txtThongTinTimKiem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnThemMonHoc;
        private System.Windows.Forms.TextBox txtTenMonHocThem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}