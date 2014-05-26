using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DanhMucDTO
    {
#region Attributes
        private int _MaDanhMuc;
        private string _TenDanhMuc;
#endregion

#region Properties
        public int MaDanhMuc        {
            get
            {
                return _MaDanhMuc;
            }
            set
            {
                _MaDanhMuc = value;
            }
        }

        public string TenDanhMuc
        {
            get
            {
                return _TenDanhMuc;
            }
            set
            {
                _TenDanhMuc = value;
            }
        }
#endregion

#region Constructor
        public DanhMucDTO()
        {
            _MaDanhMuc = 0;
            _TenDanhMuc = "";
        }
#endregion
    }
}
