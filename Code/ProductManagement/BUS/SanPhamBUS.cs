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
    public class SanPhamBUS
    {
        public class inventor
        {
            public string masp;
            public int soluong;
            public int trangthai;
        }

        public DataTable GetTable()
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.GetTable();
            return dt;
        }

        public static DataTable XuatKhoHang()
        {
            return SanPhamDAO.XuatKhoHang();
        }

        public static DataTable XuatKhoHangByDate(string date)
        {
            return SanPhamDAO.XuatKhoHangByDate(date);
        }

        //public IList GetList()
        //{
        //    SanPhamDAO sd = new SanPhamDAO();
        //    IList ds;
        //    ds = SanPhamDAO.GetList();
        //    return ds;
        //}

        public DataTable LayBangMaSanPhamTrangThai(string masp, int trangthai)
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.LayBangMaSanPhamTrangThai(masp, trangthai);
            return dt;
        }

        public DataTable LayBangMaSanPhamMaDanhMuc(string masp, int madm)
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.LayBangMaSanPhamMaDanhMuc(masp, madm);
            return dt;
        }

        public DataTable LayBangMaSanPhamMaDanhMucTrangThai(string masp, int madm, int trangthai)
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.LayBangMaSanPhamMaDanhMucTrangThai(masp, madm, trangthai);
            return dt;
        }

        public DataTable LayBangMaSanPham(string masp)
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.LayBangMaSanPham(masp);
            return dt;
        }

        public DataTable LayBangMaSanPham_ChiTietDonHang(string masp)
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.LayBangMaSanPham_ChiTietDonHang(masp);
            return dt;
        }

        public DataTable GetNull()
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.GetNull();
            return dt;
        }

        public bool KiemTraTonTai(string masp)
        {
            SanPhamDAO sd = new SanPhamDAO();
            return SanPhamDAO.KiemTraTonTai(masp);
        }

        public bool KiemTraKhoHang(string masp, int sl)
        {
            return SanPhamDAO.KiemTraKhoHang(masp, sl);
        }

        public DataTable LayBangDanhMuc(int madm)
        {
            SanPhamDAO sd = new SanPhamDAO();
            DataTable dt = new DataTable();
            dt = SanPhamDAO.LayBangDanhMuc(madm);
            return dt;
        }
        //public DataTable Search(string query)
        //{
        //    return SanPhamDAO.Search(query);
        //}
        //public DataTable Search_DTO(SanPhamDTO sach, bool NgonNguChk, bool TheLoaiChk)
        //{
        //    return SanPhamDAO.Search_DTO(sach, NgonNguChk, TheLoaiChk);
        //}
        public void Insert(SanPhamDTO sp)
        {
            SanPhamDAO sd = new SanPhamDAO();
            sd.Insert(sp);
        }
        //public void UpdateRecord(int MaSach, bool Type)
        //{
        //    SanPhamDAO sd = new SanPhamDAO();
        //    sd.UpdateRecord(MaSach, Type);
        //}

        //public SanPhamDTO Search_MaSach(int maSach)
        //{
        //    SanPhamDAO sanPhamDAO = new SanPhamDAO();
        //    SanPhamDTO sanPhamDTO = null;
        //    sanPhamDTO = sanPhamDAO.Search_MaSach(maSach);
        //    return sanPhamDTO;
        //}
        public void Update(SanPhamDTO sanPhamDTO)
        {
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            sanPhamDAO.Update(sanPhamDTO);
        }
        //public void Delete(int MaSach)
        //{
        //    SanPhamDAO sanPhamDAO = new SanPhamDAO();
        //    sanPhamDAO.Delete(MaSach);
        //}
        public void CapNhatKhoHang(string masp, int sl, int trangthai)
        {
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            sanPhamDAO.CapNhatKhoHang(masp, sl, trangthai);
        }

        public static void CapNhatKhoHang(Object threadContext)
        {
            inventor iv = (inventor)threadContext;
            SanPhamDAO sanPhamDAO = new SanPhamDAO();
            sanPhamDAO.CapNhatKhoHang(iv.masp, iv.soluong, iv.trangthai);
        }

        public static SanPhamDTO LaySanPham(string masp)
        {
            return SanPhamDAO.LaySanPham(masp);
        }
    }
}
