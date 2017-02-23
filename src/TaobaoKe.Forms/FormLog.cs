using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TaobaoKe.Core.Log;
using TaobaoKe.Forms.Properties;
using TaobaoKe.Repository;

namespace TaobaoKe.Forms
{
    public partial class FormLog : Form
    {
        public static FormLog _instance;
        LogRepository _logRepository = new LogRepository();
        DataTable _dataSource = null;

        private FormLog()
        {
            this.Icon = Resources.form_icon;
            InitializeComponent();
            InitializeControl();
        }

        public static FormLog Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormLog();
                return _instance;
            }
        }

        private void InitializeControl()
        {
            LogHelper.OnLog = OnLog;
            _dataSource = new DataTable("Master");
            _dataSource.Columns.Add("Id", typeof(int));
            _dataSource.Columns.Add("Level", typeof(byte));
            _dataSource.Columns.Add("Type", typeof(byte));
            _dataSource.Columns.Add("CreateTime", typeof(DateTime));
            _dataSource.Columns.Add("Content", typeof(string));
            bsLogs.DataSource = _dataSource;
            bsLogs.DataMember = "";

            LoadLogs();
        }

        private void LoadLogs()
        {
            _dataSource.BeginLoadData();
            try
            {
                foreach (var item in _logRepository.GetLogs(500))
                {
                    AddLog(item);
                }
            }
            finally
            {
                _dataSource.EndLoadData();
            }
        }

        void OnLog(LogItem logItem)
        {
            AddLog(logItem);
        }

        void AddLog(LogItem item)
        {
            DataRow row = _dataSource.NewRow();
            row["ID"] = item.Id;
            row["Level"] = item.Level;
            row["Type"] = item.Type;
            row["CreateTime"] = item.CreateTime;
            row["Content"] = item.Content;
            _dataSource.Rows.Add(row);
        }

        private void FormLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }
    }
}
