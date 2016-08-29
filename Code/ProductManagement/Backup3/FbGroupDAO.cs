using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class FbGroupDAO
    {
        public void Insert(FbGroupDTO fbGroup)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Insert into FBGROUP(GroupId, GroupName, NumberOfMember, NgayNhap, NguoiNhap) values(?,?,?,?,?)";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            command.Parameters.Add("@GroupId", OleDbType.VarWChar);
            command.Parameters["@GroupId"].Value = fbGroup.GroupId;

            command.Parameters.Add("@GroupName", OleDbType.VarWChar);
            command.Parameters["@GroupName"].Value = fbGroup.GroupName;

            command.Parameters.Add("@NumberOfMember", OleDbType.Integer);
            command.Parameters["@NumberOfMember"].Value = fbGroup.NumberOfMember;

            command.Parameters.Add("@NgayNhap", OleDbType.Date);
            command.Parameters["@NgayNhap"].Value = fbGroup.NgayNhap;

            command.Parameters.Add("@NguoiNhap", OleDbType.WChar);
            command.Parameters["@NguoiNhap"].Value = fbGroup.NguoiNhap;

            command.ExecuteNonQuery();

            connection.Close();
        }

        public void Update(FbGroupDTO fbGroup)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update FBGROUP Set GroupName = ?, NumberOfMember = ? Where GroupId like ?";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@GroupName", OleDbType.WChar);
            command.Parameters.Add("@NumberOfMember", OleDbType.Integer);
            command.Parameters.Add("@GroupId", OleDbType.WChar);

            command.Parameters["@GroupName"].Value = fbGroup.GroupName;
            command.Parameters["@NumberOfMember"].Value = fbGroup.NumberOfMember;
            command.Parameters["@GroupId"].Value = fbGroup.GroupId;

            int row = command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
