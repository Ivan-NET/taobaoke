using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaobaoKe.Common.Models;
using TaobaoKe.Core.IPC;
using TaobaoKe.Core.Util;
using TaobaoKe.Forms.Settings;
using TaobaoKe.Forms.Util;
using TaobaoKe.Repository;

namespace TaobaoKe.Forms
{
    [ComVisible(true)]
    public partial class FormMain : FormBase
    {
        DataTable _dataSource = null;
        private string _htmlEditValue = string.Empty;
        TransmitTaskRepository _transmitTaskRepository = new TransmitTaskRepository();
        Regex _regexCQImage = new Regex(@"\[CQ:image,file=(.+)\]");
        bool _transmitting = false;
        bool _monitorStarted = false;
        bool _transmitStarted = false;
        private bool _suspendPreview = false;

        public FormMain()
        {
            InitializeComponent();
            InitializeControl();
        }

        #region 初始化

        private void InitializeControl()
        {
            this.wbTransmit.Url = new System.Uri(Constants.HtmlEditorPath);
            this.wbTransmit.ObjectForScripting = this;

            _dataSource = new DataTable("Master");
            _dataSource.Columns.Add("RowNo", typeof(int));
            _dataSource.Columns.Add("Id", typeof(int));
            _dataSource.Columns.Add("Content", typeof(string));
            _dataSource.Columns.Add("From", typeof(string));
            _dataSource.Columns.Add("CommissionRate", typeof(decimal));
            _dataSource.Columns.Add("Coupon", typeof(string));
            _dataSource.Columns.Add("CreateTime", typeof(DateTime));
            bsTasks.DataSource = _dataSource;
            bsTasks.DataMember = "";

            LoadUntransmittedTasks();
        }

        private void LoadUntransmittedTasks()
        {
            foreach (var item in _transmitTaskRepository.GetUntransmittedTasks())
            {
                AddToDataSource(item);
            }
            ResetRowNo();
            _dataSource.AcceptChanges();
        }

        #endregion

        #region HtmlEditor

        public string HtmlEditValue
        {
            get
            {
                return GetContent();
            }
            set
            {
                _htmlEditValue = value;
                SetDetailContent();
            }
        }

        // 此方法为kindeditor必须声明的方法
        public string GetContent()
        {
            return _htmlEditValue;
        }

        // 此方法为kindeditor必须声明的方法
        public void SetDetailContent()
        {
            wbTransmit.Document.InvokeScript("setContent", new object[] { _htmlEditValue });
        }

        // 此方法为kindeditor必须声明的方法
        public void RequestContent(string str)
        {
            _htmlEditValue = str;
        }

        private void wbTransmit_Resize(object sender, EventArgs e)
        {
            this.wbTransmit.Refresh();
        }

        #endregion

        #region 采集相关

