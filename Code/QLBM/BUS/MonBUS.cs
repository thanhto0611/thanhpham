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
    public class MonBUS
    {
        public static DataTable GetTable()
        {
            return MonDAO.GetTable();
        }

        public static IList GetList()
        {
            return MonDAO.GetList();
        }

        public static void Insert(MonDTO monDTO)
        {
            MonDAO.Insert(monDTO);
        }

        public static void UpdateRecord(MonDTO monDTO)
        {
            MonDAO.UpdateRecord(monDTO);
        }

        public static void Delete(int maMon)
        {
            MonDAO.Delete(maMon);
        }
    }
}
