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

        public static void UpdateRecord(GiangVienDTO giangVienDTO)
        {
            GiangVienDAO.UpdateRecord(giangVienDTO);
        }

        public static void Delete(int maGiangVien)
        {
            GiangVienDAO.Delete(maGiangVien);
        }
    }
}
