﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaobaoKe.Core.IPC;

namespace TaobaoKe.Forms
{
    public partial class FormMain : FormBase
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnMonitorSetting_Click(object sender, EventArgs e)
        {
            FormMonitorSetting formMonitorSetting = new FormMonitorSetting();
            formMonitorSetting.ShowDialog();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnStartMonitor_Click(object sender, EventArgs e)
        {
            if (NamedPipedIpcClient.Default_A.Started)
            {
                //NamedPipedIpcClient.Default_A.Stop();
                NamedPipedIpcClient.Default_A.Send(new IpcArgs("adfasfa"));
            }
            else
            {
                NamedPipedIpcClient.Default_A.Start();
                NamedPipedIpcClient.Default_A.Recieve += Ipc_Recieve;
            }
        }

        string Ipc_Recieve(IpcArgs args)
        {
            MessageBox.Show(args.Content);
            return "";
        }
    }
}
