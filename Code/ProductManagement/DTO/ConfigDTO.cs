using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ConfigDTO
    {
        #region Attributes
        private bool _TichLuyDiem;
        private bool _UseAPISycn;
        #endregion

        #region Properties
        public bool TichLuyDiem
        {
            get
            {
                return _TichLuyDiem;
            }
            set
            {
                _TichLuyDiem = value;
            }
        }
        public bool UseAPISycn
        {
            get
            {
                return _UseAPISycn;
            }
            set
            {
                _UseAPISycn = value;
            }
        }
        #endregion

        #region Constructor
        public ConfigDTO()
        {
            _TichLuyDiem = false;
            _UseAPISycn = false;
        }
        #endregion
    }
}
