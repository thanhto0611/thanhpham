using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class LopDTO
    {
        #region Attributes
        private int _MaLop;
        private string _TenLop;
        private long _SoLuongSinhVien;
        private long _SoLuongTrongNganSach;
        private long _SoLuongNgoaiNganSach;
        private int _MaNamHoc;
        #endregion

        #region Properties
        public int MaLop
        {
            get
            {
                return _MaLop;
            }
            set
            {
                _MaLop = value;
            }
        }
        public string TenLop
        {
            get
            {
                return _TenLop;
            }
            set
            {
                _TenLop = value;
            }
        }
        public long SoLuongSinhVien
        {
            get
            {
                return _SoLuongSinhVien;
            }
            set
            {
                _SoLuongSinhVien = value;
            }
        }
        public long SoLuongTrongNganSach
        {
            get
            {
                return _SoLuongTrongNganSach;
            }
            set
            {
                _SoLuongTrongNganSach = value;
            }
        }
        public long SoLuongNgoaiNganSach
        {
            get
            {
                return _SoLuongNgoaiNganSach;
            }
            set
            {
                _SoLuongNgoaiNganSach = value;
            }
        }
        public int MaNamHoc
        {
            get
            {
                return _MaNamHoc;
            }
            set
            {
                _MaNamHoc = value;
            }
        }
        #endregion

        #region Constructor
        public LopDTO()
        {
            _MaLop = 0;
            _TenLop = "";
            _SoLuongSinhVien = 0;
            _SoLuongTrongNganSach = 0;
            _SoLuongNgoaiNganSach = 0;
            _MaNamHoc = 0;
        }
        #endregion
    }
}
