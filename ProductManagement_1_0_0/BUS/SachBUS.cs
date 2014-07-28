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
    public class SachBUS
    {
        public DataTable GetTable()
        {
            SachDAO sd = new SachDAO();
            DataTable dt = new DataTable();
            dt = SachDAO.GetTable();
            return dt;
        }
        
        public IList GetList ()
        {
            SachDAO sd = new SachDAO();
            IList ds;
            ds = SachDAO.GetList();
            return ds;
        }

        public DataTable LayBangMaSach(int masach)
        {
            SachDAO sd = new SachDAO();
            DataTable dt = new DataTable();
            dt = SachDAO.LayBangMaSach(masach);
            return dt;
        }

        public DataTable LayBangTacGia(int matg)
        {
            SachDAO sd = new SachDAO();
            DataTable dt = new DataTable();
            dt = SachDAO.LayBangTacGia(matg);
            return dt;
        }
        public  DataTable Search(string query)
        {
            return SachDAO.Search(query);
        }
        public  DataTable Search_DTO(SachDTO sach, bool NgonNguChk, bool TheLoaiChk)
        {
            return SachDAO.Search_DTO(sach, NgonNguChk, TheLoaiChk);
        }
        public void Insert(SachDTO sach)
        {
            SachDAO sd = new SachDAO();
            sd.Insert(sach);
        }
        public void UpdateRecord (int MaSach, bool Type)
        {
            SachDAO sd = new SachDAO();
            sd.UpdateRecord(MaSach,Type);
        }

        public SachDTO Search_MaSach(int maSach)
        {
            SachDAO sachDAO = new SachDAO();
            SachDTO sachDTO = null;
            sachDTO = sachDAO.Search_MaSach(maSach);
            return sachDTO;
        }
        public void Update(SachDTO sachDTO)
        {
            SachDAO sachDAO = new SachDAO();
            sachDAO.Update(sachDTO);
        }
        public void Delete(int MaSach)
        {
            SachDAO sachDAO = new SachDAO();
            sachDAO.Delete(MaSach);
        }
    }
}
