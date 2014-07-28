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
    public partial class MuonTraSach : Form
    {
        public MuonTraSach()
        {
            InitializeComponent();
        }

        private void MuonTraSach_Load(object sender, EventArgs e)
        {
            string query = txtTenSach.Text;
            SachBUS sb = new SachBUS();
           
            DataTable search = sb.Search(query);
            search.Columns[0].ColumnName = "Mã Sách";
            search.Columns[1].ColumnName = "Tên Sách";
            dtgrvSachTV.DataSource = search;
            dtgrvSachTV.Show();
            
        }

        private void tbxTenSach_TextChanged(object sender, EventArgs e)
        {
            MuonTraSach_Load(sender, e);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            try
            {
                int MaDG = int.Parse(txtMaDG.Text);
                DataTable data2 = PhieuMuonBUS.GetBook(MaDG);
                dtgrvDG.DataSource = data2;
                dtgrvDG.Show();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvRow = dtgrvDG.CurrentRow;
            int MaSach = (int)dgvRow.Cells[0].Value;
            SachBUS sb = new SachBUS();
            sb.UpdateRecord(MaSach,false);
            btnChon_Click(sender, e);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {         
            DataGridViewRow dgvRow = dtgrvSachTV.CurrentRow;
            int MaSach = (int)dgvRow.Cells[0].Value;
            SachBUS sb = new SachBUS();
            sb.UpdateRecord(MaSach,true);
            
            ChiTietMuonDTO ctmuon = new ChiTietMuonDTO();
            ctmuon.MaSach = MaSach;
            ctmuon.NgayTra = dtNgTra.Value;

            ChiTietMuonBUS ctmBus = new ChiTietMuonBUS();
            ctmBus.Insert(ctmuon);

            PhieuMuonDTO phieuMuon = new PhieuMuonDTO();
            phieuMuon.MaDocGia = int.Parse(txtMaDG.Text);
            phieuMuon.NgayMuon = DateTime.Now;

            PhieuMuonBUS pmBus = new PhieuMuonBUS();
            pmBus.Insert(phieuMuon);

            btnChon_Click(sender, e);
        }

                         
    }
}