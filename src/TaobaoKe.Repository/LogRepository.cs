using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SQLite;
using TaobaoKe.Data;
using TaobaoKe.Core.Log;
using System.IO;

namespace TaobaoKe.Repository
{
    public class LogRepository
    {
        private static string DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"DB\log.db3");

        public IEnumerable<LogItem> GetLogs(int count)
        {
            using (SQLiteConnection conn = DbHelper.OpenConnection(DataSource))
            {
                return conn.Query<LogItem>(string.Format("SELECT * FROM (SELECT * FROM `log` ORDER BY id DESC LIMIT {0}) ORDER BY ID", count));
            }
        }
    }
}
