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
using System.Data.SqlClient;

namespace QuanLyBoMon
{
    public partial class frmThemGiangVienVaoMon : Form
    {
        public DataTable dtGiangVienCuaMon = new DataTable();
        public ChiTietMonDTO chiTietMonDTO = new ChiTietMonDTO();
        public int maChiTietMon = 0;

        public frmThemGiangVienVaoMon()
        {
            InitializeComponent();
        }

        private void txtThongTinTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                layDanhSachGiangVien();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void layDanhSachGiangVien()
        {
            try
            {
                listGiangVien.DataSource = GiangVienBUS.GetTable(txtThongTinTimKiem.Text);
                listGiangVien.DisplayMember = "TenGiangVien";
                listGiangVien.ValueMember = "MaGiangVien";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmThemGiangVienVaoMon_Load(object sender, EventArgs e)
        {
            try
            {
                maChiTietMon = frmThemLop.gMaChiTietMon;
                dtGiangVienCuaMon = GiangVienBUS.LayDanhSachGiangVienCuaMon(maChiTietMon);

                listGiangVienMon.DataSource = dtGiangVienCuaMon;
                listGiangVienMon.DisplayMember = "TenGiangVien";
                listGiangVienMon.ValueMember = "MaGiangVien";
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (listGiangVien.SelectedIndex >= 0)
                {
                    int maGiangVien = Int32.Parse(listGiangVien.SelectedValue.ToString());
                    bool contains = dtGiangVienCuaMon.AsEnumerable()
                                   .Any(row => maGiangVien == row.Field<int>("MaGiangVien"));
                    if (contains == false)
                    {
                        DataRow dr = dtGiangVienCuaMon.NewRow();

                        dr[0] = maGiangVien;
                        dr[1] = listGiangVien.Text;

                        dtGiangVienCuaMon.Rows.Add(dr);

                        listGiangVienMon.DataSource = dtGiangVienCuaMon;
                        listGiangVienMon.DisplayMember = "TenGiangVien";
                        listGiangVienMon.ValueMember = "MaGiangVien";

                        if (!GiangVienBUS.KiemTraGiangVienTheoMaGiangVienMaChiTietMon(maGiangVien, maChiTietMon))
                        {
                            GiangVienBUS.ThemGiangVienMon(maGiangVien, maChiTietMon);
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBoChon_Click(object sender, EventArgs e)
        {
            try
            {
                if (listGiangVienMon.SelectedIndex >= 0)
                {
                    GiangVienBUS.XoaGiangVienMon(Int32.Parse(listGiangVienMon.SelectedValue.ToString()), maChiTietMon);

                    dtGiangVienCuaMon.Rows.Remove(dtGiangVienCuaMon.Rows[listGiangVienMon.SelectedIndex]);

                    listGiangVienMon.DataSource = dtGiangVienCuaMon;
                    listGiangVienMon.DisplayMember = "TenGiangVien";
                    listGiangVienMon.ValueMember = "MaGiangVien";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemGiangVienVaoMon_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmThemLop.isFrmThemGiangVienClosed = true;
        }
    }
}
