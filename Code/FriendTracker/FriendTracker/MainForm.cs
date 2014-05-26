#region usings

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Xml.Serialization;
using Facebook;

#endregion

namespace FriendTracker
{
    public partial class MainForm : Form
    {
        #region Local variable declarations

        private const string ExtendedPermissionsNeeded = "email,offline_access";

        private List<Friend> _friends = new List<Friend>();
        private bool _listDirty;
        private bool _authorized;
        private string _accessToken = "";
        private string _currentName = "";
        private string _currentEmail = "";
        private string _loginUrl = "";
        private bool _loggingOut;
        private bool _closeAfterUpdateAndLogout;

        private int _total;
        private int _deleted;

        #endregion

        #region Property wrappers for some of the application settings

        public string ApplicationId
        {
            get { return Properties.Settings.Default.ApplicationID; }
        }

        public string AppSecret
        {
            get { return Properties.Settings.Default.ApplicationSecret; }
        }

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Main Form events

        private void MainFormKeyDown(object sender, KeyEventArgs e)
        {
            if (loginWebBrowser.Visible)
                return;

            if (e.KeyCode == Keys.Insert)
            {
                InsertFriend();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                RemoveFriends();
            }
        }

        private void MainFormLoad(object sender, EventArgs e)
        {
            userNameLabel.Text = "Facebook User: ---";
            totalLabel.Text = "";
            _loginUrl = GenerateLoginUrl();
        }

        private void MainFormShown(object sender, EventArgs e)
        {
            loginWebBrowser.Navigate(_loginUrl);
        }

        #endregion

        #region Control events

        #region Login Browser events

        private void LoginWebBrowserNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            if (loginWebBrowser.Visible)
            {
                var fb = new FacebookClient();

                FacebookOAuthResult oauthResult;
                if (fb.TryParseOAuthCallbackUrl(e.Url, out oauthResult))
                {
                    if (oauthResult.IsSuccess)
                    {
                        _accessToken = oauthResult.AccessToken;
                        _authorized = true;
                    }
                    else
                    {
                        _accessToken = "";
                        _authorized = false;
                    }

                    if (_authorized)
                    {
                        fb = new FacebookClient(_accessToken);

                        dynamic result = fb.Get("me");
                        _currentName = result.name;
                        _currentEmail = result.email;
                        userNameLabel.Text = string.Format("Facebook User: {0}", _currentName);

                        RestoreXml();

                        UpdateListView();

                        updateBackgroundWorker.RunWorkerAsync();
                    }
                    else
                    {
                        MessageBox.Show("Couldn't log into Facebook!", "Login unsuccessful", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }

                    fileToolStripMenuItem.Enabled = true;
                    loginWebBrowser.Visible = false;

                    return;
                }
            }

            if (_loggingOut)
            {
                if (loginWebBrowser.Document != null)
                {
                    HtmlElement logoutForm = loginWebBrowser.Document.GetElementById("logout_form");

                    if (logoutForm != null)
                    {
                        loginWebBrowser.Document.InvokeScript("execScript", new Object[] { "document.getElementById('logout_form').submit();", "JavaScript" });
                    }
                }

                if (e.Url.AbsoluteUri.StartsWith(@"https://www.facebook.com/index.php") || e.Url.AbsoluteUri.StartsWith(@"http://www.facebook.com/index.php"))
                {
                    if (_closeAfterUpdateAndLogout)
                    {
                        Close();
                    }
                    else
                    {
                        userNameLabel.Text = "Facebook User: ---";
                        totalLabel.Text = "";

                        _loggingOut = false;
                        _accessToken = "";
                        _authorized = false;
                        _currentName = "";

                        fileToolStripMenuItem.Enabled = false;
                        loginWebBrowser.Navigate(_loginUrl);
                    }
                }
            }

            if (e.Url.AbsoluteUri.Equals(_loginUrl))
            {
                loginWebBrowser.Visible = true;
            }
        }

        #endregion

        #region BackgroundWorker events - this is where the facebook magic happens!

        private void UpdateBackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            e.Result = null;

