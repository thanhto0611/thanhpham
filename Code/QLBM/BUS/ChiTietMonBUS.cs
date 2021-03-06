﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;
using DAO;

namespace BUS
{
    public class ChiTietMonBUS
    {
        public static DataTable GetTable(int maLop)
        {
            return ChiTietMonDAO.GetTable(maLop);
        }

        public static IList GetList()
        {
            return ChiTietMonDAO.GetList();
        }

        public static ChiTietMonDTO TimTheoMaChiTietMon(int maCTM)
        {
            return ChiTietMonDAO.TimTheoMaChiTietMon(maCTM);
        }

        public static void Insert(ChiTietMonDTO chiTietMonDTO)
        {
            ChiTietMonDAO.Insert(chiTietMonDTO);
        }

        public static void UpdateRecord(ChiTietMonDTO chiTietMonDTO)
        {
            ChiTietMonDAO.UpdateRecord(chiTietMonDTO);
        }

        public static void UpdateGiangVien(ChiTietMonDTO chiTietMonDTO)
        {
            ChiTietMonDAO.UpdateGiangVien(chiTietMonDTO);
        }

        public static void UpdateCanBoCoiThiLan1(ChiTietMonDTO chiTietMonDTO)
        {
            ChiTietMonDAO.UpdateCanBoCoiThiLan1(chiTietMonDTO);
        }

        public static void UpdateCanBoCoiThiLan2(ChiTietMonDTO chiTietMonDTO)
        {
            ChiTietMonDAO.UpdateCanBoCoiThiLan2(chiTietMonDTO);
        }

        public static void CapNhatNamHoc(int maChiTietMon, int maNamHoc)
        {
            ChiTietMonDAO.CapNhatNamHoc(maChiTietMon, maNamHoc);
        }

        public static void Delete(int maChiTietMon)
        {
            ChiTietMonDAO.Delete(maChiTietMon);
        }
    }
}
