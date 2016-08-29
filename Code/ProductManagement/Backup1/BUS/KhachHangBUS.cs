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
    public class KhachHangBUS
    {
        public void GetKhachHang(KhachHangDTO KhachHangDTO)
        {
            KhachHangDAO khachhangDAO = new KhachHangDAO();
            khachhangDAO.GetKhachHang(KhachHangDTO);
        }
        public void Update(KhachHangDTO khachhangDTO)
        {
            KhachHangDAO khachhangDAO = new KhachHangDAO();
            khachhangDAO.UpdateKhachHang(khachhangDTO);
        }
        public static void Insert(KhachHangDTO khachhangDTO)
        {
            KhachHangDAO khachhangDAO = new KhachHangDAO();
            KhachHangDAO.Insert(khachhangDTO);
        }

        public DataTable TimKiem(string data)
        {
            DataTable dt = new DataTable();
            dt = KhachHangDAO.TimKiem(data);
            return dt;
        }

        public KhachHangDTO LayThongTinKhachHangTuMaDonHang(int maDh)
        {
            return KhachHangDAO.LayThongTinKhachHangTuMaDonHang(maDh);
        }

        public IList GetList(string data)
        {
            return KhachHangDAO.GetList(data);
        }
    }
}
