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
    public class LopBUS
    {
        public static DataTable GetTable()
        {
            return LopDAO.GetTable();
        }

        public static IList GetList()
        {
            return LopDAO.GetList();
        }

        public static void Insert(LopDTO lopDTO)
        {
            LopDAO.Insert(lopDTO);
        }

        public static void UpdateRecord(LopDTO lopDTO)
        {
            LopDAO.UpdateRecord(lopDTO);
        }

        public static void Delete(int maLop)
        {
            LopDAO.Delete(maLop);
        }

        public static DataTable TimLopTheoTenLop(string tenLop)
        {
            return LopDAO.TimLopTheoTenLop(tenLop);
        }

        public static DataTable TimLopTheoTenLop(string tenLop, int maNamHoc)
        {
            return LopDAO.TimLopTheoTenLop(tenLop, maNamHoc);
        }

        public static LopDTO TimLopTheoMaLop(int maLop)
        {
            return LopDAO.TimLopTheoMaLop(maLop);
        }

        public static DataTable TimLopTheoGiangDuong(string giangDuong)
        {
            return LopDAO.TimLopTheoGiangDuong(giangDuong);
        }

        public static DataTable TimLopTheoGiangDuong(string giangDuong, int maNamHoc)
        {
            return LopDAO.TimLopTheoGiangDuong(giangDuong, maNamHoc);
        }

        public static DataTable TimLopTheoGiangVien(string giangVien)
        {
            return LopDAO.TimLopTheoGiangVien(giangVien);
        }

        public static DataTable TimLopTheoGiangVien(string giangVien, int maNamHoc)
        {
            return LopDAO.TimLopTheoGiangVien(giangVien, maNamHoc);
        }

        public static DataTable TimLopTheoGiangDuongThiL1(string giangDuong)
        {
            return LopDAO.TimLopTheoGiangDuongThiL1(giangDuong);
        }

        public static DataTable TimLopTheoGiangDuongThiL1(string giangDuong, int maNamHoc)
        {
            return LopDAO.TimLopTheoGiangDuongThiL1(giangDuong, maNamHoc);
        }

        public static DataTable TimLopTheoCanBoCoiThiL1(string canBo)
        {
            return LopDAO.TimLopTheoCanBoCoiThiL1(canBo);
        }

        public static DataTable TimLopTheoCanBoCoiThiL1(string canBo, int maNamHoc)
        {
            return LopDAO.TimLopTheoCanBoCoiThiL1(canBo, maNamHoc);
        }

        public static DataTable TimLopTheoGiangDuongThiL2(string giangDuong)
        {
            return LopDAO.TimLopTheoGiangDuongThiL2(giangDuong);
        }

        public static DataTable TimLopTheoGiangDuongThiL2(string giangDuong, int maNamHoc)
        {
            return LopDAO.TimLopTheoGiangDuongThiL2(giangDuong, maNamHoc);
        }

        public static DataTable TimLopTheoCanBoCoiThiL2(string canBo)
        {
            return LopDAO.TimLopTheoCanBoCoiThiL2(canBo);
        }

        public static DataTable TimLopTheoCanBoCoiThiL2(string canBo, int maNamHoc)
        {
            return LopDAO.TimLopTheoCanBoCoiThiL2(canBo, maNamHoc);
        }
    }
}
