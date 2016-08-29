using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Presentation
{
    public partial class frmQuanLyTacGia : Form
    {
        public frmQuanLyTacGia()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemTacGia frm = new frmThemTacGia();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSuaDocGia frm = new frmSuaDocGia();
            frm.ShowDialog();
        }
    }
}