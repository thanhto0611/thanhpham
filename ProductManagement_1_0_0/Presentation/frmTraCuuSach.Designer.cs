namespace Presentation
{
    partial class frmTraCuuSach
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnTimTenTacGia = new System.Windows.Forms.Button();
            this.btnTimMaSach = new System.Windows.Forms.Button();
            this.btnTimTenSach = new System.Windows.Forms.Button();
            this.cmbTenTacGia = new System.Windows.Forms.ComboBox();
            this.cmbMaSach = new System.Windows.Forms.ComboBox();
            this.cmbTenSach = new System.Windows.Forms.ComboBox();
            this.cbxTenTacGia = new System.Windows.Forms.CheckBox();
            this.cbxMaSach = new System.Windows.Forms.CheckBox();
            this.cbxTenSach = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(764, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Tra Cứu Sách - Sửa Thông Tin Sách";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThoat);
            this.groupBox1.Controls.Add(this.btnSua);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.btnTimTenTacGia);
            this.groupBox1.Controls.Add(this.btnTimMaSach);
            this.groupBox1.Controls.Add(this.btnTimTenSach);
            this.groupBox1.Controls.Add(this.cmbTenTacGia);
            this.groupBox1.Controls.Add(this.cmbMaSach);
            this.groupBox1.Controls.Add(this.cmbTenSach);
            this.groupBox1.Controls.Add(this.cbxTenTacGia);
            this.groupBox1.Controls.Add(this.cbxMaSach);
            this.groupBox1.Controls.Add(this.cbxTenSach);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(764, 460);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn loại tra cứu :";
            // 
            // btnThoat
            // 
            this.btnThoat.AutoSize = true;
            this.btnThoat.Location = new System.Drawing.Point(582, 425);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnSua
            // 
            this.btnSua.AutoSize = true;
            this.btnSua.Location = new System.Drawing.Point(439, 425);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 10;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(764, 262);
            this.dataGridView1.TabIndex = 9;
            // 
            // btnTimTenTacGia
            // 
            this.btnTimTenTacGia.AutoSize = true;
            this.btnTimTenTacGia.Location = new System.Drawing.Point(582, 104);
            this.btnTimTenTacGia.Name = "btnTimTenTacGia";
            this.btnTimTenTacGia.Size = new System.Drawing.Size(75, 23);
            this.btnTimTenTacGia.TabIndex = 8;
            this.btnTimTenTacGia.Text = "Tìm";
            this.btnTimTenTacGia.UseVisualStyleBackColor = true;
            this.btnTimTenTacGia.Click += new System.EventHandler(this.btnTimTenTacGia_Click);
            // 
            // btnTimMaSach
            // 
            this.btnTimMaSach.AutoSize = true;
            this.btnTimMaSach.Location = new System.Drawing.Point(582, 68);
            this.btnTimMaSach.Name = "btnTimMaSach";
            this.btnTimMaSach.Size = new System.Drawing.Size(75, 23);
            this.btnTimMaSach.TabIndex = 7;
            this.btnTimMaSach.Text = "Tìm";
            this.btnTimMaSach.UseVisualStyleBackColor = true;
            this.btnTimMaSach.Click += new System.EventHandler(this.btnTimMaSach_Click);
            // 
            // btnTimTenSach
            // 
            this.btnTimTenSach.AutoSize = true;
            this.btnTimTenSach.Location = new System.Drawing.Point(582, 33);
            this.btnTimTenSach.Name = "btnTimTenSach";
            this.btnTimTenSach.Size = new System.Drawing.Size(75, 23);
            this.btnTimTenSach.TabIndex = 6;
            this.btnTimTenSach.Text = "Tìm";
            this.btnTimTenSach.UseVisualStyleBackColor = true;
            this.btnTimTenSach.Click += new System.EventHandler(this.btnTimTenSach_Click);
            // 
            // cmbTenTacGia
            // 
            this.cmbTenTacGia.FormattingEnabled = true;
            this.cmbTenTacGia.Location = new System.Drawing.Point(173, 106);
            this.cmbTenTacGia.Name = "cmbTenTacGia";
            this.cmbTenTacGia.Size = new System.Drawing.Size(341, 21);
            this.cmbTenTacGia.TabIndex = 5;
            // 
            // cmbMaSach
            // 
            this.cmbMaSach.FormattingEnabled = true;
            this.cmbMaSach.Location = new System.Drawing.Point(173, 70);
            this.cmbMaSach.Name = "cmbMaSach";
            this.cmbMaSach.Size = new System.Drawing.Size(341, 21);
            this.cmbMaSach.TabIndex = 4;
            // 
            // cmbTenSach
            // 
            this.cmbTenSach.FormattingEnabled = true;
            this.cmbTenSach.Location = new System.Drawing.Point(173, 35);
            this.cmbTenSach.Name = "cmbTenSach";
            this.cmbTenSach.Size = new System.Drawing.Size(341, 21);
            this.cmbTenSach.TabIndex = 3;
            // 
            // cbxTenTacGia
            // 
            this.cbxTenTacGia.AutoSize = true;
            this.cbxTenTacGia.Location = new System.Drawing.Point(44, 108);
            this.cbxTenTacGia.Name = "cbxTenTacGia";
            this.cbxTenTacGia.Size = new System.Drawing.Size(110, 17);
            this.cbxTenTacGia.TabIndex = 2;
            this.cbxTenTacGia.Text = "Theo tên tác giả :";
            this.cbxTenTacGia.UseVisualStyleBackColor = true;
            this.cbxTenTacGia.CheckedChanged += new System.EventHandler(this.cbxTenTacGia_CheckedChanged);
            // 
            // cbxMaSach
            // 
            this.cbxMaSach.AutoSize = true;
            this.cbxMaSach.Location = new System.Drawing.Point(44, 72);
            this.cbxMaSach.Name = "cbxMaSach";
            this.cbxMaSach.Size = new System.Drawing.Size(100, 17);
            this.cbxMaSach.TabIndex = 1;
            this.cbxMaSach.Text = "Theo mã sách :";
            this.cbxMaSach.UseVisualStyleBackColor = true;
            this.cbxMaSach.CheckedChanged += new System.EventHandler(this.cbxMaSach_CheckedChanged);
            // 
            // cbxTenSach
            // 
            this.cbxTenSach.AutoSize = true;
            this.cbxTenSach.Location = new System.Drawing.Point(44, 37);
            this.cbxTenSach.Name = "cbxTenSach";
            this.cbxTenSach.Size = new System.Drawing.Size(104, 17);
            this.cbxTenSach.TabIndex = 0;
            this.cbxTenSach.Text = "Theo tên sách : ";
            this.cbxTenSach.UseVisualStyleBackColor = true;
            this.cbxTenSach.CheckedChanged += new System.EventHandler(this.cbxTenSach_CheckedChanged);
            // 
            // frmTraCuuSach
            // 
            this.ClientSize = new System.Drawing.Size(764, 491);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Name = "frmTraCuuSach";
            this.Text = "Tra Cuu Sach - Sua Thong Tin Sach";
            this.Load += new System.EventHandler(this.frmTraCuuSach_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cbxTenTacGia;
        private System.Windows.Forms.CheckBox cbxMaSach;
        private System.Windows.Forms.CheckBox cbxTenSach;
        private System.Windows.Forms.Button btnTimTenTacGia;
        private System.Windows.Forms.Button btnTimMaSach;
        private System.Windows.Forms.Button btnTimTenSach;
        private System.Windows.Forms.ComboBox cmbTenTacGia;
        private System.Windows.Forms.ComboBox cmbMaSach;
        private System.Windows.Forms.ComboBox cmbTenSach;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnSua;
    }
}