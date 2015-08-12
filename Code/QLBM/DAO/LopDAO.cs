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
    public class LopDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOP";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            LopDTO lop = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOP";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lop = new LopDTO();

                lop.MaLop = (int)reader["MaLop"];
                lop.TenLop = (string)reader["TenLop"];
                lop.SoLuongSinhVien = (long)reader["SoLuongSinhVien"];
                lop.SoLuongTrongNganSach = (long)reader["SoLuongTrongNganSach"];
                lop.SoLuongNgoaiNganSach = (long)reader["SoLuongNgoaiNganSach"];
                lop.MaNamHoc = (int)reader["MaNamHoc"];
                arrList.Add(lop);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }

        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOP";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }

        public static void UpdateRecord(LopDTO lopDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update LOP Set [TenLop] = ? , [SoLuongSinhVien] = ? , [SoLuongTrongNganSach] = ? , [SoLuongNgoaiNganSach] = ?, [MaNamHoc] = ? Where [MaLop] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenLop", OleDbType.WChar);
            command.Parameters.Add("@SoLuongSinhVien", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongTrongNganSach", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongNgoaiNganSach", OleDbType.Numeric);
            command.Parameters.Add("@MaNamHoc", OleDbType.Integer);
            command.Parameters.Add("@MaLop", OleDbType.Integer);

            command.Parameters["@TenLop"].Value = lopDTO.TenLop;
            command.Parameters["@SoLuongSinhVien"].Value = lopDTO.SoLuongSinhVien;
            command.Parameters["@SoLuongTrongNganSach"].Value = lopDTO.SoLuongTrongNganSach;
            command.Parameters["@SoLuongNgoaiNganSach"].Value = lopDTO.SoLuongNgoaiNganSach;
            command.Parameters["@MaNamHoc"].Value = lopDTO.MaNamHoc;
            command.Parameters["@MaLop"].Value = lopDTO.MaLop;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Insert(LopDTO lopDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into LOP(TenLop, SoLuongSinhVien, SoLuongTrongNganSach, SoLuongNgoaiNganSach, MaNamHoc) values(?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TenLop", OleDbType.WChar);
            command.Parameters.Add("@SoLuongSinhVien", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongTrongNganSach", OleDbType.Numeric);
            command.Parameters.Add("@SoLuongNgoaiNganSach", OleDbType.Numeric);
            command.Parameters.Add("@MaNamHoc", OleDbType.Integer);

            command.Parameters["@TenLop"].Value = lopDTO.TenLop;
            command.Parameters["@SoLuongSinhVien"].Value = lopDTO.SoLuongSinhVien;
            command.Parameters["@SoLuongTrongNganSach"].Value = lopDTO.SoLuongTrongNganSach;
            command.Parameters["@SoLuongNgoaiNganSach"].Value = lopDTO.SoLuongNgoaiNganSach;
            command.Parameters["@MaNamHoc"].Value = lopDTO.MaNamHoc;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            lopDTO.MaLop = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static bool Delete(int maLop)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from LOP where MaLop = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaLop", OleDbType.Integer);
            command.Parameters["@MaLop"].Value = maLop;

            int row = command.ExecuteNonQuery();
            if (row > 0)
                result = true;
            connection.Close();
            return result;
        }

        public static DataTable TimLopTheoTenLop(string tenLop)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from LOP where TenLop like '%" + tenLop + "%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoTenLop(string tenLop, int maNamHoc)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select * from LOP where TenLop like '%" + tenLop + "%' and MaNamHoc = " + maNamHoc.ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangDuong(string giangDuong)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangDuong like '%" + giangDuong + "%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangDuong(string giangDuong, int maNamHoc)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangDuong like '%" + giangDuong + "%' and l.MaNamHoc = " + maNamHoc.ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangVien(string giangVien)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangVien like '%" + giangVien + "%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangVien(string giangVien, int maNamHoc)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangVien like '%" + giangVien + "%' and l.MaNamHoc = " + maNamHoc.ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangDuongThiL1(string giangDuong)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangDuongThiLan1 like '%" + giangDuong + "%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangDuongThiL1(string giangDuong, int maNamHoc)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangDuongThiLan1 like '%" + giangDuong + "%' and l.MaNamHoc = " + maNamHoc.ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoCanBoCoiThiL1(string canBo)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.CanBoCoiThiLan1 like '%" + canBo + "%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoCanBoCoiThiL1(string canBo, int maNamHoc)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.CanBoCoiThiLan1 like '%" + canBo + "%' and l.MaNamHoc = " + maNamHoc.ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangDuongThiL2(string giangDuong)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangDuongThiLan2 like '%" + giangDuong + "%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoGiangDuongThiL2(string giangDuong, int maNamHoc)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.GiangDuongThiLan2 like '%" + giangDuong + "%' and l.MaNamHoc = " + maNamHoc.ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoCanBoCoiThiL2(string canBo)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.CanBoCoiThiLan2 like '%" + canBo + "%' ";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable TimLopTheoCanBoCoiThiL2(string canBo, int maNamHoc)
        {
            DataTable dataTable = new DataTable();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "select DISTINCT l.MaLop, l.TenLop from (LOP l inner join LOPMON lm on l.MaLop = lm.MaLop) inner join CHITIETMON ctm on lm.MaLopMon = ctm.MaLopMon where ctm.CanBoCoiThiLan2 like '%" + canBo + "%' and l.MaNamHoc = " + maNamHoc.ToString();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);

            adapter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static LopDTO TimLopTheoMaLop(int maLop)
        {
            ArrayList arrList = new ArrayList();

            LopDTO lop = new LopDTO();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from LOP where MaLop = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaLop", OleDbType.Integer);
            command.Parameters["@MaLop"].Value = maLop;
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                lop.MaLop = (int)reader["MaLop"];
                lop.TenLop = (string)reader["TenLop"];
                lop.SoLuongSinhVien = (int)reader["SoLuongSinhVien"];
                lop.SoLuongTrongNganSach = (int)reader["SoLuongTrongNganSach"];
                lop.SoLuongNgoaiNganSach = (int)reader["SoLuongNgoaiNganSach"];
                lop.MaNamHoc = (int)reader["MaNamHoc"];
            }
                
            reader.Close();
            connection.Close();
            return lop;
        }
    }
}
