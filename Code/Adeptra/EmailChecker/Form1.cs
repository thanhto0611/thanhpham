using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace EmailChecker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "")
            {
                MessageBox.Show("Please select Email list file");
                return;
            }

            if (rdGmail.Checked == false && rdYahoo.Checked == false)
            {
                MessageBox.Show("Please must select type of mail");
                return;
            }

            StreamReader sr = new StreamReader(txtEmail.Text);

            string outfile = txtEmail.Text + ".out";
            StreamWriter sw = new StreamWriter(outfile);
            while (sr.Peek() >= 0)
            {
                string email = sr.ReadLine();

                if (rdGmail.Checked == true)
                {
                    if (email.Contains("@gmail.com"))
                    {
                        sw.WriteLine(email);
                    }
                }

                if (rdYahoo.Checked == true)
                {
                    if (email.Contains("@yahoo.com"))
                    {
                        sw.WriteLine(email);
                    }
                }
            }

            sr.Close();
            sw.Close();

            MessageBox.Show("Done");
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtEmail.Text = openFileDialog1.FileName;
        }
    }
}
