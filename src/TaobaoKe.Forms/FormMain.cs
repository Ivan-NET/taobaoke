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

namespace TaobaoKe.Forms
{
    [ComVisible(true)]
    public partial class FormMain : FormBase
    {
        DataTable _dataSource = null;
        private string _htmlContent = string.Empty;

        public FormMain()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            this.wbTransmit.Url = new System.Uri(Constants.HtmlEditorPath);
            this.wbTransmit.ObjectForScripting = this;

            _dataSource = new DataTable("Master");
            _dataSource.Columns.Add("Content", typeof(string));
            _dataSource.Columns.Add("From", typeof(string));
            bindingSrc.DataSource = _dataSource;
            bindingSrc.DataMember = "";
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        #region HtmlEditor

        public string GetContent()
        {
            return _htmlContent;
        }

        public void RequestContent(string str)
        {
            _htmlContent = str;
        }

        //public void SetDetailContent()
        //{
        //    wbTransmit.Document.InvokeScript("setContent", new object[] { _htmlContent });
        //}

        private void wbTransmit_Resize(object sender, EventArgs e)
        {
            this.wbTransmit.Refresh();
        }

        #endregion

        #region 按钮事件

        private void lnkTransmitSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.ShowDialog();
        }

        private void btnStartMonitor_Click(object sender, EventArgs e)
        {
            CheckCQProcess();
            if (!NamedPipedIpcClient.Default_A.Started)
            {
                NamedPipedIpcClient.Default_A.Start();
                NamedPipedIpcClient.Default_A.Recieve += Ipc_Recieve;
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
            Transmit(qqMessage);
            AddTask(qqMessage);
            return "";
        }

        private void AddTask(QQMessage qqMessage)
        {
            _dataSource.Rows.Add(qqMessage.Message, qqMessage.fromGroup.ToString());
            this.Invoke((EventHandler)delegate
            {
                dataGridView1.Refresh();
            });
        }

        void Transmit(QQMessage qqMessage)
        {
            string msg = qqMessage.Message;
            Regex reg = new Regex(@"\[CQ:image,file=(.+)\]");
            Match match = reg.Match(msg);
            string tempImagePath = string.Empty;
            if (match.Success && match.Groups.Count > 1)
            {
                string imageName = match.Groups[1].Value;
                tempImagePath = Path.Combine(Constants.CQImagePath, imageName);
                string iniFilePath = tempImagePath + ".cqimg";
                string imageUrl = IniFileUtil.ReadIniData("image", "url", "", iniFilePath);
                if (!string.IsNullOrEmpty(imageUrl))
                {
                    WebRequestHelper.DownloadFile(imageUrl, tempImagePath);
                    msg = msg.Remove(match.Index, match.Length);
                    msg = msg.Insert(match.Index, string.Format("<img src='file:///{0}'>", tempImagePath));
                }
            }
            msg = msg.Replace("\r\n", "<br />");
            this.Invoke((EventHandler) delegate
            {
                ClipboardHelper.CopyToClipboard(msg, "");
            });

            DirectoryInfo dir = new DirectoryInfo(GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath);
            this.Invoke((EventHandler) delegate
            {
                foreach (FileInfo file in dir.GetFiles())
                {
                    using (Process.Start(file.FullName))
                    {
                        Thread.Sleep(500);
                        SendKeys.Send("^v"); // Paster
                        Thread.Sleep(500);
                        SendKeys.Send("%s"); // Send
                    }
                }
            });
            if (File.Exists(tempImagePath))
                File.Delete(tempImagePath);
        }

        private void btnStopMonitor_Click(object sender, EventArgs e)
        {
            if (NamedPipedIpcClient.Default_A.Started)
            {
                NamedPipedIpcClient.Default_A.Stop();
            }
        }

        private void StartTransmit_Click(object sender, EventArgs e)
        {

        }

        private void btnSuspendTransmit_Click(object sender, EventArgs e)
        {

        }

        private void btnStopTransmit_Click(object sender, EventArgs e)
        {

        }

        private void btnDoTransmit_Click(object sender, EventArgs e)
        {
            QQMessage qqMessage = new QQMessage()
            {
                Message = _htmlContent
            };
            Transmit(qqMessage);
            AddTask(qqMessage);
        }

        #endregion
    }
}
