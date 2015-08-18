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
    public class ChiTietMonDAO
    {
        public static DataTable GetTable(int maLop)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select ctm.MaChiTietMon, m.TenMon, m.MaMon, nh.TenNamHoc, nh.MaNamHoc, ctm.ThoiGianHoc, ctm.GioHoc, ctm.GiangDuong, ctm.GiangVien, ctm.NgayThiLan1, ctm.GioThiLan1, ctm.GiangDuongThiLan1, ctm.CanBoCoiThiLan1, ctm.SoBaiThiLan1, ctm.NgayThiLan2, ctm.GioThiLan2, ctm.GiangDuongThiLan2, ctm.CanBoCoiThiLan2, ctm.SoBaiThiLan2, ctm.GhiChu  from ((CHITIETMON ctm inner join LOPMON lm on ctm.MaLopMon = lm.MaLopMon) inner join MON m on lm.MaMon = m.MaMon) left join NAMHOC nh on ctm.MaNamHoc = nh.MaNamHoc where lm.MaLop = ? order by m.MaMon ASC";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MaLop", OleDbType.Numeric);
            command.Parameters["@MaLop"].Value = maLop;

            OleDbDataAdapter adpter = new OleDbDataAdapter(command);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            ChiTietMonDTO chiTietMon = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CHITIETMON";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                chiTietMon = new ChiTietMonDTO();

                chiTietMon.MaChiTietMon = (int)reader["MaChiTietMon"];
                chiTietMon.MaLopMon = (int)reader["MaLopMon"];
                chiTietMon.MaNamHoc = (int)reader["MaNamHoc"];
                chiTietMon.ThoiGianHoc = (string)reader["ThoiGianHoc"];
                chiTietMon.GioHoc = (string)reader["GioHoc"];
                chiTietMon.GiangDuong = (string)reader["GiangDuong"];
                chiTietMon.GiangVien = (string)reader["GiangVien"];
                chiTietMon.NgayThiLan1 = (string)reader["NgayThiLan1"];
                chiTietMon.GioThiLan1 = (string)reader["GioThiLan1"];
                chiTietMon.GiangDuongThiLan1 = (string)reader["GiangDuongThiLan1"];
                chiTietMon.CanBoCoiThiLan1 = (string)reader["CanBoCoiThiLan1"];
                chiTietMon.SoBaiThiLan1 = (int)reader["SoBaiThiLan1"];
                chiTietMon.NgayThiLan2 = (string)reader["NgayThiLan2"];
                chiTietMon.GioThiLan2 = (string)reader["GioThiLan2"];
                chiTietMon.GiangDuongThiLan2 = (string)reader["GiangDuongThiLan2"];
                chiTietMon.CanBoCoiThiLan2 = (string)reader["CanBoCoiThiLan2"];
                chiTietMon.SoBaiThiLan2 = (int)reader["SoBaiThiLan2"];
                chiTietMon.GhiChu = (string)reader["GhiChu"];
                arrList.Add(chiTietMon);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }

        public static ChiTietMonDTO TimTheoMaChiTietMon(int maCTM)
        {
            ArrayList arrList = new ArrayList();

            ChiTietMonDTO chiTietMon = new ChiTietMonDTO();

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CHITIETMON where MaChiTietMon = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Integer);
            command.Parameters["@MaChiTietMon"].Value = maCTM;
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                chiTietMon.MaChiTietMon = (int)reader["MaChiTietMon"];
                chiTietMon.MaLopMon = (int)reader["MaLopMon"];
                chiTietMon.MaNamHoc = (int)reader["MaNamHoc"];
                chiTietMon.ThoiGianHoc = (string)reader["ThoiGianHoc"];
                chiTietMon.GioHoc = (string)reader["GioHoc"];
                chiTietMon.GiangDuong = (string)reader["GiangDuong"];
                chiTietMon.GiangVien = (string)reader["GiangVien"];
                chiTietMon.NgayThiLan1 = (string)reader["NgayThiLan1"];
                chiTietMon.GioThiLan1 = (string)reader["GioThiLan1"];
                chiTietMon.GiangDuongThiLan1 = (string)reader["GiangDuongThiLan1"];
                chiTietMon.CanBoCoiThiLan1 = (string)reader["CanBoCoiThiLan1"];
                chiTietMon.SoBaiThiLan1 = (int)reader["SoBaiThiLan1"];
                chiTietMon.NgayThiLan2 = (string)reader["NgayThiLan2"];
                chiTietMon.GioThiLan2 = (string)reader["GioThiLan2"];
                chiTietMon.GiangDuongThiLan2 = (string)reader["GiangDuongThiLan2"];
                chiTietMon.CanBoCoiThiLan2 = (string)reader["CanBoCoiThiLan2"];
                chiTietMon.SoBaiThiLan2 = (int)reader["SoBaiThiLan2"];
                chiTietMon.GhiChu = (string)reader["GhiChu"];
                arrList.Add(chiTietMon);
            }
            reader.Close();
            connection.Close();
            return chiTietMon;
        }

        public static void UpdateTable(DataTable dataTable)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CHITIETMON";
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
            OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
            adapter.Update(dataTable);

            connection.Close();
        }
        public static void UpdateRecord(ChiTietMonDTO chiTietMonDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update CHITIETMON Set [MaNamHoc] = ?, [ThoiGianHoc] = ?, [GioHoc] = ?, [GiangDuong] = ?, [NgayThiLan1] = ?, [GioThiLan1] = ?, [GiangDuongThiLan1] = ?, [SoBaiThiLan1] = ?, [NgayThiLan2] = ?, [GioThiLan2] = ?, [GiangDuongThiLan2] = ?, [SoBaiThiLan2] = ?, [GhiChu] = ? Where [MaChiTietMon] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MaNamHoc", OleDbType.Integer);
            command.Parameters.Add("@ThoiGianHoc", OleDbType.WChar);
            command.Parameters.Add("@GioHoc", OleDbType.WChar);
            command.Parameters.Add("@GiangDuong", OleDbType.WChar);
            //command.Parameters.Add("@GiangVien", OleDbType.WChar);
            command.Parameters.Add("@NgayThiLan1", OleDbType.WChar);
            command.Parameters.Add("@GioThiLan1", OleDbType.WChar);
            command.Parameters.Add("@GiangDuongThiLan1", OleDbType.WChar);
            //command.Parameters.Add("@CanBoCoiThiLan1", OleDbType.WChar);
            command.Parameters.Add("@SoBaiThiLan1", OleDbType.Numeric);
            command.Parameters.Add("@NgayThiLan2", OleDbType.WChar);
            command.Parameters.Add("@GioThiLan2", OleDbType.WChar);
            command.Parameters.Add("@GiangDuongThiLan2", OleDbType.WChar);
            //command.Parameters.Add("@CanBoCoiThiLan2", OleDbType.WChar);
            command.Parameters.Add("@SoBaiThiLan2", OleDbType.Numeric);
            command.Parameters.Add("@GhiChu", OleDbType.WChar);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Numeric);

            command.Parameters["@MaNamHoc"].Value = chiTietMonDTO.MaNamHoc;
            command.Parameters["@ThoiGianHoc"].Value = chiTietMonDTO.ThoiGianHoc;
            command.Parameters["@GioHoc"].Value = chiTietMonDTO.GioHoc;
            command.Parameters["@GiangDuong"].Value = chiTietMonDTO.GiangDuong;
            //command.Parameters["@GiangVien"].Value = chiTietMonDTO.GiangVien;
            command.Parameters["@NgayThiLan1"].Value = chiTietMonDTO.NgayThiLan1;
            command.Parameters["@GioThiLan1"].Value = chiTietMonDTO.GioThiLan1;
            command.Parameters["@GiangDuongThiLan1"].Value = chiTietMonDTO.GiangDuongThiLan1;
            //command.Parameters["@CanBoCoiThiLan1"].Value = chiTietMonDTO.CanBoCoiThiLan1;
            command.Parameters["@SoBaiThiLan1"].Value = chiTietMonDTO.SoBaiThiLan1;
            command.Parameters["@NgayThiLan2"].Value = chiTietMonDTO.NgayThiLan2;
            command.Parameters["@GioThiLan2"].Value = chiTietMonDTO.GioThiLan2;
            command.Parameters["@GiangDuongThiLan2"].Value = chiTietMonDTO.GiangDuongThiLan2;
            //command.Parameters["@CanBoCoiThiLan2"].Value = chiTietMonDTO.CanBoCoiThiLan2;
            command.Parameters["@SoBaiThiLan2"].Value = chiTietMonDTO.SoBaiThiLan2;
            command.Parameters["@GhiChu"].Value = chiTietMonDTO.GhiChu;
            command.Parameters["@MaChiTietMon"].Value = chiTietMonDTO.MaChiTietMon;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateGiangVien(ChiTietMonDTO chiTietMonDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update CHITIETMON Set [GiangVien] = ? Where [MaChiTietMon] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@GiangVien", OleDbType.WChar);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Numeric);

            command.Parameters["@GiangVien"].Value = chiTietMonDTO.GiangVien;
            command.Parameters["@MaChiTietMon"].Value = chiTietMonDTO.MaChiTietMon;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateCanBoCoiThiLan1(ChiTietMonDTO chiTietMonDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update CHITIETMON Set [CanBoCoiThiLan1] = ? Where [MaChiTietMon] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@CanBoCoiThiLan1", OleDbType.WChar);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Numeric);

            command.Parameters["@CanBoCoiThiLan1"].Value = chiTietMonDTO.CanBoCoiThiLan1;
            command.Parameters["@MaChiTietMon"].Value = chiTietMonDTO.MaChiTietMon;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void UpdateCanBoCoiThiLan2(ChiTietMonDTO chiTietMonDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update CHITIETMON Set [CanBoCoiThiLan2] = ? Where [MaChiTietMon] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@CanBoCoiThiLan2", OleDbType.WChar);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Numeric);

            command.Parameters["@CanBoCoiThiLan2"].Value = chiTietMonDTO.CanBoCoiThiLan2;
            command.Parameters["@MaChiTietMon"].Value = chiTietMonDTO.MaChiTietMon;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void CapNhatNamHoc(int maChiTietMon, int maNamHoc)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update CHITIETMON Set [MaNamHoc] = ? Where [MaChiTietMon] = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MaNamHoc", OleDbType.Numeric);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Numeric);

            command.Parameters["@MaNamHoc"].Value = maNamHoc;
            command.Parameters["@MaChiTietMon"].Value = maChiTietMon;

            command.ExecuteNonQuery();
            connection.Close();
        }

        public static void Insert(ChiTietMonDTO chiTietMonDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into CHITIETMON(MaLopMon, MaNamHoc, ThoiGianHoc, GioHoc, GiangDuong, GiangVien, NgayThiLan1, GioThiLan1, GiangDuongThiLan1, CanBoCoiThiLan1, SoBaiThiLan1, NgayThiLan2, GioThiLan2, GiangDuongThiLan2, CanBoCoiThiLan2, SoBaiThiLan2, GhiChu) values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@MaLopMon", OleDbType.Numeric);
            command.Parameters.Add("@MaNamHoc", OleDbType.Numeric);
            command.Parameters.Add("@ThoiGianHoc", OleDbType.WChar);
            command.Parameters.Add("@GioHoc", OleDbType.WChar);
            command.Parameters.Add("@GiangDuong", OleDbType.WChar);
            command.Parameters.Add("@GiangVien", OleDbType.WChar);
            command.Parameters.Add("@NgayThiLan1", OleDbType.WChar);
            command.Parameters.Add("@GioThiLan1", OleDbType.WChar);
            command.Parameters.Add("@GiangDuongThiLan1", OleDbType.WChar);
            command.Parameters.Add("@CanBoCoiThiLan1", OleDbType.WChar);
            command.Parameters.Add("@SoBaiThiLan1", OleDbType.Numeric);
            command.Parameters.Add("@NgayThiLan2", OleDbType.WChar);
            command.Parameters.Add("@GioThiLan2", OleDbType.WChar);
            command.Parameters.Add("@GiangDuongThiLan2", OleDbType.WChar);
            command.Parameters.Add("@CanBoCoiThiLan2", OleDbType.WChar);
            command.Parameters.Add("@SoBaiThiLan2", OleDbType.Numeric);
            command.Parameters.Add("@GhiChu", OleDbType.WChar);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Numeric);

            command.Parameters["@MaLopMon"].Value = chiTietMonDTO.MaLopMon;
            command.Parameters["@MaNamHoc"].Value = chiTietMonDTO.MaNamHoc;
            command.Parameters["@ThoiGianHoc"].Value = chiTietMonDTO.ThoiGianHoc;
            command.Parameters["@GioHoc"].Value = chiTietMonDTO.GioHoc;
            command.Parameters["@GiangDuong"].Value = chiTietMonDTO.GiangDuong;
            command.Parameters["@GiangVien"].Value = chiTietMonDTO.GiangVien;
            command.Parameters["@NgayThiLan1"].Value = chiTietMonDTO.NgayThiLan1;
            command.Parameters["@GioThiLan1"].Value = chiTietMonDTO.GioThiLan1;
            command.Parameters["@GiangDuongThiLan1"].Value = chiTietMonDTO.GiangDuongThiLan1;
            command.Parameters["@CanBoCoiThiLan1"].Value = chiTietMonDTO.CanBoCoiThiLan1;
            command.Parameters["@SoBaiThiLan1"].Value = chiTietMonDTO.SoBaiThiLan1;
            command.Parameters["@NgayThiLan2"].Value = chiTietMonDTO.NgayThiLan2;
            command.Parameters["@GioThiLan2"].Value = chiTietMonDTO.GioThiLan2;
            command.Parameters["@GiangDuongThiLan2"].Value = chiTietMonDTO.GiangDuongThiLan2;
            command.Parameters["@CanBoCoiThiLan2"].Value = chiTietMonDTO.CanBoCoiThiLan2;
            command.Parameters["@SoBaiThiLan2"].Value = chiTietMonDTO.SoBaiThiLan2;
            command.Parameters["@GhiChu"].Value = chiTietMonDTO.GhiChu;
            command.Parameters["@MaChiTietMon"].Value = chiTietMonDTO.MaChiTietMon;

            command.ExecuteNonQuery();
            command.CommandText = "select @@IDENTITY";
            chiTietMonDTO.MaChiTietMon = (int)command.ExecuteScalar();
            connection.Close();
        }

        public static bool Delete(int maChiTietMon)
        {
            bool result = false;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "delete from CHITIETMON where MaChiTietMon = ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaChiTietMon", OleDbType.Integer);
            command.Parameters["@MaChiTietMon"].Value = maChiTietMon;

            int row = command.ExecuteNonQuery();
            if (row > 0)
                result = true;
            connection.Close();
            return result;
        }
    }
}
