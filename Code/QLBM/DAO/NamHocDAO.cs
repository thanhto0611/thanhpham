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
    public class NamHocDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NAMHOC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable GetTable(string namHoc)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NAMHOC where TenNamHoc like '%" + namHoc + "%' order by TenNamHoc DESC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            NamHocDTO namHocDTO = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NAMHOC order by TenNamHoc DESC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                namHocDTO = new NamHocDTO();

                namHocDTO.MaNamHoc = (int)reader["MaNamHoc"];
                namHocDTO.TenNamHoc = (string)reader["TenNamHoc"];
                arrList.Add(namHocDTO);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }


        public static NamHocDTO GetRecord(int maNamHoc)
        {
            ArrayList arrList = new ArrayList();

            NamHocDTO namHocDTO = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NAMHOC where MaNamHoc = ? order by TenNamHoc DESC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaNamHoc", OleDbType.Integer);
            command.Parameters["@MaNamHoc"].Value = maNamHoc;
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                namHocDTO = new NamHocDTO();

                namHocDTO.MaNamHoc = (int)reader["MaNamHoc"];
                namHocDTO.TenNamHoc = (string)reader["TenNamHoc"];
                arrList.Add(namHocDTO);
            }
            reader.Close();
            connection.Close();
            return namHocDTO;
        }

        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from NAMHOC";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void UpdateRecord(NamHocDTO namHocDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update NAMHOC Set [TenNamHoc] = ? Where [MaNamHoc] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenNamHoc", OleDbType.WChar);
            command.Parameters.Add("@MaNamHoc", OleDbType.Integer);

            command.Parameters["@TenNamHoc"].Value = namHocDTO.TenNamHoc;
            command.Parameters["@MaNamHoc"].Value = namHocDTO.MaNamHoc;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Insert(NamHocDTO namHocDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into NAMHOC(TenNamHoc) values(?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenNamHoc", OleDbType.WChar);

            command.Parameters["@TenNamHoc"].Value = namHocDTO.TenNamHoc;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            namHocDTO.MaNamHoc = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static bool Delete(int maNamHoc)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from NAMHOC where MaNamHoc = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaNamHoc", OleDbType.Integer);
            command.Parameters["@MaNamHoc"].Value = maNamHoc;

            int row = command.ExecuteNonQuery();
            if (row > 0)
                result = true;
            connection.Close();
            return result;
        }
    }
}
