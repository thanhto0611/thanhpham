using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;
namespace DAO
{
    public class PhieuPhatDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from PHIEUPHAT";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }
        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            PhieuPhatDTO PhieuPhat = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from PHIEUPHAT";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PhieuPhat = new PhieuPhatDTO();
                PhieuPhat.MaPhieuPhat = (int)reader["MaPhieuPhat"];
                PhieuPhat.MaDocGia = (int)reader["MaDG"];
                PhieuPhat.TenPhieu = (string)reader["TenPhieu"];
                PhieuPhat.SoTien = (long)reader["SoTienThu"];
                arrList.Add(PhieuPhat);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from PHIEUPHAT";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(PhieuPhatDTO PhieuPhat)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into PhieuPhat(MaDG, TenPhieu, SoTienThu) values(?, ?, ?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDG", OleDbType.Integer);
            command.Parameters.Add("@TenPhieu", OleDbType.VarWChar);
            command.Parameters.Add("@SoTienThu", OleDbType.Integer);

            command.Parameters["@MaDG"].Value = PhieuPhat.MaDocGia;
            command.Parameters["@TenPhieu"].Value = PhieuPhat.TenPhieu;
            command.Parameters["@SoTienThu"].Value = PhieuPhat.SoTien;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            PhieuPhat.MaPhieuPhat = (int)command.ExecuteScalar();
            connection.Close();
        }
        public static bool Delete(int MaPhieuPhat)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from PHIEUPHAT where MaPhieuPhat = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaPhieuPhat", OleDbType.Integer);
            command.Parameters["@MaPhieuPhat"].Value = MaPhieuPhat;

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
