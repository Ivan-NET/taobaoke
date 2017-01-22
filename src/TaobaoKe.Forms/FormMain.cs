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
    public partial class FormMain : FormBase
    {
        DataTable _dataSource = null;

        public FormMain()
        {
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
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

        #region 按钮事件

        private void lnkTransmitSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.ShowDialog();
        }

        private void btnStartMonitor_Click(object sender, EventArgs e)
        {
            if (!NamedPipedIpcClient.Default_A.Started)
            {
                NamedPipedIpcClient.Default_A.Start();
                NamedPipedIpcClient.Default_A.Recieve += Ipc_Recieve;
            }
        }

        string Ipc_Recieve(IpcArgs args)
        {
            QQMessage qqMessage = JsonConvert.DeserializeObject<QQMessage>(args.Content);

            Transmit(qqMessage);

            _dataSource.Rows.Add(qqMessage.Message, qqMessage.fromGroup.ToString());
            this.Invoke((EventHandler)delegate
            {
                dataGridView1.Refresh();
            });
            return "";
        }

        void Transmit(QQMessage qqMessage)
        {
            string msg = qqMessage.Message;
            Regex reg = new Regex("");
            Match match = reg.Match(msg);
            if (match.Success)
            {
                string imageName = match.Value;
                string iniFilePath = Path.Combine(Constants.CQImagePath, imageName, ".cqimg");
                string imageUrl = IniFileUtil.ReadIniData("image", "url", "", iniFilePath);
                if (string.IsNullOrEmpty(imageUrl))
                {
                    msg = msg.Replace("", "");
                }
            }
            msg = msg.Replace("\r\n", "<br />");
            ClipboardHelper.CopyToClipboard(msg, "");

            DirectoryInfo dir = new DirectoryInfo(GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath);
            foreach (FileInfo file in dir.GetFiles())
            {
                using (Process.Start(file.FullName))
                {
                    Thread.Sleep(50);
                    SendKeys.Send("^v"); // Paster
                    Thread.Sleep(50);
                    SendKeys.Send("%s"); // Send
                }
            }
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

        #endregion
    }
}
