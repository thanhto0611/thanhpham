using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ChiTietDonHangDTO
    {
#region Attributes
        private int _MaChiTietDonHang;
        private int _MaDonHang;
        private string _MaSanPham;
        private int _SoLuong;
        private string _MauSac;
        private long _GiaBan;
#endregion

#region Properties
        public int MaChiTietDonHang
        {
            get
            {
                return _MaChiTietDonHang;
            }
            set
            {
                _MaChiTietDonHang = value;
            }
        }

        public int MaDonHang
        {
            get
            {
                return _MaDonHang;
            }
            set
            {
                _MaDonHang = value;
            }
        }

        public string MaSanPham
        {
            get
            {
                return _MaSanPham;
            }
            set
            {
                _MaSanPham = value;
            }
        }
        public int SoLuong
        {
            get
            {
                return _SoLuong;
            }
            set
            {
                _SoLuong = value;
            }
        }

        public string MauSac
        {
            get
            {
                return _MauSac;
            }
            set
            {
                _MauSac = value;
            }
        }

        public long GiaBan
        {
            get
            {
                return _GiaBan;
            }
            set
            {
                _GiaBan = value;
            }
        }
#endregion

#region contructor
        public ChiTietDonHangDTO()
        {
            _MaChiTietDonHang = 0;
            _MaDonHang = 0;
            _MaSanPham = "";
            _SoLuong = 0;
            _MauSac = "";
            _GiaBan = 0;
        }
#endregion
    }
}
