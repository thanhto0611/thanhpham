namespace Presentation
{
    partial class frmThemTheLoai
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnThoatThem = new System.Windows.Forms.Button();
            this.txtThemMaLoaiSach = new System.Windows.Forms.TextBox();
            this.txtThemTenLoaiSach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.btnThoatThem);
            this.groupBox1.Controls.Add(this.txtThemMaLoaiSach);
            this.groupBox1.Controls.Add(this.txtThemTenLoaiSach);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(307, 123);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // btnThem
            // 
            this.btnThem.Font = new System.Drawing.Font("Arial", 9F);
            this.btnThem.Location = new System.Drawing.Point(142, 93);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(76, 24);
            this.btnThem.TabIndex = 35;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            // 
            // btnThoatThem
            // 
            this.btnThoatThem.Font = new System.Drawing.Font("Arial", 9F);
            this.btnThoatThem.Location = new System.Drawing.Point(224, 93);
            this.btnThoatThem.Name = "btnThoatThem";
            this.btnThoatThem.Size = new System.Drawing.Size(76, 24);
            this.btnThoatThem.TabIndex = 34;
            this.btnThoatThem.Text = "Thoát";
            this.btnThoatThem.UseVisualStyleBackColor = true;
            this.btnThoatThem.Click += new System.EventHandler(this.btnThoatThem_Click);
            // 
            // txtThemMaLoaiSach
            // 
            this.txtThemMaLoaiSach.Font = new System.Drawing.Font("Arial", 9F);
            this.txtThemMaLoaiSach.Location = new System.Drawing.Point(112, 18);
            this.txtThemMaLoaiSach.Name = "txtThemMaLoaiSach";
            this.txtThemMaLoaiSach.ReadOnly = true;
            this.txtThemMaLoaiSach.Size = new System.Drawing.Size(188, 21);
            this.txtThemMaLoaiSach.TabIndex = 32;
            // 
            // txtThemTenLoaiSach
            // 
            this.txtThemTenLoaiSach.Font = new System.Drawing.Font("Arial", 9F);
            this.txtThemTenLoaiSach.Location = new System.Drawing.Point(112, 63);
            this.txtThemTenLoaiSach.Name = "txtThemTenLoaiSach";
            this.txtThemTenLoaiSach.Size = new System.Drawing.Size(188, 21);
            this.txtThemTenLoaiSach.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F);
            this.label4.Location = new System.Drawing.Point(17, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 15);
            this.label4.TabIndex = 30;
            this.label4.Text = "Tên Loại Sách:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(22, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Mã Loại Sách:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 45);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 16F);
            this.label1.Location = new System.Drawing.Point(70, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 31;
            this.label1.Text = "Thêm Loại Sách";
            // 
            // frmThemTheLoai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(307, 178);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmThemTheLoai";
            this.Text = "Thêm Thể Loại Mới";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnThoatThem;
        private System.Windows.Forms.TextBox txtThemMaLoaiSach;
        private System.Windows.Forms.TextBox txtThemTenLoaiSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;

    }
}