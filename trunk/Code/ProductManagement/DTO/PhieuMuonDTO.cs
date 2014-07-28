using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PhieuMuonDTO
    {
        
#region Attributes
        private int _MaPhieuMuon;
        private int _MaDocGia;
        private DateTime _NgayMuon;
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
        public DateTime NgayMuon
        {
            get
            {
                return _NgayMuon;
            }
            set
            {
                _NgayMuon = value;
            }
        }
#endregion

#region contructor
        public PhieuMuonDTO()
        {
            _MaPhieuMuon = 0;
            _MaDocGia = 0;
            _NgayMuon = new DateTime(1, 1, 1);
        }
#endregion
    }
}
