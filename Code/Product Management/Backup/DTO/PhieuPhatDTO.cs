using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuPhatDTO
    {
        
#region Attributes
        private int _MaPhieuPhat;
        private int _MaDocGia;
        private string _TenPhieu;
        private long _SoTien;
#endregion

#region Properties
        public int MaPhieuPhat
        {
            get
            {
                return _MaPhieuPhat;
            }
            set
            {
                _MaPhieuPhat = value;
            }
        }

        public int MaDocGia
        {
            get
            {
                return _MaDocGia;
            }
            set
            {
                _MaDocGia = value;
            }
        }

        public string TenPhieu
        {
            get
            {
                return _TenPhieu;
            }
            set
            {
                _TenPhieu = value;
            }
        }

        public long SoTien
        {
            get
            {
                return _SoTien;
            }
            set
            {
                _SoTien = value;
            }
        }
#endregion

#region constructor
        public PhieuPhatDTO()
        {
            _MaPhieuPhat = 0;
            _MaDocGia = 0;
            _TenPhieu = "";
            _SoTien = 0;
        }
#endregion
    }
}
