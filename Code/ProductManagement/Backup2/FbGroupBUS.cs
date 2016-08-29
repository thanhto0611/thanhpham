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
    public class FbGroupBUS
    {
        public static void Insert(FbGroupDTO group)
        {
            FbGroupDAO gd = new FbGroupDAO();
            gd.Insert(group);
        }

        public static void Update(FbGroupDTO group)
        {
            FbGroupDAO gd = new FbGroupDAO();
            gd.Update(group);
        }
    }
}
