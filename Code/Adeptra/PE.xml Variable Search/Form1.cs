using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace PE.xml_Variable_Search
{
    public partial class frmPEVariableSearch : Form
    {
        public DataTable resultTable = new DataTable();

        public frmPEVariableSearch()
        {
            InitializeComponent();

            resultTable.Columns.Add("No", typeof(int));
            resultTable.Columns.Add("Path", typeof(string));
            resultTable.Columns.Add("DefaultValue", typeof(string));
            resultTable.Columns.Add("Enum", typeof(string));
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "PE xml file|*.xml";
            openFileDialog1.ShowDialog();
        }

        private void txtFileLocation1_MouseDown(object sender, MouseEventArgs e)
        {
            openFileDialog1.Filter = "PE xml file|*.xml";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txtFileLocation1.Text = openFileDialog1.FileName;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtFileLocation1.Text == "")
                {
                    MessageBox.Show("Please choose PE.xml file");
                    txtVariableName.Clear();
                    return;
                }

                if (txtVariableName.Text != "")
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(txtFileLocation1.Text.ToString());

                    resultTable.Clear();
                    string path = "";
                    string enumValue = "";
                    int count = 0;

                    XmlNodeList nodeList = doc.GetElementsByTagName("variable");

                    XmlNode parentNode = null;
                    XmlNode childNode = null;

                    foreach (XmlNode node in nodeList)
                    {
                        path = "";
                        enumValue = "";
                        parentNode = null;
                        childNode = null;
                        if (String.Compare(node.Attributes["name"].Value, txtVariableName.Text, true) == 0)
                        {
                            parentNode = node;
                            
                            while (parentNode.ParentNode != null && parentNode.Attributes.GetNamedItem("name") != null)
                            {
                                if (path == "")
                                {
                                    path += parentNode.Attributes["name"].Value;
                                }
                                else
                                {
                                    path = parentNode.Attributes["name"].Value + "." + path;
                                }
                                parentNode = parentNode.ParentNode;
                            }
                            
                            XmlDocument newDoc = new XmlDocument();
                            newDoc.LoadXml(node.InnerXml);

                            XmlNodeList defaultNodeList = newDoc.GetElementsByTagName("default");
                            XmlNodeList enumNodeList = newDoc.GetElementsByTagName("item");

                            foreach (XmlNode enumNode in enumNodeList)
                            {
                                if (enumValue == "")
                                {
                                    enumValue += enumNode.InnerText;
                                } 
                                else
                                {
                                    enumValue += " | " + enumNode.InnerText;
                                }
                            }
                            
                            DataRow dr = resultTable.NewRow();
                            dr[0] = count + 1;
                            dr[1] = path;
                            dr[2] = defaultNodeList.Item(0).InnerText;
                            dr[3] = enumValue;

                            resultTable.Rows.Add(dr);
                            count++;
                        }
                    }
                    dataGridView1.DataSource = resultTable;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }
    }
}
