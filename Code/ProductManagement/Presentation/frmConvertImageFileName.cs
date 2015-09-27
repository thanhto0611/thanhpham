using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Presentation
{
    public partial class frmConvertImageFileName : Form
    {
        public frmConvertImageFileName()
        {
            InitializeComponent();
        }

        private void btnBrowseInputImageFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserInput.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtInputImageFolder.Text = folderBrowserInput.SelectedPath;
            }
        }

        private void btnBrowseOutputImageFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserOutput.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtOutputImageFolder.Text = folderBrowserOutput.SelectedPath;
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (txtOutputImageFolder.Text == "")
            {
                MessageBox.Show("Please select output images folder");
                return;
            }

            if (txtInputImageFolder.Text == "")
            {
                MessageBox.Show("Please select input images folder");
                return;
            }

            try
            {
                var imageFiles = new DirectoryInfo(txtInputImageFolder.Text).GetFiles("*.*");
                string[] imageFileNames = new string[imageFiles.Length];

                DataTable dt = new DataTable();

                dt.Columns.Add("OldFileName", typeof(string));
                dt.Columns.Add("NewFileName", typeof(string));

                for (int i = 0; i < imageFiles.Length; i++)
                {
                    if (imageFiles[i].Name.Contains('-'))
                    {
                        string[] splitName = imageFiles[i].Name.Split('-');
                        string newFileName = splitName[0];

                        if (cbxIncludeGiaLe.Checked)
                        {
                            newFileName = newFileName + "-" + splitName[1];
                        }

                        if (cbxIncludeGiaSi.Checked)
                        {
                            newFileName = newFileName + "-" + (Int32.Parse(splitName[1]) / 2).ToString();
                        }

                        newFileName += ".jpg";

                        string inputPath = Path.Combine(txtInputImageFolder.Text + @"\", imageFiles[i].Name);
                        string outputPath = Path.Combine(txtOutputImageFolder.Text + @"\", newFileName);

                        if (!File.Exists(outputPath))
                        {
                            DataRow dr = dt.NewRow();
                            dr[0] = imageFiles[i].Name;
                            dr[1] = newFileName;

                            dt.Rows.Add(dr);

                            File.Copy(inputPath, outputPath);
                        }
                    }
                }

                dtgvImageFileName.DataSource = dt;
                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void frmConvertImageFileName_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmConvertImageFileName = null;
        }

        private void btnRevert_Click(object sender, EventArgs e)
        {
            if (txtOutputImageFolder.Text == "")
            {
                MessageBox.Show("Please select output images folder");
                return;
            }

            if (txtInputImageFolder.Text == "")
            {
                MessageBox.Show("Please select input images folder");
                return;
            }

            try
            {
                foreach (DataGridViewRow dr in dtgvImageFileName.Rows)
                {
                    string inputPath = Path.Combine(txtInputImageFolder.Text + @"\", dr.Cells["NewFileName"].Value.ToString());
                    string outputPath = Path.Combine(txtOutputImageFolder.Text + @"\", dr.Cells["OldFileName"].Value.ToString());

                    if (File.Exists(inputPath))
                    {
                        File.Copy(inputPath, outputPath);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string[] productList = System.IO.File.ReadAllLines(textBox3.Text);
            foreach (string product in productList)
            {
                string rootFolderPath = textBox2.Text;
                string filesToDelete = product + "*";
                string[] fileList = System.IO.Directory.GetFiles(rootFolderPath, filesToDelete, System.IO.SearchOption.AllDirectories);
                foreach (string file in fileList)
                {
                    System.IO.File.Delete(file);
                }
            }
            MessageBox.Show("Done");
        }
    }
}
