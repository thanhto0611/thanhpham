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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.pEVariablesSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PESearch = new System.Windows.Forms.ToolStripMenuItem();
            this.copyVoxFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.windows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pEVariablesSearchToolStripMenuItem,
            this.windows});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.windows;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(972, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // pEVariablesSearchToolStripMenuItem
            // 
            this.pEVariablesSearchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PESearch,
            this.copyVoxFiles});
            this.pEVariablesSearchToolStripMenuItem.Name = "pEVariablesSearchToolStripMenuItem";
            this.pEVariablesSearchToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.pEVariablesSearchToolStripMenuItem.Text = "Tools";
            // 
            // PESearch
            // 
            this.PESearch.Name = "PESearch";
            this.PESearch.Size = new System.Drawing.Size(175, 22);
            this.PESearch.Text = "PE Variables Search";
            this.PESearch.Click += new System.EventHandler(this.PESearch_Click);
            // 
            // copyVoxFiles
            // 
            this.copyVoxFiles.Name = "copyVoxFiles";
            this.copyVoxFiles.Size = new System.Drawing.Size(175, 22);
            this.copyVoxFiles.Text = "Copy Vox Files";
            this.copyVoxFiles.Click += new System.EventHandler(this.copyVoxFiles_Click);
            // 
            // windows
            // 
            this.windows.Name = "windows";
            this.windows.Size = new System.Drawing.Size(68, 20);
            this.windows.Text = "Windows";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(972, 625);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Adeptra Tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem pEVariablesSearchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PESearch;
        private System.Windows.Forms.ToolStripMenuItem copyVoxFiles;
        private System.Windows.Forms.ToolStripMenuItem windows;


    }
}

