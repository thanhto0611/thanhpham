using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class NhaXuatBanDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NHAXUATBAN";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            NhaXuatBanDTO NXB = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NHAXUATBAN";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                NXB = new NhaXuatBanDTO();

                NXB.MaNXB = (int)reader["MaNXB"];
                NXB.TenNXB = (string)reader["TenNXB"];

                arrList.Add(NXB);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NHAXUATBAN";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(NhaXuatBanDTO NXB)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into NHAXUATBAN(TenNXB) values(?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenNXB", OleDbType.VarWChar);
            command.Parameters["@TenNXB"].Value = NXB.TenNXB;

            command.ExecuteNonQuery();

            command.CommandText = "select @@IDENTITY";
            NXB.MaNXB = (int)command.ExecuteScalar();

            connection.Close();
        }
        public static bool Modify(NhaXuatBanDTO NXB)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update NHAXUATBAN set TenNXB = ? where MaNXB = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenNXB", OleDbType.VarWChar);
            command.Parameters.Add("@MaNXB", OleDbType.Integer);

            command.Parameters["@TenNXB"].Value = NXB.TenNXB;
            command.Parameters["@MaNXB"].Value = NXB.MaNXB;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }

            return result;
        }
        public static bool Delete(int MaNXB)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from NHAXUATBAN where MaNXB = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaNXB", OleDbType.Integer);
            command.Parameters["@MaNXB"].Value = MaNXB;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }
            connection.Close();
            return result;
        }

        public NhaXuatBanDTO LayTenNhaXuatBan(int maNXB)
        {


            NhaXuatBanDTO nxb = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NHAXUATBAN where MaNXB = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaNXB", OleDbType.Integer);

            command.Parameters["@MaNXB"].Value = maNXB;
            OleDbDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                nxb = new NhaXuatBanDTO();

                nxb.MaNXB = (int)reader["MaNXB"];
                nxb.TenNXB = (string)reader["TenNXB"];
            }
            reader.Close();
            connection.Close();
            return nxb;
        }
    }
}
