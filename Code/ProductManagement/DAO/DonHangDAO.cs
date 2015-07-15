using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class DonHangDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select dh.MaDonHang as MaDH, kh.HoTen, dh.SoLuongSanPham , dh.PhiVanChuyen, dh.TongTien, dh.TrangThai, dh.NgayDatHang, dh.NguoiNhap, dh.NgayCapNhat, dh.NguoiCapNhat from DONHANG dh, KHACHHANG kh where dh.MaKhachHang = kh.MaKhachHang order by dh.NgayDatHang DESC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }

        public static DataTable GetTableWithLimitOrder(string numOfOrder)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select top " + numOfOrder + " dh.MaDonHang as MaDH, kh.HoTen, dh.SoLuongSanPham, dh.PhiVanChuyen, dh.TongTien, dh.TrangThai, dh.NgayDatHang, dh.NguoiNhap, dh.NgayCapNhat, dh.NguoiCapNhat from DONHANG dh, KHACHHANG kh where dh.MaKhachHang = kh.MaKhachHang order by dh.NgayDatHang DESC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }

        public static DataTable GetNull()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select dh.MaDonHang as MaDH, kh.HoTen, dh.SoLuongSanPham, dh.PhiVanChuyen, dh.TongTien, dh.TrangThai, dh.NgayDatHang, dh.NguoiNhap, dh.NgayCapNhat, dh.NguoiCapNhat from DONHANG dh, KHACHHANG kh where dh.MaKhachHang = kh.MaKhachHang and dh.MaDonHang = -1";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }
        public static DataTable TimKiemTheoMaDonHang(int MaDH)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select dh.MaDonHang as MaDH, kh.HoTen, dh.SoLuongSanPham, dh.PhiVanChuyen, dh.TongTien, dh.TrangThai, dh.NgayDatHang, dh.NguoiNhap, dh.NgayCapNhat, dh.NguoiCapNhat from DONHANG dh, KHACHHANG kh where dh.MaKhachHang = kh.MaKhachHang and dh.MaDonHang = ? order by dh.NgayDatHang DESC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDonHang", OleDbType.Integer);
            command.Parameters["@MaDonHang"].Value = MaDH;
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimKiemTheoThongTinKhachHang(string data)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select dh.MaDonHang as MaDH, kh.HoTen, dh.SoLuongSanPham, dh.PhiVanChuyen, dh.TongTien, dh.TrangThai, dh.NgayDatHang, dh.NguoiNhap, dh.NgayCapNhat, dh.NguoiCapNhat from DONHANG dh inner join KHACHHANG kh on dh.MaKhachHang = kh.MaKhachHang where kh.HoTen like '%" + data + "%' " + "or kh.DiaChi like '%" + data + "%' " + "or kh.DienThoai like '%" + data + "%' " + "or kh.Email like '%" + data + "%' " + "or kh.Facebook like '%" + data + "%' " + "or kh.TKNganHang like '%" + data + "%'  order by dh.NgayDatHang DESC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimKiemTheoMaSanPham(string maSp)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT dh.MaDonHang as MaDH, kh.HoTen, dh.SoLuongSanPham, dh.PhiVanChuyen, dh.TongTien, dh.TrangThai, dh.NgayDatHang, dh.NguoiNhap, dh.NgayCapNhat, dh.NguoiCapNhat from (DONHANG dh left join KHACHHANG kh on dh.MaKhachHang = kh.MaKhachHang) left join CHITIETDONHANG ctdh on dh.MaDonHang = ctdh.MaDonHang where ctdh.MaSanPham like '%" + maSp + "%'  order by dh.NgayDatHang DESC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimKiemTheoNgayDatHang(string date)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select dh.MaDonHang as MaDH, kh.HoTen, dh.SoLuongSanPham, dh.PhiVanChuyen, dh.TongTien, dh.TrangThai, dh.NgayDatHang, dh.NguoiNhap, dh.NgayCapNhat, dh.NguoiCapNhat from DONHANG dh, KHACHHANG kh where dh.MaKhachHang = kh.MaKhachHang and Format([dh.NgayDatHang],'dd/MM/yyyy') = ? order by dh.NgayDatHang DESC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@NgayDatHang", OleDbType.VarWChar);
            command.Parameters["@NgayDatHang"].Value = date;
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            connection.Close();
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
        public static void Insert(DonHangDTO DonHang)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into DONHANG(MaKhachHang, NgayDatHang, TrangThai, NguoiNhap, PhiVanChuyen, TongTien, SoLuongSanPham, HinhThucMua) values(?,?,?,?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaKhachHang", OleDbType.Integer);
            command.Parameters.Add("@NgayDatHang", OleDbType.Date);
            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            command.Parameters.Add("@NguoiNhap", OleDbType.WChar);
            command.Parameters.Add("@PhiVanChuyen", OleDbType.Integer);
            command.Parameters.Add("@TongTien", OleDbType.Integer);
            command.Parameters.Add("@SoLuongSanPham", OleDbType.Integer);
            command.Parameters.Add("@HinhThucMua", OleDbType.Integer);

            command.Parameters["@MaKhachHang"].Value = DonHang.MaKhachHang;
            command.Parameters["@NgayDatHang"].Value = DonHang.NgayDatHang;
            command.Parameters["@TrangThai"].Value = DonHang.TrangThai;
            command.Parameters["@NguoiNhap"].Value = DonHang.NguoiNhap;
            command.Parameters["@PhiVanChuyen"].Value = DonHang.PhiVanChuyen;
            command.Parameters["@TongTien"].Value = DonHang.TongTien;
            command.Parameters["@SoLuongSanPham"].Value = DonHang.SoLuongSanPham;
            command.Parameters["@HinhThucMua"].Value = DonHang.HinhThucMua;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            DonHang.MaDonHang = (int)command.ExecuteScalar();
            connection.Close();
        }
        //public static bool Delete(int MaPhieuMuon)
        //{
        //    bool result = false;

        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "delete from DONHANG where MaPhieuMuon = ?";
        //    OleDbCommand command = new OleDbCommand(cmdText, connection);
        //    command.Parameters.Add("@MaPhieuMuon", OleDbType.Integer);
        //    command.Parameters["@MaPhieuMuon"].Value = MaPhieuMuon;

        //    int row = command.ExecuteNonQuery();

        //    if (row > 0)
        //    {
        //        result = true;
        //    }
        //    connection.Close();
        //    return result;
        //}

        public static void Update(DonHangDTO dhDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update DONHANG Set DiemTichLuyCongThem = ?, DiemTichLuySuDung = ?, TrangThai = ?, NguoiCapNhat = ?, NgayCapNhat = ?, PhiVanChuyen = ?, TongTien = ?, SoLuongSanPham = ?, HinhThucMua = ? Where MaDonHang = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@DiemTichLuyCongThem", OleDbType.Integer);
            command.Parameters.Add("@DiemTichLuySuDung", OleDbType.Integer);
            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            command.Parameters.Add("@NguoiCapNhat", OleDbType.WChar);
            command.Parameters.Add("@NgayCapNhat", OleDbType.Date);
            command.Parameters.Add("@PhiVanChuyen", OleDbType.Integer);
            command.Parameters.Add("@TongTien", OleDbType.Integer);
            command.Parameters.Add("@SoLuongSanPham", OleDbType.Integer);
            command.Parameters.Add("@HinhThucMua", OleDbType.Integer);
            command.Parameters.Add("@MaDonHang", OleDbType.Integer);

            command.Parameters["@DiemTichLuyCongThem"].Value = dhDTO.DiemTichLuyCongThem;
            command.Parameters["@DiemTichLuySuDung"].Value = dhDTO.DiemTichLuySuDung;
            command.Parameters["@TrangThai"].Value = dhDTO.TrangThai;
            command.Parameters["@NguoiCapNhat"].Value = dhDTO.NguoiCapNhat;
            command.Parameters["@NgayCapNhat"].Value = dhDTO.NgayCapNhat;
            command.Parameters["@PhiVanChuyen"].Value = dhDTO.PhiVanChuyen;
            command.Parameters["@TongTien"].Value = dhDTO.TongTien;
            command.Parameters["@SoLuongSanPham"].Value = dhDTO.SoLuongSanPham;
            command.Parameters["@HinhThucMua"].Value = dhDTO.HinhThucMua;
            command.Parameters["@MaDonHang"].Value = dhDTO.MaDonHang;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static DonHangDTO LayBangMaDonHang(int maDh)
        {
            DonHangDTO dhDto = new DonHangDTO();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from DONHANG where MaDonHang = " + maDh;
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                dhDto.MaDonHang = (int)reader["MaDonHang"];
                dhDto.TongTien = (int)reader["TongTien"];
                dhDto.SoLuongSanPham = (int)reader["SoLuongSanPham"];
                dhDto.PhiVanChuyen = (int)reader["PhiVanChuyen"];
                dhDto.TrangThai = (int)reader["TrangThai"];
                dhDto.HinhThucMua = (int)reader["HinhThucMua"];
            }

            reader.Close();
            connection.Close();
            return dhDto;
        }
    }
}
