using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Microsoft.VisualBasic.FileIO;
using System.Windows.Forms;
using BUS;
using DTO;

namespace Presentation
{
    public partial class frmThemSanPham : Form
    {
        public frmThemSanPham()
        {
            InitializeComponent();
        }

        private void btnBrowseCvsFile_Click(object sender, EventArgs e)
        {
            openfdCvs.ShowDialog();
            //var i = 1234;
            //var d = 3456.789;

            //MessageBox.Show(i.ToString("n"));
            //MessageBox.Show(d.ToString("n"));
            //MessageBox.Show(i.ToString("n0"));
            //MessageBox.Show(d.ToString("n0"));
            //MessageBox.Show(i.ToString("#,0.##"));
            //MessageBox.Show(d.ToString("#,0.##"));
        }

        private void openfdCvs_FileOk(object sender, CancelEventArgs e)
        {
            txtCvsFile.Text = openfdCvs.FileName;
        }

        private void btnDocFile_Click(object sender, EventArgs e)
        {
            dtgvCvsData.Refresh();
            if (txtCvsFile.Text == "")
            {
                MessageBox.Show("Bạn phải chọn file để nhập liệu", "Thông báo!");
                return;
            }

            string csv_file_path = txtCvsFile.Text;
            DataTable csvData = GetDataTabletFromCSVFile(csv_file_path);

            dtgvCvsData.DataSource = csvData;

            btnImport.Visible = true;
        }

        private static DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();

