using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class SanPhamDAO
    {
        public static DataTable GetTable()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from SANPHAM ";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable XuatKhoHang()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham, SoLuong, TrangThai from SANPHAM ";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        //public static IList GetList()
        //{
        //    ArrayList arrList = new ArrayList();

        //    SanPhamDTO SanPham = null;

        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "Select * from SANPHAM";
        //    OleDbCommand command = new OleDbCommand(cmdText, connection);
        //    OleDbDataReader reader = command.ExecuteReader();

        //    while (reader.Read())
        //    {
        //        SanPham = new SanPhamDTO();

        //        SanPham.MaSanPham = (int)reader["MaSanPham"];
        //        SanPham.TenSanPham = (string)reader["TenSanPham"];
        //        SanPham.HinhAnh = (string)reader["HinhAnh"];
        //        SanPham.SoLuong = (int)reader["SoLuong"];
        //        SanPham.TrongLuong = (float)reader["TrongLuong"];
        //        SanPham.MauSac = (string)reader["MauSac"];
        //        SanPham.TrangThai = (int)reader["TrangThai"];
        //        SanPham.MaDanhMuc = (int)reader["MaDanhMuc"];
        //        SanPham.GiaGoc = (float)reader["GiaGoc"];
        //        SanPham.GiaSi = (float)reader["GiaSi"];
        //        SanPham.GiaLe = (float)reader["GiaLe"];
        //        SanPham.GiaBan = (float)reader["GiaBan"];
        //        SanPham.LoiNhuan = (float)reader["LoiNhuan"];
        //        SanPham.NgayNhap = (DateTime)reader["NgayNhap"];
        //        SanPham.NgayCapNhat = (DateTime)reader["NgayCapNhat"];
        //        SanPham.MaNguoiNhap = (int)reader["MaNguoiNhap"];
        //        SanPham.MaNguoiCapNhat = (int)reader["MaNguoiCapNhat"];
        //        arrList.Add(SanPham);
        //    }
        //    reader.Close();
        //    connection.Close();
        //    return arrList;
        //}
        //public static void UpdateTable(DataTable dataTable)
        //{
        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "Select * from SANPHAM";
        //    OleDbDataAdapter adapter = new OleDbDataAdapter(cmdText, connection);
        //    OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
        //    adapter.Update(dataTable);

        //    connection.Close();
        //}
        //public void UpdateRecord(int MaSanPham, bool Type)
        //{
        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "update SANPHAM set TrangThai = ? where MaSanPham = ?";
        //    OleDbCommand command = new OleDbCommand(cmdText, connection);

        //    command.Parameters.Add("@TrangThai", OleDbType.Integer);

        //    if (Type == true)
        //        command.Parameters["@TrangThai"].Value = 0;
        //    else
        //        command.Parameters["@TrangThai"].Value = 1;


        //    command.Parameters.Add("@MaSanPham", OleDbType.Integer);
        //    command.Parameters["@MaSanPham"].Value = MaSanPham;
        //    command.ExecuteNonQuery();
        //    connection.Close();
        //}

        public void Insert(SanPhamDTO SanPham)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into SANPHAM(MaSanPham, HinhAnh, TrongLuong, MauSac, SoLuong, TrangThai, MaDanhMuc, GiaGoc, GiaSi, GiaLe, NgayNhap, NguoiNhap) values(?,?,?,?,?,?,?,?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@MaSanPham", OleDbType.VarWChar);
            command.Parameters["@MaSanPham"].Value = SanPham.MaSanPham;

            command.Parameters.Add("@HinhAnh", OleDbType.VarWChar);
            command.Parameters["@HinhAnh"].Value = SanPham.HinhAnh;

            command.Parameters.Add("@TrongLuong", OleDbType.Integer);
            command.Parameters["@TrongLuong"].Value = SanPham.TrongLuong;


            command.Parameters.Add("@MauSac", OleDbType.VarWChar);
            command.Parameters["@MauSac"].Value = SanPham.MauSac;

            command.Parameters.Add("@SoLuong", OleDbType.Integer);
            command.Parameters["@SoLuong"].Value = SanPham.SoLuong;


            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            command.Parameters["@TrangThai"].Value = SanPham.TrangThai;

            command.Parameters.Add("@MaDanhMuc", OleDbType.Integer);
            command.Parameters["@MaDanhMuc"].Value = SanPham.MaDanhMuc;

            command.Parameters.Add("@GiaGoc", OleDbType.Integer);
            command.Parameters["@GiaGoc"].Value = SanPham.GiaGoc;

            command.Parameters.Add("@GiaSi", OleDbType.Integer);
            command.Parameters["@GiaSi"].Value = SanPham.GiaSi;

            command.Parameters.Add("@GiaLe", OleDbType.Integer);
            command.Parameters["@GiaLe"].Value = SanPham.GiaLe;

            command.Parameters.Add("@NgayNhap", OleDbType.Date);
            command.Parameters["@NgayNhap"].Value = SanPham.NgayNhap;

            command.Parameters.Add("@NguoiNhap", OleDbType.WChar);
            command.Parameters["@NguoiNhap"].Value = SanPham.NguoiNhap;

            command.ExecuteNonQuery();

            //command.CommandText = "select @@IDENTITY";
            //SanPham.MaSanPham = (string)command.ExecuteScalar();
            connection.Close();
        }

        //public void Delete(int MaSach)
        //{
        //    bool result = false;

        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "delete from SANPHAM where MaSach = ?";
        //    OleDbCommand command = new OleDbCommand(cmdText, connection);
        //    command.Parameters.Add("@MaSach", OleDbType.Integer);
        //    command.Parameters["@MaSach"].Value = MaSach;

        //    command.ExecuteNonQuery();


        //    connection.Close();

        //}

        public static bool KiemTraTonTai(string masp)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham from SANPHAM where MaSanPham like '%" + masp + "%'";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            if (dataTable.Rows.Count != 0)
            {
                return true;
            } 
            else
            {
                return false;
            }
        }

        public static bool KiemTraKhoHang(string masp, int sl)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select SoLuong from SANPHAM where MaSanPham like '%" + masp + "%'" + " order by MaSanPham ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            if (Int32.Parse(dataTable.Rows[0].ItemArray.GetValue(0).ToString()) < sl)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static DataTable LayBangMaSanPham(string masp)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham, HinhAnh, MauSac, TrongLuong, SoLuong, TrangThai, GiaGoc, GiaSi, GiaLe, GiaBan, NgayNhap, NguoiNhap, NgayCapNhat, NguoiCapNhat from SANPHAM where MaSanPham like '%" + masp + "%'" + " order by MaSanPham ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable LayBangMaSanPham_ChiTietDonHang(string masp)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select 0 as MaChiTietDonHang, MaSanPham, HinhAnh, MauSac, 1 as SoLuongDatMua, SoLuong as SoLuongTrongKho, GiaSi, GiaLe, GiaBan from SANPHAM where MaSanPham like '%" + masp + "%'" + " order by MaSanPham ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable LayBangMaSanPhamTrangThai(string masp, int trangthai)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham, HinhAnh, MauSac, TrongLuong, SoLuong, TrangThai, GiaGoc, GiaSi, GiaLe, GiaBan, NgayNhap, NguoiNhap, NgayCapNhat, NguoiCapNhat from SANPHAM where MaSanPham like '%" + masp + "%' and TrangThai = " + trangthai + " order by MaSanPham ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable LayBangMaSanPhamMaDanhMuc(string masp, int madm)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham, HinhAnh, MauSac, TrongLuong, SoLuong, TrangThai, GiaGoc, GiaSi, GiaLe, GiaBan, NgayNhap, NguoiNhap, NgayCapNhat, NguoiCapNhat from SANPHAM inner join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc where SANPHAM.MaSanPham like '%" + masp + "%' and SANPHAM.MaDanhMuc = " + madm + " order by MaSanPham ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable LayBangMaSanPhamMaDanhMucTrangThai(string masp, int madm, int trangthai)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham, HinhAnh, MauSac, TrongLuong, SoLuong, TrangThai, GiaGoc, GiaSi, GiaLe, GiaBan, NgayNhap, NguoiNhap, NgayCapNhat, NguoiCapNhat from SANPHAM inner join DANHMUC on DANHMUC.MaDanhMuc = SANPHAM.MaDanhMuc where SANPHAM.MaSanPham like '%" + masp + "%' and SANPHAM.MaDanhMuc = " + madm + " and TrangThai = " + trangthai + " order by MaSanPham ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable LayBangDanhMuc(int madm)
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham, HinhAnh, MauSac, TrongLuong, SoLuong, TrangThai, GiaGoc, GiaSi, GiaLe, GiaBan, NgayNhap, NguoiNhap, NgayCapNhat, NguoiCapNhat from SANPHAM where MaDanhMuc = " + madm + " order by MaSanPham ASC";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }

        public static DataTable GetNull()
        {
            DataTable dataTable = new DataTable();
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select MaSanPham, HinhAnh, MauSac, TrongLuong, SoLuong, TrangThai, GiaGoc, GiaSi, GiaLe, GiaBan, NgayNhap, NguoiNhap, NgayCapNhat, NguoiCapNhat from SANPHAM where MaSanPham like '%thanhpham%'";
            OleDbDataAdapter adpter = new OleDbDataAdapter(cmdText, connection);
            adpter.Fill(dataTable);
            connection.Close();
            return dataTable;
        }
        //public static DataTable Search(string query)
        //{
        //    DataTable dataTable = new DataTable();
        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "select MaSach, TenSach from SANPHAM where TenSach Like ?";
        //    OleDbCommand command = new OleDbCommand(cmdText, connection);
        //    command.Parameters.Add("@TenSach", OleDbType.VarWChar);
        //    command.Parameters["@TenSach"].Value = "%" + query + "%";

        //    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
        //    adapter.Fill(dataTable);
        //    return dataTable;
        //}
        //public static DataTable LayTheoDieuKien(int maDM, string maSP, bool TheLoaiChk)
        //{
        //    DataTable dataTable = new DataTable();
        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    OleDbCommand command = BuildQuery(sach, NgonNguChk, TheLoaiChk, connection);
        //    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
        //    adapter.Fill(dataTable);
        //    return dataTable;
        //}
        //private static OleDbCommand BuildQuery(SanPhamDTO sach, bool NgonNguChk, bool TheLoaiChk, OleDbConnection connection)
        //{
        //    OleDbCommand command = new OleDbCommand();

        //    String dkMaSach = " 1=1 ";
        //    String dkMaNN = " 1=1 ";
        //    String dkTenSach = " 1=1 ";
        //    String dkTL = " 1=1 ";

        //    if (sach.MaSach != 0)
        //    {
        //        dkMaSach = " MaSach = ? ";
        //        command.Parameters.Add("@MaSach", OleDbType.Integer);
        //        command.Parameters["@MaSach"].Value = sach.MaSach;
        //    }

        //    if (sach.TenSach.Length > 0)
        //    {
        //        dkTenSach = " TenSach like ? ";
        //        command.Parameters.Add("@TenSach", OleDbType.VarWChar);
        //        command.Parameters["@TenSach"].Value = "%" + sach.TenSach + "%";
        //    }

        //    if (NgonNguChk)
        //    {
        //        dkMaNN = " MaNN = ? ";
        //        command.Parameters.Add("@MaNN", OleDbType.Integer);
        //        command.Parameters["@MaNN"].Value = sach.MaNgonNgu;
        //    }

        //    if (TheLoaiChk)
        //    {
        //        dkTL = " MaLoai = ? ";
        //        command.Parameters.Add("@MaLoai", OleDbType.Integer);
        //        command.Parameters["@MaLoai"].Value = sach.MaTheLoai;
        //    }

        //    StringBuilder dkWhere = new StringBuilder();
        //    dkWhere.AppendLine(" Where ");
        //    dkWhere.Append(dkMaSach);
        //    dkWhere.AppendFormat(" and {0} ", dkTenSach);
        //    dkWhere.AppendFormat(" and {0} ", dkMaNN);
        //    dkWhere.AppendFormat(" and {0} ", dkTL);

        //    StringBuilder cmdText = new StringBuilder();
        //    cmdText.AppendLine("Select * From SANPHAM");
        //    cmdText.AppendLine(dkWhere.ToString());
        //    cmdText.AppendLine("Order by TenSach");

        //    command.Connection = connection;
        //    command.CommandText = cmdText.ToString();

        //    return command;
        //}

        //public SanPhamDTO Search_MaSanPham(string maSp)
        //{
        //    SanPhamDTO sanPhamDTO = null;
        //    DataTable dataTable = new DataTable();
        //    OleDbConnection connection = DataProvider.CreateConnection();
        //    string cmdText = "select * from SANPHAM where MaSanPham = ?";
        //    OleDbCommand command = new OleDbCommand(cmdText, connection);
        //    command.Parameters.Add("@MaSach", OleDbType.Integer);
        //    command.Parameters["@MaSach"].Value = maSp;
        //    OleDbDataReader reader = command.ExecuteReader();

        //    if (reader.Read())
        //    {
        //        sanPhamDTO = new SanPhamDTO();

        //        sanPhamDTO.TenSach = (string)reader["TenSach"];
        //        sanPhamDTO.MaNXB = (int)reader["MaNXB"];
        //        sanPhamDTO.MaTacGia = (int)reader["MaTG"];
        //        sanPhamDTO.MaTheLoai = (int)reader["MaLoai"];
        //        sanPhamDTO.MaNgonNgu = (int)reader["MaNN"];
        //        sanPhamDTO.SoTrang = (int)reader["SoTrang"];
        //        sanPhamDTO.TrangThai = (int)reader["TrangThai"];

        //    }

        //    reader.Close();
        //    connection.Close();
        //    return sanPhamDTO;
        //}

        public void Update(SanPhamDTO sanPhamDTO)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            //string masp = sanPhamDTO.MaSanPham;
            string cmdText = "Update SANPHAM Set HinhAnh = ?, TrongLuong = ? , MauSac = ? , SoLuong = ? , TrangThai = ? , GiaGoc = ? , GiaSi = ? , GiaLe = ? , NgayCapNhat = ? , NguoiCapNhat = ? Where MaSanPham like ?";
            //string cmdText = "Update SANPHAM set MauSac = ? where MaSanPham like ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);


            command.Parameters.Add("@HinhAnh", OleDbType.WChar);
            command.Parameters.Add("@TrongLuong", OleDbType.Integer);
            command.Parameters.Add("@MauSac", OleDbType.VarWChar);
            command.Parameters.Add("@SoLuong", OleDbType.Integer);
            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            command.Parameters.Add("@GiaGoc", OleDbType.Currency);
            command.Parameters.Add("@GiaSi", OleDbType.Currency);
            command.Parameters.Add("@GiaLe", OleDbType.Currency);
            //command.Parameters.Add("@GiaBan", OleDbType.Currency);
            //command.Parameters.Add("@LoiNhuan", OleDbType.Currency);
            command.Parameters.Add("@NgayCapNhat", OleDbType.Date);
            command.Parameters.Add("@NguoiCapNhat", OleDbType.WChar);
            command.Parameters.Add("@MaSanPham", OleDbType.WChar);



            command.Parameters["@HinhAnh"].Value = sanPhamDTO.HinhAnh;
            command.Parameters["@TrongLuong"].Value = sanPhamDTO.TrongLuong;
            command.Parameters["@MauSac"].Value = sanPhamDTO.MauSac;
            command.Parameters["@SoLuong"].Value = sanPhamDTO.SoLuong;
            command.Parameters["@TrangThai"].Value = sanPhamDTO.TrangThai;
            command.Parameters["@GiaGoc"].Value = sanPhamDTO.GiaGoc;
            command.Parameters["@GiaSi"].Value = sanPhamDTO.GiaSi;
            command.Parameters["@GiaLe"].Value = sanPhamDTO.GiaLe;
            //command.Parameters["@GiaBan"].Value = sanPhamDTO.GiaBan;
            //command.Parameters["@LoiNhuan"].Value = sanPhamDTO.LoiNhuan;
            command.Parameters["@NgayCapNhat"].Value = sanPhamDTO.NgayCapNhat;
            command.Parameters["@NguoiCapNhat"].Value = sanPhamDTO.NguoiCapNhat;
            command.Parameters["@MaSanPham"].Value = sanPhamDTO.MaSanPham;



            int row = command.ExecuteNonQuery();
            connection.Close();
        }

        public void CapNhatKhoHang(string masp, int sl, int trangthai)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            //string masp = sanPhamDTO.MaSanPham;
            string cmdText = "Update SANPHAM Set SoLuong = ? , TrangThai = ? Where MaSanPham like ?";
            //string cmdText = "Update SANPHAM set MauSac = ? where MaSanPham like ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);


            //command.Parameters.Add("@HinhAnh", OleDbType.WChar);
            command.Parameters.Add("@SoLuong", OleDbType.Integer);
            command.Parameters.Add("@TrangThai", OleDbType.Integer);
            command.Parameters.Add("@MaSanPham", OleDbType.VarWChar);

            //command.Parameters["@HinhAnh"].Value = sanPhamDTO.HinhAnh;
            command.Parameters["@SoLuong"].Value = sl;
            command.Parameters["@TrangThai"].Value = trangthai;
            command.Parameters["@MaSanPham"].Value = masp;

            int row = command.ExecuteNonQuery();
            connection.Close();
        }

        public static SanPhamDTO LaySanPham(string maSP)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from SANPHAM where MaSanPham like '%" + maSP + "%'";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();
            SanPhamDTO spDto = new SanPhamDTO();

            while (reader.Read())
            {
                spDto.SoLuong = (int)reader["SoLuong"];
                spDto.MauSac = (string)reader["MauSac"];
                spDto.GiaSi = (int)reader["GiaSi"];
                spDto.GiaLe = (int)reader["GiaLe"];
                spDto.HinhAnh = (string)reader["HinhAnh"];
                spDto.TrangThai = (int)reader["TrangThai"];
            }

            reader.Close();
            connection.Close();
            return spDto;
        }
    }
}
