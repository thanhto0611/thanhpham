using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class NhanVienDAO
    {
        public NhanVienDTO Search(string Username)
        {
            NhanVienDTO NhanVien = null;
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from NHANVIEN where Username = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@Username", OleDbType.WChar);
            command.Parameters["@Username"].Value = Username;
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                NhanVien = new NhanVienDTO();

                NhanVien.Username = (string)reader["Username"];
                NhanVien.Password = (string)reader["Password"];
                NhanVien.HoTen = (string)reader["HoTen"];
                NhanVien.DiaChi = (string)reader["DiaChi"];
                NhanVien.DienThoai = (string)reader["DienThoai"];
                NhanVien.Email = (string)reader["Email"];
                NhanVien.Loai = (int)reader["Loai"];
            }

            reader.Close();
            connection.Close();
            return NhanVien;
        }

        public void Insert(NhanVienDTO NhanVien)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into NHANVIEN([Username], [Password], [HoTen], [DiaChi], [DienThoai], [Email], [Loai]) values (?, ?, ?, ?, ?, ?, ?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@Username", OleDbType.VarWChar);
            command.Parameters.Add("@Password", OleDbType.VarWChar);
            command.Parameters.Add("@HoTen", OleDbType.VarWChar);
            command.Parameters.Add("@DiaChi", OleDbType.VarWChar);
            command.Parameters.Add("@DienThoai", OleDbType.VarWChar);
            command.Parameters.Add("@Email", OleDbType.VarWChar);
            command.Parameters.Add("@Loai", OleDbType.Integer);

            command.Parameters["@Username"].Value = NhanVien.Username;
            command.Parameters["@Password"].Value = NhanVien.Password;
            command.Parameters["@HoTen"].Value = NhanVien.HoTen;
            command.Parameters["@DiaChi"].Value = NhanVien.DiaChi;
            command.Parameters["@DienThoai"].Value = NhanVien.DienThoai;
            command.Parameters["@Email"].Value = NhanVien.DienThoai;
            command.Parameters["@Loai"].Value = NhanVien.Loai;

            command.ExecuteNonQuery();

            /*command.CommandText = "Select @@IDENTITY";
            NhanVien.MaDocGia = (int)command.ExecuteScalar();*/

            connection.Close();

        }
    }
}
