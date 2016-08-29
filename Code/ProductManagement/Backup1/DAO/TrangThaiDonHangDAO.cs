using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class TrangThaiDonHangDAO
    {
        public static IList GetList()
        {
            ArrayList arrList = new ArrayList();

            TrangThaiDonHangDTO TRANGTHAI = null;

            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from TRANGTHAIDONHANG";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                TRANGTHAI = new TrangThaiDonHangDTO();

                TRANGTHAI.MaTrangThai = (int)reader["MaTrangThai"];
                TRANGTHAI.TrangThai = (string)reader["TrangThai"];
                arrList.Add(TRANGTHAI);
            }
            reader.Close();
            connection.Close();
            return arrList;
        }
    }
}
