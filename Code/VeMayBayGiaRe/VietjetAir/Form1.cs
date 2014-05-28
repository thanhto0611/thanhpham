using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;

namespace VietjetAir
{
    public partial class Form1 : Form
    {
        int _step = 0;
        // 0: chưa chạy
        // 1: chọn ngày bay
        // 2: chọn giờ bay
        // 3: điền thông tin hành khách
        // 4: chọn chỗ ngồi và hành lý
        // 5: chọn hình thức thanh toán
        // 6: xác nhận thanh toán

        string strDiaChi = "790/100 Nguyen Kiem, F3, Go Vap";
        string strCity = "Ho Chi Minh";
        string strEmail = "thanh.pham611@gmail.com";
        string strPhone = "0932133282";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try
            {
                webBrowser1.Navigate(new Uri(txtUrl.Text));
                
            }
            catch (System.UriFormatException ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.AbsolutePath != (sender as WebBrowser).Url.AbsolutePath)
                return;
            txtTest.Text = "Load done";
        }

        private void timerChonNgayBay_Tick(object sender, EventArgs e)
        {
            timerChonNgayBay.Stop();
            timerCheckRefresh.Start();

            
        }

        private void main()
        {
            switch (_step)
            {
                case 1: // chọn ngày bay
                    string Id = TimVeRe();
                    if (Id == "")
                    {
                        //txtTest.Text = "";
                        webBrowser1.Refresh();
                        timer2.Start();
                    }
                    else
                    {
                        ChonNgayBay(Id);
                    }
                    break;
                case 2: // chọn giờ bay
                    if (ChonGioBay() == true)
                    {
                        _step = 3;

                        // Click button Tiếp Theo để điền thông tin khách hàng
                        HtmlElement body = webBrowser1.Document.GetElementById("contentwsb");
                        HtmlElementCollection divColec = body.GetElementsByTagName("div");
                        divColec[divColec.Count - 2].GetElementsByTagName("a")[0].InvokeMember("click");
                        //timer1.Start();
                        timerChonNgayBay.Start();
                    }
                    else
                    {
                        timer1.Start();
                    }
                    break;
                case 3:
                    DienThongTinHanhKhach();
                    break;
                case 4:
                    ChonChoNgoiVaHanhLy();
                    break;
                case 5:
                    ChonHinhThucThanhToan();
                    break;
                case 6:
                    XacNhanThanhToan();
                    break;
                default:
                    break;
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtThangBay.Text == "")
            {
                MessageBox.Show("Phải nhập tháng bay");
                return;
            }
            if (txtDiDong.Text == "")
            {
                MessageBox.Show("Phải nhập số điện thoại");
                return;
            }
            if (txtNgayBay.Text == "")
            {
                MessageBox.Show("Phải nhập ngày bay");
                return;
            }
            if (txtGiaVe.Text == "")
            {
                MessageBox.Show("Phải nhập giá vé");
                return;
            }
            if (txtTuGio.Text == "" || txtDenGio.Text == "")
            {
                MessageBox.Show("Phải nhập giờ bay");
                return;
            }
            if (cbBag.Text == "")
            {
                MessageBox.Show("Phải chọn hành lý");
                return;
            }
            dtgvThongTinHanhKhach.AllowUserToAddRows = false;

            /* Code dùng để refresh lại từ trang chủ
            // Check vào lựa chọn 1 chiều
            HtmlElement motChieu = webBrowser1.Document.GetElementById("ctl00_UcRightV31_RbOneWay");
            motChieu.InvokeMember("click");

            // Check vào tìm vé rẻ nhất
            HtmlElement timVeReNhat = webBrowser1.Document.GetElementById("ctl00_UcRightV31_ChkInfare");
            timVeReNhat.InvokeMember("click");

            // Chọn điểm khởi hành
            HtmlElement buttonDiemKhoiHanh = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbOrigin_Button");
            buttonDiemKhoiHanh.InvokeMember("click");

            //HtmlElement listDiemKhoiHanh = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbOrigin_OptionList");
            //HtmlElementCollection colecLiTagKhoiHanh = listDiemKhoiHanh.GetElementsByTagName("li");
            //foreach (HtmlElement liTag in colecLiTagKhoiHanh)
            //{
            //    if (liTag.InnerText == cbFrom.SelectedItem.ToString())
            //    {
            //        liTag.InvokeMember("click");
            //        break;
            //    }
            //}
            
            // Chọn điểm đến
            //HtmlElement diemDen = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbDepart_TextBox");
            //diemDen.SetAttribute("value", cbTo.SelectedItem.ToString());

            //HtmlElement listDiemDen = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbDepart_OptionList");
            //while (listDiemDen == null)
            //{
            //    listDiemDen = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbDepart_OptionList");
            //}
            //HtmlElementCollection colecLiTagDen = listDiemDen.GetElementsByTagName("li");
            //foreach (HtmlElement liTag in colecLiTagKhoiHanh)
            //{
            //    if (liTag.InnerText == cbTo.SelectedItem.ToString())
            //    {
            //        liTag.InvokeMember("click");
            //        break;
            //    }
            //}

            // Chọn ngày bay
            HtmlElement ngayBay = webBrowser1.Document.GetElementById("ctl00_UcRightV31_TxtDepartDate");
            string ngaybay = "";
            if (txtThangBay.Text.Length == 1)
            {
                if (Int32.Parse(txtThangBay.Text) == 2)
                {
                    ngaybay = "28/0" + txtThangBay.Text + "/2014";
                }
                else
                {
                    ngaybay = "30/0" + txtThangBay.Text + "/2014";
                }
            }
            else
            {
                ngaybay = "30/" + txtThangBay.Text + "/2014";
            }
            ngayBay.SetAttribute("value", ngaybay);

            // Tính số lượng hành khách
            int slgHanhKhach = dtgvThongTinHanhKhach.RowCount;

            // Kiểm tra có em bé đi kèm
            bool kemEmBe = false;
            //foreach (DataGridViewRow dr in dtgvThongTinHanhKhach.Rows)
            //{
            //    DataGridViewCheckBoxCell checking = dr.Cells["KemEmBe"] as DataGridViewCheckBoxCell;
            //    if ((bool)checking.Value == true)
            //    {
            //        kemEmBe = true;
            //        break;
            //    }
            //}

            // Chọn số lượng hành khách
            HtmlElement sLgHK = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbAdults_TextBox");
            sLgHK.SetAttribute("value", slgHanhKhach.ToString());

            // Chọn số lượng em bé đi kèm (nếu có)
            if (kemEmBe == true)
            {
                HtmlElement sLgEB = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbInfants_TextBox");
                sLgEB.SetAttribute("value", slgHanhKhach.ToString());
            }

            // Click tìm chuyến bay
            HtmlElement btnTimChuyenBay = webBrowser1.Document.GetElementById("ctl00_UcRightV31_BtSearch");
            //btnTimChuyenBay.InvokeMember("click");

            //timer5.Start();
            */
            _step = 1;
            timerChonNgayBay.Start();
        }

