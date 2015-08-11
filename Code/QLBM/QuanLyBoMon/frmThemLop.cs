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
    public partial class frmThemLop : Form
    {
        public DataTable dtDanhSachMon = new DataTable();
        public static bool isFrmThemMonClosed = false;

        public frmThemLop()
        {
            InitializeComponent();
        }

        private void frmThemLop_Load(object sender, EventArgs e)
        {
            dtDanhSachMon = MonBUS.GetTable();
            dtgvDSMon.DataSource = dtDanhSachMon;

            DataGridViewCheckBoxColumn checkboxColumn = new DataGridViewCheckBoxColumn();
            checkboxColumn.Width = 30;
            checkboxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDSMon.Columns.Insert(0, checkboxColumn);

            // add checkbox header
            Rectangle rect = dtgvDSMon.GetCellDisplayRectangle(0, -1, true);
            // set checkbox header to center of header cell. +1 pixel to position correctly.
            rect.X = rect.Location.X + (rect.Width / 4);

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = rect.Location;
            checkboxHeader.CheckedChanged += new EventHandler(checkboxHeader_CheckedChanged);

            dtgvDSMon.Controls.Add(checkboxHeader);
        }

        private void checkboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgvDSMon.RowCount; i++)
            {
                dtgvDSMon[0, i].Value = ((CheckBox)dtgvDSMon.Controls.Find("checkboxHeader", true)[0]).Checked;
            }
            dtgvDSMon.EndEdit();
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            try
            {
                isFrmThemMonClosed = false;
                timer1.Start();
                frmThemMon frm = new frmThemMon();
                frm.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void refreshData()
        {
            dtDanhSachMon = MonBUS.GetTable();
            dtgvDSMon.DataSource = dtDanhSachMon;
            ((CheckBox)dtgvDSMon.Controls.Find("checkboxHeader", true)[0]).Checked = false;
        }

        private void dtgvDSMon_DataSourceChanged(object sender, EventArgs e)
        {
            dtgvDSMon.Columns["MaMon"].Visible = false;
            dtgvDSMon.Columns["TenMon"].HeaderText = "Tên Môn";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isFrmThemMonClosed)
            {
                timer1.Stop();
                refreshData();
            }
        }

        private void btnThemLop_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtTenLop.Text == "")
                {
                    MessageBox.Show("Phải nhập tên lớp");
                    return;
                }
                if (countSelectedRow() == 0)
                {
                    MessageBox.Show("Phải chọn ít nhất 1 môn học");
                    return;
                }

                LopDTO lopDTO = new LopDTO();
                lopDTO.TenLop = txtTenLop.Text;
                lopDTO.SoLuongSinhVien = Int32.Parse(txtSoLuongSinhVien.Text);
                lopDTO.SoLuongTrongNganSach = Int32.Parse(txtSoLuongTrongNganSach.Text);
                lopDTO.SoLuongNgoaiNganSach = Int32.Parse(txtSoLuongNgoaiNganSach.Text);
                LopBUS.Insert(lopDTO);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int countSelectedRow()
        {
            int count = 0;

            foreach (DataGridViewRow row in dtgvDSMon.Rows)
            {
                if (row.Cells[0].Value != null)
                    count++;
            }

            return count;
        }
    }
}
