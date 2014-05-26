using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPPlusDemo
{
	public partial class FormSheetName : Form
	{
		public FormSheetName()
		{
			InitializeComponent();
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtSheetName.Text)) this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			else
			{
				this.Tag = txtSheetName.Text;
				this.DialogResult = System.Windows.Forms.DialogResult.OK;
			}
			this.Close();
		}
	}
}
