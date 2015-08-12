﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyBoMon
{
    public partial class frmMain : Form
    {
        public static frmThemLop frmThemLop = null;
        public static frmTimKiemLop frmTimLop = null;

        public frmMain()
        {
            InitializeComponent();
        }

        private void thêmLơpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmThemLop == null)
            {
                frmThemLop = new frmThemLop();
                frmThemLop.MdiParent = this;
                frmThemLop.Dock = DockStyle.Fill;
                frmThemLop.WindowState = FormWindowState.Maximized;
                frmThemLop.Show();
            }
            else
            {
                frmThemLop.BringToFront();
            }
        }

        private void timLopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTimLop == null)
            {
                frmTimLop = new frmTimKiemLop();
                frmTimLop.MdiParent = this;
                frmTimLop.Dock = DockStyle.Fill;
                frmTimLop.WindowState = FormWindowState.Maximized;
                frmTimLop.Show();
            }
            else
            {
                frmTimLop.BringToFront();
            }
        }
    }
}
