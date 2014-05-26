using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DocGiaDTO
    {
        #region Attributes
        private int _MaDG;
        private string _HoTen;
        private string _DiaChi;
        private string _DienThoai;
        #endregion

        #region Properties
        public int MaDocGia
        {
            get
            {
                return _MaDG;
            }
            set
            {
                _MaDG = value;
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
        #endregion

        #region constructor
        public DocGiaDTO()
        {
            _MaDG = 0;
            _HoTen = "";
            _DiaChi = "";
            _DienThoai = "";
        }
        #endregion
    }
}
