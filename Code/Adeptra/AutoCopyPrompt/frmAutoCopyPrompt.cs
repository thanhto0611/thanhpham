using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace AutoCopyPrompt
{
    public partial class frmAutoCopyPrompt : Form
    {
        public DataTable resultTable = new DataTable();

        public frmAutoCopyPrompt()
        {
            InitializeComponent();

            resultTable.Columns.Add("No", typeof(int));
            resultTable.Columns.Add("VoxFile", typeof(string));
            resultTable.Columns.Add("Module", typeof(string));
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTtsFolder.Text == "")
                {
                    MessageBox.Show("Please choose Tts folder");
                    return;
                }
                if (txtSourceVoxFolder.Text == "")
                {
                    MessageBox.Show("Please choose source vox folder");
                    return;
                }
                if (txtTargetVoxFolder.Text == "")
                {
                    MessageBox.Show("Please choose target vox folder");
                    return;
                }
                string[] filePaths = Directory.GetFiles(txtTtsFolder.Text, "*.js");
                if (filePaths.Length == 0)
                {
                    MessageBox.Show("There is no text to speech file");
                    return;
                }
                string temp = "";
                int count = 0;
                resultTable.Clear();
                for (int i = 0; i < filePaths.Length; i++)
                {
                    string moduleName = Path.GetFileName(filePaths[i]);
                    moduleName = moduleName.Replace(".js", "");
                    string newPath = txtTargetVoxFolder.Text + @"\" + moduleName;
                    if (!Directory.Exists(newPath))
                    {
                        Directory.CreateDirectory(newPath);
                    }
                    StreamReader sr = new StreamReader(filePaths[i]);
                    while (sr.Peek() >= 0)
                    {
                        string line = sr.ReadLine();
                        line = line.Replace(" ", "");
                        line = line.Replace("\t", "");
                        if (line.IndexOf(":") >= 0)
                        {
                            string[] temp1 = line.Split(':');
                            string voxName = temp1[0];
                            if (voxName.StartsWith("p") & char.IsDigit(voxName[1]) & char.IsDigit(voxName[2]))
                            {
                                voxName = voxName.Remove(0, 1);
                                string sourceVoxPath = txtSourceVoxFolder.Text + @"\" + voxName + ".vox";
                                string targetVoxPath = newPath + @"\" + voxName + ".vox";
                                if (!File.Exists(sourceVoxPath) && !File.Exists(targetVoxPath))
                                {
                                    DataRow dr = resultTable.NewRow();
                                    dr[0] = count + 1;
                                    dr[1] = voxName;
                                    dr[2] = moduleName;

                                    resultTable.Rows.Add(dr);
                                    count++;
                                }
                                else
                                {
                                    if (File.Exists(sourceVoxPath))
                                    {
                                        if (File.Exists(targetVoxPath))
                                        {
                                            File.Delete(targetVoxPath);
                                        }
                                        File.Copy(sourceVoxPath, targetVoxPath);
                                    }
                                }
                                temp = temp + voxName + "\r\n";
                            }
                        }
                    }
                }
                dataGridView1.DataSource = resultTable;
                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnBrowseTtsFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserTts.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtTtsFolder.Text = folderBrowserTts.SelectedPath;
            }
        }

        private void btnBrowseSourceVoxFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserSourceVox.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSourceVoxFolder.Text = folderBrowserSourceVox.SelectedPath;
            }
        }

        private void btnBrowseTargetVoxFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserTargetVox.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtTargetVoxFolder.Text = folderBrowserTargetVox.SelectedPath;
            }
        }
    }
}
