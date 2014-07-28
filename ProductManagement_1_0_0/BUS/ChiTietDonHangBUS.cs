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
    public class ChiTietDonHangBUS
    {
        public void Insert(ChiTietDonHangDTO ctdh)
        {
            ChiTietDonHangDAO.Insert(ctdh);
        }

        public DataTable TimKiemTheoMaDonHang(int maDh)
        {
            return ChiTietDonHangDAO.TimKiemTheoMaDonHang(maDh);
        }

        public DataTable LayDanhSachSanPham(int maDh)
        {
            return ChiTietDonHangDAO.LayDanhSachSanPham(maDh);
        }

        public void Update(ChiTietDonHangDTO ctdhDTO)
        {
            ChiTietDonHangDAO.Update(ctdhDTO);
        }

        public ChiTietDonHangDTO KiemTraTonTai(int maDH, string maSP)
        {
            return ChiTietDonHangDAO.KiemTraTonTai(maDH, maSP);
        }

        public bool Delete(int maCtdh)
        {
            return ChiTietDonHangDAO.Delete(maCtdh);
        }

        public DataTable LaySanPham(int maDh, string maSp)
        {
            return ChiTietDonHangDAO.LaySanPham(maDh, maSp);
        }
    }
}
