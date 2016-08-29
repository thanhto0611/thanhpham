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
    public class NhaXuatBanBUS
    {
        public static IList GetList()
        {
            return NhaXuatBanDAO.GetList();
        }
        public static void Modify(NhaXuatBanDTO NXB)
        {
            NhaXuatBanDAO.Modify(NXB);
        }
        public static void Insert(NhaXuatBanDTO NXB)
        {
            NhaXuatBanDAO.Insert(NXB);
        }
        public NhaXuatBanDTO LayTenNhaXuatBan(int maNXB)
        {
            NhaXuatBanDAO nxbDAO = new NhaXuatBanDAO();
            NhaXuatBanDTO nxbDTO = null;
            nxbDTO = nxbDAO.LayTenNhaXuatBan(maNXB);
            return nxbDTO;
        }
    }
}
