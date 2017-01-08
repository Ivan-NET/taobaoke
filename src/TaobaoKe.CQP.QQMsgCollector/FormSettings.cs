﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using TaobaoKe.Core.IPC;

namespace Rap.CQP.QQMsgCollector
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
            this.lblStatus.Text = NamedPipedIpcClient.Default_B.Started ? "已启动" : "未启动";
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            IpcResult ipcResult = NamedPipedIpcClient.Default_B.Send(new IpcArgs("test"));
            if (ipcResult.Success)
            {
                MessageBox.Show("连接正常");
            }
            else
            {
                MessageBox.Show("无法连接");
            }
        }
    }
}