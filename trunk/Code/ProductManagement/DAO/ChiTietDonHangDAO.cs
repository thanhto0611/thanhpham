using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class ChiTietDonHangDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CHITIETDONHANG ctdh, DONHANG dh, SANPHAM sp";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }

        public static DataTable TimKiemTheoMaDonHang(int MaDH)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select MaChiTietDonHang, MaSanPham, SoLuong, MauSac, GiaBan from CHITIETDONHANG where MaDonHang = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDonHang", OleDbType.Integer);
            command.Parameters["@MaDonHang"].Value = MaDH;
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable LayDanhSachSanPham(int MaDH)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select ctdh.MaChiTietDonHang, sp.MaSanPham, sp.HinhAnh, ctdh.MauSac, ctdh.SoLuong as SoLuongDatMua, sp.TrangThai, sp.GiaSi, sp.GiaLe, ctdh.GiaBan from CHITIETDONHANG ctdh, SANPHAM sp where ctdh.MaSanPham = sp.MaSanPham and MaDonHang = ? order by sp.MaSanPham ASC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDonHang", OleDbType.Integer);
            command.Parameters["@MaDonHang"].Value = MaDH;
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }

        public static DataTable LaySanPham(int MaDH, string maSP)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select ctdh.MaChiTietDonHang, sp.MaSanPham, sp.HinhAnh, ctdh.MauSac, ctdh.SoLuong as SoLuongDatMua, sp.TrangThai, sp.GiaSi, sp.GiaLe, ctdh.GiaBan from CHITIETDONHANG ctdh, SANPHAM sp where ctdh.MaSanPham = sp.MaSanPham and MaDonHang = ? and sp.MaSanPham = ? order by sp.MaSanPham ASC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDonHang", OleDbType.Integer);
            command.Parameters.Add("@MaSanPham", OleDbType.WChar);
            command.Parameters["@MaDonHang"].Value = MaDH;
            command.Parameters["@MaSanPham"].Value = maSP;
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
        //public static IList GetList()
        //{
        //    ArrayList arrList = new ArrayList();

        //    DonHangDTO DonHang = null;

        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "Select * from DONHANG";
        //    OleDbCommand command = new OleDbCommand(cmdText, connection);
        //    OleDbDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        DonHang = new DonHangDTO();
        //        DonHang.MaDocGia = (int)reader["MaDocGia"];
        //        DonHang.MaPhieuMuon = (int)reader["MaPhieuMuon"];
        //        DonHang.NgayMuon = (DateTime)reader["NgayMuon"];
        //        arrList.Add(DonHang);
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return arrList;
        //}
        //public static void UpdateTable(DataTable dataTable)
        //{
        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "Select * from DONHANG";
        //    OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
        //    OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
        //    adapter.Update(dataTable);

        //    connection.Close();
        //}
        public static void Insert(ChiTietDonHangDTO CTDonHang)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into CHITIETDONHANG(MaDonHang, MaSanPham, SoLuong, MauSac, GiaBan) values(?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDonHang", OleDbType.Integer);
            command.Parameters.Add("@MaSanPham", OleDbType.WChar);
            command.Parameters.Add("@SoLuong", OleDbType.Integer);
            command.Parameters.Add("@MauSac", OleDbType.WChar);
            command.Parameters.Add("@GiaBan", OleDbType.Integer);

            command.Parameters["@MaDonHang"].Value = CTDonHang.MaDonHang;
            command.Parameters["@MaSanPham"].Value = CTDonHang.MaSanPham;
            command.Parameters["@SoLuong"].Value = CTDonHang.SoLuong;
            command.Parameters["@MauSac"].Value = CTDonHang.MauSac;
            command.Parameters["@GiaBan"].Value = CTDonHang.GiaBan;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            CTDonHang.MaDonHang = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static void Update(ChiTietDonHangDTO ctdhDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update CHITIETDONHANG Set MauSac = ?, SoLuong = ?, GiaBan = ? Where MaChiTietDonHang = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MauSac", OleDbType.VarWChar);
            command.Parameters.Add("@SoLuong", OleDbType.Integer);
            command.Parameters.Add("@GiaBan", OleDbType.Integer);
            command.Parameters.Add("@MaChiTietDonHang", OleDbType.Integer);

            command.Parameters["@MauSac"].Value = ctdhDTO.MauSac;
            command.Parameters["@SoLuong"].Value = ctdhDTO.SoLuong;
            command.Parameters["@GiaBan"].Value = ctdhDTO.GiaBan;
            command.Parameters["@MaChiTietDonHang"].Value = ctdhDTO.MaChiTietDonHang;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static ChiTietDonHangDTO KiemTraTonTai(int maDH, string maSP)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CHITIETDONHANG where MaSanPham like '%" + maSP + "%' and MaDonHang = " + maDH;
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();
            ChiTietDonHangDTO ctdhDto = new ChiTietDonHangDTO();

            while (reader.Read())
            {
                ctdhDto.MaChiTietDonHang = (int)reader["MaChiTietDonHang"];
                ctdhDto.SoLuong = (int)reader["SoLuong"];
                ctdhDto.MauSac = (string)reader["MauSac"];
                ctdhDto.MaSanPham = (string)reader["MaSanPham"];
                ctdhDto.GiaBan = (int)reader["GiaBan"];
            }

            reader.Close();
            connection.Close();
            return ctdhDto;
        }
        public static bool Delete(int MaChiTietDonHang)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from CHITIETDONHANG where MaChiTietDonHang = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaChiTietDonHang", OleDbType.Integer);
            command.Parameters["@MaChiTietDonHang"].Value = MaChiTietDonHang;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }
            connection.Close();
            return result;
        }
    }
}
