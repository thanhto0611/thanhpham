using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Presentation
{
    public partial class frmImportProducts : Form
    {
        public DataTable resultTable = new DataTable();

        public frmImportProducts()
        {
            InitializeComponent();

            resultTable.Columns.Add("store", typeof(string));
            resultTable.Columns.Add("websites", typeof(string));
            resultTable.Columns.Add("attribute_set", typeof(string));
            resultTable.Columns.Add("type", typeof(string));
            resultTable.Columns.Add("category_ids", typeof(string));
            resultTable.Columns.Add("sku", typeof(string));
            resultTable.Columns.Add("has_options", typeof(string));
            resultTable.Columns.Add("name", typeof(string));
            resultTable.Columns.Add("meta_title", typeof(string));
            resultTable.Columns.Add("meta_description", typeof(string));
            resultTable.Columns.Add("media_gallery", typeof(string));
            resultTable.Columns.Add("image", typeof(string));
            resultTable.Columns.Add("small_image", typeof(string));
            resultTable.Columns.Add("url_key", typeof(string));
            resultTable.Columns.Add("thumbnail", typeof(string));
            resultTable.Columns.Add("gift_message_available", typeof(string));
            resultTable.Columns.Add("url_path", typeof(string));
            resultTable.Columns.Add("custom_design", typeof(string));
            resultTable.Columns.Add("options_container", typeof(string));
            resultTable.Columns.Add("image_label", typeof(string));
            resultTable.Columns.Add("small_image_label", typeof(string));
            resultTable.Columns.Add("thumbnail_label", typeof(string));
            resultTable.Columns.Add("page_layout", typeof(string));
            resultTable.Columns.Add("country_of_manufacture", typeof(string));
            resultTable.Columns.Add("msrp_enabled", typeof(string));
            resultTable.Columns.Add("msrp_display_actual_price_type", typeof(string));
            resultTable.Columns.Add("price", typeof(string));
            resultTable.Columns.Add("cost", typeof(string));
            resultTable.Columns.Add("weight", typeof(string));
            resultTable.Columns.Add("special_price", typeof(string));
            resultTable.Columns.Add("msrp", typeof(string));
            resultTable.Columns.Add("gia_si", typeof(string));
            resultTable.Columns.Add("meta_keyword", typeof(string));
            resultTable.Columns.Add("description", typeof(string));
            resultTable.Columns.Add("short_description", typeof(string));
            resultTable.Columns.Add("custom_layout_update", typeof(string));
            resultTable.Columns.Add("manufacturer", typeof(string));
            resultTable.Columns.Add("status", typeof(string));
            resultTable.Columns.Add("tax_class_id", typeof(string));
            resultTable.Columns.Add("visibility", typeof(string));
            resultTable.Columns.Add("enable_googlecheckout", typeof(string));
            resultTable.Columns.Add("is_recurring", typeof(string));
            resultTable.Columns.Add("special_from_date", typeof(string));
            resultTable.Columns.Add("special_to_date", typeof(string));
            resultTable.Columns.Add("custom_design_from", typeof(string));
            resultTable.Columns.Add("custom_design_to", typeof(string));
            resultTable.Columns.Add("news_from_date", typeof(string));
            resultTable.Columns.Add("news_to_date", typeof(string));
            resultTable.Columns.Add("qty", typeof(string));
            resultTable.Columns.Add("min_qty", typeof(string));
            resultTable.Columns.Add("use_config_min_qty", typeof(string));
            resultTable.Columns.Add("is_qty_decimal", typeof(string));
            resultTable.Columns.Add("backorders", typeof(string));
            resultTable.Columns.Add("use_config_backorders", typeof(string));
            resultTable.Columns.Add("min_sale_qty", typeof(string));
            resultTable.Columns.Add("use_config_min_sale_qty", typeof(string));
            resultTable.Columns.Add("max_sale_qty", typeof(string));
            resultTable.Columns.Add("use_config_max_sale_qty", typeof(string));
            resultTable.Columns.Add("is_in_stock", typeof(string));
            resultTable.Columns.Add("low_stock_date", typeof(string));
            resultTable.Columns.Add("notify_stock_qty", typeof(string));
            resultTable.Columns.Add("use_config_notify_stock_qty", typeof(string));
            resultTable.Columns.Add("manage_stock", typeof(string));
            resultTable.Columns.Add("use_config_manage_stock", typeof(string));
            resultTable.Columns.Add("stock_status_changed_auto", typeof(string));
            resultTable.Columns.Add("use_config_qty_increments", typeof(string));
            resultTable.Columns.Add("qty_increments", typeof(string));
            resultTable.Columns.Add("use_config_enable_qty_inc", typeof(string));
            resultTable.Columns.Add("enable_qty_increments", typeof(string));
            resultTable.Columns.Add("is_decimal_divided", typeof(string));
            resultTable.Columns.Add("stock_status_changed_automatically", typeof(string));
            resultTable.Columns.Add("use_config_enable_qty_increments", typeof(string));
            resultTable.Columns.Add("product_name", typeof(string));
            resultTable.Columns.Add("store_id", typeof(string));
            resultTable.Columns.Add("product_type_id", typeof(string));
            resultTable.Columns.Add("product_status_changed", typeof(string));
            resultTable.Columns.Add("product_changed_websites", typeof(string));
            resultTable.Columns.Add("mau_sac", typeof(string));
        }

        private void btnBrowseImageFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserImage.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtImageFolder.Text = folderBrowserImage.SelectedPath;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtImageFolder.Text == "")
                {
                    MessageBox.Show("Please select images folder");
                    return;
                }
                if (String.Format("{0:yyyy-MM-dd HH:mm:ss}", dtpNewFromDate.Value) == String.Format("{0:yyyy-MM-dd HH:mm:ss}", dtpNewToDate.Value))
                {
                    MessageBox.Show("Please select different value for NEW TO DATE");
                    return;
                }

                resultTable.Clear();
                var imageFiles = new DirectoryInfo(txtImageFolder.Text).GetFiles("*.*");

                string result = "";
                string[] imagesAddedName = new string[imageFiles.Length];
                int indexImageAdded = 0;

                string store = "admin";
                string websites = "base";
                string attribute_set = "";
                string type = "simple";
                string category_ids = "";
                string sku = "";
                string has_options = "0";
                string name = "";
                string meta_title = "";
                string meta_description = "";
                string media_gallery = "";
                string image = "";
                string small_image = "";
                string url_key = "";
                string thumbnail = "";
                string gift_message_available = "No";
                string url_path = "";
                string custom_design = "";
                string options_container = "Block after Info Column";
                string image_label = "";
                string small_image_label = "";
                string thumbnail_label = "";
                string page_layout = "No layout updates";
                string country_of_manufacture = " ";
                string msrp_enabled = "Use config";
                string msrp_display_actual_price_type = "Use config";
                string price = "";
                string cost = "";
                string weight = "0.0000";
                string special_price = "";
                string msrp = "";
                string gia_si = "";
                string meta_keyword = "";
                string description = "";
                string short_description = "";
                string custom_layout_update = "";
                string manufacturer = "";
                string status = "Hiệu lực";
                string tax_class_id = "None";
                string visibility = "Catalog, Search";
                string enable_googlecheckout = "Đồng ý";
                string is_recurring = "No";
                string special_from_date = "";
                string special_to_date = "";
                string custom_design_from = "";
                string custom_design_to = "";
                string news_from_date = String.Format("{0:yyyy-MM-dd}", dtpNewFromDate.Value);
                string news_to_date = String.Format("{0:yyyy-MM-dd}", dtpNewToDate.Value);
                news_from_date += " 00:00:00";
                news_to_date += " 00:00:00";
                string qty = "10.0000";
                string min_qty = "0.0000";
                string use_config_min_qty = "1";
                string is_qty_decimal = "0";
                string backorders = "0";
                string use_config_backorders = "1";
                string min_sale_qty = "1.0000";
                string use_config_min_sale_qty = "1";
                string max_sale_qty = "0.0000";
                string use_config_max_sale_qty = "1";
                string is_in_stock = "1";
                string low_stock_date = "";
                string notify_stock_qty = "";
                string use_config_notify_stock_qty = "1";
                string manage_stock = "0";
                string use_config_manage_stock = "1";
                string stock_status_changed_auto = "0";
                string use_config_qty_increments = "1";
                string qty_increments = "0.0000";
                string use_config_enable_qty_inc = "1";
                string enable_qty_increments = "0";
                string is_decimal_divided = "0";
                string stock_status_changed_automatically = "0";
                string use_config_enable_qty_increments = "1";
                string product_name = "";
                string store_id = "0";
                string product_type_id = "simple";
                string product_status_changed = "";
                string product_changed_websites = "";
                string mau_sac = "";

                for (int i = 0; i < imageFiles.Length; i++)
                {
                    

                    string[] splitName = imageFiles[i].Name.Split('-');
                    string transName = imageFiles[i].Name;
                    transName = transName.Replace('(', '_');
                    transName = transName.Replace(')','_');

                    imagesAddedName[indexImageAdded] = imageFiles[i].Name.Substring(0, splitName[0].Length);


                    if (checkImageExist(splitName[0]) == true)
                    {
                        DataRow[] drs = resultTable.Select("name = '" + splitName[0].ToUpper() + "'");

                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "BT")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/b/t/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "DC")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/d/c/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "VT")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/v/t/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "DH")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/d/h/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "KT")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/k/t/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "DL")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/d/l/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "MK")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/m/k/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "BA")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/b/a/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "CA")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/c/a/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 1).ToUpper() == "N")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/n/" + transName.Substring(1, 1).ToLower() + "/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }
                        if (imageFiles[i].Name.Substring(0, 1).ToUpper() == "X")
                        {
                            description = drs[0]["description"].ToString();
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/x/" + transName.Substring(1, 1).ToLower() + "/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";
                            drs[0]["description"] = description;
                        }

                        media_gallery = drs[0]["media_gallery"].ToString();
                        media_gallery = media_gallery + @";/" + imageFiles[i].Name;
                        drs[0]["media_gallery"] = media_gallery;
                    }
                    else
                    {
                        attribute_set = "";
                        category_ids = "";
                        sku = "";
                        name = "";
                        image = "";
                        small_image = "";
                        url_key = "";
                        thumbnail = "";
                        url_path = "";
                        short_description = "";
                        product_name = "";
                        description = "";
                        price = "";
                        gia_si = "";
                        media_gallery = "";


                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "BT")
                        {
                            attribute_set = "Bông Tai";
                            category_ids = "106,113,105";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">BÔNG TAI</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/b/t/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "BÔNG TAI " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "DC")
                        {
                            attribute_set = "Dây Chuyền";
                            category_ids = "105,107,113";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">DÂY CHUYỀN</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/d/c/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "DÂY CHUYỀN " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "VT")
                        {
                            attribute_set = "Vòng tay";
                            category_ids = "105,112,113";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">VÒNG TAY</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/v/t/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "VÒNG TAY " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "DH")
                        {
                            attribute_set = "Đồng Hồ";
                            category_ids = "113,124,115";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">ĐỒNG HỒ</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/d/h/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "ĐỒNG HỒ " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "MK")
                        {
                            attribute_set = "Móc Khóa";
                            category_ids = "113,128,115";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">MÓC KHÓA</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/m/k/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "MÓC KHÓA " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "KT")
                        {
                            attribute_set = "Phụ Kiện Tóc";
                            category_ids = "113,114,115";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">PHỤ KIỆN TÓC</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/k/t/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "PHỤ KIỆN TÓC " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "DL")
                        {
                            attribute_set = "Dây lưng";
                            category_ids = "113,115,117";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">DÂY LƯNG</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/d/l/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "DÂY LƯNG " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "KQ")
                        {
                            attribute_set = "Khăn Quàng Cổ";
                            category_ids = "113,115,120";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">KHĂN QUÀNG CỔ</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/k/q/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "KHĂN QUÀNG CỔ " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "BA")
                        {
                            attribute_set = "Cài áo & túi xách";
                            category_ids = "115,118,113";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">TÚI XÁCH</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/b/a/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "TÚI XÁCH " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "CA")
                        {
                            attribute_set = "Cài áo & túi xách";
                            category_ids = "115,130,113";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">CÀI ÁO</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/c/a/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "CÀI ÁO " + splitName[0].ToUpper();
                        }
                        if (imageFiles[i].Name.Substring(0, 1).ToUpper() == "N")
                        {
                            attribute_set = "Nhẫn";
                            category_ids = "105,110,113";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">NHẪN</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/n/" + transName.Substring(1, 1).ToLower() + "/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "NHẪN " + splitName[0].ToUpper();
                        }

                        if (imageFiles[i].Name.Substring(0, 1).ToUpper() == "X")
                        {
                            attribute_set = "Hình Xăm";
                            category_ids = "113,115,126";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">HÌNH XĂM</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/x/" + transName.Substring(1, 1).ToLower() + "/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "HÌNH XĂM " + splitName[0].ToUpper();
                        }

                        if (imageFiles[i].Name.Substring(0, 2).ToUpper() == "BK")
                        {
                            attribute_set = "Đồ Bơi";
                            category_ids = "113,122";

                            description = description + "<h1><font color=\"";
                            description = description + "blue\"";
                            description = description + ">BIKINI</font></h1>";
                            description = description + "\n";
                            description = description + "<h1><font size=\"";
                            description = description + "7\"";
                            description = description + " color=\"";
                            description = description + "red\"";
                            description = description + ">" + splitName[0].ToUpper() + "</font></h1>";
                            description = description + "\n";
                            description = description + "</br>";
                            description = description + "\n";
                            description = description + "<img src=\"";
                            description = description + "http://www.thoitrangella.com/media/catalog/product/k/q/" + transName.ToLower() + "\"";
                            description = description + " width=\"";
                            description = description + "400\"";
                            description = description + " height=\"";
                            description = description + "auto\"";
                            description = description + " />";

                            short_description = short_description + "BIKINI " + splitName[0].ToUpper();
                        }

                        sku = splitName[0].ToUpper();
                        name = splitName[0].ToUpper();
                        media_gallery = media_gallery + @"/" + imageFiles[i].Name;
                        image = image + @"+/" + imageFiles[i].Name;
                        small_image = small_image + @"/" + imageFiles[i].Name;
                        url_key = splitName[0].ToLower();
                        thumbnail = thumbnail + @"/" + imageFiles[i].Name;
                        url_path = url_path + splitName[0].ToLower() + ".html";

                        //string[] splitPrice = splitName[1].Split('(');
                        if (splitName.Length > 1)
                        {
                            //string[] splitGiaSi = splitPrice[1].Split(')');
                            //price = price + splitPrice[0] + "000.0000";

                            if (cbxIncludeQty.Checked)
                            {
                                string[] splitSoluong = splitName[3].Split('.');
                                price = price + splitName[1] + "000.0000";
                                gia_si = gia_si + splitName[2] + "000.0000";
                                qty = splitSoluong[0] + ".0000";
                            }
                            else
                            {
                                string[] splitGiaSi = splitName[2].Split('.');
                                price = price + splitName[1] + "000.0000";
                                gia_si = gia_si + splitGiaSi[0] + "000.0000";

                                if (txtManualQty.Text != "")
                                {
                                    qty = Int32.Parse(txtManualQty.Text) + ".0000";
                                }
                            }
                        }

                        product_name += splitName[0].ToUpper();

                        result += splitName[0] + ";";
                        result += "\n";

                        DataRow dr = resultTable.NewRow();
                        dr[0] = store;
                        dr[1] = websites;
                        dr[2] = attribute_set;
                        dr[3] = type;
                        dr[4] = category_ids;
                        dr[5] = sku;
                        dr[6] = has_options;
                        dr[7] = name;
                        dr[8] = meta_title;
                        dr[9] = meta_description;
                        dr[10] = media_gallery;
                        dr[11] = image;
                        dr[12] = small_image;
                        dr[13] = url_key;
                        dr[14] = thumbnail;
                        dr[15] = gift_message_available;
                        dr[16] = url_path;
                        dr[17] = custom_design;
                        dr[18] = options_container;
                        dr[19] = image_label;
                        dr[20] = small_image_label;
                        dr[21] = thumbnail_label;
                        dr[22] = page_layout;
                        dr[23] = country_of_manufacture;
                        dr[24] = msrp_enabled;
                        dr[25] = msrp_display_actual_price_type;
                        dr[26] = price;
                        dr[27] = cost;
                        dr[28] = weight;
                        dr[29] = special_price;
                        dr[30] = msrp;
                        dr[31] = gia_si;
                        dr[32] = meta_keyword;
                        dr[33] = description;
                        dr[34] = short_description;
                        dr[35] = custom_layout_update;
                        dr[36] = manufacturer;
                        dr[37] = status;
                        dr[38] = tax_class_id;
                        dr[39] = visibility;
                        dr[40] = enable_googlecheckout;
                        dr[41] = is_recurring;
                        dr[42] = special_from_date;
                        dr[43] = special_to_date;
                        dr[44] = custom_design_from;
                        dr[45] = custom_design_to;
                        dr[46] = news_from_date;
                        dr[47] = news_to_date;
                        dr[48] = qty;
                        dr[49] = min_qty;
                        dr[50] = use_config_min_qty;
                        dr[51] = is_qty_decimal;
                        dr[52] = backorders;
                        dr[53] = use_config_backorders;
                        dr[54] = min_sale_qty;
                        dr[55] = use_config_min_sale_qty;
                        dr[56] = max_sale_qty;
                        dr[57] = use_config_max_sale_qty;
                        dr[58] = is_in_stock;
                        dr[59] = low_stock_date;
                        dr[60] = notify_stock_qty;
                        dr[61] = use_config_notify_stock_qty;
                        dr[62] = manage_stock;
                        dr[63] = use_config_manage_stock;
                        dr[64] = stock_status_changed_auto;
                        dr[65] = use_config_qty_increments;
                        dr[66] = qty_increments;
                        dr[67] = use_config_enable_qty_inc;
                        dr[68] = enable_qty_increments;
                        dr[69] = is_decimal_divided;
                        dr[70] = stock_status_changed_automatically;
                        dr[71] = use_config_enable_qty_increments;
                        dr[72] = product_name;
                        dr[73] = store_id;
                        dr[74] = product_type_id;
                        dr[75] = product_status_changed;
                        dr[76] = product_changed_websites;
                        dr[77] = mau_sac;

                        resultTable.Rows.Add(dr);
                    }

                    

                    btnGenerateCVSFile.Enabled = true;
                }


                dataGridView1.DataSource = resultTable;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnBrowseCVSFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserCVS.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtCVSFolder.Text = folderBrowserCVS.SelectedPath;
            }
        }

        private void btnGenerateCVSFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCVSFolder.Text == "")
                {
                    MessageBox.Show("Please select CVS folder");
                    return;
                }

                string outFileName = txtCVSFolder.Text + @"/import_Products.csv";

                if (File.Exists(outFileName))
                {
                    MessageBox.Show("File already exists");
                    return;
                }

                StringBuilder sb = new StringBuilder();

                var columnNames = resultTable.Columns.Cast<DataColumn>().Select(column => "\"" + column.ColumnName.Replace("\"", "\"\"") + "\"").ToArray();
                sb.AppendLine(string.Join(",", columnNames));

                foreach (DataRow row in resultTable.Rows)
                {
                    var fields = row.ItemArray.Select(field => "\"" + field.ToString().Replace("\"", "\"\"") + "\"").ToArray();
                    sb.AppendLine(string.Join(",", fields));
                }

                File.WriteAllText(outFileName, sb.ToString(), Encoding.UTF8);

                MessageBox.Show("Done");
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private bool checkImageExist(string imageName)
        {
            foreach (DataRow dr in resultTable.Rows)
            {
                if (dr["name"].ToString() == imageName.ToUpper())
                {
                    return true;
                }
            }
            return false;
        }

        private void frmImportProducts_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main2.frmIP = null;
        }
    }
}
