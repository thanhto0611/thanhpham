using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TrangThaiDonHangDTO
    {
#region Attributes
        private int _MaTrangThai;
        private string _TrangThai;
#endregion

#region Properties
        public int MaTrangThai        {
            get
            {
                return _MaTrangThai;
            }
            set
            {
                _MaTrangThai = value;
            }
        }

        public string TrangThai
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
#endregion

#region Constructor
        public TrangThaiDonHangDTO()
        {
            _MaTrangThai = 0;
            _TrangThai = "";
        }
#endregion
    }
}
