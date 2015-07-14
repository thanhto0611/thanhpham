namespace Adeptra_Tools
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.visioCompareToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.variableSearchToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonClose = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.copyVoxFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visioCompareToolStripButton,
            this.toolStripSeparator1,
            this.variableSearchToolStripButton,
            this.toolStripSeparator4,
            this.copyVoxFile,
            this.toolStripSeparator2,
            this.toolStripButtonClose});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(752, 82);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // visioCompareToolStripButton
            // 
            this.visioCompareToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("visioCompareToolStripButton.Image")));
            this.visioCompareToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.visioCompareToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.visioCompareToolStripButton.Name = "visioCompareToolStripButton";
            this.visioCompareToolStripButton.Size = new System.Drawing.Size(88, 79);
            this.visioCompareToolStripButton.Text = "Visio Compare";
            this.visioCompareToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.visioCompareToolStripButton.Click += new System.EventHandler(this.visioCompareToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 82);
            // 
            // variableSearchToolStripButton
            // 
            this.variableSearchToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("variableSearchToolStripButton.Image")));
            this.variableSearchToolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.variableSearchToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.variableSearchToolStripButton.Name = "variableSearchToolStripButton";
            this.variableSearchToolStripButton.Size = new System.Drawing.Size(129, 79);
            this.variableSearchToolStripButton.Text = "PE.xml Variable Search";
            this.variableSearchToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.variableSearchToolStripButton.Click += new System.EventHandler(this.variableSearchToolStripButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 82);
            // 
            // toolStripButtonClose
            // 
            this.toolStripButtonClose.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonClose.Image")));
            this.toolStripButtonClose.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClose.Name = "toolStripButtonClose";
            this.toolStripButtonClose.Size = new System.Drawing.Size(44, 79);
            this.toolStripButtonClose.Text = "Close";
            this.toolStripButtonClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonClose.Click += new System.EventHandler(this.toolStripButtonClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(526, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Version 2.0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(414, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 43);
            this.label1.TabIndex = 6;
            this.label1.Text = "ADEPTRA TOOLS";
            // 
            // copyVoxFile
            // 
            this.copyVoxFile.Image = ((System.Drawing.Image)(resources.GetObject("copyVoxFile.Image")));
            this.copyVoxFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.copyVoxFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyVoxFile.Name = "copyVoxFile";
            this.copyVoxFile.Size = new System.Drawing.Size(82, 79);
            this.copyVoxFile.Text = "Copy Vox File";
            this.copyVoxFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.copyVoxFile.Click += new System.EventHandler(this.copyVoxFile_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 82);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(752, 575);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip2);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Adeptra Tools";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton visioCompareToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton variableSearchToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton copyVoxFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

    }
}

