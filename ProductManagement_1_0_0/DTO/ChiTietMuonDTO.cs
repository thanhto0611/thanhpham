using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ChiTietMuonDTO
    {
#region Attributes
        private int _MaPhieuMuon;
        private int _MaSach;
        private DateTime _NgayTra;
#endregion

#region Properties
        public int MaPhieuMuon
        {
            get
            {
                return _MaPhieuMuon;
            }
            set
            {
                _MaPhieuMuon = value;
            }
        }

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
        public DateTime NgayTra
        {
            get
            {
                return _NgayTra;
            }
            set
            {
                _NgayTra = value;
            }
        }
#endregion

#region contructor
        public ChiTietMuonDTO()
        {
            _MaPhieuMuon = 0;
            _MaSach = 0;
            _NgayTra = new DateTime(1, 1, 1);
        }
#endregion
    }
}