            try
            {

                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datacolumn = new DataColumn(column);
                        datacolumn.AllowDBNull = true;
                        csvData.Columns.Add(datacolumn);
                    }

                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        //Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }
                        csvData.Rows.Add(fieldData);
                    }
                }
                csvData.Columns.Remove("store");
                csvData.Columns.Remove("websites");
                csvData.Columns.Remove("attribute_set");
                csvData.Columns.Remove("type");
                csvData.Columns.Remove("category_ids");
                csvData.Columns.Remove("sku");
                csvData.Columns.Remove("has_options");
                csvData.Columns.Remove("meta_title");
                csvData.Columns.Remove("meta_description");
                csvData.Columns.Remove("small_image");
                csvData.Columns.Remove("url_key");
                csvData.Columns.Remove("thumbnail");
                csvData.Columns.Remove("gift_message_available");
                csvData.Columns.Remove("url_path");
                csvData.Columns.Remove("custom_design");
                csvData.Columns.Remove("options_container");
                csvData.Columns.Remove("image_label");
                csvData.Columns.Remove("small_image_label");
                csvData.Columns.Remove("thumbnail_label");
                csvData.Columns.Remove("page_layout");
                csvData.Columns.Remove("country_of_manufacture");
                csvData.Columns.Remove("msrp_enabled");
                csvData.Columns.Remove("msrp_display_actual_price_type");
                csvData.Columns.Remove("cost");
                csvData.Columns.Remove("special_price");
                csvData.Columns.Remove("msrp");
                csvData.Columns.Remove("description");
                csvData.Columns.Remove("meta_keyword");
                csvData.Columns.Remove("short_description");
                csvData.Columns.Remove("custom_layout_update");
                csvData.Columns.Remove("status");
                csvData.Columns.Remove("tax_class_id");
                csvData.Columns.Remove("visibility");
                csvData.Columns.Remove("manufacturer");
                csvData.Columns.Remove("enable_googlecheckout");
                csvData.Columns.Remove("is_recurring");
                csvData.Columns.Remove("news_from_date");
                csvData.Columns.Remove("news_to_date");
                csvData.Columns.Remove("special_from_date");
                csvData.Columns.Remove("special_to_date");
                csvData.Columns.Remove("custom_design_from");
                csvData.Columns.Remove("custom_design_to");
                csvData.Columns.Remove("min_qty");
                csvData.Columns.Remove("use_config_min_qty");
                csvData.Columns.Remove("is_qty_decimal");
                csvData.Columns.Remove("backorders");
                csvData.Columns.Remove("use_config_backorders");
                csvData.Columns.Remove("min_sale_qty");
                csvData.Columns.Remove("use_config_min_sale_qty");
                csvData.Columns.Remove("max_sale_qty");
                csvData.Columns.Remove("use_config_max_sale_qty");
                csvData.Columns.Remove("low_stock_date");
                csvData.Columns.Remove("notify_stock_qty");
                csvData.Columns.Remove("use_config_notify_stock_qty");
                csvData.Columns.Remove("manage_stock");
                csvData.Columns.Remove("use_config_manage_stock");
                csvData.Columns.Remove("stock_status_changed_auto");
                csvData.Columns.Remove("use_config_qty_increments");
                csvData.Columns.Remove("qty_increments");
                csvData.Columns.Remove("use_config_enable_qty_inc");
                csvData.Columns.Remove("enable_qty_increments");
                csvData.Columns.Remove("is_decimal_divided");
                csvData.Columns.Remove("stock_status_changed_automatically");
                csvData.Columns.Remove("use_config_enable_qty_increments");
                csvData.Columns.Remove("product_name");
                csvData.Columns.Remove("store_id");
                csvData.Columns.Remove("product_type_id");
                csvData.Columns.Remove("product_status_changed");
                csvData.Columns.Remove("product_changed_websites");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return csvData;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (!rdNew.Checked && !rdUpdate.Checked)
                {
                    MessageBox.Show("Please select type of import");
                    return;
                }

                SanPhamBUS spBus = new SanPhamBUS();
                foreach (DataGridViewRow row in this.dtgvCvsData.Rows)
                {
                    SanPhamDTO sp = new SanPhamDTO();
                    sp.MaSanPham = row.Cells["name"].Value.ToString();
                    if (row.Cells["image"].Value.ToString() != "")
                    {
                        string[] splitHinhAnh = row.Cells["image"].Value.ToString().Split('/');
                        if (splitHinhAnh.Length > 2)
                        {
                            sp.HinhAnh = splitHinhAnh[3];
                        }
                        else
                        {
                            sp.HinhAnh = row.Cells["image"].Value.ToString().Substring(2).ToLower();
                        }
                    } 
                    else
                    {
                        sp.HinhAnh = "";
                    }
                    
                    string[] splitTrongLuong = row.Cells["weight"].Value.ToString().Split('.');
                    sp.TrongLuong = Int32.Parse(splitTrongLuong[0]);
                    sp.MauSac = row.Cells["mau_sac"].Value.ToString();
                    string[] splitSoLuong = row.Cells["qty"].Value.ToString().Split('.');
                    //if (rdNew.Checked == true)
                    //{
                    //    sp.SoLuong = 100;
                    //}
                    //else
                    //{
                    //    sp.SoLuong = Int32.Parse(splitSoLuong[0]);
                    //}

                    sp.SoLuong = Int32.Parse(splitSoLuong[0]);
                    
                    sp.TrangThai = Int32.Parse(row.Cells["is_in_stock"].Value.ToString());
                    string[] splitGiaLe = row.Cells["price"].Value.ToString().Split('.');
                    sp.GiaLe = long.Parse(splitGiaLe[0]);
                    string[] splitGiaSi = row.Cells["gia_si"].Value.ToString().Split('.');
                    sp.GiaSi = long.Parse(splitGiaSi[0]);
                    if (sp.GiaSi == 0)
                    {
                        double a = (sp.GiaLe / 3) * 2;
                        sp.GiaSi = (long)Math.Round(a);
                    }
                    sp.GiaGoc = sp.GiaSi / 2;
                    sp.NgayNhap = System.DateTime.Now;
                    sp.NguoiNhap = frmDangNhap.gUserName;
                    sp.NgayCapNhat = System.DateTime.Now;
                    sp.NguoiCapNhat = frmDangNhap.gUserName;
                    DanhMucBUS dmBUS = new DanhMucBUS();
                    if (sp.MaSanPham.Substring(0, 1) == "N")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Nhẫn").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 1) == "X")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Hình Xăm").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "BT")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Bông Tai").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "DC")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Dây Chuyền").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "VT")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Vòng Tay").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "DL")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Dây Lưng").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "BA")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Túi Xách").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "KT")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Phụ Kiện Tóc").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "CA")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Cài Áo").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "BK")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Bikini").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "DH")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Đồng Hồ").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "MK")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Móc Khóa").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "KQ")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Khăn Quàng Cổ").MaDanhMuc;
                    }
                    if (sp.MaSanPham.Substring(0, 2) == "PK")
                    {
                        sp.MaDanhMuc = dmBUS.LayMaDanhMuc(@"Phụ Kiện Trang Trí").MaDanhMuc;
                    }
                    if (spBus.KiemTraTonTai(sp.MaSanPham) == true)
                    {
                        spBus.Update(sp);
                    }
                    else
                    {
                        spBus.Insert(sp);
                    }

                }
                MessageBox.Show("Import dữ liệu thành công!", "Thông báo!");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void dtgvCvsData_DataSourceChanged(object sender, EventArgs e)
        {
            
        }

        private void frmThemSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmThemSP = null;
        }
    }
}
