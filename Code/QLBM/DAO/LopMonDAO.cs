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
    public class LopMonDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOPMON";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            LopMonDTO lopMonDTO = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOPMON";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lopMonDTO = new LopMonDTO();

                lopMonDTO.MaLopMon = (int)reader["MaLopMon"];
                lopMonDTO.MaLop = (int)reader["MaLop"];
                lopMonDTO.MaMon = (int)reader["MaMon"];
                arrList.Add(lopMonDTO);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOPMON";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void UpdateRecord(LopMonDTO lopMonDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update LOPMON Set [MaLop] = ?, [MaMon] = ? Where [MaLopMon] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MaLop", OleDbType.Integer);
            command.Parameters.Add("@MaMon", OleDbType.Integer);
            command.Parameters.Add("@MaLopMon", OleDbType.Integer);

            command.Parameters["@MaLop"].Value = lopMonDTO.MaLop;
            command.Parameters["@MaMon"].Value = lopMonDTO.MaMon;
            command.Parameters["@MaLopMon"].Value = lopMonDTO.MaLopMon;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Insert(LopMonDTO lopMonDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into LopMON(MaLop, MaMon) values(?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MaLop", OleDbType.Numeric);
            command.Parameters.Add("@MaMon", OleDbType.Numeric);

            command.Parameters["@MaLop"].Value = lopMonDTO.MaLop;
            command.Parameters["@MaMon"].Value = lopMonDTO.MaMon;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            lopMonDTO.MaLopMon = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static bool Delete(int maLopMon)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from LopMON where MaLopMon = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaLopMon", OleDbType.Integer);
            command.Parameters["@MaLopMon"].Value = maLopMon;

            int row = command.ExecuteNonQuery();
            if (row > 0)
                result = true;
            connection.Close();
            return result;
        }
    }
}
