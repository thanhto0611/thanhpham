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
    public partial class frmQuanLySach : Form
    {
        public frmQuanLySach()
        {
            InitializeComponent();
        }

        private void btnThemSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxTenSach.Text=="")
                {
                    MessageBox.Show("Phải nhập tựa sách");
                    return;
                }
                if (cmbNgonNgu.Text=="")
                {
                    MessageBox.Show("Phải chọn ngôn ngữ");
                    return;
                }
                if (cmbTenTG.Text == "")
                {
                    MessageBox.Show("Phải chọn tác giả");
                    return;
                }
                if (comboBox4.Text == "")
                {
                    MessageBox.Show("Phải chọn nhà xuất bản");
                    return;
                }
                if (cmbLoaiSach.Text == "")
                {
                    MessageBox.Show("Phải chọn loại sách");
                    return;
                }
                if (textBox2.Text=="")
                {
                    MessageBox.Show("Phải nhập số trang");
                    return;
                }
                DialogResult result = MessageBox.Show("Bạn có chắc là muốn thực hiện tác vụ này không",
                    "Question",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    DateTime date;
                    int matg;
                    int manxb;
                    int maloai;
                    int mann;
                    matg = (cmbTenTG.SelectedItem as TacGiaDTO).MaTG;
                    manxb = (comboBox4.SelectedItem as NhaXuatBanDTO).MaNXB;
                    maloai = (cmbLoaiSach.SelectedItem as TheLoaiDTO).MaLoai;
                    mann = (cmbNgonNgu.SelectedItem as NgonNguDTO).MaNgonNgu;

                    date = DateTime.Now.Date;
                    string temp = Convert.ToString(date.Month) + "/" + Convert.ToString(date.Day) + "/" + Convert.ToString(date.Year);
                    SachDTO sach = new SachDTO();
                    sach.TenSach = tbxTenSach.Text;
                    sach.MaTacGia = matg;
                    sach.MaTheLoai = maloai;
                    sach.MaNXB = manxb;
                    sach.MaNgonNgu = mann;
                    sach.TrangThai = 0;
                    sach.NgayNhap = Convert.ToDateTime(temp);
                    sach.SoTrang = int.Parse(textBox2.Text);
                    SachBUS sb = new SachBUS();
                    sb.Insert(sach);
                    MessageBox.Show("Thêm thành công");
                    tbxTenSach.Text = "";
                    textBox2.Text = "";
                    cmbNgonNgu.Text = "";
                    cmbLoaiSach.Text = "";
                    cmbTenTG.Text = "";
                    comboBox4.Text = "";
                }
                else
                {
                    return;
                }
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmQuanLySach_Load(object sender, EventArgs e)
        {
           
            cmbTenTG.DataSource = TacGiaBUS.GetList();
            cmbTenTG.DisplayMember = "TenTG";
            cmbTenTG.ValueMember = "MaTG";

            comboBox4.DataSource = NhaXuatBanBUS.GetList();
            comboBox4.DisplayMember = "TenNXB";
            comboBox4.ValueMember = "MaNXB";

            cmbLoaiSach.DataSource = TheLoaiBUS.GetList();
            cmbLoaiSach.DisplayMember = "TenTheLoai";
            cmbLoaiSach.ValueMember = "MaLoai";

            cmbNgonNgu.DataSource = NgonNguBUS.GetList();
            cmbNgonNgu.DisplayMember = "TenNgonNgu";
            cmbNgonNgu.ValueMember = "MaNgonNgu";

            tbxTenSach.Text = "";
            textBox2.Text = "";
            cmbNgonNgu.Text = "";
            cmbLoaiSach.Text = "";
            cmbTenTG.Text = "";
            comboBox4.Text = "";
        } 

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemSach frmTimKiem = new TimKiemSach();
            frmTimKiem.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemTG_Click(object sender, EventArgs e)
        {
            frmThemTacGia frm = new frmThemTacGia();
            frm.ShowDialog();
            this.frmQuanLySach_Load(sender, e);
        }

        private void btnThemNXB_Click(object sender, EventArgs e)
        {
            frmQuanLyNXB frm = new frmQuanLyNXB();
            frm.ShowDialog();
            this.frmQuanLySach_Load(sender, e);
        }

        private void btnThemLoaiSach_Click(object sender, EventArgs e)
        {
            frmThemTheLoaiSach frm = new frmThemTheLoaiSach();
            frm.ShowDialog();
            this.frmQuanLySach_Load(sender, e);
        }

        private void btnThemNgonNgu_Click(object sender, EventArgs e)
        {
            frmThemNgonNgu frm = new frmThemNgonNgu();
            frm.ShowDialog();
            this.frmQuanLySach_Load(sender, e);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            

        }

    }
}