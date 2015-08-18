using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;
using DAO;

namespace BUS
{
    public class GiangVienBUS
    {
        public static DataTable GetTable()
        {
            return GiangVienDAO.GetTable();
        }

        public static DataTable GetTable(string thongTinGiangVien)
        {
            return GiangVienDAO.GetTable(thongTinGiangVien);
        }

        public static DataTable LayDanhSachGiangVienCuaMon(int maChiTietMon)
        {
            return GiangVienDAO.LayDanhSachGiangVienCuaMon(maChiTietMon);
        }

        public static DataTable LayDanhSachCanBoCoiThiLan1CuaMon(int maChiTietMon)
        {
            return GiangVienDAO.LayDanhSachCanBoCoiThiLan1CuaMon(maChiTietMon);
        }

        public static DataTable LayDanhSachCanBoCoiThiLan2CuaMon(int maChiTietMon)
        {
            return GiangVienDAO.LayDanhSachCanBoCoiThiLan2CuaMon(maChiTietMon);
        }

        public static bool KiemTraGiangVienTheoMaGiangVienMaChiTietMon(int maGiangVien, int maChiTietMon)
        {
            return GiangVienDAO.KiemTraGiangVienTheoMaGiangVienMaChiTietMon(maGiangVien, maChiTietMon);
        }

        public static bool KiemTraCanBoCoiThiLan1TheoMaGiangVienMaChiTietMon(int maGiangVien, int maChiTietMon)
        {
            return GiangVienDAO.KiemTraCanBoCoiThiLan1TheoMaGiangVienMaChiTietMon(maGiangVien, maChiTietMon);
        }

        public static bool KiemTraCanBoCoiThiLan2TheoMaGiangVienMaChiTietMon(int maGiangVien, int maChiTietMon)
        {
            return GiangVienDAO.KiemTraCanBoCoiThiLan2TheoMaGiangVienMaChiTietMon(maGiangVien, maChiTietMon);
        }
        
        public static IList GetList()
        {
            return GiangVienDAO.GetList();
        }

        public static GiangVienDTO TimTheoMaGiangVien(int maGiangVien)
        {
            return GiangVienDAO.TimTheoMaGiangVien(maGiangVien);
        }

        public static void Insert(GiangVienDTO giangVienDTO)
        {
            GiangVienDAO.Insert(giangVienDTO);
        }

        public static void ThemGiangVienMon(int maGiangVien, int maChiTietMon)
        {
            GiangVienDAO.ThemGiangVienMon(maGiangVien, maChiTietMon);
        }

        public static void ThemCanBoCoiThiLan1Mon(int maGiangVien, int maChiTietMon)
        {
            GiangVienDAO.ThemCanBoCoiThiLan1Mon(maGiangVien, maChiTietMon);
        }

        public static void ThemCanBoCoiThiLan2Mon(int maGiangVien, int maChiTietMon)
        {
            GiangVienDAO.ThemCanBoCoiThiLan2Mon(maGiangVien, maChiTietMon);
        }

        public static void UpdateRecord(GiangVienDTO giangVienDTO)
        {
            GiangVienDAO.UpdateRecord(giangVienDTO);
        }

        public static void Delete(int maGiangVien)
        {
            GiangVienDAO.Delete(maGiangVien);
        }

        public static void XoaGiangVienMon(int maGiangVien, int maChiTietMon)
        {
            GiangVienDAO.XoaGiangVienMon(maGiangVien, maChiTietMon);
        }

        public static void XoaCanBoCoiThiLan1Mon(int maGiangVien, int maChiTietMon)
        {
            GiangVienDAO.XoaCanBoCoiThiLan1Mon(maGiangVien, maChiTietMon);
        }

        public static void XoaCanBoCoiThiLan2Mon(int maGiangVien, int maChiTietMon)
        {
            GiangVienDAO.XoaCanBoCoiThiLan2Mon(maGiangVien, maChiTietMon);
        }

        public static DataTable LayDanhSachMonCuaGiangVien(int maGiangVien)
        {
            return GiangVienDAO.LayDanhSachMonCuaGiangVien(maGiangVien);
        }

        public static DataTable LayDanhSachMonCuaGiangVien(int maGiangVien, int maNamHoc)
        {
            return GiangVienDAO.LayDanhSachMonCuaGiangVien(maGiangVien, maNamHoc);
        }
    }
}
