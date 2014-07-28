using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class NgonNguDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NGONNGU";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            NgonNguDTO NgonNgu = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NGONNGU";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                NgonNgu = new NgonNguDTO();

                NgonNgu.MaNgonNgu = (int)reader["MaNgonNgu"];
                NgonNgu.TenNgonNgu = (string)reader["TenNgonNgu"];

                arrList.Add(NgonNgu);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NGONNGU";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(NgonNguDTO NgonNgu)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into NGONNGU(TenNgonNgu) values(?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenNgonNgu", OleDbType.VarWChar);
            command.Parameters["@TenNgonNgu"].Value = NgonNgu.TenNgonNgu;

            command.ExecuteNonQuery();

            command.CommandText = "select @@IDENTITY";
            NgonNgu.MaNgonNgu = (int)command.ExecuteScalar();

            connection.Close();
        }
        public static bool Modify(NgonNguDTO ngoNgu)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update NGONNGU set TenNgonNgu = ? where MaNgonNgu = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenNgonNgu", OleDbType.VarWChar);
            command.Parameters.Add("@MaNgonNgu", OleDbType.Integer);

            command.Parameters["@TenNgonNgu"].Value = ngoNgu.TenNgonNgu;
            command.Parameters["@MaNgonNgu"].Value = ngoNgu.MaNgonNgu;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }

            return result;
        }
        public static bool Delete(int MaNN)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from NGONNGU where MaNN = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaNgonNgu", OleDbType.Integer);
            command.Parameters["@MaNgonNgu"].Value = MaNN;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }
            connection.Close();
            return result;
        }

        public NgonNguDTO LayTenNgonNgu(int maNN)
        {


            NgonNguDTO nn = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NGONNGU where MaNgonNgu = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaNgonNgu", OleDbType.Integer);

            command.Parameters["@MaNgonNgu"].Value = maNN;
            OleDbDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                nn = new NgonNguDTO();

                nn.MaNgonNgu = (int)reader["MaNgonNgu"];
                nn.TenNgonNgu = (string)reader["TenNgonNgu"];
            }
            reader.Close();
            connection.Close();
            return nn;
        }
    }
}
