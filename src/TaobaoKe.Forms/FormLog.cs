using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TaobaoKe.Core.Log;
//using TaobaoKe.Forms.Properties;
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
            //this.Icon = Resources.form_icon;
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
            _dataSource.Columns.Add("TypeName", typeof(string));
            _dataSource.Columns.Add("CreateTime", typeof(DateTime));
            _dataSource.Columns.Add("Content", typeof(string));
            bsLogs.DataSource = _dataSource;
            bsLogs.DataMember = "";
            LoadLogs();

            foreach (LogLevel item in Enum.GetValues(typeof(LogLevel)))
            {
                cboxLevel.Items.Add(new KeyValuePair<string, string>(item.ToString(), GetDescription(item)));
            }
            cboxLevel.SelectedIndex = 4;
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
            ScrollToBottom();
        }

        void AddLog(LogItem item)
        {
            DataRow row = _dataSource.NewRow();
            row["ID"] = item.Id;
            row["Level"] = item.Level;
            row["Type"] = item.Type;
            row["TypeName"] = GetDescription((LogItemType)item.Type);
            row["CreateTime"] = item.CreateTime;
            row["Content"] = item.Content;
            _dataSource.Rows.Add(row);
        }

        public static string GetDescription(Enum value)
        {
            Type enumType = value.GetType();
            // 获取枚举常数名称。
            string name = Enum.GetName(enumType, value);
            if (name != null)
            {
                // 获取枚举字段。
                FieldInfo fieldInfo = enumType.GetField(name);
                if (fieldInfo != null)
                {
                    // 获取描述的属性。
                    DescriptionAttribute attr = Attribute.GetCustomAttribute(fieldInfo,
                        typeof(DescriptionAttribute), false) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        private void FormLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            _instance = null;
        }

        private void cboxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                KeyValuePair<string, string> item = (KeyValuePair<string, string>)this.cboxLevel.SelectedItem;
                bsLogs.Filter = "Level = " + (byte)Enum.Parse(typeof(LogLevel), item.Key);
            }
        }

        private void chkTopMost_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = this.chkTopMost.Checked;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridLogs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1) // 时间
            {
                e.Value = e.Value.ToString();
            }
        }

        private void gridLogs_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            LogLevel logLevel = (LogLevel)_dataSource.DefaultView[e.RowIndex]["Level"];
            Color color = Color.Black;
            switch (logLevel)
            {
                case LogLevel.Fatal:
                    color = Color.OrangeRed;
                    break;
                case LogLevel.ERROR:
                    color = Color.Red;
                    break;
                case LogLevel.WARN:
                    color = Color.DarkOrange;
                    break;
                case LogLevel.DEBUG:
                    color = Color.DarkGray;
                    break;
                case LogLevel.INFO:
                    color = Color.DodgerBlue;
                    break;
                default:
                    break;
            }
            gridLogs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = color;
        }

        private void ScrollToBottom()
        {
            if (this.gridLogs.Rows.Count > 0)
                this.gridLogs.FirstDisplayedScrollingRowIndex = this.gridLogs.Rows.Count - 1;
        }

        private void FormLog_Shown(object sender, EventArgs e)
        {
            ScrollToBottom();
        }
    }
}
