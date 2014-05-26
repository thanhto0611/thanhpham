using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class SachDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from SACH ";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

         public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            SachDTO Sach = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from SACH";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Sach = new SachDTO();

                Sach.MaSach = (int)reader["MaSach"];
                Sach.TenSach = (string)reader["TenSach"];
                Sach.MaTacGia = (int)reader["MaTG"];
                Sach.MaNXB = (int)reader["MaNXB"];
                Sach.MaTheLoai = (int)reader["MaLoai"];
                Sach.NgayNhap = (DateTime)reader["NgayNhap"];
                Sach.SoTrang = (int)reader["SoTrang"];
                Sach.TrangThai = (int)reader["TrangThai"];
                Sach.MaNgonNgu = (int)reader["MaNN"];
                arrList.Add(Sach);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from SACH";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public void UpdateRecord (int MaSach, bool Type)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "update SACH set TrangThai = ? where MaSach = ?";
            OleDbCommand command = new OleDbCommand(cmdText,connection);

            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            
            if(Type == true)
                command.Parameters["@TrangThai"].Value = 0;
            else
                command.Parameters["@TrangThai"].Value = 1;
            

            command.Parameters.Add("@MaSach", OleDbType.Integer);
            command.Parameters["@MaSach"].Value = MaSach;
            command.ExecuteNonQuery();
            connection.Close();
        }
        public  void Insert(SachDTO Sach)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into SACH(TenSach, MaTG, MaNXB, MaLoai, NgayNhap, SoTrang, TrangThai, MaNN) values(?,?,?,?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@TenSach", OleDbType.VarWChar);
            command.Parameters["@TenSach"].Value = Sach.TenSach;

            command.Parameters.Add("@MaTG", OleDbType.Integer);
            command.Parameters["@MaTG"].Value = Sach.MaTacGia;

            command.Parameters.Add("@MaNXB", OleDbType.Integer);
            command.Parameters["@MaNXB"].Value = Sach.MaNXB;


            command.Parameters.Add("@MaLoai", OleDbType.Integer);
            command.Parameters["@MaLoai"].Value = Sach.MaTacGia;

            command.Parameters.Add("@NgayNhap", OleDbType.Date);
            command.Parameters["@NgayNhap"].Value = Sach.NgayNhap;

            
            command.Parameters.Add("@SoTrang", OleDbType.Integer);
            command.Parameters["@SoTrang"].Value = Sach.SoTrang;

            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            command.Parameters["@TrangThai"].Value = Sach.TrangThai;

            command.Parameters.Add("@MaNN", OleDbType.Integer);
            command.Parameters["@MaNN"].Value = Sach.MaNgonNgu;
            command.ExecuteNonQuery();

            command.CommandText = "select @@IDENTITY";
            Sach.MaSach = (int)command.ExecuteScalar();
            connection.Close();
        }
        public void  Delete(int MaSach)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from SACH where MaSach = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaSach", OleDbType.Integer);
            command.Parameters["@MaSach"].Value = MaSach;

            command.ExecuteNonQuery();

            
            connection.Close();
            
        }

        public static DataTable LayBangMaSach(int masach)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from SACH where MaSach = " + masach;
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable LayBangTacGia(int matg)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from SACH where MaTG = " + matg;
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        public static DataTable Search(string query)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select MaSach, TenSach from SACH where TenSach Like ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@TenSach", OleDbType.VarWChar);
            command.Parameters["@TenSach"].Value = "%" + query + "%";

            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
        public static DataTable Search_DTO(SachDTO sach, bool NgonNguChk, bool TheLoaiChk)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            OleDbCommand command = BuildQuery(sach,NgonNguChk,TheLoaiChk, connection);
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
        private static OleDbCommand BuildQuery(SachDTO sach, bool NgonNguChk, bool TheLoaiChk, OleDbConnection connection)
        {
            OleDbCommand command = new OleDbCommand();

            String dkMaSach = " 1=1 ";
            String dkMaNN = " 1=1 ";
            String dkTenSach = " 1=1 ";
            String dkTL = " 1=1 ";

            if (sach.MaSach != 0)
            {
                dkMaSach = " MaSach = ? ";
                command.Parameters.Add("@MaSach", OleDbType.Integer);
                command.Parameters["@MaSach"].Value = sach.MaSach;
            }

            if (sach.TenSach.Length > 0)
            {
                dkTenSach = " TenSach like ? ";
                command.Parameters.Add("@TenSach", OleDbType.VarWChar);
                command.Parameters["@TenSach"].Value = "%" + sach.TenSach + "%";
            }

            if (NgonNguChk)
            {
                dkMaNN = " MaNN = ? ";
                command.Parameters.Add("@MaNN", OleDbType.Integer);
                command.Parameters["@MaNN"].Value = sach.MaNgonNgu;
            }

            if (TheLoaiChk)
            {
                dkTL = " MaLoai = ? ";
                command.Parameters.Add("@MaLoai", OleDbType.Integer);
                command.Parameters["@MaLoai"].Value = sach.MaTheLoai;
            }

            StringBuilder dkWhere = new StringBuilder();
            dkWhere.AppendLine(" Where ");
            dkWhere.Append(dkMaSach);
            dkWhere.AppendFormat(" and {0} ", dkTenSach);
            dkWhere.AppendFormat(" and {0} ", dkMaNN);
            dkWhere.AppendFormat(" and {0} ", dkTL);

            StringBuilder cmdText = new StringBuilder();
            cmdText.AppendLine("Select * From SACH");
            cmdText.AppendLine(dkWhere.ToString());
            cmdText.AppendLine("Order by TenSach");

            command.Connection = connection;
            command.CommandText = cmdText.ToString();

            return command;
        }

        public SachDTO Search_MaSach(int maSach)
        {
            SachDTO sachDTO = null;
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from SACH where MaSach = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaSach", OleDbType.Integer);
            command.Parameters["@MaSach"].Value = maSach;
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                sachDTO = new SachDTO();

                sachDTO.TenSach = (string)reader["TenSach"];
                sachDTO.MaNXB = (int)reader["MaNXB"];
                sachDTO.MaTacGia = (int)reader["MaTG"];
                sachDTO.MaTheLoai = (int)reader["MaLoai"];
                sachDTO.MaNgonNgu=(int)reader["MaNN"];
                sachDTO.SoTrang = (int)reader["SoTrang"];
                sachDTO.TrangThai = (int)reader["TrangThai"];
                
            }

            reader.Close();
            connection.Close();
            return sachDTO;
        }

        public void Update(SachDTO sachDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update SACH Set [TenSach] = ? , [MaTG] = ? , [MaNXB] = ? , [MaLoai] = ? , [SoTrang] = ? , [TrangThai] = ? , [MaNN] = ? Where [MaSach] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            
            command.Parameters.Add("@TenSach", OleDbType.WChar);
            command.Parameters.Add("@MaTG", OleDbType.Integer);
            command.Parameters.Add("@MaNXB", OleDbType.Integer);
            command.Parameters.Add("@MaLoai", OleDbType.Integer);
            command.Parameters.Add("@SoTrang", OleDbType.Integer);
            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            command.Parameters.Add("@MaNN", OleDbType.Integer);
            command.Parameters.Add("@MaSach", OleDbType.Integer);

            
            command.Parameters["@TenSach"].Value = sachDTO.TenSach;
            command.Parameters["@MaTG"].Value = sachDTO.MaTacGia;
            command.Parameters["@MaNXB"].Value = sachDTO.MaNXB;
            command.Parameters["@MaLoai"].Value = sachDTO.MaTheLoai;
            command.Parameters["@SoTrang"].Value = sachDTO.SoTrang;
            command.Parameters["@TrangThai"].Value = sachDTO.TrangThai;
            command.Parameters["@MaNN"].Value = sachDTO.MaNgonNgu;
            command.Parameters["@MaSach"].Value = sachDTO.MaSach;


            
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
