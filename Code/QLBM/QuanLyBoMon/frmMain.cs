using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace QuanLyBoMon
{
    public partial class frmMain : Form
    {
        public static frmThemLop frmThemLop = null;
        public static frmTimKiemLop frmTimLop = null;
        public static frmQuanLyGiangVien frmQLGV = null;
        public static frmThongKeLopCuaGiangVien frmTKLGV = null;
        public static frmQuanLyMonHoc frmQLMH = null;
        public static frmQuanLyNamHoc frmQLNH = null;

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

        private void thôngKêLơpCuaGiangViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmTKLGV == null)
            {
                frmTKLGV = new frmThongKeLopCuaGiangVien();
                frmTKLGV.MdiParent = this;
                frmTKLGV.Dock = DockStyle.Fill;
                frmTKLGV.WindowState = FormWindowState.Maximized;
                frmTKLGV.Show();
            }
            else
            {
                frmTKLGV.BringToFront();
            }
        }

        private void timKiêmLơpToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void quanLyGiangVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmQLGV == null)
            {
                frmQLGV = new frmQuanLyGiangVien();
                frmQLGV.MdiParent = this;
                frmQLGV.Dock = DockStyle.Fill;
                frmQLGV.WindowState = FormWindowState.Maximized;
                frmQLGV.Show();
            }
            else
            {
                frmQLGV.BringToFront();
            }
        }

        private void quanLyMonHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmQLMH == null)
            {
                frmQLMH = new frmQuanLyMonHoc();
                frmQLMH.MdiParent = this;
                frmQLMH.Dock = DockStyle.Fill;
                frmQLMH.WindowState = FormWindowState.Maximized;
                frmQLMH.Show();
            }
            else
            {
                frmQLMH.BringToFront();
            }
        }

        private void quanLyNamHocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (frmQLNH == null)
            {
                frmQLNH = new frmQuanLyNamHoc();
                frmQLNH.MdiParent = this;
                frmQLNH.Dock = DockStyle.Fill;
                frmQLNH.WindowState = FormWindowState.Maximized;
                frmQLNH.Show();
            }
            else
            {
                frmQLNH.BringToFront();
            }
        }

        

        //public string ConvertToUnsign3(string str)
        //{
        //    Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        //    string temp = str.Normalize(NormalizationForm.FormD);
        //    return regex.Replace(temp, String.Empty)
        //                .Replace('\u0111', 'd').Replace('\u0110', 'D');
        //}

    }
}
