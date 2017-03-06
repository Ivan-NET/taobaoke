using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TaobaoKe.Common.Models;
using TaobaoKe.Forms.Settings;

namespace TaobaoKe.Forms
{
    public partial class FormSetting : FormBase
    {
        private Dictionary<string, string> _qqGroupAdZones = null;

        public FormSetting()
        {
            InitializeComponent();
            this.txtSleepInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            this.txtTransmitInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            //this.txtSiteId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            //this.txtAdZoneId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            InitializeControl();
        }

        private void lnkBrowseFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (DialogResult.OK == dialog.ShowDialog())
                {
                    GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath = txtQQGroupLnkPath.Text = dialog.SelectedPath;
                }
            }
        }

        private void lnkOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath))
                Process.Start("explorer.exe", GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ApplySettings();
            this.DialogResult = DialogResult.OK;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            ApplySettings();
        }

        private void ApplySettings()
        {
            GlobalSetting.Instance.MonitorSetting.QQGroupNo = this.txtQQGroupNo.Text.Trim();
            GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath = txtQQGroupLnkPath.Text;

            GlobalSetting.Instance.TransmitSetting.TransmitInterval = Convert.ToInt32(txtTransmitInterval.Text);
            GlobalSetting.Instance.TransmitSetting.SleepInterval = Convert.ToInt32(txtSleepInterval.Text);

            GlobalSetting.Instance.TaokeSetting.DefaultAdZoneId = cboxAdZone.SelectedValue == null ? string.Empty : cboxAdZone.SelectedValue.ToString();
            GlobalSetting.Instance.TaokeSetting.QQGroupAdZones = _qqGroupAdZones;
            string newAccount = txtAccount.Text.Trim();
            if (GlobalSetting.Instance.TaokeSetting.Account != null && GlobalSetting.Instance.TaokeSetting.Account != newAccount)
            {
                // 帐号发生切换，需要重新启动
                AlimamaAPI.CleanTbToken();
                GlobalSetting.Instance.TaokeSetting.DefaultAdZoneId = string.Empty;
                GlobalSetting.Instance.TaokeSetting.QQGroupAdZones = null;
            }
            GlobalSetting.Instance.TaokeSetting.Account = newAccount;
            GlobalSetting.Instance.TaokeSetting.Password = txtPassword.Text;

            GlobalSetting.Instance.Save();
        }

        private void InitializeControl()
        {
            this.txtQQGroupNo.Text = GlobalSetting.Instance.MonitorSetting.QQGroupNo;
            this.txtQQGroupLnkPath.Text = GlobalSetting.Instance.TransmitSetting.QQGroupLnkPath;

            this.txtTransmitInterval.Text = GlobalSetting.Instance.TransmitSetting.TransmitInterval.ToString();
            this.txtSleepInterval.Text = GlobalSetting.Instance.TransmitSetting.SleepInterval.ToString();

            txtAccount.Text = GlobalSetting.Instance.TaokeSetting.Account;
            txtPassword.Text = GlobalSetting.Instance.TaokeSetting.Password;
            if (!string.IsNullOrEmpty(txtAccount.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                AdZone[] adzones = new AdZone[AlimamaAPI.AdZones.Count];
                AlimamaAPI.AdZones.Values.CopyTo(adzones, 0);
                cboxAdZone.DataSource = adzones;
                cboxAdZone.ValueMember = "AdZoneId";
                cboxAdZone.DisplayMember = "AdZoneName";
                cboxAdZone.Text = GlobalSetting.Instance.TaokeSetting.DefaultAdZoneId;
            }
            _qqGroupAdZones = new Dictionary<string, string>();
            foreach (var item in GlobalSetting.Instance.TaokeSetting.QQGroupAdZones)
            {
                _qqGroupAdZones.Add(item.Key, item.Value);
            }
        }

        private void DigitTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lnkTestLoginAlimama_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAlimamaLogin formAlimamaLogin = new FormAlimamaLogin(txtAccount.Text.Trim(), txtPassword.Text);
            if (formAlimamaLogin.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("测试自动登录成功");
            }
        }

        private void lnkAdZonesSetting_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormAdZonesSetting formAdZonesSetting = new FormAdZonesSetting(txtQQGroupLnkPath.Text, _qqGroupAdZones);
            formAdZonesSetting.ShowDialog();
        }

        private void cboxAdZone_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index > -1)
            {
                AdZone item = (AdZone)cboxAdZone.Items[e.Index];
                e.Graphics.DrawString(item.AdZoneName, e.Font, Brushes.Black, e.Bounds);
            }
        }
    }
}
