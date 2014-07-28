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
    public class TheLoaiBUS
    {
        public static IList GetList ()
        {
            return TheLoaiDAO.GetList();
        }
        public static void Modify (TheLoaiDTO theLoai)
        {
            TheLoaiDAO.Modify(theLoai);
        }
        public static void Insert(TheLoaiDTO theLoai)
        {
            TheLoaiDAO.Insert(theLoai);
        }

        public TheLoaiDTO LayTenTheLoai(int maLoai)
        {
            TheLoaiDAO tlDAO = new TheLoaiDAO();
            TheLoaiDTO tlDTO = null;
            tlDTO = tlDAO.LayTenTheLoai(maLoai);
            return tlDTO;
        }
    }
}
