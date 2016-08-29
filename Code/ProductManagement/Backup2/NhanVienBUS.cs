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
    public class NhanVienBUS
    {
        public NhanVienDTO Search(string Username)
        {
            NhanVienDAO nhanvienDao = new NhanVienDAO();
            NhanVienDTO nhanvienDto = nhanvienDao.Search(Username);
            return nhanvienDto;
        }

        public void Insert(NhanVienDTO NhanVien)
        {
            NhanVienDAO nhanVienDAO = new NhanVienDAO();
            nhanVienDAO.Insert(NhanVien);
        }
    }
}
