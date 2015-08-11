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
    public partial class frmThemMon : Form
    {
        public frmThemMon()
        {
            InitializeComponent();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenMon.Text == "")
                {
                    MessageBox.Show("Phải nhập tên môn học");
                    return;
                }
                MonDTO monDTO = new MonDTO();
                monDTO.TenMon = txtTenMon.Text;
                MonBUS.Insert(monDTO);
                MessageBox.Show("Thêm môn thành công");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmThemMon_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmThemLop.isFrmThemMonClosed = true;
        }
    }
}
