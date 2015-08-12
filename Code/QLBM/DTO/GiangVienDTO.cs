using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class GiangVienDTO
    {
        #region Attributes
        private int _MaGiangVien;
        private string _TenGiangVien;
        private string _SoDienThoai;
        private string _DiaChi;
        private string _Email;
        #endregion

        #region Properties
        public int MaGiangVien
        {
            get
            {
                return _MaGiangVien;
            }
            set
            {
                _MaGiangVien = value;
            }
        }
        public string TenGiangVien
        {
            get
            {
                return _TenGiangVien;
            }
            set
            {
                _TenGiangVien = value;
            }
        }
        public string SoDienThoai
        {
            get
            {
                return _SoDienThoai;
            }
            set
            {
                _SoDienThoai = value;
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
        #endregion

        #region Constructor
        public GiangVienDTO()
        {
            _MaGiangVien = 0;
            _TenGiangVien = "";
            _SoDienThoai = "";
            _DiaChi = "";
            _Email = "";
        }
        #endregion
    }
}
