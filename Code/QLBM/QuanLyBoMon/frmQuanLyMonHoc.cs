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
    public partial class frmQuanLyMonHoc : Form
    {
        public MonDTO monDTO;
        public frmQuanLyMonHoc()
        {
            InitializeComponent();
        }

        private void btnThemMonHoc_Click(object sender, EventArgs e)
        {
            if (txtTenMonHocThem.Text == "")
            {
                MessageBox.Show("Phải nhập tên môn học");
                return;
            }
            try
            {
                MonDTO monDTO = new MonDTO();
                monDTO.TenMon = txtTenMonHocThem.Text;
                MonBUS.Insert(monDTO);
                MessageBox.Show("Thêm môn học thành công");
                layDanhSachMon();
                txtTenMonHocThem.Text = "";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLyMonHoc_Load(object sender, EventArgs e)
        {
            try
            {
                layDanhSachMon();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void layDanhSachMon()
        {
            try
            {
                listMonHoc.DataSource = MonBUS.GetTable(txtThongTinTimKiem.Text);
                listMonHoc.DisplayMember = "TenMon";
                listMonHoc.ValueMember = "MaMon";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtThongTinTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachMon();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listMonHoc_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (listMonHoc.SelectedIndex >= 0)
                {
                    monDTO = MonBUS.GetRecord(Int32.Parse(listMonHoc.SelectedValue.ToString()));

                    txtTenMonHocUpdate.Text = monDTO.TenMon;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLyMonHoc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain.frmQLMH = null;
        }

        private void btnCapNhatMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn cập nhật môn học này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    monDTO.TenMon = txtTenMonHocUpdate.Text;

                    MonBUS.UpdateRecord(monDTO);
                    MessageBox.Show("Cập nhật môn học thành công");
                    layDanhSachMon();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoaMonHoc_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa môn học này không?",
                        "Question",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    MonBUS.Delete(monDTO.MaMon);
                    MessageBox.Show("Xóa môn học thành công");
                    layDanhSachMon();

                    txtTenMonHocUpdate.Text = "";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
