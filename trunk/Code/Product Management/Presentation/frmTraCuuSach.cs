using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BUS;
using DTO;

namespace Presentation
{
    public partial class frmTraCuuSach : Form
    {
        public frmTraCuuSach()
        {
            InitializeComponent();
        }

        private void frmTraCuuSach_Load(object sender, EventArgs e)
        {
            cmbMaSach.Enabled = false;
            cmbTenSach.Enabled = false;
            cmbTenTacGia.Enabled = false;
            btnTimMaSach.Enabled = false;
            btnTimTenSach.Enabled = false;
            btnTimTenTacGia.Enabled = false;
            btnSua.Enabled = false;
        }

        private void cbxTenSach_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTenSach.Checked)
            {
                cmbTenSach.Enabled = true;
                btnTimTenSach.Enabled = true;
                cbxMaSach.Enabled = false;
                cbxTenTacGia.Enabled = false;
                GetList();
            }
            else
            {
                cmbTenSach.Enabled = false;
                btnTimTenSach.Enabled = false;
                cbxMaSach.Enabled = true;
                cbxTenTacGia.Enabled = true;
            }
        }

        private void cbxMaSach_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMaSach.Checked)
            {
                cmbMaSach.Enabled = true;
                btnTimMaSach.Enabled = true;
                cbxTenSach.Enabled = false;
                cbxTenTacGia.Enabled = false;
                LayMaSach();
            }
            else
            {
                cmbMaSach.Enabled = false;
                btnTimMaSach.Enabled = false;
                cbxTenSach.Enabled = true;
                cbxTenTacGia.Enabled = true;
            }
        }

        private void cbxTenTacGia_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTenTacGia.Checked)
            {
                cmbTenTacGia.Enabled = true;
                btnTimTenTacGia.Enabled = true;
                cbxTenSach.Enabled = false;
                cbxMaSach.Enabled = false;
                LayTenTacGia();
            }
            else
            {
                cmbTenTacGia.Enabled = false;
                btnTimTenTacGia.Enabled = false;
                cbxTenSach.Enabled = true;
                cbxMaSach.Enabled = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimTenSach_Click(object sender, EventArgs e)
        {
            string tensach = (string)cmbTenSach.SelectedValue ;
           
            DataTable dt = new DataTable();
            SachBUS sb = new SachBUS();
            dt=sb.GetTable();
            dataGridView1.DataSource = dt;

        }

        public void GetList()
        {
            IList ds;
            SachBUS sb = new SachBUS();
            ds = sb.GetList();
            cmbTenSach.DataSource = ds;
            cmbTenSach.ValueMember = "TenSach";
            cmbTenSach.DisplayMember = "TenSach";
        }

        public void LayMaSach()
        {
            
            IList ds;
            SachBUS sb = new SachBUS();
            ds = sb.GetList();
            cmbMaSach.DataSource = ds;
            cmbMaSach.ValueMember = "MaSach";
            cmbMaSach.DisplayMember = "MaSach";
        }

        private void btnTimMaSach_Click(object sender, EventArgs e)
        {
            int masach = (int)cmbMaSach.SelectedValue;
            SachBUS sb = new SachBUS();
            DataTable dt = new DataTable();
            dt = sb.LayBangMaSach(masach);
            dataGridView1.DataSource = dt;
        }

        public void LayTenTacGia()
        {
            TacGiaBUS tacgiaBus = new TacGiaBUS();
            IList ds;
            ds = TacGiaBUS.GetList();
            cmbTenTacGia.DataSource = ds;
            cmbTenTacGia.ValueMember = "MaTG";
            cmbTenTacGia.DisplayMember = "TenTG";
        }

        private void btnTimTenTacGia_Click(object sender, EventArgs e)
        {
            int matg = (int)cmbTenTacGia.SelectedValue;
            SachBUS sb = new SachBUS();
            DataTable dt = new DataTable();
            dt = sb.LayBangTacGia(matg);
            dataGridView1.DataSource = dt;
        }
    }
}