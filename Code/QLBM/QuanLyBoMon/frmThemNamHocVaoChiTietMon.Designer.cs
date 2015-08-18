namespace QuanLyBoMon
{
    partial class frmThemNamHocVaoChiTietMon
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.cmbNamHoc = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThoat.ForeColor = System.Drawing.Color.Red;
            this.btnThoat.Location = new System.Drawing.Point(56, 64);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(101, 64);
            this.btnThoat.TabIndex = 6;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cmbNamHoc
            // 
            this.cmbNamHoc.FormattingEnabled = true;
            this.cmbNamHoc.Location = new System.Drawing.Point(69, 25);
            this.cmbNamHoc.Name = "cmbNamHoc";
            this.cmbNamHoc.Size = new System.Drawing.Size(108, 21);
            this.cmbNamHoc.TabIndex = 5;
            this.cmbNamHoc.SelectedIndexChanged += new System.EventHandler(this.cmbNamHoc_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Năm Học:";
            // 
            // frmThemNamHocVaoChiTietMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 148);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.cmbNamHoc);
            this.Controls.Add(this.label1);
            this.Name = "frmThemNamHocVaoChiTietMon";
            this.Text = "frmThemNamHocVaoChiTietMon";
            this.Load += new System.EventHandler(this.frmThemNamHocVaoChiTietMon_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cmbNamHoc;
        private System.Windows.Forms.Label label1;
    }
}