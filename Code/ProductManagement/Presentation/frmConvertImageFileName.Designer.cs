namespace Presentation
{
    partial class frmConvertImageFileName
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
            this.txtOutputImageFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseOutputImageFolder = new System.Windows.Forms.Button();
            this.txtInputImageFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseInputImageFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.folderBrowserInput = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.cbxIncludeGiaLe = new System.Windows.Forms.CheckBox();
            this.cbxIncludeGiaSi = new System.Windows.Forms.CheckBox();
            this.dtgvImageFileName = new System.Windows.Forms.DataGridView();
            this.btnRevert = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvImageFileName)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutputImageFolder
            // 
            this.txtOutputImageFolder.Location = new System.Drawing.Point(132, 62);
            this.txtOutputImageFolder.Name = "txtOutputImageFolder";
            this.txtOutputImageFolder.Size = new System.Drawing.Size(395, 20);
            this.txtOutputImageFolder.TabIndex = 37;
            // 
            // btnBrowseOutputImageFolder
            // 
            this.btnBrowseOutputImageFolder.Location = new System.Drawing.Point(535, 62);
            this.btnBrowseOutputImageFolder.Name = "btnBrowseOutputImageFolder";
            this.btnBrowseOutputImageFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseOutputImageFolder.TabIndex = 38;
            this.btnBrowseOutputImageFolder.Text = "Browse";
            this.btnBrowseOutputImageFolder.UseVisualStyleBackColor = true;
            this.btnBrowseOutputImageFolder.Click += new System.EventHandler(this.btnBrowseOutputImageFolder_Click);
            // 
            // txtInputImageFolder
            // 
            this.txtInputImageFolder.Location = new System.Drawing.Point(132, 31);
            this.txtInputImageFolder.Name = "txtInputImageFolder";
            this.txtInputImageFolder.Size = new System.Drawing.Size(395, 20);
            this.txtInputImageFolder.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 33;
            this.label2.Text = "Input Images Folder:";
            // 
            // btnBrowseInputImageFolder
            // 
            this.btnBrowseInputImageFolder.Location = new System.Drawing.Point(535, 29);
            this.btnBrowseInputImageFolder.Name = "btnBrowseInputImageFolder";
            this.btnBrowseInputImageFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseInputImageFolder.TabIndex = 35;
            this.btnBrowseInputImageFolder.Text = "Browse";
            this.btnBrowseInputImageFolder.UseVisualStyleBackColor = true;
            this.btnBrowseInputImageFolder.Click += new System.EventHandler(this.btnBrowseInputImageFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Output Images Folder:";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(683, 31);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(75, 62);
            this.btnConvert.TabIndex = 40;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // cbxIncludeGiaLe
            // 
            this.cbxIncludeGiaLe.AutoSize = true;
            this.cbxIncludeGiaLe.Location = new System.Drawing.Point(132, 113);
            this.cbxIncludeGiaLe.Name = "cbxIncludeGiaLe";
            this.cbxIncludeGiaLe.Size = new System.Drawing.Size(95, 17);
            this.cbxIncludeGiaLe.TabIndex = 41;
            this.cbxIncludeGiaLe.Text = "Include Giá Lẻ";
            this.cbxIncludeGiaLe.UseVisualStyleBackColor = true;
            // 
            // cbxIncludeGiaSi
            // 
            this.cbxIncludeGiaSi.AutoSize = true;
            this.cbxIncludeGiaSi.Location = new System.Drawing.Point(132, 150);
            this.cbxIncludeGiaSi.Name = "cbxIncludeGiaSi";
            this.cbxIncludeGiaSi.Size = new System.Drawing.Size(92, 17);
            this.cbxIncludeGiaSi.TabIndex = 42;
            this.cbxIncludeGiaSi.Text = "Include Giá Sỉ";
            this.cbxIncludeGiaSi.UseVisualStyleBackColor = true;
            // 
            // dtgvImageFileName
            // 
            this.dtgvImageFileName.AllowUserToAddRows = false;
            this.dtgvImageFileName.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvImageFileName.Location = new System.Drawing.Point(12, 202);
            this.dtgvImageFileName.Name = "dtgvImageFileName";
            this.dtgvImageFileName.Size = new System.Drawing.Size(776, 228);
            this.dtgvImageFileName.TabIndex = 43;
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(683, 107);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(75, 60);
            this.btnRevert.TabIndex = 44;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 470);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(478, 204);
            this.textBox1.TabIndex = 45;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(604, 480);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(376, 20);
            this.textBox2.TabIndex = 46;
            this.textBox2.Text = "G:\\Work\\Hinh Up\\T39-2 - Resize\\media\\catalog\\product";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(715, 613);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 47;
            this.button1.Text = "delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(604, 535);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(376, 20);
            this.textBox3.TabIndex = 48;
            this.textBox3.Text = "H:\\delete.txt";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 489);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "folder";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(550, 535);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 50;
            this.label4.Text = "file";
            // 
            // frmConvertImageFileName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1123, 736);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.dtgvImageFileName);
            this.Controls.Add(this.cbxIncludeGiaSi);
            this.Controls.Add(this.cbxIncludeGiaLe);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutputImageFolder);
            this.Controls.Add(this.btnBrowseOutputImageFolder);
            this.Controls.Add(this.txtInputImageFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBrowseInputImageFolder);
            this.Name = "frmConvertImageFileName";
            this.Text = "frmConvertImageFileName";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConvertImageFileName_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvImageFileName)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutputImageFolder;
        private System.Windows.Forms.Button btnBrowseOutputImageFolder;
        private System.Windows.Forms.TextBox txtInputImageFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseInputImageFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserInput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserOutput;
        private System.Windows.Forms.CheckBox cbxIncludeGiaLe;
        private System.Windows.Forms.CheckBox cbxIncludeGiaSi;
        private System.Windows.Forms.DataGridView dtgvImageFileName;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}