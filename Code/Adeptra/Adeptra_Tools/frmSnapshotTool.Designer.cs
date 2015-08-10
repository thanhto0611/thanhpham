namespace Adeptra_Tools
{
    partial class frmSnapshotTool
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
            this.btnCheck = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.listPortfolioName = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRawData = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtReg = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(197, 34);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 1;
            this.btnCheck.Text = "Check";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 242);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1180, 472);
            this.tabControl1.TabIndex = 3;
            // 
            // listPortfolioName
            // 
            this.listPortfolioName.FormattingEnabled = true;
            this.listPortfolioName.Location = new System.Drawing.Point(40, 28);
            this.listPortfolioName.Name = "listPortfolioName";
            this.listPortfolioName.Size = new System.Drawing.Size(120, 160);
            this.listPortfolioName.TabIndex = 4;
            this.listPortfolioName.SelectedIndexChanged += new System.EventHandler(this.listPortfolioName_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(836, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRawData
            // 
            this.txtRawData.Location = new System.Drawing.Point(448, 34);
            this.txtRawData.Multiline = true;
            this.txtRawData.Name = "txtRawData";
            this.txtRawData.Size = new System.Drawing.Size(322, 183);
            this.txtRawData.TabIndex = 6;
            this.txtRawData.Text = "<span data-raw=\"inputPayload\" class=\"drag-variable\" value=\"inputPayload\">Input Pa" +
                "yload</span>";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(894, 148);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(179, 20);
            this.textBox1.TabIndex = 7;
            // 
            // txtReg
            // 
            this.txtReg.Location = new System.Drawing.Point(836, 73);
            this.txtReg.Name = "txtReg";
            this.txtReg.Size = new System.Drawing.Size(100, 20);
            this.txtReg.TabIndex = 8;
            this.txtReg.Text = "<span data-raw=\\\"([0-9a-zA-Z :.-]{0,}).*\">([0-9a-zA-Z :.-]{0,})<\\/span>";
            // 
            // frmSnapshotTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 714);
            this.Controls.Add(this.txtReg);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtRawData);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listPortfolioName);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnCheck);
            this.Name = "frmSnapshotTool";
            this.Text = "frmSnapshotTool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ListBox listPortfolioName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRawData;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtReg;
    }
}