using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using DTO;
using DAO;

namespace BUS
{
    public class ConfigBUS
    {
        public static ConfigDTO GetConfig()
        {
            return ConfigDAO.GetConfig();
        }

        public static void SaveConfig(ConfigDTO cfgDto)
        {
            ConfigDAO.SaveConfig(cfgDto);
        }
    }
}