        // Tìm ngày có vé rẻ trong tháng
        private string TimVeRe()
        {
            string thangBay = txtThangBay.Text;
            if (thangBay.Length == 1)
            {
                thangBay = "0" + thangBay;
            }

            string[] ngayBay = txtNgayBay.Text.Split(',');

            //foreach (string item in lstNgaybay.Items)
            for (int i = 0; i < ngayBay.Length; i++ )
            {
                string item = ngayBay[i];
                string Id = "ctrValueViewerDep2014" + thangBay;
                if (item.Length == 1)
                {
                    Id = Id + "0" + item;
                }
                else
                {
                    Id += item;
                }
                HtmlElement chieuDi = webBrowser1.Document.GetElementById(Id);
                if (chieuDi != null)
                {
                    HtmlElementCollection colec = chieuDi.GetElementsByTagName("p");

                    string cost = colec[0].InnerText.Replace(",", "");

                    //long giaVe = Int32.Parse(txtGiaVe.Text);
                    //for (long j = 50000; j <= giaVe; j+= 50000 )
                    //{
                    //    if (Int32.Parse(cost) <= j)
                    //    {
                    //        return Id;
                    //    }
                    //}
                    
                    if (Int32.Parse(cost) <= Int32.Parse(txtGiaVe.Text))
                    {
                        return Id;
                    }
                }
            }
            return "";
        }

        private void timerCheckRefresh_Tick(object sender, EventArgs e)
        {
            if (webBrowser1.ReadyState != WebBrowserReadyState.Complete)
            {
                return;
            }
            else
            {
                timerCheckRefresh.Stop();
                main();
                //timerChonNgayBay.Start();
                txtTest.Text = webBrowser1.Url.AbsoluteUri.ToString();
            }
        }

