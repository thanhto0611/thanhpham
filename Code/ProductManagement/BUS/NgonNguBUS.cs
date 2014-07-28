using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DAO;
using DTO;

namespace BUS
{
    public class NgonNguBUS
    {
        public static IList GetList()
        {
            return NgonNguDAO.GetList();
        }
        public static void Modify(NgonNguDTO ngonNgu)
        {
            NgonNguDAO.Modify(ngonNgu);
        }
        public static void Insert(NgonNguDTO ngonNgu)
        {
            NgonNguDAO.Insert(ngonNgu);
        }
        public NgonNguDTO LayTenNgonNgu(int maNN)
        {
            NgonNguDAO nnDAO = new NgonNguDAO();
            NgonNguDTO nnDTO = null;
            nnDTO = nnDAO.LayTenNgonNgu(maNN);
            return nnDTO;
        }
    }
}
