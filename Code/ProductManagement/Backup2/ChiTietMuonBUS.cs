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
    public class ChiTietMuonBUS
    {
        public void Insert (ChiTietMuonDTO ctMuon)
        {
            ChiTietMuonDAO.Insert(ctMuon);    
        }
    }
}
