using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class KhachHangDTO
    {
        #region Attributes
        private int _MaKhachHang;
        private string _HoTen;
        private string _DiaChi;
        private string _DienThoai;
        private string _Email;
        private string _Facebook;
        private string _TKNganHang;
        private DateTime _NgayThem;
        private string _NguoiThem;
        private DateTime _NgayCapNhat;
        private string _NguoiCapNhat;
        #endregion

        #region Properties
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

        public string HoTen
        {
            get
            {
                return _HoTen;
            }
            set
            {
                _HoTen = value;
            }
        }

        public string DiaChi
        {
            get
            {
                return _DiaChi;
            }
            set
            {
                _DiaChi = value;
            }
        }

        public string DienThoai
        {
            get
            {
                return _DienThoai;
            }
            set
            {
                _DienThoai = value;
            }
        }

        public string Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }

        public string Facebook
        {
            get
            {
                return _Facebook;
            }
            set
            {
                _Facebook = value;
            }
        }

        public string TKNganHang
        {
            get
            {
                return _TKNganHang;
            }
            set
            {
                _TKNganHang = value;
            }
        }

        public DateTime NgayThem
        {
            get
            {
                return _NgayThem;
            }
            set
            {
                _NgayThem = value;
            }
        }

        public string NguoiThem
        {
            get
            {
                return _NguoiThem;
            }
            set
            {
                _NguoiThem = value;
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
        #endregion

        #region constructor
        public KhachHangDTO()
        {
            _MaKhachHang = 0;
            _HoTen = "";
            _DiaChi = "";
            _DienThoai = "";
            _Email = "";
            _Facebook = "";
            _TKNganHang = "";
            _NgayThem = System.DateTime.Now;
            _NguoiThem = "";
            _NgayCapNhat = System.DateTime.Now;
            _NguoiCapNhat = "";
        }
        #endregion
    }
}
