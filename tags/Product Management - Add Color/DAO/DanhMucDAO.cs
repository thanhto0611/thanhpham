using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class DanhMucDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from DANHMUC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            DanhMucDTO DANHMUC = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from DANHMUC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DANHMUC = new DanhMucDTO();

                DANHMUC.MaDanhMuc = (int)reader["MaDanhMuc"];
                DANHMUC.TenDanhMuc = (string)reader["TenDanhMuc"];
                arrList.Add(DANHMUC);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from DANHMUC";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(DanhMucDTO DANHMUC)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into DANHMUC(TenDanhMuc) values(?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenDanhMuc", OleDbType.VarWChar);
            command.Parameters["@TenDanhMuc"].Value = DANHMUC.TenDanhMuc;

            command.ExecuteNonQuery();

            command.CommandText = "select @@IDENTITY";
            DANHMUC.MaDanhMuc = (int)command.ExecuteScalar();

            connection.Close();
        }
        public static bool Modify(DanhMucDTO danhMuc)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update DANHMUC set TenDanhMuc = ? where MaDanhMuc = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenDanhMuc", OleDbType.VarWChar);
            command.Parameters.Add("@MaDanhMuc", OleDbType.Integer);

            command.Parameters["@TenDanhMuc"].Value = danhMuc.TenDanhMuc;
            command.Parameters["@MaDanhMuc"].Value = danhMuc.MaDanhMuc;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }

            return result;
        }

        public static bool Delete(int MaDanhMuc)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from DANHMUC where MaDanhMuc = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDanhMuc", OleDbType.Integer);
            command.Parameters["@MaDanhMuc"].Value = MaDanhMuc;

            int row = command.ExecuteNonQuery();

            if (row > 0)
            {
                result = true;
            }
            connection.Close();
            return result;
        }

        public DanhMucDTO LayTenDanhMuc(int maTG)
        {


            DanhMucDTO DANHMUC = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from DANHMUC where MaDanhMuc = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDanhMuc", OleDbType.Integer);

            command.Parameters["@MaDanhMuc"].Value = maTG;
            OleDbDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                DANHMUC = new DanhMucDTO();

                DANHMUC.MaDanhMuc = (int)reader["MaDanhMuc"];
                DANHMUC.TenDanhMuc = (string)reader["TenDanhMuc"];
            }
            reader.Close();
            connection.Close();
            return DANHMUC;
        }

        public DanhMucDTO LayMaDanhMuc(string tenDM)
        {
            DanhMucDTO DANHMUC = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from DANHMUC where TenDanhMuc like ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@TenDanhMuc", OleDbType.VarWChar);

            command.Parameters["@TenDanhMuc"].Value = tenDM;
            OleDbDataReader reader = command.ExecuteReader();



            while (reader.Read())
            {
                DANHMUC = new DanhMucDTO();

                DANHMUC.MaDanhMuc = (int)reader["MaDanhMuc"];
                DANHMUC.TenDanhMuc = (string)reader["TenDanhMuc"];
            }
            reader.Close();
            connection.Close();
            return DANHMUC;
        }
    }
}
