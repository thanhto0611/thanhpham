using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DTO;
using BUS;

namespace QuanLyBoMon
{
    public partial class frmThemNamHoc : Form
    {
        public frmThemNamHoc()
        {
            InitializeComponent();
        }

        private void btnThemNamHoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNamHoc.Text == "")
                {
                    MessageBox.Show("Phải nhập năm học");
                    return;
                }
                NamHocDTO namHocDTO = new NamHocDTO();
                namHocDTO.TenNamHoc = txtNamHoc.Text;
                NamHocBUS.Insert(namHocDTO);
                MessageBox.Show("Thêm năm học thành công");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmThemNamHoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmThemLop.isFrmThemNamHocClosed = true;
        }
    }
}
