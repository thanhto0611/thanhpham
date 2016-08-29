using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class PhieuMuonDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from PHIEUMUON";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);

            connection.Close();
            return dataTable;
        }
        public static DataTable GetBook (int MaDG)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select s.MaSach, s.TenSach from PHIEUMUON pm, CHITIETMUON ctm, SACH s where pm.MaPhieuMuon = ctm.MaPhieuMuon and s.MaSach = ctm.MaSach and s.TrangThai = 0 and pm.MaDG = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaDG", OleDbType.Integer);
            command.Parameters["@MaDG"].Value = MaDG;
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            adapter.Fill(dataTable);
            return dataTable;
        }
        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            PhieuMuonDTO PhieuMuon = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from PHIEUMUON";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PhieuMuon = new PhieuMuonDTO();
                PhieuMuon.MaDocGia = (int)reader["MaDocGia"];
                PhieuMuon.MaPhieuMuon = (int)reader["MaPhieuMuon"];
                PhieuMuon.NgayMuon = (DateTime)reader["NgayMuon"];
                arrList.Add(PhieuMuon);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from PhieuMuon";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void Insert(PhieuMuonDTO PhieuMuon)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into PHIEUMUON(NgayMuon, MaDG) values(?, ?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@NgayMuon", OleDbType.Date);
            command.Parameters.Add("@MaDG", OleDbType.Integer);

            command.Parameters["@NgayMuon"].Value = PhieuMuon.NgayMuon;
            command.Parameters["@MaDG"].Value = PhieuMuon.MaDocGia;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            PhieuMuon.MaPhieuMuon = (int)command.ExecuteScalar();
            connection.Close();
        }
        public static bool Delete(int MaPhieuMuon)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from PHIEUMUON where MaPhieuMuon = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaPhieuMuon", OleDbType.Integer);
            command.Parameters["@MaPhieuMuon"].Value = MaPhieuMuon;

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
