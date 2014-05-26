using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace DAO
{
    class DataProvider
    {
        public static OleDbConnection CreateConnection()
        {
            string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = QLTV.mdb";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
