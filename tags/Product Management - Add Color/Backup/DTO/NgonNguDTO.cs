using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class NgonNguDTO
    {
#region Attributes
        private int _MaNgonNgu;
        private string _TenNgonNgu;
#endregion

#region Properties
        public int MaNgonNgu
        {
            get
            {
                return _MaNgonNgu;
            }
            set
            {
                _MaNgonNgu = value;
            }
        }
        public string TenNgonNgu
        {
            get
            {
                return _TenNgonNgu;
            }
            set
            {
                _TenNgonNgu = value;
            }
        }
#endregion

#region constructor
        public NgonNguDTO()
        {
            _MaNgonNgu = 0;
            _TenNgonNgu="";
        }

#endregion
    }
}
