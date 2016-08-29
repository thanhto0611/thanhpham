using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class TacGiaDTO
    {
        
#region Attributes
        private int _MaTG;
        private string _TenTG;
#endregion

#region Properties
        public int MaTG        {
            get
            {
                return _MaTG;
            }
            set
            {
                _MaTG = value;
            }
        }

        public string TenTG
        {
            get
            {
                return _TenTG;
            }
            set
            {
                _TenTG = value;
            }
        }
#endregion

#region Constructor
        public TacGiaDTO()
        {
            _MaTG = 0;
            _TenTG = "";
        }
#endregion
    }
}
