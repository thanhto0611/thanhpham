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
            //string text = System.IO.File.ReadAllText(@"C:\Users\Admin\Desktop\Portal\apm2_lloydsbgukfraudcredit_snapshot.sql");
            string text = System.IO.File.ReadAllText(@"C:\Users\thanhpham.HARVEYNASH\Desktop\Portal\apm2_lloydsbgukfraudcredit_snapshot.sql");

            string html = "<html lang=\"en\"><head><title>FICO - Portfolio Manager</title><meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\"><link rel=\"icon\" type=\"image/ico\" href=\"https://portal-rabat.dev.gb2.adeptra.com:9443/favicon.ico\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/container.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/reset.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/menu.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/adeptra.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/portfolio.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/bootstrap.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/cloud.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/header_100.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/style.css\" rel=\"stylesheet\">";
            html += "<link href=\"" + path + "/lloydsCredit_files/fonts.css\" rel=\"stylesheet\">";
            html += System.IO.File.ReadAllText(path + "/lloydsCredit.htm");

            Regex regModel = new Regex(@"<model>(.*?)<\/model>");
            MatchCollection mcModel = regModel.Matches(text);

            Regex regPortfolio = new Regex(@"INSERT INTO `tblPortfolio` VALUES(.*?);");
            MatchCollection mcPortfolio = regPortfolio.Matches(text);

            //string[] portfolioNames = new string[mcPortfolio.Count];
            List<string> portfolioNames = new List<string>();

            for (int i = 0; i< mcPortfolio.Count;i++)
            {
                Regex regPortfolioName = new Regex(@"'(.*?)'");
                MatchCollection mcPortfolioName = regPortfolioName.Matches(mcPortfolio[i].Value);
                portfolioNames.Add(mcPortfolioName[0].Value.Replace("'", ""));
            }

            //DisplayHtml(html);

            foreach (string porfolioName in portfolioNames)
            {
                TabPage myTabPage = new TabPage(porfolioName);
                myTabPage.Name = "tabPage" + tabControl1.TabCount.ToString();
                WebBrowser myWebBrowser = new WebBrowser();
                myWebBrowser.Dock = DockStyle.Fill;
                myWebBrowser.ScriptErrorsSuppressed = true;
                //myWebBrowser.DocumentText = "<html>Thanh Pham</html>";
                myWebBrowser.DocumentText = html;
                myTabPage.Controls.Add(myWebBrowser);
                tabControl1.TabPages.Add(myTabPage);
            }
            listPortfolioName.DataSource = portfolioNames;
        }

        private void DisplayHtml(string html)
        {
            //webBrowser1.Navigate("about:blank");
            //if (webBrowser1.Document != null)
            //{
            //    webBrowser1.Document.Write(string.Empty);
            //}
            //webBrowser1.DocumentText = html;
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

        private void listPortfolioName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox. 
            string curItem = listPortfolioName.SelectedItem.ToString();

            // Find the string in ListBox2. 
            int index = listPortfolioName.FindString(curItem);

            tabControl1.SelectedTab = tabControl1.TabPages[index];
            
        }
    }
}