            if (_authorized)
            {
                Dictionary<string, string> tempFriends = new Dictionary<string, string>();

                try
                {
                    var client = new FacebookClient(_accessToken);

                    dynamic myInfo = client.Get(@"\me\friends");

                    foreach (dynamic friend in myInfo.data)
                    {
                        tempFriends.Add(friend.id, friend.name);
                    }

                    e.Result = tempFriends;
                }
                catch (Exception)
                {
                    //Do nothing - returning null in Result is enough
                }
            }
        }

        private void UpdateBackgroundWorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Dictionary<string, string> tempFriends = e.Result as Dictionary<string, string>;
            List<string> newFriends = new List<string>();
            List<string> deletedFriends = new List<string>();

            if (e.Result == null || !_authorized)
            {
                if (Properties.Settings.Default.SendEmail)
                {
                    SendMail(0, newFriends, deletedFriends, "Couldn't retrieve friends from Facebook");
                    Close();
                }

                return;
            }

            if (_authorized)
            {
                if (tempFriends != null)
                {
                    foreach (KeyValuePair<string, string> tempFriend in tempFriends)
                    {
                        bool found = false;
                        string tempName = tempFriend.Value;
                        string tempId = tempFriend.Key;

                        foreach (Friend friend in _friends)
                        {
                            if (tempId != "")
                            {
                                if (friend.ID.Equals(tempId, StringComparison.InvariantCultureIgnoreCase) && friend.DeleteDate == "" && !friend.IsManual)
                                {
                                    if (!friend.Name.Equals(tempName, StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        friend.Name = tempName;
                                        friend.HasChangedName = true;
                                        _listDirty = true;
                                    }

                                    found = true;
                                    break;
                                }
                            }
                            else
                            {
                                if (friend.Name.Equals(tempName, StringComparison.InvariantCultureIgnoreCase) && friend.DeleteDate == "" && !friend.IsManual)
                                {
                                    found = true;
                                    break;
                                }
                            }
                        }

                        if (!found)
                        {
                            Friend newFriend = new Friend
                                                   {
                                                       Name = tempName,
                                                       AddDate = string.Format("{0:d}", DateTime.Now),
                                                       DeleteDate = "",
                                                       ID = tempId,
                                                       IsNew = true
                                                   };

                            newFriends.Add(tempName);

                            _friends.Add(newFriend);
                            _listDirty = true;
                        }
                    }

                    foreach (Friend friend in _friends)
                    {
                        bool found = tempFriends.ContainsKey(friend.ID) && friend.ID != "";

                        if (!found && !friend.IsManual && friend.AddDate != "MANUAL" && friend.DeleteDate == "")
                        {
                            friend.DeleteDate = string.Format("{0:d}", DateTime.Now);

                            deletedFriends.Add(friend.Name);
                        }
                    }
                }

                UpdateListView();

                SaveXml();

                int totalFriends = _friends.FindAll(x => x.DeleteDate == "").Count;

                if (Properties.Settings.Default.SendEmail && (newFriends.Count + deletedFriends.Count > 0))
                {
                    SendMail(totalFriends, newFriends, deletedFriends, "");
                }
            }

            if (Properties.Settings.Default.LogOutAfterUpdate)
            {
                DoLogOut(Properties.Settings.Default.CloseAfterUpdate);
            }
            else if (Properties.Settings.Default.CloseAfterUpdate)
            {
                Close();
            }
        }

        #endregion

        #region Menu events

        #region Main Menu events

        private void FileToolStripMenuItemDropDownOpening(object sender, EventArgs e)
        {
            removeFriendManuallyToolStripMenuItem.Enabled = (friendsListView.SelectedItems.Count > 0);

            if (friendsListView.SelectedItems.Count > 0)
            {
                removeFriendManuallyToolStripMenuItem.Text = friendsListView.SelectedItems.Count == 1 ? "Remove friend manually" : "Remove friends manually";
            }
        }

        private void AddFriendManuallyToolStripMenuItemClick(object sender, EventArgs e)
        {
            InsertFriend();
        }

        private void RemoveFriendManuallyToolStripMenuItemClick(object sender, EventArgs e)
        {
            RemoveFriends();
        }

        private void CloseToolStripMenuItemClick(object sender, EventArgs e)
        {
            Close();
        }

        private void LogoutMenuItemClick(object sender, EventArgs e)
        {
            DoLogOut(false);
        }

