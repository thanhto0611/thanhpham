using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;
using DAO;

namespace BUS
{
    public class TrangThaiDonHangBUS
    {
        public static IList GetList()
        {
            return TrangThaiDonHangDAO.GetList();
        }
    }
}
