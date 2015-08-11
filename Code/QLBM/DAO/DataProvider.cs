using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;

namespace DAO
{
    public class DataProvider
    {
        public static OleDbConnection CreateConnection()
        {
            string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = QLBM.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
