using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class ChiTietMuonDAO
    {
        public static DataTable GetTable()
        {
            DataTable datatable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CHITIETMUON";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);


            adapter.Fill(datatable);

            connection.Close();
            return datatable;
        }
        public static IList GetList()
        {
            ArrayList arrCTMuon = new ArrayList();
            ChiTietMuonDTO CTMuon;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from CHITIETMUON";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CTMuon = new ChiTietMuonDTO();
                CTMuon.MaSach = (int)reader["MaSach"];
                CTMuon.MaPhieuMuon = (int)reader["MaPhieuMuon"];
                CTMuon.NgayTra = (DateTime)reader["NgayTra"];

                arrCTMuon.Add(CTMuon);
            }
            reader.Close();
            connection.Close();
            return arrCTMuon;
        }
        public static void UpdateTable(DataTable datatable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CHITIETMUON";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(adpter);

            adpter.Update(datatable);
            connection.Close();
        }

        public static ChiTietMuonDTO Search(int MaPhieuMuon)
        {
            ChiTietMuonDTO CTMuon = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from CHITIETMUON where MaPhieuMuon = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaPhieuMuon", OleDbType.Integer);
            command.Parameters["@MaPhieuMuon"].Value = MaPhieuMuon;
            OleDbDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                CTMuon = new ChiTietMuonDTO();

                CTMuon.MaPhieuMuon = (int)reader["MaPhieuMuon"];
                CTMuon.MaSach = (int)reader["MaSach"];
                CTMuon.NgayTra = (DateTime)reader["NgayTra"];
            }

            reader.Close();
            connection.Close();
            return CTMuon;
        }
        public static void Insert(ChiTietMuonDTO CTMuon)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into CHITIETMUON(MaSach, NgayTra) values(?,?) ";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MaSach", OleDbType.Integer);

            command.Parameters["@MaSach"].Value = CTMuon.MaSach;
            
            command.Parameters.Add("@NgayTra", OleDbType.Date);

            command.Parameters["@NgayTra"].Value = CTMuon.NgayTra;

            command.ExecuteNonQuery();
            command.CommandText = "Select @@IDENTITY";
            CTMuon.MaPhieuMuon = (int)command.ExecuteScalar();
            // CTMuon.MaSach = (int)command.ExecuteScalar();
            connection.Close();

        }
    }
}
