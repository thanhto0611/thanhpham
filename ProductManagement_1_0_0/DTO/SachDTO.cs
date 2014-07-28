using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class SachDTO
    {
#region Attributes
        private int _MaSach;
        private string _TenSach;
        private int _MaTG;
        private int _MaNXB;
        private int _MaNgonNgu;
        private int _MaTheLoai;
        private DateTime _NgayNhap;
        private int _SoTrang;
        private int _TrangThai;
#endregion

#region Properties
        public int MaSach
        {
            get
            {
                return _MaSach;
            }
            set
            {
                _MaSach = value;
            }
        }

        public string TenSach
        {
            get
            {
                return _TenSach;
            }
            set
            {
                _TenSach = value;
            }
        }
         public int MaTacGia
        {
            get
            {
                return _MaTG;
            }
            set
            {
                _MaTG = value;
            }
        }
        public int MaNXB
        {
            get
            {
                return _MaNXB;
            }
            set
            {
                _MaNXB=value;
            }
        }
        public int MaNgonNgu
        {
            get
            {
                return _MaNgonNgu;
            }
            set
            {
                _MaNgonNgu=value;
            }
        }
        public int MaTheLoai
        {
            get
            {
                return _MaTheLoai;
            }
            set
            {
                _MaTheLoai=value;
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
        public int SoTrang
        {
            get
            {
                return _SoTrang;
            }
            set
            {
                _SoTrang=value;
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
                _TrangThai=value;
            }
        }
#endregion

#region Constructor
        public SachDTO()
        {
            _MaSach = 0;
            _TenSach = "";
            _MaTG = 0;
            _MaNXB = 0;
            _MaNgonNgu = 0;
            _MaTheLoai = 0;
            _NgayNhap = new DateTime(1,1,1);
            _SoTrang = 0;
            _TrangThai = 0;
        }
#endregion
    }
}
