using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mfb;

namespace Presentation
{
    public partial class frmFacebook : Form
    {
        Facebook fb;

        public frmFacebook()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                fb = Facebook.Login(txtEmail.Text.ToString(), txtPass.Text.ToString());
                if (fb == null)
                {
                    MessageBox.Show("Failed To Login\n\nCheck Status Message Shown in Browser");
                }
                else
                {
                    MessageBox.Show("Đăng nhập thành công");
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnSearchGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //Dictionary<string, string> groups;
                DataTable dt = new DataTable();
                dt.Columns.Add("GroupId");
                dt.Columns.Add("GroupName");
                DataTable temp = new DataTable();
                int startCount = 1;     //First Search Result Starts From 1
                do
                {

                    temp = fb.SearchGroups(txtSearchKey.Text, startCount);

                    for (int i = 0; i < temp.Rows.Count;i++ )
                    {
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = temp.Rows[i].ItemArray.Clone() as object[];
                        dt.Rows.Add(dr);
                    }

                    //Next Page Results will Start From this Count
                    startCount += temp.Rows.Count;

                    //Traversing Through the Results
                    //string txt = "";
                    //foreach (string k in groups.Keys)
                    //    txt += k + "\t\t" + groups[k] + Environment.NewLine;
                    //MessageBox.Show(txt);
                } while (temp.Rows.Count > 0);

                dtgvGroups.DataSource = dt;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnFindGroup_Click(object sender, EventArgs e)
        {
            try
            {
                //Dictionary<string, string> groups;
                DataTable dt = new DataTable();
                dt.Columns.Add("GroupId");
                dt.Columns.Add("GroupName");
                DataTable temp = new DataTable();

                int startCount = 1;     //First Search Result Starts From 1

                do
                {
                    temp = fb.LoadGroups();
                    startCount += temp.Rows.Count;

                    for (int i = 0; i < temp.Rows.Count; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr.ItemArray = temp.Rows[i].ItemArray.Clone() as object[];
                        dt.Rows.Add(dr);
                    }
                } while (temp.Rows.Count > 0);

                dtgvGroupsJoined.DataSource = dt;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
