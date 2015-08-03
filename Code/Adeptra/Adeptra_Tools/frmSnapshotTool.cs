using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.IO.IsolatedStorage;
using System.Reflection;

namespace Adeptra_Tools
{
    public partial class frmSnapshotTool : Form
    {

        public frmSnapshotTool()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location).Replace("\\", "/");
            string text = System.IO.File.ReadAllText(@"C:\Users\Admin\Desktop\Portal\apm2_lloydsbgukfraudcredit_snapshot.sql");

            string html = System.IO.File.ReadAllText(@"C:\Users\Admin\Desktop\Portal\lloydsCredit.htm");

            Regex regModel = new Regex(@"<model>(.*?)<\/model>");
            MatchCollection mcModel = regModel.Matches(text);

            Regex regPortfolio = new Regex(@"INSERT INTO `tblPortfolio` VALUES(.*?);");
            MatchCollection mcPortfolio = regPortfolio.Matches(text);

            string[] portfolioNames = new string[mcPortfolio.Count];

            for (int i = 0; i< mcPortfolio.Count;i++)
            {
                Regex regPortfolioName = new Regex(@"'(.*?)'");
                MatchCollection mcPortfolioName = regPortfolioName.Matches(mcPortfolio[i].Value);
                portfolioNames[i] = mcPortfolioName[0].Value.Replace("'", "");
            }

            DisplayHtml(html);
            //MatchCollection mcPortfolio = regPortfolio.Match(text);

            textBox1.Text = mcModel[0].Value;
        }

        private void DisplayHtml(string html)
        {
            webBrowser1.Navigate("about:blank");
            if (webBrowser1.Document != null)
            {
                webBrowser1.Document.Write(string.Empty);
            }
            webBrowser1.DocumentText = html;
        }

        public static void CopyContentToIsolatedStorage(string file)
        {
            // Obtain the virtual store for the application.
            IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication();

            //if (iso. iso.FileExists(file))
            //    return;

            //var fullDirectory = System.IO.Path.GetDirectoryName(file);
            //if (!iso.DirectoryExists(fullDirectory))
            //    iso.CreateDirectory(fullDirectory);

            //// Create a stream for the file in the installation folder.
            //using (Stream input = Application.GetResourceStream(new Uri(file, UriKind.Relative)).Stream)
            //{
            //    // Create a stream for the new file in isolated storage.
            //    using (IsolatedStorageFileStream output = iso.CreateFile(file))
            //    {
            //        // Initialize the buffer.
            //        byte[] readBuffer = new byte[4096];
            //        int bytesRead = -1;

            //        // Copy the file from the installation folder to isolated storage. 
            //        while ((bytesRead = input.Read(readBuffer, 0, readBuffer.Length)) > 0)
            //        {
            //            output.Write(readBuffer, 0, bytesRead);
            //        }
            //    }
            //}
        }
    }
}
