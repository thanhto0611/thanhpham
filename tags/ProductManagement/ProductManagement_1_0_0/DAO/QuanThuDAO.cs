using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class QuanThuDAO
    {
        public QuanThuDTO Search(string Username)
        {
            QuanThuDTO QuanThu = null;
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from QUANTHU where Username = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@Username", OleDbType.WChar);
            command.Parameters["@Username"].Value = Username;
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                QuanThu = new QuanThuDTO();

                QuanThu.Username = (string)reader["Username"];
                QuanThu.Password = (string)reader["Password"];
                QuanThu.HoTen = (string)reader["HoTen"];
                QuanThu.DiaChi = (string)reader["DiaChi"];
                QuanThu.DienThoai = (string)reader["DienThoai"];
                QuanThu.Loai = (int)reader["Loai"];
            }

            reader.Close();
            connection.Close();
            return QuanThu;
        }

        public void Insert(QuanThuDTO QuanThu)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into QUANTHU([Username], [Password], [HoTen], [DiaChi], [DienThoai], [Loai]) values (?, ?, ?, ?, ?, ?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@Username", OleDbType.VarWChar);
            command.Parameters.Add("@Password", OleDbType.VarWChar);
            command.Parameters.Add("@HoTen", OleDbType.VarWChar);
            command.Parameters.Add("@DiaChi", OleDbType.VarWChar);
            command.Parameters.Add("@DienThoai", OleDbType.VarWChar);
            command.Parameters.Add("@Loai", OleDbType.Integer);

            command.Parameters["@Username"].Value = QuanThu.Username;
            command.Parameters["@Password"].Value = QuanThu.Password;
            command.Parameters["@HoTen"].Value = QuanThu.HoTen;
            command.Parameters["@DiaChi"].Value = QuanThu.DiaChi;
            command.Parameters["@DienThoai"].Value = QuanThu.DienThoai;
            command.Parameters["@Loai"].Value = QuanThu.Loai;

            command.ExecuteNonQuery();

            /*command.CommandText = "Select @@IDENTITY";
            QuanThu.MaDocGia = (int)command.ExecuteScalar();*/

            connection.Close();

        }
    }
}
