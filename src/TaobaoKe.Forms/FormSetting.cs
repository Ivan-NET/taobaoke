using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using TaobaoKe.Common.Models;
using TaobaoKe.Forms.Settings;

namespace TaobaoKe.Forms
{
    public partial class FormSetting : FormBase
    {
        private Dictionary<string, SiteAdZone> _qqGroupSiteAdZones = null;

        public FormSetting()
        {
            InitializeComponent();
            this.txtSleepInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            this.txtTransmitInterval.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            //this.txtSiteId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            //this.txtAdZoneId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitTextBox_KeyPress);
            InitializeControl();
        }

        private Dictionary<string, SiteAdZone> QQGroupSiteAdZones
        {
            get
            {
                if (_qqGroupSiteAdZones == null)
                {
                    _qqGroupSiteAdZones = new Dictionary<string, SiteAdZone>();
                }
                return _qqGroupSiteAdZones;
            }
            set { _qqGroupSiteAdZones = value; }
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

            GlobalSetting.Instance.TaokeSetting.Account = txtAccount.Text.Trim();
            GlobalSetting.Instance.TaokeSetting.Password = txtPassword.Text;
            GlobalSetting.Instance.TaokeSetting.DefaultSiteAdZone.SiteId = txtSiteId.Text.Trim();
            GlobalSetting.Instance.TaokeSetting.DefaultSiteAdZone.AdZoneId = txtAdZoneId.Text.Trim();
            GlobalSetting.Instance.TaokeSetting.QQGroupSiteAdZones = QQGroupSiteAdZones;

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
            txtSiteId.Text = GlobalSetting.Instance.TaokeSetting.DefaultSiteAdZone.SiteId;
            txtAdZoneId.Text = GlobalSetting.Instance.TaokeSetting.DefaultSiteAdZone.AdZoneId;
            QQGroupSiteAdZones = new Dictionary<string, SiteAdZone>();
            foreach (var item in GlobalSetting.Instance.TaokeSetting.QQGroupSiteAdZones)
            {
                QQGroupSiteAdZones.Add(item.Key, new SiteAdZone()
                    {
                        SiteId = item.Value.SiteId,
                        AdZoneId = item.Value.AdZoneId
                    });
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
            FormAdZonesSetting formAdZonesSetting = new FormAdZonesSetting(txtQQGroupLnkPath.Text, QQGroupSiteAdZones);
            formAdZonesSetting.ShowDialog();
        }
    }
}
