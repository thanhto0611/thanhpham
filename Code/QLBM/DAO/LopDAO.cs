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
    public class LopDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOP";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            LopDTO lop = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOP";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lop = new LopDTO();

                lop.MaLop = (int)reader["MaLop"];
                lop.TenLop = (string)reader["TenLop"];
                lop.SoLuongSinhVien = (long)reader["SoLuongSinhVien"];
                lop.SoLuongTrongNganSach = (long)reader["SoLuongTrongNganSach"];
                lop.SoLuongNgoaiNganSach = (long)reader["SoLuongNgoaiNganSach"];
                arrList.Add(lop);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }

        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOP";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }

        public static void UpdateRecord(LopDTO lopDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update LOP Set [TenLop] = ? , [SoLuongSinhVien] = ? , [SoLuongTrongNganSach] = ? , [SoLuongNgoaiNganSach] = ? Where [MaLop] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenLop", OleDbType.WChar);
            command.Parameters.Add("@SoLuongSinhVien", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongTrongNganSach", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongNgoaiNganSach", OleDbType.Numeric);
            command.Parameters.Add("@MaLop", OleDbType.Integer);

            command.Parameters["@TenLop"].Value = lopDTO.TenLop;
            command.Parameters["@SoLuongSinhVien"].Value = lopDTO.SoLuongSinhVien;
            command.Parameters["@SoLuongTrongNganSach"].Value = lopDTO.SoLuongTrongNganSach;
            command.Parameters["@SoLuongNgoaiNganSach"].Value = lopDTO.SoLuongNgoaiNganSach;
            command.Parameters["@MaLop"].Value = lopDTO.MaLop;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Insert(LopDTO lopDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into LOP(TenLop, SoLuongSinhVien, SoLuongTrongNganSach, SoLuongNgoaiNganSach) values(?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenLop", OleDbType.WChar);
            command.Parameters.Add("@SoLuongSinhVien", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongTrongNganSach", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongNgoaiNganSach", OleDbType.Numeric);

            command.Parameters["@TenLop"].Value = lopDTO.TenLop;
            command.Parameters["@SoLuongSinhVien"].Value = lopDTO.SoLuongSinhVien;
            command.Parameters["@SoLuongTrongNganSach"].Value = lopDTO.SoLuongTrongNganSach;
            command.Parameters["@SoLuongNgoaiNganSach"].Value = lopDTO.SoLuongNgoaiNganSach;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            lopDTO.MaLop = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static bool Delete(int maLop)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from LOP where MaLop = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaLop", OleDbType.Integer);
            command.Parameters["@MaLop"].Value = maLop;

            int row = command.ExecuteNonQuery();
            if (row > 0)
                result = true;
            connection.Close();
            return result;
        }
    }
}
