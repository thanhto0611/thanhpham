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
    public class DanhMucBUS
    {
        public static IList GetList()
        {
            return DanhMucDAO.GetList();
        }
        public static void Modify(DanhMucDTO danhMuc)
        {
            DanhMucDAO.Modify(danhMuc);
        }
        public static void Insert(DanhMucDTO danhMuc)
        {
            DanhMucDAO.Insert(danhMuc);
        }
        public DanhMucDTO LayTenDanhMuc(int maDM)
        {
            DanhMucDAO dmDAO = new DanhMucDAO();
            DanhMucDTO dmDTO = null;
            dmDTO = dmDAO.LayTenDanhMuc(maDM);
            return dmDTO;
        }
        public DanhMucDTO LayMaDanhMuc(string tenDM)
        {
            DanhMucDAO dmDAO = new DanhMucDAO();
            DanhMucDTO dmDTO = null;
            dmDTO = dmDAO.LayMaDanhMuc(tenDM);
            return dmDTO;
        }
    }
}
