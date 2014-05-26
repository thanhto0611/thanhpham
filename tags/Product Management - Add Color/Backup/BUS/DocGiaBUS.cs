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
    public class DocGiaBUS
    {
        public void GetDocGia(DocGiaDTO DocGiaDTO)
        {
            DocGiaDAO docgiaDAO = new DocGiaDAO();
            docgiaDAO.GetDocGia(DocGiaDTO);
        }
        public void Update(DocGiaDTO docgiaDTO)
        {
            DocGiaDAO docgiaDAO = new DocGiaDAO();
            docgiaDAO.UpdateDocGia(docgiaDTO);
        }
        public static void Insert(DocGiaDTO docgiaDTO)
        {
            DocGiaDAO docgiaDAO = new DocGiaDAO();
            DocGiaDAO.Insert(docgiaDTO);
        }
    }
}
