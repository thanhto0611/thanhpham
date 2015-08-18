using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ChiTietMonDTO
    {
        #region Attributes
        private int _MaChiTietMon;
        private int _MaLopMon;
        private int _MaNamHoc;
        private string _ThoiGianHoc;
        private string _GioHoc;
        private string _GiangDuong;
        private string _GiangVien;
        private string _NgayThiLan1;
        private string _GioThiLan1;
        private string _GiangDuongThiLan1;
        private string _CanBoCoiThiLan1;
        private int _SoBaiThiLan1;
        private string _NgayThiLan2;
        private string _GioThiLan2;
        private string _GiangDuongThiLan2;
        private string _CanBoCoiThiLan2;
        private int _SoBaiThiLan2;
        private string _GhiChu;
        #endregion

        #region Properties
        public int MaChiTietMon
        {
            get { return _MaChiTietMon; }
            set { _MaChiTietMon = value; }
        }
        public int MaLopMon
        {
            get { return _MaLopMon; }
            set { _MaLopMon = value; }
        }
        public int MaNamHoc
        {
            get { return _MaNamHoc; }
            set { _MaNamHoc = value; }
        }
        public string ThoiGianHoc
        {
            get { return _ThoiGianHoc; }
            set { _ThoiGianHoc = value; }
        }
        public string GioHoc
        {
            get { return _GioHoc; }
            set { _GioHoc = value; }
        }
        public string GiangDuong
        {
            get { return _GiangDuong; }
            set { _GiangDuong = value; }
        }
        public string GiangVien
        {
            get { return _GiangVien; }
            set { _GiangVien = value; }
        }
        public string NgayThiLan1
        {
            get { return _NgayThiLan1; }
            set { _NgayThiLan1 = value; }
        }
        public string GioThiLan1
        {
            get { return _GioThiLan1; }
            set { _GioThiLan1 = value; }
        }
        public string GiangDuongThiLan1
        {
            get { return _GiangDuongThiLan1; }
            set { _GiangDuongThiLan1 = value; }
        }
        public string CanBoCoiThiLan1
        {
            get { return _CanBoCoiThiLan1; }
            set { _CanBoCoiThiLan1 = value; }
        }
        public int SoBaiThiLan1
        {
            get { return _SoBaiThiLan1; }
            set { _SoBaiThiLan1 = value; }
        }
        public string NgayThiLan2
        {
            get { return _NgayThiLan2; }
            set { _NgayThiLan2 = value; }
        }
        public string GioThiLan2
        {
            get { return _GioThiLan2; }
            set { _GioThiLan2 = value; }
        }
        public string GiangDuongThiLan2
        {
            get { return _GiangDuongThiLan2; }
            set { _GiangDuongThiLan2 = value; }
        }
        public string CanBoCoiThiLan2
        {
            get { return _CanBoCoiThiLan2; }
            set { _CanBoCoiThiLan2 = value; }
        }
        public int SoBaiThiLan2
        {
            get { return _SoBaiThiLan2; }
            set { _SoBaiThiLan2 = value; }
        }
        public string GhiChu
        {
            get { return _GhiChu; }
            set { _GhiChu = value; }
        }
        #endregion

        #region Constructor
        public ChiTietMonDTO()
        {
            _MaChiTietMon = 0;
            _MaLopMon = 0;
            _MaNamHoc = 0;
            _ThoiGianHoc = "";
            _GioHoc = "";
            _GiangDuong = "";
            _GiangVien = "";
            _NgayThiLan1 = "";
            _GioThiLan1 = "";
            _GiangDuongThiLan1 = "";
            _CanBoCoiThiLan1 = "";
            _SoBaiThiLan1 = 0;
            _NgayThiLan2 = "";
            _GioThiLan2 = "";
            _GiangDuongThiLan2 = "";
            _CanBoCoiThiLan2 = "";
            _SoBaiThiLan2 = 0;
            _GhiChu = "";
        }
        #endregion
    }
}
