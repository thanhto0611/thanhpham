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
        private string _SoapAddress;
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
        public string SoapAddress
        {
            get
            {
                return _SoapAddress;
            }
            set
            {
                _SoapAddress = value;
            }
        }
        #endregion

        #region Constructor
        public ConfigDTO()
        {
            _TichLuyDiem = false;
            _UseAPISycn = false;
            _SoapAddress = "";
        }
        #endregion
    }
}
