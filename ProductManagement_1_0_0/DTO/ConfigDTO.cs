using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class ConfigDTO
    {
        #region Attributes
        private bool _TichLuyDiem;
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
        #endregion

        #region Constructor
        public ConfigDTO()
        {
            _TichLuyDiem = false;
        }
        #endregion
    }
}
