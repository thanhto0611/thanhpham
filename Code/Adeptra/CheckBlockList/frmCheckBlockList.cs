using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Visio;
using System.IO;

namespace CheckBlockList
{
    public partial class frmCheckBlockList : Form
    {
        public frmCheckBlockList()
        {
            InitializeComponent();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Visio file|*.vsd";
            openFileDialog1.ShowDialog();
        }

        private void txtFileLocation1_MouseDown(object sender, MouseEventArgs e)
        {
            openFileDialog1.Filter = "Visio file|*.vsd";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFileLocation1.Text = openFileDialog1.FileName;
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                Microsoft.Office.Interop.Visio.Application app = new Microsoft.Office.Interop.Visio.Application();
                Document doc = app.Documents.Open(txtFileLocation1.Text.ToString());
                Pages pagesObj = doc.Pages;

                string fileloc = doc.Path + "blockList.txt";
                StreamWriter wr = new StreamWriter(fileloc);

                foreach (Page pageObj in pagesObj)
                {
                    foreach (Shape shapeObj in pageObj.Shapes)
                    {
                        wr.WriteLine(shapeObj.Text);
                        wr.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        //if (shapeObj.Text.IndexOf("Block:") >= 0)
                        //{
                        //    //string temp = shapeObj.Text;
                        //    //temp = temp.Replace(" ", "");
                        //    //temp = temp.Substring(temp.IndexOf("Block:") + 6, 5);
                        //    //if (char.IsDigit(temp, 0))
                        //    //{
                        //    //    wr.WriteLine(temp);
                        //    //}
                        //    wr.WriteLine(shapeObj.Text);
                        //    wr.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                        //}
                    }
                }
                wr.Close();
                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
