namespace Presentation
{
    partial class frmConfig
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
            this.chbxTichLuyDiem = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chbxTichLuyDiem
            // 
            this.chbxTichLuyDiem.AutoSize = true;
            this.chbxTichLuyDiem.Location = new System.Drawing.Point(35, 31);
            this.chbxTichLuyDiem.Name = "chbxTichLuyDiem";
            this.chbxTichLuyDiem.Size = new System.Drawing.Size(96, 17);
            this.chbxTichLuyDiem.TabIndex = 1;
            this.chbxTichLuyDiem.Text = "Tích Lũy Điểm";
            this.chbxTichLuyDiem.UseVisualStyleBackColor = true;
            this.chbxTichLuyDiem.CheckedChanged += new System.EventHandler(this.chbxTichLuyDiem_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(627, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 59);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 485);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chbxTichLuyDiem);
            this.Name = "frmConfig";
            this.Text = "Application Config";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmConfig_FormClosed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConfig_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbxTichLuyDiem;
        private System.Windows.Forms.Button btnSave;
    }
}