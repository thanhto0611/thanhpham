using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class GiangVienDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from GIANGVIEN";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable GetTable(string thongTinGiangVien)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from GIANGVIEN where [TenGiangVien] like '%" + thongTinGiangVien + "%' or [SoDienThoai] like '%" + thongTinGiangVien + "%' or [DiaChi] like '%" + thongTinGiangVien + "%' or [Email] like '%" + thongTinGiangVien + "%' order by TenGiangVien ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            GiangVienDTO giangVienDTO = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from GIANGVIEN";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                giangVienDTO = new GiangVienDTO();

                giangVienDTO.MaGiangVien = (int)reader["MaGiangVien"];
                giangVienDTO.TenGiangVien = (string)reader["TenGiangVien"];
                giangVienDTO.DiaChi = (string)reader["DiaChi"];
                giangVienDTO.SoDienThoai = (string)reader["SoDienThoai"];
                giangVienDTO.Email = (string)reader["Email"];
                arrList.Add(giangVienDTO);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }

        public static GiangVienDTO TimTheoMaGiangVien(int maGiangVien)
        {
            ArrayList arrList = new ArrayList();

            GiangVienDTO giangVienDTO = new GiangVienDTO();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from GIANGVIEN where MaGiangVien = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaGiangVien", OleDbType.Integer);
            command.Parameters["@MaGiangVien"].Value = maGiangVien;
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                giangVienDTO.MaGiangVien = (int)reader["MaGiangVien"];
                giangVienDTO.TenGiangVien = (string)reader["TenGiangVien"];
                giangVienDTO.DiaChi = (string)reader["DiaChi"];
                giangVienDTO.SoDienThoai = (string)reader["SoDienThoai"];
                giangVienDTO.Email = (string)reader["Email"];
                arrList.Add(giangVienDTO);
            }
            reader.Close();
            connection.Close();
            return giangVienDTO;
        }

        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from GIANGVIEN";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void UpdateRecord(GiangVienDTO giangVienDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update GIANGVIEN Set [TenGiangVien] = ?, [DiaChi] = ?, [SoDienThoai] = ?, [Email] = ? Where [MaGiangVien] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenGiangVien", OleDbType.WChar);
            command.Parameters.Add("@DiaChi", OleDbType.WChar);
            command.Parameters.Add("@SoDienThoai", OleDbType.WChar);
            command.Parameters.Add("@Email", OleDbType.WChar);
            command.Parameters.Add("@MaGiangVien", OleDbType.Integer);

            command.Parameters["@TenGiangVien"].Value = giangVienDTO.TenGiangVien;
            command.Parameters["@DiaChi"].Value = giangVienDTO.DiaChi;
            command.Parameters["@SoDienThoai"].Value = giangVienDTO.SoDienThoai;
            command.Parameters["@Email"].Value = giangVienDTO.Email;
            command.Parameters["@MaGiangVien"].Value = giangVienDTO.MaGiangVien;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Insert(GiangVienDTO giangVienDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into GIANGVIEN(TenGiangVien, SoDienThoai, DiaChi, Email) values(?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenGiangVien", OleDbType.WChar);
            command.Parameters.Add("@SoDienThoai", OleDbType.WChar);
            command.Parameters.Add("@DiaChi", OleDbType.WChar);
            command.Parameters.Add("@Email", OleDbType.WChar);

            command.Parameters["@TenGiangVien"].Value = giangVienDTO.TenGiangVien;
            command.Parameters["@SoDienThoai"].Value = giangVienDTO.SoDienThoai;
            command.Parameters["@DiaChi"].Value = giangVienDTO.DiaChi;
            command.Parameters["@Email"].Value = giangVienDTO.Email;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            giangVienDTO.MaGiangVien = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static bool Delete(int maGiangVien)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from GIANGVIEN where MaGiangVien = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaGiangVien", OleDbType.Integer);
            command.Parameters["@MaGiangVien"].Value = maGiangVien;

            int row = command.ExecuteNonQuery();
            if (row > 0)
                result = true;
            connection.Close();
            return result;
        }
    }
}
