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
    public class MonDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from MON";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable GetTable(string tenMon)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from MON where TenMon like '%" + tenMon + "%'";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            MonDTO mon = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from MON";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                mon = new MonDTO();

                mon.MaMon = (int)reader["MaMon"];
                mon.TenMon = (string)reader["TenMon"];
                arrList.Add(mon);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }

        public static MonDTO GetRecord(int maMon)
        {
            ArrayList arrList = new ArrayList();

            MonDTO mon = new MonDTO();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from MON where MaMon = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaMon", OleDbType.Integer);
            command.Parameters["@MaMon"].Value = maMon;
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                mon.MaMon = (int)reader["MaMon"];
                mon.TenMon = (string)reader["TenMon"];
                arrList.Add(mon);
            }
            reader.Close();
            connection.Close();
            return mon;
        }

        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from MON";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void UpdateRecord(MonDTO monDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update MON Set [TenMon] = ? Where [MaMon] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenMon", OleDbType.WChar);
            command.Parameters.Add("@MaMon", OleDbType.Integer);

            command.Parameters["@TenMon"].Value = monDTO.TenMon;
            command.Parameters["@MaMon"].Value = monDTO.MaMon;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Insert(MonDTO monDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into MON(TenMon) values(?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenMon", OleDbType.WChar);

            command.Parameters["@TenMon"].Value = monDTO.TenMon;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            monDTO.MaMon = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static bool Delete(int maMon)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from MON where MaMon = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaMon", OleDbType.Integer);
            command.Parameters["@MaMon"].Value = maMon;

            int row = command.ExecuteNonQuery();
            if (row > 0)
                result = true;
            connection.Close();
            return result;
        }
    }
}
