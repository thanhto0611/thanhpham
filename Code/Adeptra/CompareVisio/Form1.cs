using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace CompareVisio
{
    public partial class frmVisioCompare : Form
    {
        XmlTextReader reader1;
        XmlTextReader reader2;
        XmlDocument xmlDoc1;
        XmlDocument xmlDoc2;
        XmlNodeList list1;
        XmlNodeList list2;

        public frmVisioCompare()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Visio xml file|*.vdx";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFileLocation1.Text = openFileDialog1.FileName;
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            openFileDialog2.Filter = "Visio xml file|*.vdx";
            openFileDialog2.ShowDialog();
        }

        private void openFileDialog2_FileOk(object sender, CancelEventArgs e)
        {
            txtFileLocation2.Text = openFileDialog2.FileName;
        }

        private void btnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFileLocation1.Text == "")
                {
                    MessageBox.Show("Please choose file 1");
                    return;
                }
                if (txtFileLocation2.Text == "")
                {
                    MessageBox.Show("Please choose file 2");
                    return;
                }

                string filePath1 = txtFileLocation1.Text.ToString();
                string filePath2 = txtFileLocation2.Text.ToString();

                // Read File 1
                reader1 = new XmlTextReader(filePath1.ToString());

                reader1.WhitespaceHandling = WhitespaceHandling.None;
                xmlDoc1 = new XmlDocument();
                //Load the file into the XmlDocument
                xmlDoc1.Load(reader1);
                //Close off the connection to the file.
                reader1.Close();


                // Read File 2
                reader2 = new XmlTextReader(filePath2.ToString());

                reader2.WhitespaceHandling = WhitespaceHandling.None;
                xmlDoc2 = new XmlDocument();
                //Load the file into the XmlDocument
                xmlDoc2.Load(reader2);
                //Close off the connection to the file.
                reader2.Close();

                list1 = xmlDoc1.GetElementsByTagName("Page");

                list2 = xmlDoc2.GetElementsByTagName("Page");

                List<string> result1 = new List<string>();
                List<string> result2 = new List<string>();

                bool exist = false;

                progressBar1.Visible = true;
                progressBar1.Minimum = 1;
                progressBar1.Maximum = list1.Count + list2.Count;
                progressBar1.Value = 1;
                progressBar1.Step = 1;
                progressBar1.PerformStep();

                foreach(XmlNode xmlNode1 in list1)
                {
                    foreach (XmlNode xmlNode2 in list2)
                    {
                        exist = false;

                        if (xmlNode1.Attributes["Name"].Value == xmlNode2.Attributes["Name"].Value)
                        {
                            exist = true;
                            if (xmlNode1.InnerXml != xmlNode2.InnerXml)
                            {
                                result1.Add(xmlNode1.Attributes["Name"].Value);
                                result2.Add(xmlNode1.Attributes["Name"].Value);
                            }
                            break;
                        }
                    }
                    if (exist == false)
                    {
                        result1.Add(xmlNode1.Attributes["Name"].Value);
                        result2.Add("");
                    }
                    progressBar1.PerformStep();
                }

                foreach (XmlNode xmlNode2 in list2)
                {
                    foreach (XmlNode xmlNode1 in list1)
                    {
                        exist = false;

                        if (xmlNode2.Attributes["Name"].Value == xmlNode1.Attributes["Name"].Value)
                        {
                            exist = true;
                            break;
                        }
                    }
                    if (exist == false)
                    {
                        result2.Add(xmlNode2.Attributes["Name"].Value);
                        result1.Add("");
                    }
                    progressBar1.PerformStep();
                }

                if (result1.Count == 0)
                {
                    result1.Add("No difference found");
                    result2.Add("No difference found");
                    listBox1.DataSource = result1;
                    listBox2.DataSource = result2;
                    btnCreateXml.Enabled = false;
                } 
                else
                {
                    btnCreateXml.Enabled = true;
                    listBox1.DataSource = result1;
                    listBox2.DataSource = result2;
                }
                listBox1.Enabled = false;
                progressBar1.Visible = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void txtFileLocation1_MouseDown(object sender, MouseEventArgs e)
        {
            openFileDialog1.Filter = "Visio xml file|*.vdx";
            openFileDialog1.ShowDialog();
        }

        private void txtFileLocation2_MouseDown(object sender, MouseEventArgs e)
        {
            openFileDialog2.Filter = "Visio xml file|*.vdx";
            openFileDialog2.ShowDialog();
        }

        private void btnCreateXml_Click(object sender, EventArgs e)
        {
            try
            {
                string moduleName = listBox2.SelectedValue.ToString();
                string filename1 = moduleName.Replace("*","") + "_File_1.xml";
                string filename2 = moduleName.Replace("*", "") + "_File_2.xml";

                if (File.Exists(filename1))
                {
                    MessageBox.Show("File exists");
                    return;
                }

                if (File.Exists(filename2))
                {
                    MessageBox.Show("File exists");
                    return;
                }

                foreach (XmlNode xmlNode1 in list1)
                {
                    if (xmlNode1.Attributes["Name"].Value == moduleName)
                    {
                        StreamWriter writer = new StreamWriter(filename1);
                        writer.WriteLine(xmlNode1.InnerXml);
                        writer.Close();
                    }
                }
                foreach (XmlNode xmlNode2 in list2)
                {
                    if (xmlNode2.Attributes["Name"].Value == moduleName)
                    {
                        StreamWriter writer = new StreamWriter(filename2);
                        writer.WriteLine(xmlNode2.InnerXml);
                        writer.Close();
                    }
                }
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
