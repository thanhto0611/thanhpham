namespace Presentation
{
    partial class frmCronJob
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtDelayTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUri = new System.Windows.Forms.TextBox();
            this.txtRefreshTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wbCron = new System.Windows.Forms.WebBrowser();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.timerCron = new System.Windows.Forms.Timer(this.components);
            this.timerTemp = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Delay time:";
            // 
            // txtDelayTime
            // 
            this.txtDelayTime.Location = new System.Drawing.Point(93, 32);
            this.txtDelayTime.Name = "txtDelayTime";
            this.txtDelayTime.Size = new System.Drawing.Size(100, 20);
            this.txtDelayTime.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtUri);
            this.groupBox1.Controls.Add(this.txtRefreshTime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Controls.Add(this.txtDelayTime);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(807, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clear Image Cache";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtUri
            // 
            this.txtUri.Location = new System.Drawing.Point(348, 35);
            this.txtUri.Name = "txtUri";
            this.txtUri.Size = new System.Drawing.Size(425, 20);
            this.txtUri.TabIndex = 5;
            // 
            // txtRefreshTime
            // 
            this.txtRefreshTime.Location = new System.Drawing.Point(93, 67);
            this.txtRefreshTime.Name = "txtRefreshTime";
            this.txtRefreshTime.Size = new System.Drawing.Size(100, 20);
            this.txtRefreshTime.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Refresh time:";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(228, 30);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wbCron);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 93);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(807, 385);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Web";
            // 
            // wbCron
            // 
            this.wbCron.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbCron.Location = new System.Drawing.Point(3, 16);
            this.wbCron.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbCron.Name = "wbCron";
            this.wbCron.Size = new System.Drawing.Size(801, 366);
            this.wbCron.TabIndex = 0;
            this.wbCron.Url = new System.Uri("http://www.thoitrangella.com/admin", System.UriKind.Absolute);
            this.wbCron.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbCron_DocumentCompleted);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 180000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // timerCron
            // 
            this.timerCron.Tick += new System.EventHandler(this.timerCron_Tick);
            // 
            // timerTemp
            // 
            this.timerTemp.Tick += new System.EventHandler(this.timerTemp_Tick);
            // 
            // frmCronJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 478);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmCronJob";
            this.Text = "Cron Job";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmCronJob_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDelayTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.WebBrowser wbCron;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Timer timerCron;
        private System.Windows.Forms.TextBox txtRefreshTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUri;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerTemp;
    }
}