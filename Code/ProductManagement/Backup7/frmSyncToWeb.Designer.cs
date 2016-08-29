namespace Presentation
{
    partial class frmSyncToWeb
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
            this.btnUpload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTimeBetweenSync = new System.Windows.Forms.TextBox();
            this.timerSync = new System.Windows.Forms.Timer(this.components);
            this.btnSetSyncTime = new System.Windows.Forms.Button();
            this.btnStartSync = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.webSync = new System.Windows.Forms.WebBrowser();
            this.timerCheck = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(82, 26);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(124, 48);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Time between sync";
            // 
            // txtTimeBetweenSync
            // 
            this.txtTimeBetweenSync.Location = new System.Drawing.Point(139, 97);
            this.txtTimeBetweenSync.Name = "txtTimeBetweenSync";
            this.txtTimeBetweenSync.Size = new System.Drawing.Size(144, 20);
            this.txtTimeBetweenSync.TabIndex = 2;
            // 
            // timerSync
            // 
            this.timerSync.Tick += new System.EventHandler(this.timerSync_Tick);
            // 
            // btnSetSyncTime
            // 
            this.btnSetSyncTime.Location = new System.Drawing.Point(311, 95);
            this.btnSetSyncTime.Name = "btnSetSyncTime";
            this.btnSetSyncTime.Size = new System.Drawing.Size(75, 23);
            this.btnSetSyncTime.TabIndex = 3;
            this.btnSetSyncTime.Text = "Set Time";
            this.btnSetSyncTime.UseVisualStyleBackColor = true;
            this.btnSetSyncTime.Click += new System.EventHandler(this.btnSetSyncTime_Click);
            // 
            // btnStartSync
            // 
            this.btnStartSync.Location = new System.Drawing.Point(431, 95);
            this.btnStartSync.Name = "btnStartSync";
            this.btnStartSync.Size = new System.Drawing.Size(75, 23);
            this.btnStartSync.TabIndex = 4;
            this.btnStartSync.Text = "Start Sync";
            this.btnStartSync.UseVisualStyleBackColor = true;
            this.btnStartSync.Click += new System.EventHandler(this.btnStartSync_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUpload);
            this.groupBox1.Controls.Add(this.btnStartSync);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnSetSyncTime);
            this.groupBox1.Controls.Add(this.txtTimeBetweenSync);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(960, 128);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sync Control";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.webSync);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 373);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web";
            // 
            // webSync
            // 
            this.webSync.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webSync.Location = new System.Drawing.Point(3, 16);
            this.webSync.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSync.Name = "webSync";
            this.webSync.Size = new System.Drawing.Size(954, 354);
            this.webSync.TabIndex = 0;
            // 
            // timerCheck
            // 
            this.timerCheck.Tick += new System.EventHandler(this.timerCheck_Tick);
            // 
            // frmSyncToWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 501);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSyncToWeb";
            this.Text = "Sync To Web";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTimeBetweenSync;
        private System.Windows.Forms.Timer timerSync;
        private System.Windows.Forms.Button btnSetSyncTime;
        private System.Windows.Forms.Button btnStartSync;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser webSync;
        private System.Windows.Forms.Timer timerCheck;
    }
}