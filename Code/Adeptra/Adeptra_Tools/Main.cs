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

namespace Adeptra_Tools
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void visioCompareToolStripButton_Click(object sender, EventArgs e)
        {
            frmVisioCompare frm = new frmVisioCompare();
            frm.Show();
        }

        private void variableSearchToolStripButton_Click(object sender, EventArgs e)
        {
            frmPEVariableSearch frm = new frmPEVariableSearch();
            frm.Show();
        }

        private void copyVoxFile_Click(object sender, EventArgs e)
        {
            frmAutoCopyPrompt frm = new frmAutoCopyPrompt();
            frm.Show();
        }
    }
}
