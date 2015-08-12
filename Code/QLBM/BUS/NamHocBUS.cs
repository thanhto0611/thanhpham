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
    public class NamHocBUS
    {
        public static DataTable GetTable()
        {
            return NamHocDAO.GetTable();
        }

        public static IList GetList()
        {
            return NamHocDAO.GetList();
        }

        public static void Insert(NamHocDTO namHocDTO)
        {
            NamHocDAO.Insert(namHocDTO);
        }

        public static void UpdateRecord(NamHocDTO namHocDTO)
        {
            NamHocDAO.UpdateRecord(namHocDTO);
        }

        public static void Delete(int maNamHoc)
        {
            NamHocDAO.Delete(maNamHoc);
        }
    }
}
