using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using mfb;

namespace FacebookClass
{
    public partial class Form1 : Form
    {
        Facebook fb;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fb = Facebook.Login("hongthanh0611@gmail.com", "nguoicodoc");
            if (fb == null)
            {
                MessageBox.Show("Failed To Login\n\nCheck Status Message Shown in Browser");
            }
            else
            {
                MessageBox.Show("Login success");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fb.UploadPhoto(@"...", ":)");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fb.StatusUpdate("i like it");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> groups;
            int startCount = 1;     //First Search Result Starts From 1
            do
            {
                groups = fb.SearchGroups("rao vặt", startCount);

                //Next Page Results will Start From this Count
                startCount += groups.Count;

                //Traversing Through the Results
                string txt = "";
                foreach (string k in groups.Keys)
                    txt += k + "\t\t" + groups[k] + Environment.NewLine;
                MessageBox.Show(txt);
            } while (groups.Count > 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
