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
    public class DonHangBUS
    {
        public void Insert(DonHangDTO dh)
        {
            DonHangDAO.Insert(dh);
        }

        public DataTable TimKiemTheoMaDonHang(int maDh)
        {
            return DonHangDAO.TimKiemTheoMaDonHang(maDh);
        }

        public DataTable TimKiemTheoThongTinKhachHang(string dataKh)
        {
            return DonHangDAO.TimKiemTheoThongTinKhachHang(dataKh);
        }

        public DataTable TimKiemTheoMaSanPham(string maSp)
        {
            return DonHangDAO.TimKiemTheoMaSanPham(maSp);
        }

        public DataTable TimKiemTheoNgayDatHang(string date)
        {
            return DonHangDAO.TimKiemTheoNgayDatHang(date);
        }

        public DonHangDTO LayBangMaDonHang(int maDh)
        {
            return DonHangDAO.LayBangMaDonHang(maDh);
        }

        public DataTable GetNull()
        {
            return DonHangDAO.GetNull();
        }

        public void Update(DonHangDTO dhDto)
        {
            DonHangDAO.Update(dhDto);
        }

        public DataTable GetTable()
        {
            return DonHangDAO.GetTable();
        }

        public DataTable GetTableWithLimitOrder(string numOfOrder)
        {
            return DonHangDAO.GetTableWithLimitOrder(numOfOrder);
        }
    }
}
