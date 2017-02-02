using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaobaoKe.Common.Models;
using Dapper;
using TaobaoKe.Data;
using System.Data.SQLite;
using System.Data;

namespace TaobaoKe.Repository
{
    public class TransmitTaskRepository
    {
        public void Add(TransmitTask transmitTask)
        {
            const string sql = "INSERT INTO transmit_task (content, `from`, commission_rate, coupon, create_time, status, transmit_time, priority)"
                + " VALUES (@Content, @From, @CommissionRate, @Coupon, @CreateTime, @Status, @TransmitTime, @Priority)";
            using (SQLiteConnection conn = DbHelper.OpenConnection())
            {
                conn.Execute(sql, transmitTask);
                transmitTask.Id = DbHelper.GetLastInsertID(conn);
            }
        }

        public IEnumerable<TransmitTask> GetUntransmittedTasks()
        {
            const string sql = "SELECT * FROM transmit_task WHERE status = 0 ORDER BY priority DESC, id ASC";
            using (SQLiteConnection conn = DbHelper.OpenConnection())
            {
                return conn.Query<TransmitTask>(sql);
            }
        }

        public void UpdateStatus(int id)
        {
            const string sql = "UPDATE transmit_task SET status = 1, transmit_time = @TransmitTime WHERE id = @Id";
            using (SQLiteConnection conn = DbHelper.OpenConnection())
            {
                conn.Execute(sql, new { Id = id, TransmitTime = DateTime.Now });
            }
        }
    }
}
 