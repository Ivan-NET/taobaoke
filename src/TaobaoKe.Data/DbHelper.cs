using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace TaobaoKe.Data
{
    public static class DbHelper
    {
        private static string DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\taobaoke.db3");

        public static SQLiteConnection OpenConnection()
        {
            return OpenConnection(DataSource);
        }

        public static SQLiteConnection OpenConnection(string dataSource)
        {
            SQLiteConnectionStringBuilder connStrBld = new SQLiteConnectionStringBuilder();
            connStrBld.DataSource = dataSource;
            var conn = new SQLiteConnection(connStrBld.ToString());
            conn.Open();
            return conn;
        }

        public static int GetLastInsertID(IDbConnection conn)
        {
            const string sql = "SELECT last_insert_rowid()";
            return Convert.ToInt32(conn.ExecuteScalar(sql));
        }
    }
}
