using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Globalization;
using Adeptra_Tools;

namespace PE.xml_Variable_Search
{
    public partial class frmPEVariableSearch : Form
    {
        public DataTable resultTable = new DataTable();

        public frmPEVariableSearch()
        {
            InitializeComponent();

            resultTable.Columns.Add("No", typeof(int));
            resultTable.Columns.Add("Variable", typeof(string));
            resultTable.Columns.Add("Path", typeof(string));
            resultTable.Columns.Add("DefaultValue", typeof(string));
            resultTable.Columns.Add("Enum", typeof(string));
            resultTable.Columns.Add("Type", typeof(string));
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.Filter = "PE xml file|parameters_effective.xml";
            openFileDialog1.ShowDialog();
        }

        private void txtFileLocation1_MouseDown(object sender, MouseEventArgs e)
        {
            //openFileDialog1.Filter = "PE xml file|parameters_effective.xml";
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
                search();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void search()
        {
            try
            {
                if (txtFileLocation1.Text == "")
                {
                    MessageBox.Show("Please choose PE.xml file");
                    txtVariableName.Clear();
                    return;
                }

                if (rdVarStartWith.Checked == false && rdVarContainOf.Checked == false)
                {
                    MessageBox.Show("Please select Search Type");
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

                    if (rdVarContainOf.Checked || rdVarStartWith.Checked)
                    {
                        XmlNodeList nodeList = doc.GetElementsByTagName("variable");
                        XmlNode parentNode = null;

                        foreach (XmlNode node in nodeList)
                        {
                            path = "";
                            enumValue = "";
                            parentNode = null;
                            CultureInfo ci = new CultureInfo("en-US");

                            //if (String.Compare(node.Attributes["name"].Value, txtVariableName.Text, true) == 0)
                            if (rdVarStartWith.Checked)
                            {
                                if (node.Attributes["name"].Value.ToLower().StartsWith(txtVariableName.Text.ToLower(), true, ci))
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
                                    XmlNodeList typeNodeList = newDoc.GetElementsByTagName("type");

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
                                    dr[1] = node.Attributes["name"].Value;
                                    dr[2] = path;
                                    dr[3] = defaultNodeList.Item(0).InnerText;
                                    dr[4] = enumValue;
                                    dr[5] = typeNodeList.Item(0).ChildNodes[0].Name.ToString();

                                    resultTable.Rows.Add(dr);
                                    count++;
                                }
                            }

                            if (rdVarContainOf.Checked)
                            {
                                if (node.Attributes["name"].Value.ToLower().Contains(txtVariableName.Text.ToLower()))
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
                                    XmlNodeList typeNodeList = newDoc.GetElementsByTagName("type");

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
                                    dr[1] = node.Attributes["name"].Value;
                                    dr[2] = path;
                                    dr[3] = defaultNodeList.Item(0).InnerText;
                                    dr[4] = enumValue;
                                    dr[5] = typeNodeList.Item(0).ChildNodes[0].Name.ToString();

                                    resultTable.Rows.Add(dr);
                                    count++;
                                }
                            }
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreateXslt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtFileLocation1.Text == "")
                {
                    MessageBox.Show("Please choose PE.xml file");
                    txtVariableName.Clear();
                    return;
                }
                if (txtVariableName.Text == "")
                {
                    MessageBox.Show("Please type variable name");
                    txtVariableName.Clear();
                    return;
                }
                
                DataGridViewSelectedRowCollection rowList = dataGridView1.SelectedRows;
                DataGridViewSelectedCellCollection cellList = dataGridView1.SelectedCells;
                if (rowList.Count == 0 && cellList.Count == 0)
                {
                    MessageBox.Show("Please select atleast 1 row or 1 cell to create XSLT");
                    return;
                }
                string xslt = "";
                if (rowList.Count != 0)
                {
                    foreach (DataGridViewRow row in rowList)
                    {
                        string[] temp = row.Cells[2].Value.ToString().Split('.');
                        if (temp.Length == 3)
                        {
                            xslt = xslt + "<xsl:template match='dictionary [@name=" + textBox2.Text + temp[0] + textBox2.Text + "]/dictionary [@name=" + textBox2.Text + temp[1] + textBox2.Text + "]/variable [@name=" + textBox2.Text + temp[2] + textBox2.Text + "]/type/" + row.Cells[5].Value.ToString() + "/default'>" + "\r\n";
                            xslt = xslt + "  " + "<xsl:element name='default'>" + row.Cells[3].Value + "</xsl:element>" + "\r\n";
                            xslt = xslt + "</xsl:template>" + "\r\n";
                        }
                        if (temp.Length == 2)
                        {
                            xslt = xslt + "<xsl:template match='dictionary [@name=" + textBox2.Text + temp[0] + textBox2.Text + "]/variable [@name=" + textBox2.Text + temp[1] + textBox2.Text + "]/type/" + row.Cells[5].Value.ToString() + "/default'>" + "\r\n";
                            xslt = xslt + "  " + "<xsl:element name='default'>" + row.Cells[3].Value + "</xsl:element>" + "\r\n";
                            xslt = xslt + "</xsl:template>" + "\r\n";
                        }
                    }
                }

                if (cellList.Count != 0)
                {
                    foreach (DataGridViewCell cell in cellList)
                    {
                        int rowIndex = cell.RowIndex;
                        int colIndex = cell.ColumnIndex;
                        DataGridViewRow row = dataGridView1.Rows[rowIndex];
                        string[] temp = row.Cells[2].Value.ToString().Split('.');
                        
                        if (temp.Length == 3)
                        {
                            xslt = xslt + "<xsl:template match='dictionary [@name=" + textBox2.Text + temp[0] + textBox2.Text + "]/dictionary [@name=" + textBox2.Text + temp[1] + textBox2.Text + "]/variable [@name=" + textBox2.Text + temp[2] + textBox2.Text + "]/type/" + row.Cells[5].Value.ToString() + "/default'>" + "\r\n";
                            xslt = xslt + "  " + "<xsl:element name='default'>" + row.Cells[3].Value + "</xsl:element>" + "\r\n";
                            xslt = xslt + "</xsl:template>" + "\r\n";
                        }
                        if (temp.Length == 2)
                        {
                            xslt = xslt + "<xsl:template match='dictionary [@name=" + textBox2.Text + temp[0] + textBox2.Text + "]/variable [@name=" + textBox2.Text + temp[1] + textBox2.Text + "]/type/" + row.Cells[5].Value.ToString() + "/default'>" + "\r\n";
                            xslt = xslt + "  " + "<xsl:element name='default'>" + row.Cells[3].Value + "</xsl:element>" + "\r\n";
                            xslt = xslt + "</xsl:template>" + "\r\n";
                        }
                    }
                }

                textBox1.Text = xslt;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            
        }

        int selectedColumn;
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {   
            switch (dataGridView1.SelectedCells.Count)
            {
                case 0:
                    // store no current selection
                    selectedColumn = -1;
                    return;
                case 1:
                    // store starting point for multi-select
                    selectedColumn = dataGridView1.SelectedCells[0].ColumnIndex;
                    return;
            }

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (cell.ColumnIndex != selectedColumn)
                {
                    cell.Selected = false;
                }
            }
        }

        private void rdStartWith_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void rdContainOf_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                search();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void frmPEVariableSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.frmPESearch = null;
        }
    }
}
