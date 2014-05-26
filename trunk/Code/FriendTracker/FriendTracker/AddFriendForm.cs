#region usings

using System;
using System.Windows.Forms;

#endregion

namespace FriendTracker
{
    public partial class AddFriendForm : Form
    {
        #region Constructor

        public AddFriendForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Property Declarations

        public string FriendName
        { 
            get { return friendNameTextBox.Text; }
        }

        #endregion

        #region Control Events

        private void friendNameTextBox_TextChanged(object sender, EventArgs e)
        {
            okButton.Enabled = (friendNameTextBox.Text != "");
        }

        #endregion
    }
}
