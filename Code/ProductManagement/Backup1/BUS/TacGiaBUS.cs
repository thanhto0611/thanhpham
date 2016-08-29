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
    public class TacGiaBUS
    {
        public static IList GetList()
        {
            return TacGiaDAO.GetList();
        }
        public static void Modify(TacGiaDTO tacGia)
        {
            TacGiaDAO.Modify(tacGia);
        }
        public static void Insert(TacGiaDTO tacGia)
        {
            TacGiaDAO.Insert(tacGia);
        }
        public TacGiaDTO LayTenTacGia(int maTG)
        {
            TacGiaDAO tgDAO = new TacGiaDAO();
            TacGiaDTO tgDTO = null;
            tgDTO=tgDAO.LayTenTacGia(maTG);
            return tgDTO;
        }
    }
}
