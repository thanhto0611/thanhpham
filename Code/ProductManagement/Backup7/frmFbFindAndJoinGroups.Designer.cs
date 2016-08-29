namespace Presentation
{
    partial class frmFbFindAndJoinGroups
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
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.wbFindAndJoinGroups = new System.Windows.Forms.WebBrowser();
            this.dtgvGroupSearchResult = new System.Windows.Forms.DataGridView();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnShowHideWbFindAndJoinGroups = new System.Windows.Forms.Button();
            this.btnUpdateGroups = new System.Windows.Forms.Button();
            this.btnSaveGroups = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumOfGroup = new System.Windows.Forms.TextBox();
            this.btnJoinGroup = new System.Windows.Forms.Button();
            this.btnSearchGroup = new System.Windows.Forms.Button();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.timeCheck = new System.Windows.Forms.Timer(this.components);
            this.timerJoin = new System.Windows.Forms.Timer(this.components);
            this.timerTemp = new System.Windows.Forms.Timer(this.components);
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroupSearchResult)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.wbFindAndJoinGroups);
            this.groupBox8.Controls.Add(this.dtgvGroupSearchResult);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(0, 100);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(918, 419);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Search Results";
            // 
            // wbFindAndJoinGroups
            // 
            this.wbFindAndJoinGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbFindAndJoinGroups.Location = new System.Drawing.Point(3, 16);
            this.wbFindAndJoinGroups.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbFindAndJoinGroups.Name = "wbFindAndJoinGroups";
            this.wbFindAndJoinGroups.Size = new System.Drawing.Size(912, 400);
            this.wbFindAndJoinGroups.TabIndex = 12;
            this.wbFindAndJoinGroups.Url = new System.Uri("https://m.facebook.com", System.UriKind.Absolute);
            this.wbFindAndJoinGroups.Visible = false;
            // 
            // dtgvGroupSearchResult
            // 
            this.dtgvGroupSearchResult.AllowUserToAddRows = false;
            this.dtgvGroupSearchResult.AllowUserToDeleteRows = false;
            this.dtgvGroupSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvGroupSearchResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvGroupSearchResult.Location = new System.Drawing.Point(3, 16);
            this.dtgvGroupSearchResult.Name = "dtgvGroupSearchResult";
            this.dtgvGroupSearchResult.Size = new System.Drawing.Size(912, 400);
            this.dtgvGroupSearchResult.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnShowHideWbFindAndJoinGroups);
            this.groupBox7.Controls.Add(this.btnUpdateGroups);
            this.groupBox7.Controls.Add(this.btnSaveGroups);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.txtNumOfGroup);
            this.groupBox7.Controls.Add(this.btnJoinGroup);
            this.groupBox7.Controls.Add(this.btnSearchGroup);
            this.groupBox7.Controls.Add(this.txtGroupName);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(918, 100);
            this.groupBox7.TabIndex = 2;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Search Info:";
            // 
            // btnShowHideWbFindAndJoinGroups
            // 
            this.btnShowHideWbFindAndJoinGroups.Location = new System.Drawing.Point(557, 31);
            this.btnShowHideWbFindAndJoinGroups.Name = "btnShowHideWbFindAndJoinGroups";
            this.btnShowHideWbFindAndJoinGroups.Size = new System.Drawing.Size(113, 23);
            this.btnShowHideWbFindAndJoinGroups.TabIndex = 12;
            this.btnShowHideWbFindAndJoinGroups.Text = "Show/Hide WEB";
            this.btnShowHideWbFindAndJoinGroups.UseVisualStyleBackColor = true;
            this.btnShowHideWbFindAndJoinGroups.Click += new System.EventHandler(this.btnShowHideWbFindAndJoinGroups_Click);
            // 
            // btnUpdateGroups
            // 
            this.btnUpdateGroups.Location = new System.Drawing.Point(803, 31);
            this.btnUpdateGroups.Name = "btnUpdateGroups";
            this.btnUpdateGroups.Size = new System.Drawing.Size(88, 23);
            this.btnUpdateGroups.TabIndex = 7;
            this.btnUpdateGroups.Text = "Update Groups";
            this.btnUpdateGroups.UseVisualStyleBackColor = true;
            // 
            // btnSaveGroups
            // 
            this.btnSaveGroups.Location = new System.Drawing.Point(709, 30);
            this.btnSaveGroups.Name = "btnSaveGroups";
            this.btnSaveGroups.Size = new System.Drawing.Size(88, 23);
            this.btnSaveGroups.TabIndex = 6;
            this.btnSaveGroups.Text = "Save Groups";
            this.btnSaveGroups.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(31, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(76, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Num of Group:";
            // 
            // txtNumOfGroup
            // 
            this.txtNumOfGroup.Location = new System.Drawing.Point(113, 59);
            this.txtNumOfGroup.Name = "txtNumOfGroup";
            this.txtNumOfGroup.Size = new System.Drawing.Size(100, 20);
            this.txtNumOfGroup.TabIndex = 4;
            // 
            // btnJoinGroup
            // 
            this.btnJoinGroup.Location = new System.Drawing.Point(467, 57);
            this.btnJoinGroup.Name = "btnJoinGroup";
            this.btnJoinGroup.Size = new System.Drawing.Size(75, 23);
            this.btnJoinGroup.TabIndex = 3;
            this.btnJoinGroup.Text = "Join Group";
            this.btnJoinGroup.UseVisualStyleBackColor = true;
            this.btnJoinGroup.Click += new System.EventHandler(this.btnJoinGroup_Click);
            // 
            // btnSearchGroup
            // 
            this.btnSearchGroup.Location = new System.Drawing.Point(467, 31);
            this.btnSearchGroup.Name = "btnSearchGroup";
            this.btnSearchGroup.Size = new System.Drawing.Size(75, 23);
            this.btnSearchGroup.TabIndex = 2;
            this.btnSearchGroup.Text = "Search";
            this.btnSearchGroup.UseVisualStyleBackColor = true;
            this.btnSearchGroup.Click += new System.EventHandler(this.btnSearchGroup_Click);
            // 
            // txtGroupName
            // 
            this.txtGroupName.Location = new System.Drawing.Point(113, 33);
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(319, 20);
            this.txtGroupName.TabIndex = 1;
            this.txtGroupName.Text = "rao vặt";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(37, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Group Name:";
            // 
            // timeCheck
            // 
            this.timeCheck.Tick += new System.EventHandler(this.timeCheck_Tick);
            // 
            // timerJoin
            // 
            this.timerJoin.Interval = 2000;
            this.timerJoin.Tick += new System.EventHandler(this.timerJoin_Tick);
            // 
            // timerTemp
            // 
            this.timerTemp.Interval = 5000;
            this.timerTemp.Tick += new System.EventHandler(this.timerTemp_Tick);
            // 
            // frmFbFindAndJoinGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 519);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.Name = "frmFbFindAndJoinGroups";
            this.Text = "Find & Join Groups";
            this.Load += new System.EventHandler(this.frmFbFindAndJoinGroups_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFbFindAndJoinGroups_FormClosed);
            this.groupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvGroupSearchResult)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DataGridView dtgvGroupSearchResult;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnUpdateGroups;
        private System.Windows.Forms.Button btnSaveGroups;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumOfGroup;
        private System.Windows.Forms.Button btnJoinGroup;
        private System.Windows.Forms.Button btnSearchGroup;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.WebBrowser wbFindAndJoinGroups;
        private System.Windows.Forms.Button btnShowHideWbFindAndJoinGroups;
        private System.Windows.Forms.Timer timeCheck;
        private System.Windows.Forms.Timer timerJoin;
        private System.Windows.Forms.Timer timerTemp;
    }
}