using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CompareVisio;
using PE.xml_Variable_Search;
using AutoCopyPrompt;
using System.Globalization;

namespace Adeptra_Tools
{
    public partial class frmMain : Form
    {
        public static frmPEVariableSearch frmPESearch = null;
        public static frmAutoCopyPrompt frmCopyPrompts = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void PESearch_Click(object sender, EventArgs e)
        {
            if (frmPESearch == null)
            {
                frmPESearch = new frmPEVariableSearch();
                frmPESearch.MdiParent = this;
                frmPESearch.Dock = DockStyle.Fill;
                frmPESearch.WindowState = FormWindowState.Maximized;
                frmPESearch.Show();
            }
            else
            {
                frmPESearch.BringToFront();
            }
        }

        private void copyVoxFiles_Click(object sender, EventArgs e)
        {
            if (frmCopyPrompts == null)
            {
                frmCopyPrompts = new frmAutoCopyPrompt();
                frmCopyPrompts.MdiParent = this;
                frmCopyPrompts.Dock = DockStyle.Fill;
                frmCopyPrompts.WindowState = FormWindowState.Maximized;
                frmCopyPrompts.Show();
            }
            else
            {
                frmCopyPrompts.BringToFront();
            }
        }
    }
}