        private void lnkMonitor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_monitorStarted)
            {
                StopMonitor();
            }
            else
            {
                StartMonitor();
            }
            ResetMonitorButtonState();
        }

        private void StartMonitor()
        {
            CheckCQProcess();
            if (!NamedPipedIpcClient.Default_A.Started)
            {
                NamedPipedIpcClient.Default_A.Start();
                NamedPipedIpcClient.Default_A.Recieve += Ipc_Recieve;
            }
            _monitorStarted = true;
        }

        private void StopMonitor()
        {
            if (NamedPipedIpcClient.Default_A.Started)
            {
                NamedPipedIpcClient.Default_A.Stop();
            }
            _monitorStarted = false;
        }

        private void ResetMonitorButtonState()
        {
            if (_monitorStarted)
            {
                this.lnkMonitor.Text = "停止采集(&E)";
                this.lnkMonitor.LinkColor = Color.LightCoral;
            }
            else
            {
                this.lnkMonitor.Text = "启动采集(&E)";
                this.lnkMonitor.LinkColor = Color.DodgerBlue;
            }
        }

        private void CheckCQProcess()
        {
            if (Process.GetProcessesByName("CQA").Length == 0)
                Process.Start(Constants.CQPath);
            if (Process.GetProcessesByName("Flexlive.CQP.CSharpProxy").Length == 0)
                Process.Start(Constants.CQProxyPath);
        }

        string Ipc_Recieve(IpcArgs args)
        {
            QQMessage qqMessage = JsonConvert.DeserializeObject<QQMessage>(args.Content);
            AddTask(qqMessage);
            return "";
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask(false);
        }

        private void btnAddTaskAtOnce_Click(object sender, EventArgs e)
        {
            AddTask(true);
        }

        private void AddTask(bool addToTop)
        {
            if (!string.IsNullOrEmpty(this.HtmlEditValue))
            {
                QQMessage qqMessage = new QQMessage()
                {
                    Message = this.HtmlEditValue
                };
                AddTask(qqMessage, addToTop);
                this.HtmlEditValue = string.Empty;
                this.tabMain.SelectedTab = this.tpageTransmit;
            }
        }

        private void AddTask(QQMessage qqMessage, bool addToTop = false)
        {
            TransmitTask transmitTask = new TransmitTask()
            {
                Content = qqMessage.Message,
                From = qqMessage.fromGroup > 0 ? qqMessage.fromGroup.ToString() : "手工添加",
                CreateTime = DateTime.Now,
                Priority = addToTop ? 1 : 0
            };
            _transmitTaskRepository.Add(transmitTask);
            AddToDataSource(transmitTask, addToTop, true);
            this.Invoke((EventHandler)delegate
            {
                gridTasks.Refresh();
            });
        }

        #endregion

        #region 转发Timer

        private void linkTransmit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_transmitStarted)
            {
                StopTransmit();
            }
            else
            {
                StartTransmit();
            }
            ResetTransmitButtonState();
        }

        private void StartTransmit()
        {
            //NamedPipedIpcClient.Default_A.Send(new IpcArgs("asdf"));
            timerTransmit.Interval = GlobalSetting.Instance.TransmitSetting.TransmitInterval * 1000;
            timerTransmit.Start();
            _transmitStarted = true;
        }

        private void StopTransmit()
        {
            timerTransmit.Stop();
            _transmitStarted = false;
        }

        private void ResetTransmitButtonState()
        {
            if (_transmitStarted)
            {
                this.lnkTransmit.Text = "停止转发(&R)";
                this.lnkTransmit.LinkColor = Color.LightCoral;
            }
            else
            {
                this.lnkTransmit.Text = "启动转发(&R)";
                this.lnkTransmit.LinkColor = Color.DodgerBlue;
            }
        }

        private void timerTransmit_Tick(object sender, EventArgs e)
        {
            if (!_transmitting && _dataSource.Rows.Count > 0)
            {
                _transmitting = true;
                try
                {
                    DataRow row = _dataSource.Rows[0];
                    TransmitTask transmitTask = GetTransmitTaskFromRow(row);
                    Transmit(transmitTask);
                    _transmitTaskRepository.UpdateStatus(transmitTask.Id);
                    _dataSource.Rows.Remove(row);
                    this.gridTasks.Refresh();
                }
                finally
                {
                    _transmitting = false;
                }
            }
        }

        void Transmit(TransmitTask transmitTask)
        {
            string tempImagePath = string.Empty;
            string msg = ParseCQMessage(transmitTask.Content, out tempImagePath);
            // 复制到剪切板
            this.Invoke((EventHandler)delegate
            {
                ClipboardHelper.CopyToClipboard(msg, "");
            });
            // 打开群快捷方式，进行粘贴
            if (string.IsNullOrEmpty(GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath))
            {
                MessageBox.Show("群快捷方式路径为空，请在全局设置中设置", "错误", MessageBoxButtons.OK);
            }
            else
            {
                DirectoryInfo dir = new DirectoryInfo(GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath);
                this.Invoke((EventHandler)delegate
                {
                    foreach (FileInfo file in dir.GetFiles())
                    {
                        using (Process.Start(file.FullName))
                        {
                            Thread.Sleep(GlobalSetting.Instance.TransmitSetting.SleepInterval);
                            SendKeys.Send("^v"); // Paster
                            Thread.Sleep(GlobalSetting.Instance.TransmitSetting.SleepInterval);
                            SendKeys.Send("%s"); // Send
                        }
                    }
                });
            }
            if (File.Exists(tempImagePath))
                File.Delete(tempImagePath);
        }

        #endregion

        #region 其它事件

        private void lnkSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.ShowDialog();
            timerTransmit.Interval = GlobalSetting.Instance.TransmitSetting.TransmitInterval * 1000;
        }

        private void gridTasks_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 1) // 转发内容
            {
                e.Value = _regexCQImage.Replace(e.Value.ToString(), "[图片]");
            }
            else if (e.ColumnIndex == 5) // 创建时间
            {
                e.Value = e.Value.ToString();
            }
        }

        private void gridTasks_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                DataRowView rowView = (DataRowView)this.bsTasks[e.RowIndex];
                string content = Convert.ToString(rowView["Content"]);
                if (!FormPreview.Instance.Visible)
                    FormPreview.Instance.Show();
                string tempImagePath;
                FormPreview.Instance.DocumentText = ParseCQMessage(content, out tempImagePath);
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(this.tabMain.SelectedTab == this.tpageTransmit)
            {
                if (_suspendPreview && !FormPreview.Instance.Visible)
                {
                    FormPreview.Instance.Show();
                    _suspendPreview = false;
                }
            }
            else
            {
                if (FormPreview.Instance.Visible)
                {
                    FormPreview.Instance.Hide();
                    _suspendPreview = true;
                }
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #endregion
        
        #region 私有方法

        private void ResetRowNo()
        {
            for (int i = 0; i < _dataSource.Rows.Count; i++)
            {
                _dataSource.Rows[i]["RowNo"] = i + 1;
            }
        }

        private void AddToDataSource(TransmitTask transmitTask, bool addToTop = false, bool resetRowNo = false)
        {
            DataRow newRow = _dataSource.NewRow();
            newRow["Id"] = transmitTask.Id;
            newRow["Content"] = transmitTask.Content;
            newRow["From"] = transmitTask.From;
            newRow["CommissionRate"] = transmitTask.CommissionRate;
            newRow["Coupon"] = transmitTask.Coupon;
            newRow["CreateTime"] = transmitTask.CreateTime;
            if (addToTop)
                _dataSource.Rows.InsertAt(newRow, 0);
            else
                _dataSource.Rows.Add(newRow);

            if (resetRowNo)
            {
                if (addToTop)
                    ResetRowNo();
                else
                {
                    if (_dataSource.Rows.Count > 1)
                    {
                        newRow["RowNo"] = Convert.ToInt32(_dataSource.Rows[_dataSource.Rows.Count - 2]["RowNo"]) + 1;
                    }
                    else
                    {
                        newRow["RowNo"] = 1;
                    }
                }
            }
        }

        private TransmitTask GetTransmitTaskFromRow(DataRow row)
        {
            return new TransmitTask()
            {
                Id = Convert.ToInt32(row["Id"]),
                Content = Convert.ToString(row["Content"]),
                From = Convert.ToString(row["From"]),
                CommissionRate = Convert.ToInt32(row["CommissionRate"]),
                Coupon = Convert.ToString(row["Coupon"]),
                CreateTime = Convert.ToDateTime(row["CreateTime"])
            };
        }

        // 替换CQ消息为html文本（cqimg图片）
        private string ParseCQMessage(string msg, out string tempImagePath)
        {
            Match match = _regexCQImage.Match(msg);
            tempImagePath = string.Empty;
            if (match.Success && match.Groups.Count > 1)
            {
                string imageName = match.Groups[1].Value;
                tempImagePath = Path.Combine(Constants.CQImagePath, imageName);
                string iniFilePath = tempImagePath + ".cqimg";
                string imageUrl = IniFileUtil.ReadIniData("image", "url", "", iniFilePath);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    if (!File.Exists(tempImagePath))
                        WebRequestHelper.DownloadFile(imageUrl, tempImagePath);
                    msg = msg.Remove(match.Index, match.Length);
                    msg = msg.Insert(match.Index, string.Format("<img src='file:///{0}' height='200'>", tempImagePath));
                }
            }
            return msg.Replace("\r\n", "<br />");
        }

        #endregion

    }
}
