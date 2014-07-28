namespace Presentation
{
    partial class frmImportProducts
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
            this.btnBrowseImageFolder = new System.Windows.Forms.Button();
            this.txtImageFolder = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserImage = new System.Windows.Forms.FolderBrowserDialog();
            this.btnCheck = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpNewFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtpNewToDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateCVSFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCVSFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnBrowseCVSFolder = new System.Windows.Forms.Button();
            this.folderBrowserCVS = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseImageFolder
            // 
            this.btnBrowseImageFolder.Location = new System.Drawing.Point(567, 17);
            this.btnBrowseImageFolder.Name = "btnBrowseImageFolder";
            this.btnBrowseImageFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseImageFolder.TabIndex = 21;
            this.btnBrowseImageFolder.Text = "Browse";
            this.btnBrowseImageFolder.UseVisualStyleBackColor = true;
            this.btnBrowseImageFolder.Click += new System.EventHandler(this.btnBrowseImageFolder_Click);
            // 
            // txtImageFolder
            // 
            this.txtImageFolder.Location = new System.Drawing.Point(164, 19);
            this.txtImageFolder.Name = "txtImageFolder";
            this.txtImageFolder.Size = new System.Drawing.Size(395, 20);
            this.txtImageFolder.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Images Folder:";
            // 
            // folderBrowserImage
            // 
            this.folderBrowserImage.ShowNewFolderButton = false;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.ForeColor = System.Drawing.Color.Blue;
            this.btnCheck.Location = new System.Drawing.Point(679, 19);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(92, 66);
            this.btnCheck.TabIndex = 22;
            this.btnCheck.Text = "CHECK DIRECTORY";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(900, 355);
            this.dataGridView1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "New From Date:";
            // 
            // dtpNewFromDate
            // 
            this.dtpNewFromDate.Location = new System.Drawing.Point(164, 78);
            this.dtpNewFromDate.Name = "dtpNewFromDate";
            this.dtpNewFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpNewFromDate.TabIndex = 26;
            // 
            // dtpNewToDate
            // 
            this.dtpNewToDate.Location = new System.Drawing.Point(164, 116);
            this.dtpNewToDate.Name = "dtpNewToDate";
            this.dtpNewToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpNewToDate.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 27;
            this.label3.Text = "New To Date:";
            // 
            // btnGenerateCVSFile
            // 
            this.btnGenerateCVSFile.Enabled = false;
            this.btnGenerateCVSFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateCVSFile.ForeColor = System.Drawing.Color.Red;
            this.btnGenerateCVSFile.Location = new System.Drawing.Point(794, 17);
            this.btnGenerateCVSFile.Name = "btnGenerateCVSFile";
            this.btnGenerateCVSFile.Size = new System.Drawing.Size(84, 68);
            this.btnGenerateCVSFile.TabIndex = 29;
            this.btnGenerateCVSFile.Text = "GENERATE CVS FILE";
            this.btnGenerateCVSFile.UseVisualStyleBackColor = true;
            this.btnGenerateCVSFile.Click += new System.EventHandler(this.btnGenerateCVSFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCVSFolder);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnBrowseCVSFolder);
            this.groupBox1.Controls.Add(this.txtImageFolder);
            this.groupBox1.Controls.Add(this.btnGenerateCVSFile);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpNewToDate);
            this.groupBox1.Controls.Add(this.btnBrowseImageFolder);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnCheck);
            this.groupBox1.Controls.Add(this.dtpNewFromDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 145);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Read Data From Image Folder";
            // 
            // txtCVSFolder
            // 
            this.txtCVSFolder.Location = new System.Drawing.Point(164, 50);
            this.txtCVSFolder.Name = "txtCVSFolder";
            this.txtCVSFolder.Size = new System.Drawing.Size(395, 20);
            this.txtCVSFolder.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "CVS Folder:";
            // 
            // btnBrowseCVSFolder
            // 
            this.btnBrowseCVSFolder.Location = new System.Drawing.Point(567, 50);
            this.btnBrowseCVSFolder.Name = "btnBrowseCVSFolder";
            this.btnBrowseCVSFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseCVSFolder.TabIndex = 32;
            this.btnBrowseCVSFolder.Text = "Browse";
            this.btnBrowseCVSFolder.UseVisualStyleBackColor = true;
            this.btnBrowseCVSFolder.Click += new System.EventHandler(this.btnBrowseCVSFolder_Click);
            // 
            // folderBrowserCVS
            // 
            this.folderBrowserCVS.ShowNewFolderButton = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(906, 374);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Import  Data";
            // 
            // frmImportProducts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(906, 519);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmImportProducts";
            this.Text = "Import Products";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmImportProducts_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseImageFolder;
        private System.Windows.Forms.TextBox txtImageFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserImage;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpNewFromDate;
        private System.Windows.Forms.DateTimePicker dtpNewToDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenerateCVSFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCVSFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnBrowseCVSFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserCVS;
        private System.Windows.Forms.GroupBox groupBox2;

    }
}

