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
    }
}
