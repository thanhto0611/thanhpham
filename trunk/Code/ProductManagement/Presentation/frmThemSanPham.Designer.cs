namespace Presentation
{
    partial class frmThemSanPham
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabNhapTuFile = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtgvCvsData = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.txtCvsFile = new System.Windows.Forms.TextBox();
            this.btnDocFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowseCvsFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.openfdCvs = new System.Windows.Forms.OpenFileDialog();
            this.rdNew = new System.Windows.Forms.RadioButton();
            this.rdUpdate = new System.Windows.Forms.RadioButton();
            this.tabControl1.SuspendLayout();
            this.tabNhapTuFile.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCvsData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabNhapTuFile);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 594);
            this.tabControl1.TabIndex = 0;
            // 
            // tabNhapTuFile
            // 
            this.tabNhapTuFile.BackColor = System.Drawing.SystemColors.Control;
            this.tabNhapTuFile.Controls.Add(this.groupBox2);
            this.tabNhapTuFile.Controls.Add(this.groupBox1);
            this.tabNhapTuFile.Location = new System.Drawing.Point(4, 22);
            this.tabNhapTuFile.Name = "tabNhapTuFile";
            this.tabNhapTuFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabNhapTuFile.Size = new System.Drawing.Size(952, 568);
            this.tabNhapTuFile.TabIndex = 0;
            this.tabNhapTuFile.Text = "Nhập Từ File";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtgvCvsData);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 123);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(946, 442);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kết quả đọc file:";
            // 
            // dtgvCvsData
            // 
            this.dtgvCvsData.AllowUserToAddRows = false;
            this.dtgvCvsData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dtgvCvsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCvsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvCvsData.Location = new System.Drawing.Point(3, 16);
            this.dtgvCvsData.Name = "dtgvCvsData";
            this.dtgvCvsData.Size = new System.Drawing.Size(940, 423);
            this.dtgvCvsData.TabIndex = 0;
            this.dtgvCvsData.DataSourceChanged += new System.EventHandler(this.dtgvCvsData_DataSourceChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdUpdate);
            this.groupBox1.Controls.Add(this.rdNew);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.txtCvsFile);
            this.groupBox1.Controls.Add(this.btnDocFile);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnBrowseCvsFile);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 120);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin nhập liệu:";
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Red;
            this.btnImport.Location = new System.Drawing.Point(792, 19);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(108, 71);
            this.btnImport.TabIndex = 4;
            this.btnImport.Text = "Lưu Dữ Liệu";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtCvsFile
            // 
            this.txtCvsFile.Location = new System.Drawing.Point(77, 19);
            this.txtCvsFile.Name = "txtCvsFile";
            this.txtCvsFile.Size = new System.Drawing.Size(460, 20);
            this.txtCvsFile.TabIndex = 0;
            // 
            // btnDocFile
            // 
            this.btnDocFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDocFile.ForeColor = System.Drawing.Color.Blue;
            this.btnDocFile.Location = new System.Drawing.Point(671, 17);
            this.btnDocFile.Name = "btnDocFile";
            this.btnDocFile.Size = new System.Drawing.Size(115, 73);
            this.btnDocFile.TabIndex = 3;
            this.btnDocFile.Text = "Đọc File";
            this.btnDocFile.UseVisualStyleBackColor = true;
            this.btnDocFile.Click += new System.EventHandler(this.btnDocFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "CVS File:";
            // 
            // btnBrowseCvsFile
            // 
            this.btnBrowseCvsFile.Location = new System.Drawing.Point(570, 17);
            this.btnBrowseCvsFile.Name = "btnBrowseCvsFile";
            this.btnBrowseCvsFile.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseCvsFile.TabIndex = 2;
            this.btnBrowseCvsFile.Text = "Browse";
            this.btnBrowseCvsFile.UseVisualStyleBackColor = true;
            this.btnBrowseCvsFile.Click += new System.EventHandler(this.btnBrowseCvsFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(952, 568);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Nhập tay";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // openfdCvs
            // 
            this.openfdCvs.FileName = "openFileDialog1";
            this.openfdCvs.FileOk += new System.ComponentModel.CancelEventHandler(this.openfdCvs_FileOk);
            // 
            // rdNew
            // 
            this.rdNew.AutoSize = true;
            this.rdNew.Location = new System.Drawing.Point(77, 46);
            this.rdNew.Name = "rdNew";
            this.rdNew.Size = new System.Drawing.Size(87, 17);
            this.rdNew.TabIndex = 5;
            this.rdNew.TabStop = true;
            this.rdNew.Text = "Nhập mới SP";
            this.rdNew.UseVisualStyleBackColor = true;
            // 
            // rdUpdate
            // 
            this.rdUpdate.AutoSize = true;
            this.rdUpdate.Location = new System.Drawing.Point(77, 73);
            this.rdUpdate.Name = "rdUpdate";
            this.rdUpdate.Size = new System.Drawing.Size(85, 17);
            this.rdUpdate.TabIndex = 6;
            this.rdUpdate.TabStop = true;
            this.rdUpdate.Text = "Cập nhật SP";
            this.rdUpdate.UseVisualStyleBackColor = true;
            // 
            // frmThemSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 594);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmThemSanPham";
            this.ShowIcon = false;
            this.Text = "Thêm Sản Phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmThemSanPham_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabNhapTuFile.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCvsData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabNhapTuFile;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCvsFile;
        private System.Windows.Forms.Button btnBrowseCvsFile;
        private System.Windows.Forms.OpenFileDialog openfdCvs;
        private System.Windows.Forms.Button btnDocFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dtgvCvsData;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.RadioButton rdUpdate;
        private System.Windows.Forms.RadioButton rdNew;
    }
}