using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DonHangDTO
    {
#region Attributes
        private int _MaDonHang;
        private int _MaKhachHang;
        private DateTime _NgayDatHang;
        private int _TrangThai;
        private string _NguoiNhap;
        private DateTime _NgayCapNhat;
        private string _NguoiCapNhat;
        private long _PhiVanChuyen;
        private long _TongTien;
        private int _SoLuongSanPham;
        private int _HinhThucMua;
#endregion

#region Properties
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

        public int MaKhachHang
        {
            get
            {
                return _MaKhachHang;
            }
            set
            {
                _MaKhachHang = value;
            }
        }

        public int TrangThai
        {
            get
            {
                return _TrangThai;
            }
            set
            {
                _TrangThai = value;
            }
        }
        public DateTime NgayDatHang
        {
            get
            {
                return _NgayDatHang;
            }
            set
            {
                _NgayDatHang = value;
            }
        }

        public string NguoiNhap
        {
            get
            {
                return _NguoiNhap;
            }
            set
            {
                _NguoiNhap = value;
            }
        }

        public DateTime NgayCapNhat
        {
            get
            {
                return _NgayCapNhat;
            }
            set
            {
                _NgayCapNhat = value;
            }
        }

        public string NguoiCapNhat
        {
            get
            {
                return _NguoiCapNhat;
            }
            set
            {
                _NguoiCapNhat = value;
            }
        }

        public long PhiVanChuyen
        {
            get
            {
                return _PhiVanChuyen;
            }
            set
            {
                _PhiVanChuyen = value;
            }
        }

        public long TongTien
        {
            get
            {
                return _TongTien;
            }
            set
            {
                _TongTien = value;
            }
        }

        public int SoLuongSanPham
        {
            get
            {
                return _SoLuongSanPham;
            }
            set
            {
                _SoLuongSanPham = value;
            }
        }
        public int HinhThucMua
        {
            get
            {
                return _HinhThucMua;
            }
            set
            {
                _HinhThucMua = value;
            }
        }
#endregion

#region contructor
        public DonHangDTO()
        {
            _MaDonHang = 0;
            _MaKhachHang = 0;
            _NgayDatHang = System.DateTime.Now;
            _TrangThai = 0;
            _NguoiNhap = "";
            _NgayCapNhat = System.DateTime.Now;
            _NguoiCapNhat = "";
            _PhiVanChuyen = 0;
            _TongTien = 0;
            _SoLuongSanPham = 0;
            _HinhThucMua = -1;
        }
#endregion

    }
}
