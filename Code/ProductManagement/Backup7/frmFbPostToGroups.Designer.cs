namespace Presentation
{
    partial class frmFbPostToGroups
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtTimeBetweenPost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPostToGroup = new System.Windows.Forms.Button();
            this.btnBrowseImages = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImages = new System.Windows.Forms.TextBox();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.webFB = new System.Windows.Forms.WebBrowser();
            this.dtgvGroupList = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnShowHideWbPostToGroups = new System.Windows.Forms.Button();
            this.btnLoadGroup = new System.Windows.Forms.Button();
            this.timeCheck = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timerDelayBetweenPost = new System.Windows.Forms.Timer(this.components);
            this.timerTemp = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroupList)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 68);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1101, 500);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtTimeBetweenPost);
            this.groupBox6.Controls.Add(this.label5);
            this.groupBox6.Controls.Add(this.btnPostToGroup);
            this.groupBox6.Controls.Add(this.btnBrowseImages);
            this.groupBox6.Controls.Add(this.label4);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Controls.Add(this.txtImages);
            this.groupBox6.Controls.Add(this.txtCaption);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(526, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(572, 481);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Post info:";
            // 
            // txtTimeBetweenPost
            // 
            this.txtTimeBetweenPost.Location = new System.Drawing.Point(124, 410);
            this.txtTimeBetweenPost.Name = "txtTimeBetweenPost";
            this.txtTimeBetweenPost.Size = new System.Drawing.Size(100, 20);
            this.txtTimeBetweenPost.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 413);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Time between post:";
            // 
            // btnPostToGroup
            // 
            this.btnPostToGroup.Location = new System.Drawing.Point(291, 423);
            this.btnPostToGroup.Name = "btnPostToGroup";
            this.btnPostToGroup.Size = new System.Drawing.Size(116, 41);
            this.btnPostToGroup.TabIndex = 1;
            this.btnPostToGroup.Text = "Post Group";
            this.btnPostToGroup.UseVisualStyleBackColor = true;
            this.btnPostToGroup.Click += new System.EventHandler(this.btnPostToGroup_Click);
            // 
            // btnBrowseImages
            // 
            this.btnBrowseImages.Location = new System.Drawing.Point(431, 362);
            this.btnBrowseImages.Name = "btnBrowseImages";
            this.btnBrowseImages.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseImages.TabIndex = 4;
            this.btnBrowseImages.Text = "Browse";
            this.btnBrowseImages.UseVisualStyleBackColor = true;
            this.btnBrowseImages.Click += new System.EventHandler(this.btnBrowseImages_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 314);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Images:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Caption:";
            // 
            // txtImages
            // 
            this.txtImages.Location = new System.Drawing.Point(21, 344);
            this.txtImages.Multiline = true;
            this.txtImages.Name = "txtImages";
            this.txtImages.Size = new System.Drawing.Size(404, 55);
            this.txtImages.TabIndex = 1;
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(21, 42);
            this.txtCaption.Multiline = true;
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(453, 256);
            this.txtCaption.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.webFB);
            this.groupBox5.Controls.Add(this.dtgvGroupList);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(3, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(523, 481);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Group List:";
            // 
            // webFB
            // 
            this.webFB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webFB.Location = new System.Drawing.Point(3, 16);
            this.webFB.MinimumSize = new System.Drawing.Size(20, 20);
            this.webFB.Name = "webFB";
            this.webFB.Size = new System.Drawing.Size(517, 462);
            this.webFB.TabIndex = 3;
            this.webFB.Url = new System.Uri("https://m.facebook.com", System.UriKind.Absolute);
            this.webFB.Visible = false;
            // 
            // dtgvGroupList
            // 
            this.dtgvGroupList.AllowUserToAddRows = false;
            this.dtgvGroupList.AllowUserToDeleteRows = false;
            this.dtgvGroupList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvGroupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvGroupList.Location = new System.Drawing.Point(3, 16);
            this.dtgvGroupList.Name = "dtgvGroupList";
            this.dtgvGroupList.Size = new System.Drawing.Size(517, 462);
            this.dtgvGroupList.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnShowHideWbPostToGroups);
            this.groupBox3.Controls.Add(this.btnLoadGroup);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1101, 68);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Post Info:";
            // 
            // btnShowHideWbPostToGroups
            // 
            this.btnShowHideWbPostToGroups.Location = new System.Drawing.Point(209, 34);
            this.btnShowHideWbPostToGroups.Name = "btnShowHideWbPostToGroups";
            this.btnShowHideWbPostToGroups.Size = new System.Drawing.Size(113, 23);
            this.btnShowHideWbPostToGroups.TabIndex = 12;
            this.btnShowHideWbPostToGroups.Text = "Show/Hide WEB";
            this.btnShowHideWbPostToGroups.UseVisualStyleBackColor = true;
            this.btnShowHideWbPostToGroups.Click += new System.EventHandler(this.btnShowHideWbPostToGroups_Click);
            // 
            // btnLoadGroup
            // 
            this.btnLoadGroup.Location = new System.Drawing.Point(43, 34);
            this.btnLoadGroup.Name = "btnLoadGroup";
            this.btnLoadGroup.Size = new System.Drawing.Size(100, 23);
            this.btnLoadGroup.TabIndex = 0;
            this.btnLoadGroup.Text = "Load Groups";
            this.btnLoadGroup.UseVisualStyleBackColor = true;
            this.btnLoadGroup.Click += new System.EventHandler(this.btnLoadGroup_Click);
            // 
            // timeCheck
            // 
            this.timeCheck.Tick += new System.EventHandler(this.timeCheck_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // timerDelayBetweenPost
            // 
            this.timerDelayBetweenPost.Tick += new System.EventHandler(this.timerDelayBetweenPost_Tick);
            // 
            // timerTemp
            // 
            this.timerTemp.Interval = 5000;
            // 
            // frmFbPostToGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 568);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmFbPostToGroups";
            this.Text = "Post To Group";
            this.Load += new System.EventHandler(this.frmFbPostToGroups_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFbPostToGroups_FormClosed);
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroupList)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtTimeBetweenPost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPostToGroup;
        private System.Windows.Forms.Button btnBrowseImages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImages;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dtgvGroupList;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLoadGroup;
        private System.Windows.Forms.WebBrowser webFB;
        private System.Windows.Forms.Button btnShowHideWbPostToGroups;
        private System.Windows.Forms.Timer timeCheck;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timerDelayBetweenPost;
        private System.Windows.Forms.Timer timerTemp;
    }
}