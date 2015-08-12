using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class NamHocDTO
    {
        #region Attributes
        private int _MaNamHoc;
        private string _TenNamHoc;
        #endregion

        #region Properties
        public int MaNamHoc
        {
            get
            {
                return _MaNamHoc;
            }
            set
            {
                _MaNamHoc = value;
            }
        }
        public string TenNamHoc
        {
            get
            {
                return _TenNamHoc;
            }
            set
            {
                _TenNamHoc = value;
            }
        }
        #endregion

        #region Constructor
        public NamHocDTO()
        {
            _MaNamHoc = 0;
            _TenNamHoc = "";
        }
        #endregion
    }
}
