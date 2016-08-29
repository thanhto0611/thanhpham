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
    public class PhieuMuonBUS
    {
        public static DataTable GetBook (int MaDG)
        {
            return PhieuMuonDAO.GetBook(MaDG);
        }
        public void Insert (PhieuMuonDTO phMuon)
        {
            PhieuMuonDAO.Insert(phMuon);
        }
    }
}
