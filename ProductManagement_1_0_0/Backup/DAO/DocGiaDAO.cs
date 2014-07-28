using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class DocGiaDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from DOCGIA";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();
            DocGiaDTO DocGia;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from DOCGIA";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DocGia = new DocGiaDTO();

                DocGia.MaDocGia = (int)reader["MaDG"];
                DocGia.HoTen = (string)reader["HoTen"];
                DocGia.DiaChi = (string)reader["DiaChi"];
                DocGia.DienThoai = (string)reader["DienThoai"];

                arrList.Add(DocGia);
            }

            reader.Close();
            connection.Close();
            return arrList;
        }
        public void GetDocGia(DocGiaDTO DocGiaDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from DOCGIA where MaDG =" + DocGiaDTO.MaDocGia;
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                DocGiaDTO.HoTen = (string)reader["HoTen"];
                DocGiaDTO.DiaChi = (string)reader["DiaChi"];
                DocGiaDTO.DienThoai = (string)reader["DienThoai"];
            }
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from DOCGIA";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adapter);

            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(DocGiaDTO DocGia)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into DOCGIA( HoTen, DiaChi, DienThoai) values (?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@HoTen", OleDbType.VarWChar);
            command.Parameters.Add("@DiaChi", OleDbType.VarWChar);
            command.Parameters.Add("@DienThoai", OleDbType.VarWChar);

            command.Parameters["@HoTen"].Value = DocGia.HoTen;
            command.Parameters["@DiaChi"].Value = DocGia.DiaChi;
            command.Parameters["@DienThoai"].Value = DocGia.DienThoai;

            command.ExecuteNonQuery();

            command.CommandText = "Select @@IDENTITY";
            DocGia.MaDocGia = (int)command.ExecuteScalar();

            connection.Close();

        }
        public static DocGiaDTO Search(int MaDG)
        {
            DocGiaDTO DocGia = null;
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from DOCGIA where MaDG = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDG", OleDbType.Integer);
            command.Parameters["@MaDG"].Value = MaDG;
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                DocGia = new DocGiaDTO();

                DocGia.MaDocGia = (int)reader["MaDG"];
                DocGia.HoTen = (string)reader["HoTen"];
                DocGia.DiaChi = (string)reader["DiaChi"];
                DocGia.DienThoai = (string)reader["DienThoai"];
            }

            reader.Close();
            connection.Close();
            return DocGia;
        }
        public static bool Delete(int MaDG)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Delete * from DocGia where MaDG = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDG", OleDbType.Integer);
            command.Parameters["@MaDG"].Value = MaDG;

            int row = command.ExecuteNonQuery();

            if (row > 0)
                result = true;

            connection.Close();
            return result;
        }
        public void UpdateDocGia(DocGiaDTO docgiaDTO)
        {
            OleDbConnection cn = DataProvider.CreateConnection();
            string strSql = "Update DOCGIA set HoTen = ?, DiaChi = ?, DienThoai = ? where MaDG=" + docgiaDTO.MaDocGia;
            OleDbCommand cmd = new OleDbCommand(strSql, cn);
            cmd.Parameters.Add("@HoTen", OleDbType.WChar);
            cmd.Parameters.Add("@DiaChi", OleDbType.WChar);
            cmd.Parameters.Add("@DienThoai", OleDbType.WChar);
            
            cmd.Parameters["@HoTen"].Value = docgiaDTO.HoTen;
            cmd.Parameters["@DiaChi"].Value = docgiaDTO.DiaChi;
            cmd.Parameters["@DienThoai"].Value = docgiaDTO.DienThoai;
            cmd.ExecuteNonQuery();
            cn.Close();
        }
       
    }
}