        // Chọn ngày bay trong tháng
        private void ChonNgayBay(string Id)
        {
            _step = 2;
            HtmlElement veRe = webBrowser1.Document.GetElementById(Id);
            veRe.InvokeMember("click");
            HtmlElement submitButton = webBrowser1.Document.GetElementById("tblBackCont");
            HtmlElementCollection colec = submitButton.GetElementsByTagName("a");
            colec[1].InvokeMember("click");
            //timer1.Start();
            timerChonNgayBay.Start();
        }

        // Điền thông tin khách hàng
        private void DienThongTinHanhKhach()
        {
            try
            {
                string TxtPax = "txtPax";
                string Gender = "_Gender";
                string strGenderId = "";

                string LName = "_LName";
                string strLName = "";

                string FName = "_FName";
                string strFName = "";

                foreach (DataGridViewRow row in this.dtgvThongTinHanhKhach.Rows)
                {
                    // chọn giới tính hành khách
                    strGenderId = TxtPax + (row.Index + 1).ToString() + Gender;
                    HtmlElement eleGenderId = webBrowser1.Document.GetElementById(strGenderId);
                    if (eleGenderId == null)
                    {
                        timer1.Start();
                        return;
                    }
                    eleGenderId.Focus();
                    HtmlElementCollection genderOptions = eleGenderId.GetElementsByTagName("option");
                    foreach (HtmlElement genderOption in genderOptions)
                    {
                        if (genderOption.InnerText == row.Cells["GioiTinh"].Value.ToString())
                        {
                            genderOption.SetAttribute("selected", "true");
                            break;
                        }
                    }
                    eleGenderId.RemoveFocus();

                    // điền Họ của hành khách
                    strLName = TxtPax + (row.Index + 1).ToString() + LName;
                    HtmlElement eleLName = webBrowser1.Document.GetElementById(strLName);
                    eleLName.SetAttribute("value", row.Cells["Ho"].Value.ToString());

                    // điền tên đệm và tên của hành khách
                    strFName = TxtPax + (row.Index + 1).ToString() + FName;
                    HtmlElement eleFName = webBrowser1.Document.GetElementById(strFName);
                    eleFName.SetAttribute("value", row.Cells["TenDemTen"].Value.ToString());
                }

                // điền thông tin liên hệ
                // Địa chỉ
                HtmlElement eleDiaChi = webBrowser1.Document.GetElementById("txtPax1_Addr1");
                eleDiaChi.SetAttribute("value", strDiaChi);

                // Thành phố
                HtmlElement eleCity = webBrowser1.Document.GetElementById("txtPax1_City");
                eleCity.SetAttribute("value", strCity);

                // Quốc gia
                HtmlElement eleQuocGia = webBrowser1.Document.GetElementById("txtPax1_Ctry");
                eleQuocGia.Focus();
                HtmlElementCollection ctryOptions = eleQuocGia.GetElementsByTagName("option");
                ctryOptions[232].SetAttribute("selected", "true");
                eleQuocGia.InvokeMember("onchange");
                eleQuocGia.RemoveFocus();

                // Tiểu bang
                HtmlElement eleProv = webBrowser1.Document.GetElementById("txtPax1_Prov");
                eleProv.Focus();
                HtmlElementCollection provOptions = eleProv.GetElementsByTagName("option");
                provOptions[30].SetAttribute("selected", "true");
                eleProv.InvokeMember("onchange");
                eleProv.RemoveFocus();

                // Email
                HtmlElement eleEmail = webBrowser1.Document.GetElementById("txtPax1_EMail");
                eleEmail.SetAttribute("value", strEmail);

                // Di động
                HtmlElement elePhone = webBrowser1.Document.GetElementById("txtPax1_Phone2");
                elePhone.SetAttribute("value", txtDiDong.Text);

                // Click button Tiếp Theo
                HtmlElement body = webBrowser1.Document.GetElementById("contentwsb");
                HtmlElementCollection divColec = body.GetElementsByTagName("div");
                divColec[divColec.Count - 2].GetElementsByTagName("a")[0].InvokeMember("click");

                _step = 4;
                timerChonNgayBay.Start();
            }
            catch (System.Exception ex)
            {
                timer1.Stop();
                timerChonNgayBay.Stop();
                timerCheckRefresh.Stop();
                MessageBox.Show(ex.Message);
            }
        }

