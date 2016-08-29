using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DTO;
using BUS;
namespace Presentation
{
    public partial class frmQuanLyTheLoaiSach : Form
    {
        public frmQuanLyTheLoaiSach()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmThemTheLoaiSach frm = new frmThemTheLoaiSach();
            frm.ShowDialog();
        }
    }
}