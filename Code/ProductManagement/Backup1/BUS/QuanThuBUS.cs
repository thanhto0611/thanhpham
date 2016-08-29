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
    public class QuanThuBUS
    {
        public QuanThuDTO Search(string Username)
        {
            QuanThuDAO quanthuDao = new QuanThuDAO();
            QuanThuDTO quanthuDto = quanthuDao.Search(Username);
            return quanthuDto;
        }

        public void Insert(QuanThuDTO QuanThu)
        {
            QuanThuDAO quanthuDAO = new QuanThuDAO();
            quanthuDAO.Insert(QuanThu);
        }
    }
}
