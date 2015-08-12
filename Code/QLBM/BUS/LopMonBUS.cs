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
    public class LopMonBUS
    {
        public static DataTable GetTable()
        {
            return LopMonDAO.GetTable();
        }

        public static IList GetList()
        {
            return LopMonDAO.GetList();
        }

        public static void Insert(LopMonDTO lopMonDTO)
        {
            LopMonDAO.Insert(lopMonDTO);
        }

        public static void UpdateRecord(LopMonDTO lopMonDTO)
        {
            LopMonDAO.UpdateRecord(lopMonDTO);
        }

        public static void Delete(int maLopMon)
        {
            LopMonDAO.Delete(maLopMon);
        }
    }
}
