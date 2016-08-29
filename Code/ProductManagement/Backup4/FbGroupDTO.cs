using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class FbGroupDTO
    {
        #region Attributes
        private string _GroupId;
        private string _GroupName;
        private long _NumberOfMember;
        private DateTime _NgayNhap;
        private DateTime _NgayCapNhat;
        private string _NguoiNhap;
        private string _NguoiCapNhat;
        #endregion

        #region Properties
        public string GroupId
        {
            get
            {
                return _GroupId;
            }
            set
            {
                _GroupId = value;
            }
        }
        public string GroupName
        {
            get
            {
                return _GroupName;
            }
            set
            {
                _GroupName = value;
            }
        }
        public long NumberOfMember
        {
            get
            {
                return _NumberOfMember;
            }
            set
            {
                _NumberOfMember = value;
            }
        }
        public DateTime NgayNhap
        {
            get
            {
                return _NgayNhap;
            }
            set
            {
                _NgayNhap = value;
            }
        }
        public DateTime NgayCapNhat
        {
            get
            {
                return _NgayCapNhat;
            }
            set
            {
                _NgayCapNhat = value;
            }
        }
        public string NguoiNhap
        {
            get
            {
                return _NguoiNhap;
            }
            set
            {
                _NguoiNhap = value;
            }
        }
        public string NguoiCapNhat
        {
            get
            {
                return _NguoiCapNhat;
            }
            set
            {
                _NguoiCapNhat = value;
            }
        }
        #endregion

        #region Constructor
        public FbGroupDTO()
        {
            _GroupId = "";
            _GroupName = "";
            _NumberOfMember = 0;
            _NgayNhap = System.DateTime.Now;
            _NgayCapNhat = System.DateTime.Now;
            _NguoiNhap = "";
            _NguoiCapNhat = "";
        }
        #endregion
    }
}