        private void ChonChoNgoiVaHanhLy()
        {
            // Không chọn chỗ ngồi
            HtmlElement eleSeat = webBrowser1.Document.GetElementById("editBtn1");
            if (eleSeat == null)
            {
                timer1.Start();
                return;
            }
            HtmlElementCollection aColecs = eleSeat.GetElementsByTagName("a");
            aColecs[1].InvokeMember("click");

            // Chọn hành lý kí gửi
            for (int i = 1; i <= dtgvThongTinHanhKhach.RowCount; i++ )
            {
                string paxId = "lstPaxItem:-" + i.ToString() + ":1:" + (i * 4).ToString();
                HtmlElement eleBag = webBrowser1.Document.GetElementById(paxId);
                eleBag.Focus();
                HtmlElementCollection bagOptions = eleBag.GetElementsByTagName("option");
                if (i == 1)
                {
                    foreach (HtmlElement bagOption in bagOptions)
                    {
                        if (bagOption.InnerText == cbBag.Text)
                        {
                            bagOption.SetAttribute("selected", "true");
                            break;
                        }
                    }
                }
                else
                {
                    foreach (HtmlElement bagOption in bagOptions)
                    {
                        if (bagOption.InnerText == "Không, Cảm ơn")
                        {
                            bagOption.SetAttribute("selected", "true");
                            break;
                        }
                    }
                }
                eleBag.InvokeMember("onchange");
                eleBag.RemoveFocus();
            }
            

            // Bấm button tiếp theo
            HtmlElement eleShop = webBrowser1.Document.GetElementById("shop");
            HtmlElementCollection tableColecs = eleShop.GetElementsByTagName("table");
            HtmlElementCollection aColecs_2 = tableColecs[tableColecs.Count - 1].GetElementsByTagName("a");
            aColecs_2[1].InvokeMember("click");

            _step = 5;
            timerChonNgayBay.Start();
        }

        private void ChonHinhThucThanhToan()
        {
            string strCardHolder = "Pham Nguyen Hong Thanh";
            // Chọn hình thức thanh toán bằng Visa
            HtmlElement elePayType = webBrowser1.Document.GetElementById("tblPayTypesSlv2");
            if (elePayType == null)
            {
                timer1.Start();
                return;
            }
            HtmlElementCollection inputColecs = elePayType.GetElementsByTagName("input");
            foreach (HtmlElement input in inputColecs)
            {
                if (input.GetAttribute("value").Contains("VI"))
                {
                    input.InvokeMember("click");
                    break;
                }
            }

            // Điền số thẻ
            HtmlElement eleCarNo = webBrowser1.Document.GetElementById("txtCardNo");
            //eleCarNo.SetAttribute("value", "4221092000650608");
            eleCarNo.SetAttribute("value", "4220758681272000");

            // Điền ngày hết hạn
            HtmlElement eleExpDate = webBrowser1.Document.GetElementById("dlstExpiry");
            eleExpDate.Focus();
            HtmlElementCollection dateOptions = eleExpDate.GetElementsByTagName("option");
            foreach (HtmlElement dateOption in dateOptions)
            {
                if (dateOption.InnerText == "07/2016")
                {
                    dateOption.SetAttribute("selected", "true");
                    break;
                }
            }
            eleExpDate.InvokeMember("onchange");
            eleExpDate.RemoveFocus();

            // Điền số CVC
            HtmlElement eleCVC = webBrowser1.Document.GetElementById("txtCVC");
            eleCVC.SetAttribute("value", "681");

            // Điền tên chủ thẻ
            HtmlElement eleCardHolder = webBrowser1.Document.GetElementById("txtCardholder");
            eleCardHolder.SetAttribute("value", strCardHolder);

            // Điền địa chỉ
            HtmlElement eleDiaChi = webBrowser1.Document.GetElementById("txtAddr1");
            eleDiaChi.SetAttribute("value", strDiaChi);

            // Điền thành phố
            HtmlElement eleCity = webBrowser1.Document.GetElementById("txtCity");
            eleCity.SetAttribute("value", strCity);

            // Quốc gia
            HtmlElement eleQuocGia = webBrowser1.Document.GetElementById("lstCtry");
            eleQuocGia.Focus();
            HtmlElementCollection ctryOptions = eleQuocGia.GetElementsByTagName("option");
            ctryOptions[232].SetAttribute("selected", "true");
            eleQuocGia.InvokeMember("onchange");
            eleQuocGia.RemoveFocus();

            // Tiểu bang
            HtmlElement eleProv = webBrowser1.Document.GetElementById("lstProv");
            eleProv.Focus();
            HtmlElementCollection provOptions = eleProv.GetElementsByTagName("option");
            provOptions[30].SetAttribute("selected", "true");
            eleProv.InvokeMember("onchange");
            eleProv.RemoveFocus();

            // Điện thoại
            HtmlElement elePhone = webBrowser1.Document.GetElementById("txtPhone");
            elePhone.SetAttribute("value", strPhone);

            // Click Tiếp tục
            HtmlElement elePaymentSection = webBrowser1.Document.GetElementById("paymentSection");
            HtmlElementCollection tableColecs = elePaymentSection.GetElementsByTagName("table");
            HtmlElementCollection aColecs = tableColecs[tableColecs.Count - 1].GetElementsByTagName("a");
            aColecs[0].InvokeMember("click");

            _step = 6;
            timerChonNgayBay.Start();
        }

