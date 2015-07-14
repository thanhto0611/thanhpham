namespace CheckBlockList
{
    partial class frmCheckBlockList
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
            this.txtFileLocation1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtFileLocation1
            // 
            this.txtFileLocation1.Location = new System.Drawing.Point(77, 12);
            this.txtFileLocation1.Name = "txtFileLocation1";
            this.txtFileLocation1.Size = new System.Drawing.Size(356, 20);
            this.txtFileLocation1.TabIndex = 11;
            this.txtFileLocation1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtFileLocation1_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Visio File:";
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Location = new System.Drawing.Point(450, 9);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse1.TabIndex = 9;
            this.btnBrowse1.Text = "Browse";
            this.btnBrowse1.UseVisualStyleBackColor = true;
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(255, 90);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(96, 94);
            this.btnCheck.TabIndex = 12;
            this.btnCheck.Text = "CHECK";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // frmCheckBlockList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 353);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtFileLocation1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBrowse1);
            this.Name = "frmCheckBlockList";
            this.Text = "Check Block List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFileLocation1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnCheck;
    }
}

