using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class NhanVienDTO
    {
        #region Attributes
        private string _Username;
        private string _Password;
        private string _HoTen;
        private string _DiaChi;
        private string _DienThoai;
        private string _Email;
        private int _Loai;
        #endregion

        #region Properties
        public string Username
        {
            get
            {
                return _Username;
            }
            set
            {
                _Username = value;
            }
        }

        public string Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
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

        public int Loai
        {
            get
            {
                return _Loai;
            }
            set
            {
                _Loai = value;
            }
        }
        #endregion

        #region constructor
        public NhanVienDTO()
        {
            _Username = "";
            _Password="";
            _HoTen = "";
            _DiaChi = "";
            _DienThoai = "";
            _Email = "";
            _Loai = 1;
        }
        #endregion
    }
}
