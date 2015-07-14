namespace AutoCopyPrompt
{
    partial class frmAutoCopyPrompt
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
            this.btnCopy = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.folderBrowserTts = new System.Windows.Forms.FolderBrowserDialog();
            this.txtTtsFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseTtsFolder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSourceVoxFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseSourceVoxFolder = new System.Windows.Forms.Button();
            this.folderBrowserSourceVox = new System.Windows.Forms.FolderBrowserDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTargetVoxFolder = new System.Windows.Forms.TextBox();
            this.btnBrowseTargetVoxFolder = new System.Windows.Forms.Button();
            this.folderBrowserTargetVox = new System.Windows.Forms.FolderBrowserDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.ForeColor = System.Drawing.Color.Blue;
            this.btnCopy.Location = new System.Drawing.Point(626, 17);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(92, 75);
            this.btnCopy.TabIndex = 16;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Text To Speech Folder:";
            // 
            // folderBrowserTts
            // 
            this.folderBrowserTts.ShowNewFolderButton = false;
            // 
            // txtTtsFolder
            // 
            this.txtTtsFolder.Location = new System.Drawing.Point(129, 17);
            this.txtTtsFolder.Name = "txtTtsFolder";
            this.txtTtsFolder.Size = new System.Drawing.Size(395, 20);
            this.txtTtsFolder.TabIndex = 17;
            // 
            // btnBrowseTtsFolder
            // 
            this.btnBrowseTtsFolder.Location = new System.Drawing.Point(536, 15);
            this.btnBrowseTtsFolder.Name = "btnBrowseTtsFolder";
            this.btnBrowseTtsFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTtsFolder.TabIndex = 18;
            this.btnBrowseTtsFolder.Text = "Browse";
            this.btnBrowseTtsFolder.UseVisualStyleBackColor = true;
            this.btnBrowseTtsFolder.Click += new System.EventHandler(this.btnBrowseTtsFolder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Source Vox Folder:";
            // 
            // txtSourceVoxFolder
            // 
            this.txtSourceVoxFolder.Location = new System.Drawing.Point(129, 46);
            this.txtSourceVoxFolder.Name = "txtSourceVoxFolder";
            this.txtSourceVoxFolder.Size = new System.Drawing.Size(395, 20);
            this.txtSourceVoxFolder.TabIndex = 19;
            // 
            // btnBrowseSourceVoxFolder
            // 
            this.btnBrowseSourceVoxFolder.Location = new System.Drawing.Point(536, 44);
            this.btnBrowseSourceVoxFolder.Name = "btnBrowseSourceVoxFolder";
            this.btnBrowseSourceVoxFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseSourceVoxFolder.TabIndex = 20;
            this.btnBrowseSourceVoxFolder.Text = "Browse";
            this.btnBrowseSourceVoxFolder.UseVisualStyleBackColor = true;
            this.btnBrowseSourceVoxFolder.Click += new System.EventHandler(this.btnBrowseSourceVoxFolder_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Target Vox Folder:";
            // 
            // txtTargetVoxFolder
            // 
            this.txtTargetVoxFolder.Location = new System.Drawing.Point(129, 71);
            this.txtTargetVoxFolder.Name = "txtTargetVoxFolder";
            this.txtTargetVoxFolder.Size = new System.Drawing.Size(395, 20);
            this.txtTargetVoxFolder.TabIndex = 21;
            // 
            // btnBrowseTargetVoxFolder
            // 
            this.btnBrowseTargetVoxFolder.Location = new System.Drawing.Point(536, 69);
            this.btnBrowseTargetVoxFolder.Name = "btnBrowseTargetVoxFolder";
            this.btnBrowseTargetVoxFolder.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseTargetVoxFolder.TabIndex = 22;
            this.btnBrowseTargetVoxFolder.Text = "Browse";
            this.btnBrowseTargetVoxFolder.UseVisualStyleBackColor = true;
            this.btnBrowseTargetVoxFolder.Click += new System.EventHandler(this.btnBrowseTargetVoxFolder_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 164);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(728, 396);
            this.dataGridView1.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Missing Voxs:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(626, 104);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 39);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmAutoCopyPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(728, 560);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnBrowseTargetVoxFolder);
            this.Controls.Add(this.txtTargetVoxFolder);
            this.Controls.Add(this.btnBrowseSourceVoxFolder);
            this.Controls.Add(this.txtSourceVoxFolder);
            this.Controls.Add(this.btnBrowseTtsFolder);
            this.Controls.Add(this.txtTtsFolder);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmAutoCopyPrompt";
            this.Text = "Auto Copy Prompt";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserTts;
        private System.Windows.Forms.TextBox txtTtsFolder;
        private System.Windows.Forms.Button btnBrowseTtsFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSourceVoxFolder;
        private System.Windows.Forms.Button btnBrowseSourceVoxFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserSourceVox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTargetVoxFolder;
        private System.Windows.Forms.Button btnBrowseTargetVoxFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserTargetVox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}

