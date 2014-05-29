using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class KhachHangDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from KHACHHANG";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList(string data)
        {
            ArrayList arrList = new ArrayList();
            KhachHangDTO KhachHang;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select MaKhachHang, HoTen from KHACHHANG where HoTen like '%" + data + "%' " + "or DiaChi like '%" + data + "%' " + "or DienThoai like '%" + data + "%' " + "or Email like '%" + data + "%' " + "or Facebook like '%" + data + "%' " + "or TKNganHang like '%" + data + "%' ";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                KhachHang = new KhachHangDTO();

                KhachHang.MaKhachHang = (int)reader["MaKhachHang"];
                KhachHang.HoTen = (string)reader["HoTen"];
                //KhachHang.DiaChi = (string)reader["DiaChi"];
                //KhachHang.DienThoai = (string)reader["DienThoai"];
                //KhachHang.Email = (string)reader["Email"];
                //KhachHang.Facebook = (string)reader["Facebook"];
                //KhachHang.TKNganHang = (string)reader["TKNganHang"];

                arrList.Add(KhachHang);
            }

            reader.Close();
            connection.Close();
            return arrList;
        }
        public void GetKhachHang(KhachHangDTO KhachHangDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from KHACHHANG where MaKhachHang =" + KhachHangDTO.MaKhachHang;
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                KhachHangDTO.HoTen = (string)reader["HoTen"];
                KhachHangDTO.DiaChi = (string)reader["DiaChi"];
                KhachHangDTO.DienThoai = (string)reader["DienThoai"];
                KhachHangDTO.Email = (string)reader["Email"];
                KhachHangDTO.Facebook = (string)reader["Facebook"];
                KhachHangDTO.TKNganHang = (string)reader["TKNganHang"];
            }

            reader.Close();
            connection.Close();
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from KHACHHANG";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adapter);

            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(KhachHangDTO KhachHang)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into KHACHHANG( HoTen, DiaChi, DienThoai, Email, Facebook, TKNganHang, NgayThem, NguoiThem) values (?,?,?,?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@HoTen", OleDbType.VarWChar);
            command.Parameters.Add("@DiaChi", OleDbType.VarWChar);
            command.Parameters.Add("@DienThoai", OleDbType.VarWChar);
            command.Parameters.Add("@Email", OleDbType.VarWChar);
            command.Parameters.Add("@Facebook", OleDbType.VarWChar);
            command.Parameters.Add("@TKNganHang", OleDbType.VarWChar);
            command.Parameters.Add("@NgayThem", OleDbType.VarWChar);
            command.Parameters.Add("@NguoiThem", OleDbType.VarWChar);

            command.Parameters["@HoTen"].Value = KhachHang.HoTen;
            command.Parameters["@DiaChi"].Value = KhachHang.DiaChi;
            command.Parameters["@DienThoai"].Value = KhachHang.DienThoai;
            command.Parameters["@Email"].Value = KhachHang.Email;
            command.Parameters["@Facebook"].Value = KhachHang.Facebook;
            command.Parameters["@TKNganHang"].Value = KhachHang.TKNganHang;
            command.Parameters["@NgayThem"].Value = KhachHang.NgayThem;
            command.Parameters["@NguoiThem"].Value = KhachHang.NguoiThem;

            command.ExecuteNonQuery();
           
            command.CommandText = "Select @@IDENTITY";
            KhachHang.MaKhachHang = (int)command.ExecuteScalar();

            connection.Close();

        }
        public static DataTable TimKiem(string data)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from KHACHHANG where HoTen like '%" + data + "%' " + "or DiaChi like '%" + data + "%' " + "or DienThoai like '%" + data + "%' " + "or Email like '%" + data + "%' " + "or Facebook like '%" + data + "%' " + "or TKNganHang like '%" + data + "%' order by HoTen";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        public static bool Delete(int MaKhachHang)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Delete * from KhachHang where MaKhachHang = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaKhachHang", OleDbType.Integer);
            command.Parameters["@MaKhachHang"].Value = MaKhachHang;

            int row = command.ExecuteNonQuery();

            if (row > 0)
                result = true;

            connection.Close();
            return result;
        }
        public void UpdateKhachHang(KhachHangDTO khachhangDTO)
        {
            OleDbConnection cn = DataProvider.CreateConnection();
            string strSql = "Update KHACHHANG set HoTen = ?, DiemTichLuy = ?, DiaChi = ?, DienThoai = ?, Email = ?, Facebook = ?, TKNganHang = ?, NgayCapNhat = ?, NguoiCapNhat = ? where MaKhachHang=" + khachhangDTO.MaKhachHang;
            OleDbCommand cmd = new OleDbCommand(strSql, cn);
            cmd.Parameters.Add("@HoTen", OleDbType.VarWChar);
            cmd.Parameters.Add("@DiemTichLuy", OleDbType.Integer);
            cmd.Parameters.Add("@DiaChi", OleDbType.VarWChar);
            cmd.Parameters.Add("@DienThoai", OleDbType.VarWChar);
            cmd.Parameters.Add("@Email", OleDbType.VarWChar);
            cmd.Parameters.Add("@Facebook", OleDbType.VarWChar);
            cmd.Parameters.Add("@TKNganHang", OleDbType.VarWChar);
            cmd.Parameters.Add("@NgayCapNhat", OleDbType.Date);
            cmd.Parameters.Add("@NguoiCapNhat", OleDbType.WChar);

            cmd.Parameters["@HoTen"].Value = khachhangDTO.HoTen;
            cmd.Parameters["@DiemTichLuy"].Value = khachhangDTO.DiemTichLuy;
            cmd.Parameters["@DiaChi"].Value = khachhangDTO.DiaChi;
            cmd.Parameters["@DienThoai"].Value = khachhangDTO.DienThoai;
            cmd.Parameters["@Email"].Value = khachhangDTO.Email;
            cmd.Parameters["@Facebook"].Value = khachhangDTO.Facebook;
            cmd.Parameters["@TKNganHang"].Value = khachhangDTO.TKNganHang;
            cmd.Parameters["@NgayCapNhat"].Value = khachhangDTO.NgayCapNhat;
            cmd.Parameters["@NguoiCapNhat"].Value = khachhangDTO.NguoiCapNhat;
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public static KhachHangDTO LayThongTinKhachHangTuMaDonHang(int maDh)
        {
            KhachHangDTO khDto = new KhachHangDTO();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select kh.MaKhachHang, kh.HoTen, kh.DiaChi, kh.DienThoai, kh.Email, kh.Facebook, kh.TKNganHang from KHACHHANG kh, DONHANG dh where kh.MaKhachHang = dh.MaKhachHang and dh.MaDonHang = " + maDh;
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                khDto.MaKhachHang = (int)reader["MaKhachHang"];
                khDto.HoTen = (string)reader["HoTen"];
                khDto.DiaChi = (string)reader["DiaChi"];
                khDto.DienThoai = (string)reader["DienThoai"];
                khDto.Email = (string)reader["Email"];
                khDto.Facebook = (string)reader["Facebook"];
                khDto.TKNganHang = (string)reader["TKNganHang"];
            }

            reader.Close();
            connection.Close();
            return khDto;
        }
    }
}