        private void LogoutAndCloseToolStripMenuItemClick(object sender, EventArgs e)
        {
            DoLogOut(true);
        }

        #endregion

        #region ContextMenu events

        private void FriendListViewContextMenuStripOpening(object sender, CancelEventArgs e)
        {
            if (friendsListView.SelectedItems.Count <= 0)
            {
                e.Cancel = true;
            }
            else
            {
                removeFriendManuallyToolStripMenuItem2.Text = friendsListView.SelectedItems.Count == 1 ? "Remove friend manually" : "Remove friends manually";
            }
        }

        #endregion

        #endregion

        #endregion

        #region Private Methods

        #region XML Methods

        private void SaveXml()
        {
            if (!_listDirty)
                return;

            string xmlPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), string.Format("{0}.xml", _currentName.Replace(" ", "_")));

            XmlSerializer serializer = new XmlSerializer(typeof(List<Friend>));

            using (FileStream stream = File.OpenWrite(xmlPath))
            {
                serializer.Serialize(stream, _friends);
            }

            _listDirty = false;
        }

        private void RestoreXml()
        {
            if (_currentName == "")
                return;

            string xmlPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), string.Format("{0}.xml", _currentName.Replace(" ", "_")));

            if (File.Exists(xmlPath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Friend>));

                using (FileStream stream = File.OpenRead(xmlPath))
                {
                    _friends = (List<Friend>)serializer.Deserialize(stream);
                }

                foreach (Friend friend in _friends)
                {
                    friend.HasChangedName = false;
                    friend.IsNew = false;
                }
            }
            else
            {
                _friends = new List<Friend>();
            }

            _listDirty = false;
        }

        #endregion

        #region Facebook Methods

        private void DoLogOut(bool closeAfterLogout)
        {
            _loggingOut = true;
            _closeAfterUpdateAndLogout = closeAfterLogout;

            string logoutUrl = GenerateLogoutUrl();
            loginWebBrowser.Navigate(logoutUrl);
        }

        private string GenerateLoginUrl()
        {
            dynamic parameters = new ExpandoObject();
            parameters.client_id = ApplicationId;
            parameters.redirect_uri = "https://www.facebook.com/connect/login_success.html";
            parameters.response_type = "token";
            parameters.display = "popup";

            if (!string.IsNullOrWhiteSpace(ExtendedPermissionsNeeded))
                parameters.scope = ExtendedPermissionsNeeded;

            var fb = new FacebookClient();

            Uri loginUri = fb.GetLoginUrl(parameters);
            return loginUri.AbsoluteUri;
        }

        private string GenerateLogoutUrl()
        {
            dynamic parameters = new ExpandoObject();

            parameters.next = HttpUtility.UrlEncode(@"http://www.google.com", Encoding.UTF8);
            parameters.access_token = _accessToken;

            var fb = new FacebookClient(_accessToken);

            Uri logoutUri = fb.GetLogoutUrl(parameters);
            return logoutUri.AbsoluteUri;
        }

        #endregion

        #region Friend List Methods

        private void UpdateListView()
        {
            _total = 0;
            _deleted = 0;

            friendsListView.Items.Clear();

            foreach (Friend friend in _friends)
            {
                AddFriendToListView(friend);
            }

            totalLabel.Text = string.Format("Total: {0} Active, {1} Removed", _total.ToString(), _deleted.ToString());
        }

        private void AddFriendToListView(Friend friend)
        {
            ListViewItem newItem = new ListViewItem(friend.Name);
            newItem.SubItems.Add(friend.AddDate);
            newItem.SubItems.Add(friend.DeleteDate);

            if (friend.IsNew)
            {
                newItem.Group = friendsListView.Groups[0];
                _total += 1;
            }
            else if (friend.DeleteDate != "")
            {
                newItem.Group = friendsListView.Groups[2];
                _deleted += 1;
            }
            else
            {
                newItem.Group = friendsListView.Groups[1];
                _total += 1;
            }

            newItem.ImageIndex = 0;

            if (friend.IsManual)
                newItem.ImageIndex = 1;

            if (friend.HasChangedName)
                newItem.ForeColor = Color.Red;

            newItem.Tag = friend.ID;

            friendsListView.Items.Add(newItem);
        }

        private void InsertFriend()
        {
            AddFriendForm frm = new AddFriendForm();

            if (frm.ShowDialog(this) == DialogResult.OK)
            {
                bool exists = _friends.Any(friend => friend.Name.Equals(frm.FriendName, StringComparison.InvariantCultureIgnoreCase));

                if (exists)
                {
                    MessageBox.Show(string.Format("You've already got a friend in your list with the name {0}!", frm.FriendName),
                        "Cannot add this name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Friend newFriend = new Friend
                                           {
                                               AddDate = string.Format("{0:d}", DateTime.Now),
                                               DeleteDate = "",
                                               HasChangedName = false,
                                               ID = frm.FriendName.Replace(" ", "."),
                                               IsManual = true,
                                               IsNew = true,
                                               Name = frm.FriendName
                                           };

                    _friends.Add(newFriend);

                    _listDirty = true;

                    UpdateListView();

                    SaveXml();
                }
            }
        }

        private void RemoveFriends()
        {
            string person = "person";

            if (friendsListView.SelectedItems.Count > 1)
                person = "persons";

            if (MessageBox.Show(string.Format("Do you really want to remove the selected {0}?", person) + Environment.NewLine + Environment.NewLine + string.Format("Please note: The {0} will only be removed from THIS LIST, not from Facebook itself!", person), "Please confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                foreach (ListViewItem item in friendsListView.SelectedItems)
                {
                    string friendId = item.Tag as string;

                    if (!string.IsNullOrEmpty(friendId))
                    {
                        foreach (Friend friend in _friends)
                        {
                            if (friend.ID.Equals(friendId, StringComparison.InvariantCultureIgnoreCase))
                            {
                                friend.IsNew = false;
                                friend.DeleteDate = string.Format("{0:d}", DateTime.Now);
                                _listDirty = true;
                                break;
                            }
                        }
                    }
                }

                UpdateListView();

                SaveXml();
            }
        }

        #endregion

        #region Email Methods

        private void SendMail(int activeFriends, List<string> newFriends, List<string> deletedFriends, string errorMessage)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("Active friends: {0}", activeFriends));

            if (newFriends.Count > 0)
            {
                sb.AppendLine("");
                sb.AppendLine("New Friends:");
                sb.AppendLine("------------");

                foreach (string friend in newFriends)
                {
                    sb.AppendLine(friend);
                }
            }

            if (deletedFriends.Count > 0)
            {
                sb.AppendLine("");
                sb.AppendLine("Deleted friends:");
                sb.AppendLine("----------------");

                foreach (string friend in deletedFriends)
                {
                    sb.AppendLine(friend);
                }
            }

            if ((Properties.Settings.Default.FromEmailAddress.Equals("[CURRENT_EMAIL]") || Properties.Settings.Default.ToEmailAddress.Equals("[CURRENT_EMAIL]")) && string.IsNullOrEmpty(_currentEmail))
            {
                MessageBox.Show("Either FROM or TO address is set to the current user's email address, but that address cannot be retrieved from Facebook!",
                                "Couldn't send email!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MailMessage message = new MailMessage();
            message.To.Add(Properties.Settings.Default.ToEmailAddress.Replace("[CURRENT_EMAIL]", _currentEmail));
            message.Subject = "Facebook FriendTracker Update";
            message.From = new MailAddress(Properties.Settings.Default.FromEmailAddress.Replace("[CURRENT_EMAIL]", _currentEmail));
            message.Body = (errorMessage != "" ? errorMessage : sb.ToString());

            SmtpClient smtp = new SmtpClient(Properties.Settings.Default.SMTPServer);

            smtp.Port = Properties.Settings.Default.SMTPPort;
            smtp.EnableSsl = Properties.Settings.Default.SMTPUseSecurity;

            if (Properties.Settings.Default.SMTPUser != "" && Properties.Settings.Default.SMTPPassword != "")
                smtp.Credentials = new NetworkCredential(Properties.Settings.Default.SMTPUser, Properties.Settings.Default.SMTPPassword);

            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine + ex.StackTrace,
                                "Couldn't send email!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion
    }
}
