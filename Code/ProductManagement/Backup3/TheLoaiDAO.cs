using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class TheLoaiDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from THELOAI";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            TheLoaiDTO theLoai = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from THELOAI";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                theLoai = new TheLoaiDTO();

                theLoai.MaLoai = (int)reader["MaLoai"];
                theLoai.TenTheLoai = (string)reader["TenTheLoai"];
                arrList.Add(theLoai);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from THELOAI";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(TheLoaiDTO theLoai)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into THELOAI(TenTheLoai) values(?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenTheLoai", OleDbType.VarWChar);
            command.Parameters["@TenTheLoai"].Value = theLoai.TenTheLoai;

            command.ExecuteNonQuery();

            command.CommandText = "select @@IDENTITY";
            theLoai.MaLoai = (int)command.ExecuteScalar();

            connection.Close();
        }
        public static bool Modify (TheLoaiDTO theLoai)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update THELOAI set TenTheLoai = ? where MaLoai = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenTheLoai", OleDbType.VarWChar);
            command.Parameters.Add("@MaLoai", OleDbType.Integer);

            command.Parameters["@TenTheLoai"].Value = theLoai.TenTheLoai;
            command.Parameters["@MaLoai"].Value = theLoai.MaLoai;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }

            return result;
        }
        public static bool Delete(int MaLoai)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from THELOAI where MaLoai = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaLoai", OleDbType.Integer);
            command.Parameters["@MaLoai"].Value = MaLoai;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }
            connection.Close();
            return result;
        }

        public TheLoaiDTO LayTenTheLoai(int maTL)
        {


            TheLoaiDTO tl = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from THELOAI where MaLoai = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaLoai", OleDbType.Integer);

            command.Parameters["@MaLoai"].Value = maTL;
            OleDbDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                tl = new TheLoaiDTO();

                tl.MaLoai = (int)reader["MaLoai"];
                tl.TenTheLoai = (string)reader["TenTheLoai"];
            }
            reader.Close();
            connection.Close();
            return tl;
        }
    }
}
