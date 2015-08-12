using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class LopMonDTO
    {
        #region Attributes
        private int _MaLopMon;
        private int _MaLop;
        private int _MaMon;
        #endregion

        #region Properties
        public int MaLopMon
        {
            get
            {
                return _MaLopMon;
            }
            set
            {
                _MaLopMon = value;
            }
        }
        public int MaLop
        {
            get
            {
                return _MaLop;
            }
            set
            {
                _MaLop = value;
            }
        }
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
        #endregion

        #region Constructor
        public LopMonDTO()
        {
            _MaLopMon = 0;
            _MaLop = 0;
            _MaMon = 0;
        }
        #endregion
    }
}
