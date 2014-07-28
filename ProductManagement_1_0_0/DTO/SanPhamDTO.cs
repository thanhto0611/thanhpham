using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SanPhamDTO
    {
        #region Attributes
        private string _MaSanPham;
        private string _HinhAnh;
        private int _TrongLuong;
        private string _MauSac;
        private int _SoLuong;
        private int _TrangThai;
        private int _MaDanhMuc;
        private long _GiaGoc;
        private long _GiaSi;
        private long _GiaLe;
        private long _GiaBan;
        private long _LoiNhuan;
        private DateTime _NgayNhap;
        private DateTime _NgayCapNhat;
        private string _NguoiNhap;
        private string _NguoiCapNhat;
        #endregion

        #region Properties
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
        public string HinhAnh
        {
            get
            {
                return _HinhAnh;
            }
            set
            {
                _HinhAnh = value;
            }
        }
        public int TrongLuong
        {
            get
            {
                return _TrongLuong;
            }
            set
            {
                _TrongLuong = value;
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
        public int MaDanhMuc
        {
            get
            {
                return _MaDanhMuc;
            }
            set
            {
                _MaDanhMuc = value;
            }
        }
        public long GiaGoc
        {
            get
            {
                return _GiaGoc;
            }
            set
            {
                _GiaGoc = value;
            }
        }
        public long GiaSi
        {
            get
            {
                return _GiaSi;
            }
            set
            {
                _GiaSi = value;
            }
        }
        public long GiaLe
        {
            get
            {
                return _GiaLe;
            }
            set
            {
                _GiaLe = value;
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
        public long LoiNhuan
        {
            get
            {
                return _LoiNhuan;
            }
            set
            {
                _LoiNhuan = value;
            }
        }
        public DateTime NgayNhap
        {
            get
            {
                return _NgayNhap;
            }
            set
            {
                _NgayNhap = value;
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
        #endregion

        #region Constructor
        public SanPhamDTO()
        {
            _MaSanPham = "";
            _HinhAnh = "";
            _TrongLuong = 0;
            _MauSac = "";
            _SoLuong = 0;
            _TrangThai = 0;
            _MaDanhMuc = -1;
            _GiaGoc = 0;
            _GiaSi = 0;
            _GiaLe = 0;
            _GiaBan = 0;
            _LoiNhuan = 0;
            _NgayNhap = System.DateTime.Now;
            _NgayCapNhat = System.DateTime.Now;
            _NguoiNhap = "";
            _NguoiCapNhat = "";
        }
        #endregion
    }
}