        private void XacNhanThanhToan()
        {
            // Check vào ô đồng ý các điều khoản
            HtmlElement eleIAgree = webBrowser1.Document.GetElementById("chkIAgree");
            if (eleIAgree == null)
            {
                timer1.Start();
                return;
            }
            eleIAgree.InvokeMember("click");

            // Click nút Tiếp tục
            HtmlElement eleBackCont = webBrowser1.Document.GetElementById("tblBackCont");
            eleBackCont.GetElementsByTagName("a")[1].InvokeMember("click");
        }

        // Chọn giờ bay trong ngày
        private bool ChonGioBay()
        {
            string tempRowId = "gridTravelOptDep";
            string maCb = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string gioBayBatDau = txtTuGio.Text.Replace(":","");
            string gioBayKetThuc = txtDenGio.Text.Replace(":", "");
            //HtmlElement body = webBrowser1.Document.GetElementById("contentwsb");
            //if (body == null)
            //{
            //    timer1.Start();
            //    return false;
            //}
            for (int i = 1; i <= 20; i++ )
            {
                string rowId = tempRowId + i.ToString();
                HtmlElement row = webBrowser1.Document.GetElementById(rowId);
                if (row != null)
                {
                    HtmlElementCollection table = row.GetElementsByTagName("table");
                    HtmlElement table_1 = table[1];
                    for (int j = 0; j < maCb.Length; j++)
                    {
                        string colGiaVeId = tempRowId + "-" + i.ToString() + "-" + maCb.Substring(j, 1) + "_Promo-O";
                        //string colGiaVeId = tempRowId + "-" + i.ToString() + "-" + maCb.Substring(j, 1) + "_Eco-O";
                        HtmlElementCollection tdColec = table[1].GetElementsByTagName("td");
                        HtmlElementCollection tdColecGioBay = table[0].GetElementsByTagName("td");
                        foreach (HtmlElement td in tdColec)
                        {
                            if (td.GetAttribute("id").ToString() == colGiaVeId)
                            {
                                HtmlElementCollection input = td.GetElementsByTagName("input");
                                
                                if (Int32.Parse(input[0].GetAttribute("value").ToString().Replace(",", "")) <= Int32.Parse(txtGiaVe.Text))
                                {
                                    string gioBay = input[3].GetAttribute("value").ToString().Replace(":","");
                                    if (Int32.Parse(gioBay) >= Int32.Parse(gioBayBatDau) && Int32.Parse(gioBay) <= Int32.Parse(gioBayKetThuc))
                                    {
                                        input[6].InvokeMember("click");
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //HtmlElement listDiemKhoiHanh = webBrowser1.Document.GetElementById("ctl00_UcRightV31_CbbOrigin_OptionList");
            //HtmlElementCollection colecLiTagKhoiHanh = listDiemKhoiHanh.GetElementsByTagName("li");
            //foreach (HtmlElement liTag in colecLiTagKhoiHanh)
            //{
            //    if (liTag.InnerText == cbFrom.SelectedItem.ToString())
            //    {
            //        liTag.SetAttribute("selected", "selected");
            //        liTag.InvokeMember("click");
            //        listDiemKhoiHanh.InvokeMember("click");
            //        break;
            //    }
            //}
            StopAllTimer();
        }

        private void dtgvThongTinHanhKhach_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var grid = sender as DataGridView;
            var rowIdx = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                // right alignment might actually make more sense for numbers
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dtgvThongTinHanhKhach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtgvThongTinHanhKhach.Columns["GioiTinh"].Index && e.RowIndex >= 0)
            {
                dtgvThongTinHanhKhach.BeginEdit(true);
                ComboBox comboBox = (ComboBox)dtgvThongTinHanhKhach.EditingControl;
                if (comboBox != null)
                {
                    comboBox.DroppedDown = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timerChonNgayBay.Start();
        }

        private void StopAllTimer()
        {
            timerChonNgayBay.Stop();
            timerCheckRefresh.Stop();
            timer1.Stop();
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
            timerChonNgayBay.Start();
        }
    }
}
