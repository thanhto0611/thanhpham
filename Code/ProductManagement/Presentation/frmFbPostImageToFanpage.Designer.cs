namespace Presentation
{
    partial class frmFbPostImageToFanpage
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
            this.components = new System.ComponentModel.Container();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.wbPostToFanpage = new System.Windows.Forms.WebBrowser();
            this.dtgvAlbumImages = new System.Windows.Forms.DataGridView();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.btnShowHideWbPostToFanpage = new System.Windows.Forms.Button();
            this.txtDelayAlbumPost = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAlbumImageCaption = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnPostToAlbum = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnBrowseAlbumImages = new System.Windows.Forms.Button();
            this.txtAlbumImages = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxAlbumList = new System.Windows.Forms.ComboBox();
            this.btnGetAlbumList = new System.Windows.Forms.Button();
            this.timeCheck = new System.Windows.Forms.Timer(this.components);
            this.openAlbumImages = new System.Windows.Forms.OpenFileDialog();
            this.timerPostToAlbum = new System.Windows.Forms.Timer(this.components);
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAlbumImages)).BeginInit();
            this.groupBox9.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.wbPostToFanpage);
            this.groupBox10.Controls.Add(this.dtgvAlbumImages);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(0, 221);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(1043, 338);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Post Result:";
            // 
            // wbPostToFanpage
            // 
            this.wbPostToFanpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbPostToFanpage.Location = new System.Drawing.Point(3, 16);
            this.wbPostToFanpage.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbPostToFanpage.Name = "wbPostToFanpage";
            this.wbPostToFanpage.Size = new System.Drawing.Size(1037, 319);
            this.wbPostToFanpage.TabIndex = 11;
            this.wbPostToFanpage.Url = new System.Uri("https://m.facebook.com", System.UriKind.Absolute);
            this.wbPostToFanpage.Visible = false;
            // 
            // dtgvAlbumImages
            // 
            this.dtgvAlbumImages.AllowUserToAddRows = false;
            this.dtgvAlbumImages.AllowUserToDeleteRows = false;
            this.dtgvAlbumImages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAlbumImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvAlbumImages.Location = new System.Drawing.Point(3, 16);
            this.dtgvAlbumImages.Name = "dtgvAlbumImages";
            this.dtgvAlbumImages.Size = new System.Drawing.Size(1037, 319);
            this.dtgvAlbumImages.TabIndex = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.btnShowHideWbPostToFanpage);
            this.groupBox9.Controls.Add(this.txtDelayAlbumPost);
            this.groupBox9.Controls.Add(this.label10);
            this.groupBox9.Controls.Add(this.txtAlbumImageCaption);
            this.groupBox9.Controls.Add(this.label9);
            this.groupBox9.Controls.Add(this.btnPostToAlbum);
            this.groupBox9.Controls.Add(this.label8);
            this.groupBox9.Controls.Add(this.btnBrowseAlbumImages);
            this.groupBox9.Controls.Add(this.txtAlbumImages);
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.cbxAlbumList);
            this.groupBox9.Controls.Add(this.btnGetAlbumList);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(0, 0);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1043, 221);
            this.groupBox9.TabIndex = 2;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Album list:";
            // 
            // btnShowHideWbPostToFanpage
            // 
            this.btnShowHideWbPostToFanpage.Location = new System.Drawing.Point(722, 35);
            this.btnShowHideWbPostToFanpage.Name = "btnShowHideWbPostToFanpage";
            this.btnShowHideWbPostToFanpage.Size = new System.Drawing.Size(113, 23);
            this.btnShowHideWbPostToFanpage.TabIndex = 11;
            this.btnShowHideWbPostToFanpage.Text = "Show/Hide WEB";
            this.btnShowHideWbPostToFanpage.UseVisualStyleBackColor = true;
            this.btnShowHideWbPostToFanpage.Click += new System.EventHandler(this.btnShowHideWbPostToFanpage_Click);
            // 
            // txtDelayAlbumPost
            // 
            this.txtDelayAlbumPost.Location = new System.Drawing.Point(711, 179);
            this.txtDelayAlbumPost.Name = "txtDelayAlbumPost";
            this.txtDelayAlbumPost.Size = new System.Drawing.Size(167, 20);
            this.txtDelayAlbumPost.TabIndex = 10;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(588, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "Delay Between Post:";
            // 
            // txtAlbumImageCaption
            // 
            this.txtAlbumImageCaption.Location = new System.Drawing.Point(122, 164);
            this.txtAlbumImageCaption.Multiline = true;
            this.txtAlbumImageCaption.Name = "txtAlbumImageCaption";
            this.txtAlbumImageCaption.Size = new System.Drawing.Size(426, 46);
            this.txtAlbumImageCaption.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 167);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Caption:";
            // 
            // btnPostToAlbum
            // 
            this.btnPostToAlbum.Location = new System.Drawing.Point(722, 78);
            this.btnPostToAlbum.Name = "btnPostToAlbum";
            this.btnPostToAlbum.Size = new System.Drawing.Size(87, 62);
            this.btnPostToAlbum.TabIndex = 6;
            this.btnPostToAlbum.Text = "Post To Album";
            this.btnPostToAlbum.UseVisualStyleBackColor = true;
            this.btnPostToAlbum.Click += new System.EventHandler(this.btnPostToAlbum_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Album List:";
            // 
            // btnBrowseAlbumImages
            // 
            this.btnBrowseAlbumImages.Location = new System.Drawing.Point(591, 104);
            this.btnBrowseAlbumImages.Name = "btnBrowseAlbumImages";
            this.btnBrowseAlbumImages.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseAlbumImages.TabIndex = 4;
            this.btnBrowseAlbumImages.Text = "Browse";
            this.btnBrowseAlbumImages.UseVisualStyleBackColor = true;
            this.btnBrowseAlbumImages.Click += new System.EventHandler(this.btnBrowseAlbumImages_Click);
            // 
            // txtAlbumImages
            // 
            this.txtAlbumImages.Location = new System.Drawing.Point(122, 81);
            this.txtAlbumImages.Multiline = true;
            this.txtAlbumImages.Name = "txtAlbumImages";
            this.txtAlbumImages.Size = new System.Drawing.Size(426, 59);
            this.txtAlbumImages.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Post Images:";
            // 
            // cbxAlbumList
            // 
            this.cbxAlbumList.FormattingEnabled = true;
            this.cbxAlbumList.Location = new System.Drawing.Point(122, 37);
            this.cbxAlbumList.Name = "cbxAlbumList";
            this.cbxAlbumList.Size = new System.Drawing.Size(426, 21);
            this.cbxAlbumList.TabIndex = 1;
            // 
            // btnGetAlbumList
            // 
            this.btnGetAlbumList.Location = new System.Drawing.Point(591, 26);
            this.btnGetAlbumList.Name = "btnGetAlbumList";
            this.btnGetAlbumList.Size = new System.Drawing.Size(96, 40);
            this.btnGetAlbumList.TabIndex = 0;
            this.btnGetAlbumList.Text = "Get Album List";
            this.btnGetAlbumList.UseVisualStyleBackColor = true;
            this.btnGetAlbumList.Click += new System.EventHandler(this.btnGetAlbumList_Click);
            // 
            // timeCheck
            // 
            this.timeCheck.Tick += new System.EventHandler(this.timeCheck_Tick);
            // 
            // openAlbumImages
            // 
            this.openAlbumImages.FileName = "openFileDialog2";
            this.openAlbumImages.Multiselect = true;
            this.openAlbumImages.FileOk += new System.ComponentModel.CancelEventHandler(this.openAlbumImages_FileOk);
            // 
            // timerPostToAlbum
            // 
            this.timerPostToAlbum.Interval = 7200000;
            this.timerPostToAlbum.Tick += new System.EventHandler(this.timerPostToAlbum_Tick);
            // 
            // frmFbPostImageToFanpage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 559);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.groupBox9);
            this.Name = "frmFbPostImageToFanpage";
            this.Text = "Post Image To Fanpage";
            this.Load += new System.EventHandler(this.frmFbPostImageToFanpage_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFbPostImageToFanpage_FormClosed);
            this.groupBox10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAlbumImages)).EndInit();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.WebBrowser wbPostToFanpage;
        private System.Windows.Forms.DataGridView dtgvAlbumImages;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Button btnShowHideWbPostToFanpage;
        private System.Windows.Forms.TextBox txtDelayAlbumPost;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtAlbumImageCaption;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnPostToAlbum;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnBrowseAlbumImages;
        private System.Windows.Forms.TextBox txtAlbumImages;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxAlbumList;
        private System.Windows.Forms.Button btnGetAlbumList;
        private System.Windows.Forms.Timer timeCheck;
        private System.Windows.Forms.OpenFileDialog openAlbumImages;
        private System.Windows.Forms.Timer timerPostToAlbum;
    }
}