namespace Presentation
{
    partial class frmFacebook
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
            this.tabFacebook = new System.Windows.Forms.TabControl();
            this.tabLogin = new System.Windows.Forms.TabPage();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabFindJoinGroup = new System.Windows.Forms.TabPage();
            this.dtgvGroups = new System.Windows.Forms.DataGridView();
            this.btnSearchGroup = new System.Windows.Forms.Button();
            this.txtSearchKey = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPostToGroup = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnFindGroup = new System.Windows.Forms.Button();
            this.dtgvGroupsJoined = new System.Windows.Forms.DataGridView();
            this.tabFacebook.SuspendLayout();
            this.tabLogin.SuspendLayout();
            this.tabFindJoinGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroups)).BeginInit();
            this.tabPostToGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroupsJoined)).BeginInit();
            this.SuspendLayout();
            // 
            // tabFacebook
            // 
            this.tabFacebook.Controls.Add(this.tabLogin);
            this.tabFacebook.Controls.Add(this.tabFindJoinGroup);
            this.tabFacebook.Controls.Add(this.tabPostToGroup);
            this.tabFacebook.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabFacebook.Location = new System.Drawing.Point(0, 0);
            this.tabFacebook.Name = "tabFacebook";
            this.tabFacebook.SelectedIndex = 0;
            this.tabFacebook.Size = new System.Drawing.Size(886, 472);
            this.tabFacebook.TabIndex = 0;
            // 
            // tabLogin
            // 
            this.tabLogin.Controls.Add(this.btnLogin);
            this.tabLogin.Controls.Add(this.txtPass);
            this.tabLogin.Controls.Add(this.label2);
            this.tabLogin.Controls.Add(this.txtEmail);
            this.tabLogin.Controls.Add(this.label1);
            this.tabLogin.Location = new System.Drawing.Point(4, 22);
            this.tabLogin.Name = "tabLogin";
            this.tabLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogin.Size = new System.Drawing.Size(878, 446);
            this.tabLogin.TabIndex = 0;
            this.tabLogin.Text = "Tài khoản";
            this.tabLogin.UseVisualStyleBackColor = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(93, 98);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(63, 62);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(249, 20);
            this.txtPass.TabIndex = 3;
            this.txtPass.Text = "nguoicodoc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pass:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(63, 36);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(249, 20);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "hongthanh0611@gmail.com";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Email:";
            // 
            // tabFindJoinGroup
            // 
            this.tabFindJoinGroup.Controls.Add(this.dtgvGroups);
            this.tabFindJoinGroup.Controls.Add(this.btnSearchGroup);
            this.tabFindJoinGroup.Controls.Add(this.txtSearchKey);
            this.tabFindJoinGroup.Controls.Add(this.label3);
            this.tabFindJoinGroup.Location = new System.Drawing.Point(4, 22);
            this.tabFindJoinGroup.Name = "tabFindJoinGroup";
            this.tabFindJoinGroup.Padding = new System.Windows.Forms.Padding(3);
            this.tabFindJoinGroup.Size = new System.Drawing.Size(878, 446);
            this.tabFindJoinGroup.TabIndex = 1;
            this.tabFindJoinGroup.Text = "Find & Join Group";
            this.tabFindJoinGroup.UseVisualStyleBackColor = true;
            // 
            // dtgvGroups
            // 
            this.dtgvGroups.AllowUserToAddRows = false;
            this.dtgvGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvGroups.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvGroups.Location = new System.Drawing.Point(3, 92);
            this.dtgvGroups.Name = "dtgvGroups";
            this.dtgvGroups.Size = new System.Drawing.Size(872, 351);
            this.dtgvGroups.TabIndex = 3;
            // 
            // btnSearchGroup
            // 
            this.btnSearchGroup.Location = new System.Drawing.Point(542, 22);
            this.btnSearchGroup.Name = "btnSearchGroup";
            this.btnSearchGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGroup.TabIndex = 2;
            this.btnSearchGroup.Text = "Search";
            this.btnSearchGroup.UseVisualStyleBackColor = true;
            this.btnSearchGroup.Click += new System.EventHandler(this.btnSearchGroup_Click);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(77, 24);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Size = new System.Drawing.Size(423, 20);
            this.txtSearchKey.TabIndex = 1;
            this.txtSearchKey.Text = "ThanhPham Test";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Từ khóa:";
            // 
            // tabPostToGroup
            // 
            this.tabPostToGroup.Controls.Add(this.dtgvGroupsJoined);
            this.tabPostToGroup.Controls.Add(this.btnFindGroup);
            this.tabPostToGroup.Controls.Add(this.txtMessage);
            this.tabPostToGroup.Controls.Add(this.label4);
            this.tabPostToGroup.Location = new System.Drawing.Point(4, 22);
            this.tabPostToGroup.Name = "tabPostToGroup";
            this.tabPostToGroup.Size = new System.Drawing.Size(878, 446);
            this.tabPostToGroup.TabIndex = 2;
            this.tabPostToGroup.Text = "Post To Group";
            this.tabPostToGroup.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(315, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "label4";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(371, 26);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(323, 20);
            this.txtMessage.TabIndex = 1;
            // 
            // btnFindGroup
            // 
            this.btnFindGroup.Location = new System.Drawing.Point(22, 18);
            this.btnFindGroup.Name = "btnFindGroup";
            this.btnFindGroup.Size = new System.Drawing.Size(75, 23);
            this.btnFindGroup.TabIndex = 2;
            this.btnFindGroup.Text = "Lấy Group";
            this.btnFindGroup.UseVisualStyleBackColor = true;
            this.btnFindGroup.Click += new System.EventHandler(this.btnFindGroup_Click);
            // 
            // dtgvGroupsJoined
            // 
            this.dtgvGroupsJoined.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvGroupsJoined.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgvGroupsJoined.Location = new System.Drawing.Point(0, 67);
            this.dtgvGroupsJoined.Name = "dtgvGroupsJoined";
            this.dtgvGroupsJoined.Size = new System.Drawing.Size(878, 379);
            this.dtgvGroupsJoined.TabIndex = 3;
            // 
            // frmFacebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 472);
            this.Controls.Add(this.tabFacebook);
            this.Name = "frmFacebook";
            this.Text = "Facebook Tools";
            this.tabFacebook.ResumeLayout(false);
            this.tabLogin.ResumeLayout(false);
            this.tabLogin.PerformLayout();
            this.tabFindJoinGroup.ResumeLayout(false);
            this.tabFindJoinGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroups)).EndInit();
            this.tabPostToGroup.ResumeLayout(false);
            this.tabPostToGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroupsJoined)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabFacebook;
        private System.Windows.Forms.TabPage tabLogin;
        private System.Windows.Forms.TabPage tabFindJoinGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSearchKey;
        private System.Windows.Forms.Button btnSearchGroup;
        private System.Windows.Forms.DataGridView dtgvGroups;
        private System.Windows.Forms.TabPage tabPostToGroup;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnFindGroup;
        private System.Windows.Forms.DataGridView dtgvGroupsJoined;
    }
}