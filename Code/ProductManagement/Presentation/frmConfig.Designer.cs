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
            this.cbUseAPISync = new System.Windows.Forms.CheckBox();
            this.txtSoapAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            // cbUseAPISync
            // 
            this.cbUseAPISync.AutoSize = true;
            this.cbUseAPISync.Location = new System.Drawing.Point(35, 54);
            this.cbUseAPISync.Name = "cbUseAPISync";
            this.cbUseAPISync.Size = new System.Drawing.Size(92, 17);
            this.cbUseAPISync.TabIndex = 3;
            this.cbUseAPISync.Text = "Use API Sync";
            this.cbUseAPISync.UseVisualStyleBackColor = true;
            this.cbUseAPISync.CheckedChanged += new System.EventHandler(this.cbUseAPISync_CheckedChanged);
            // 
            // txtSoapAddress
            // 
            this.txtSoapAddress.Location = new System.Drawing.Point(111, 77);
            this.txtSoapAddress.Name = "txtSoapAddress";
            this.txtSoapAddress.Size = new System.Drawing.Size(295, 20);
            this.txtSoapAddress.TabIndex = 4;
            this.txtSoapAddress.TextChanged += new System.EventHandler(this.txtSoapAddress_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SOAP Address:";
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 485);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSoapAddress);
            this.Controls.Add(this.cbUseAPISync);
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
        private System.Windows.Forms.CheckBox cbUseAPISync;
        private System.Windows.Forms.TextBox txtSoapAddress;
        private System.Windows.Forms.Label label1;
    }
}