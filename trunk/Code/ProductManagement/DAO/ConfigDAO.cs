﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using DTO;

namespace DAO
{
    public class ConfigDAO
    {
        public static ConfigDTO GetConfig()
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Select * from CONFIG";
            OleDbCommand command = new OleDbCommand(cmdText, connection);
            OleDbDataReader reader = command.ExecuteReader();
            ConfigDTO cfgDto = new ConfigDTO();

            while (reader.Read())
            {
                cfgDto.TichLuyDiem = (bool)reader["TichLuyDiem"];
            }

            reader.Close();
            connection.Close();
            return cfgDto;
        }

        public static void SaveConfig(ConfigDTO cfgDto)
        {
            OleDbConnection connection = DataProvider.CreateConnection();
            string cmdText = "Update CONFIG Set TichLuyDiem = ? where ID=1";
            OleDbCommand command = new OleDbCommand(cmdText, connection);

            command.Parameters.Add("@TichLuyDiem", OleDbType.Boolean);

            command.Parameters["@TichLuyDiem"].Value = cfgDto.TichLuyDiem;

            int row = command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
