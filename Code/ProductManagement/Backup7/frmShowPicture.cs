using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using DTO;
using BUS;
using System.Globalization;

namespace Presentation
{
    public partial class frmShowPicture : Form
    {
        public frmShowPicture()
        {
            InitializeComponent();
        }

        public void LoadPicture(string path, string maSp)
        {
            SanPhamDTO spDto = SanPhamBUS.LaySanPham(maSp);
            lbMaSanPham.Text = maSp;
            lbGiaLe.Text = spDto.GiaLe.ToString("n0");
            lbGiaSi.Text = spDto.GiaSi.ToString("n0");
            this.Text = maSp + " - " + lbGiaLe.Text + " - " + lbGiaSi.Text;
            pictureBox1.Load(path);
        }

        public void ClearPicture()
        {
            pictureBox1.Refresh();
        }
    }
}
