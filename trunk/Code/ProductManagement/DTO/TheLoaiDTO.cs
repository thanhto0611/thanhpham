using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TheLoaiDTO
    {
        
#region Attributes
        private int _MaLoai;
        private string _TenTheLoai;
#endregion

#region Properties
        public int MaLoai
        {
            get
            {
                return _MaLoai;
            }
            set
            {
                _MaLoai = value;
            }
        }

        public string TenTheLoai
        {
            get
            {
                return _TenTheLoai;
            }
            set
            {
                _TenTheLoai = value;
            }
        }
#endregion

#region Constructor
        public TheLoaiDTO()
        {
            _MaLoai = 0;
            _TenTheLoai = "";
        }
#endregion
    }
}
