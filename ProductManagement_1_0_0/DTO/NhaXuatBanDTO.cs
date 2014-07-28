using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class NhaXuatBanDTO
    {
#region Attributes
        private int _MaNXB;
        private string _TenNXB;
#endregion

#region Properties
        public int MaNXB
        {
            get
            {
                return _MaNXB;
            }
            set
            {
                _MaNXB = value;
            }
        }

        public string TenNXB
        {
            get
            {
                return _TenNXB;
            }
            set
            {
                _TenNXB = value;
            }
        }
#endregion

#region Constructor
        public NhaXuatBanDTO()
        {
            _MaNXB = 0;
            _TenNXB = "";
        }
#endregion
    }
}
