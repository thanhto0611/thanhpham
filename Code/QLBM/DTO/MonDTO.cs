using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class MonDTO
    {
        #region Attributes
        private int _MaMon;
        private string _TenMon;
        #endregion

        #region Properties
        public int MaMon
        {
            get
            {
                return _MaMon;
            }
            set
            {
                _MaMon = value;
            }
        }
        public string TenMon
        {
            get
            {
                return _TenMon;
            }
            set
            {
                _TenMon = value;
            }
        }
        #endregion

        #region Constructor
        public MonDTO()
        {
            _MaMon = 0;
            _TenMon = "";
        }
        #endregion
    }
}
