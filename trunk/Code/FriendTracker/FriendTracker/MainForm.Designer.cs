namespace FriendTracker
{
    partial class MainForm
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("New Friends", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Old Friends", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Removed Friends", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.friendsListView = new System.Windows.Forms.ListView();
            this.nameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.addedDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.removedDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.friendListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeFriendManuallyToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.iconImageList = new System.Windows.Forms.ImageList(this.components);
            this.updateBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.userNameLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.spaceLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.totalLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.loginWebBrowser = new System.Windows.Forms.WebBrowser();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFriendManuallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFriendManuallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.logoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutAndCloseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.friendListViewContextMenuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // friendsListView
            // 
            this.friendsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumn,
            this.addedDateColumn,
            this.removedDateColumn});
            this.friendsListView.ContextMenuStrip = this.friendListViewContextMenuStrip;
            this.friendsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.friendsListView.FullRowSelect = true;
            listViewGroup1.Header = "New Friends";
            listViewGroup1.Name = "grpNewFriends";
            listViewGroup2.Header = "Old Friends";
            listViewGroup2.Name = "grpOldFriends";
            listViewGroup3.Header = "Removed Friends";
            listViewGroup3.Name = "grpRemovedFriends";
            this.friendsListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.friendsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.friendsListView.Location = new System.Drawing.Point(0, 24);
            this.friendsListView.Name = "friendsListView";
            this.friendsListView.Size = new System.Drawing.Size(809, 415);
            this.friendsListView.SmallImageList = this.iconImageList;
            this.friendsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.friendsListView.TabIndex = 1;
            this.friendsListView.UseCompatibleStateImageBehavior = false;
            this.friendsListView.View = System.Windows.Forms.View.Details;
            // 
            // nameColumn
            // 
            this.nameColumn.Text = "Name";
            this.nameColumn.Width = 300;
            // 
            // addedDateColumn
            // 
            this.addedDateColumn.Text = "Added";
            this.addedDateColumn.Width = 120;
            // 
            // removedDateColumn
            // 
            this.removedDateColumn.Text = "Removed";
            this.removedDateColumn.Width = 120;
            // 
            // friendListViewContextMenuStrip
            // 
            this.friendListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeFriendManuallyToolStripMenuItem2});
            this.friendListViewContextMenuStrip.Name = "friendListViewContextMenuStrip";
            this.friendListViewContextMenuStrip.Size = new System.Drawing.Size(204, 26);
            this.friendListViewContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.FriendListViewContextMenuStripOpening);
            // 
            // removeFriendManuallyToolStripMenuItem2
            // 
            this.removeFriendManuallyToolStripMenuItem2.Name = "removeFriendManuallyToolStripMenuItem2";
            this.removeFriendManuallyToolStripMenuItem2.Size = new System.Drawing.Size(203, 22);
            this.removeFriendManuallyToolStripMenuItem2.Text = "Remove friend manually";
            this.removeFriendManuallyToolStripMenuItem2.Click += new System.EventHandler(this.RemoveFriendManuallyToolStripMenuItemClick);
            // 
            // iconImageList
            // 
            this.iconImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iconImageList.ImageStream")));
            this.iconImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.iconImageList.Images.SetKeyName(0, "1372690732_facebook-icon.jpg");
            this.iconImageList.Images.SetKeyName(1, "administrator.png");
            // 
            // updateBackgroundWorker
            // 
            this.updateBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.UpdateBackgroundWorkerDoWork);
            this.updateBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.UpdateBackgroundWorkerRunWorkerCompleted);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userNameLabel,
            this.spaceLabel,
            this.totalLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(809, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // userNameLabel
            // 
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(87, 17);
            this.userNameLabel.Text = "Facebook User:";
            // 
            // spaceLabel
            // 
            this.spaceLabel.Name = "spaceLabel";
            this.spaceLabel.Size = new System.Drawing.Size(19, 17);
            this.spaceLabel.Text = "    ";
            // 
            // totalLabel
            // 
            this.totalLabel.Name = "totalLabel";
            this.totalLabel.Size = new System.Drawing.Size(37, 17);
            this.totalLabel.Text = "Total:";
            // 
            // loginWebBrowser
            // 
            this.loginWebBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginWebBrowser.Location = new System.Drawing.Point(0, 24);
            this.loginWebBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.loginWebBrowser.Name = "loginWebBrowser";
            this.loginWebBrowser.Size = new System.Drawing.Size(809, 415);
            this.loginWebBrowser.TabIndex = 3;
            this.loginWebBrowser.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.LoginWebBrowserNavigated);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(809, 24);
            this.menuStrip.TabIndex = 4;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFriendManuallyToolStripMenuItem,
            this.removeFriendManuallyToolStripMenuItem,
            this.toolStripSeparator1,
            this.logoutMenuItem,
            this.closeToolStripMenuItem,
            this.logoutAndCloseToolStripMenuItem});
            this.fileToolStripMenuItem.Enabled = false;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.FileToolStripMenuItemDropDownOpening);
            // 
            // addFriendManuallyToolStripMenuItem
            // 
            this.addFriendManuallyToolStripMenuItem.Name = "addFriendManuallyToolStripMenuItem";
            this.addFriendManuallyToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.addFriendManuallyToolStripMenuItem.Text = "Add friend manually";
            this.addFriendManuallyToolStripMenuItem.Click += new System.EventHandler(this.AddFriendManuallyToolStripMenuItemClick);
            // 
            // removeFriendManuallyToolStripMenuItem
            // 
            this.removeFriendManuallyToolStripMenuItem.Name = "removeFriendManuallyToolStripMenuItem";
            this.removeFriendManuallyToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.removeFriendManuallyToolStripMenuItem.Text = "Remove friend manually";
            this.removeFriendManuallyToolStripMenuItem.Click += new System.EventHandler(this.RemoveFriendManuallyToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Name = "logoutMenuItem";
            this.logoutMenuItem.Size = new System.Drawing.Size(203, 22);
            this.logoutMenuItem.Text = "Logout";
            this.logoutMenuItem.Click += new System.EventHandler(this.LogoutMenuItemClick);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.CloseToolStripMenuItemClick);
            // 
            // logoutAndCloseToolStripMenuItem
            // 
            this.logoutAndCloseToolStripMenuItem.Name = "logoutAndCloseToolStripMenuItem";
            this.logoutAndCloseToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.logoutAndCloseToolStripMenuItem.Text = "Logout && Close";
            this.logoutAndCloseToolStripMenuItem.Click += new System.EventHandler(this.LogoutAndCloseToolStripMenuItemClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 461);
            this.Controls.Add(this.loginWebBrowser);
            this.Controls.Add(this.friendsListView);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook Friend Tracker";
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Shown += new System.EventHandler(this.MainFormShown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainFormKeyDown);
            this.friendListViewContextMenuStrip.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView friendsListView;
        private System.Windows.Forms.ColumnHeader nameColumn;
        private System.Windows.Forms.ColumnHeader addedDateColumn;
        private System.Windows.Forms.ColumnHeader removedDateColumn;
        private System.ComponentModel.BackgroundWorker updateBackgroundWorker;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel totalLabel;
        private System.Windows.Forms.WebBrowser loginWebBrowser;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFriendManuallyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFriendManuallyToolStripMenuItem;
        private System.Windows.Forms.ImageList iconImageList;
        private System.Windows.Forms.ContextMenuStrip friendListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem removeFriendManuallyToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel userNameLabel;
        private System.Windows.Forms.ToolStripStatusLabel spaceLabel;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutAndCloseToolStripMenuItem;

    }
}

