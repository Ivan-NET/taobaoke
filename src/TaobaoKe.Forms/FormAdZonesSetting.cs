using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaobaoKe.Common.Models;

namespace TaobaoKe.Forms
{
    public partial class FormAdZonesSetting : FormBase
    {
        DataTable _dataSource = null;
        private string _qqGroupLinkPath;
        private Dictionary<string, SiteAdZone> _qqGroupSiteAdZones;

        public FormAdZonesSetting(string qqGroupLinkPath, Dictionary<string, SiteAdZone> qqGroupSiteAdZones)
        {
            _qqGroupLinkPath = qqGroupLinkPath;
            _qqGroupSiteAdZones = qqGroupSiteAdZones;
            if (!Directory.Exists(_qqGroupLinkPath))
            {
                throw new Exception("群快捷方式路径不存在");
            }
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            _dataSource = new DataTable("Master");
            _dataSource.Columns.Add("QQGroupName", typeof(string));
            _dataSource.Columns.Add("SiteId", typeof(string));
            _dataSource.Columns.Add("AdZoneId", typeof(string));
            bsAdZones.DataSource = _dataSource;
            bsAdZones.DataMember = "";
        }

        private void FormAdZonesSetting_Load(object sender, EventArgs e)
        {
            LoadAdZones();
        }

        private void LoadAdZones()
        {
            DirectoryInfo dir = new DirectoryInfo(_qqGroupLinkPath);
            foreach (FileInfo file in dir.GetFiles())
            {
                string qqGroupName = Path.GetFileNameWithoutExtension(file.Name);
                SiteAdZone siteAdZone = GetSiteAdZone(qqGroupName);
                DataRow newRow = _dataSource.NewRow();
                newRow["QQGroupName"] = qqGroupName;
                if (siteAdZone != null)
                {
                    newRow["SiteId"] = siteAdZone.SiteId;
                    newRow["AdZoneId"] = siteAdZone.AdZoneId;
                }
                _dataSource.Rows.Add(newRow);
            }
            _dataSource.AcceptChanges();
        }

        private SiteAdZone GetSiteAdZone(string qqGroupName)
        {
            SiteAdZone result = null;
            _qqGroupSiteAdZones.TryGetValue(qqGroupName, out result);
            return result;
        }

        private void FormAdZonesSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            gridAdZones.EndEdit();
            ApplySetting();
        }

        private void ApplySetting()
        {
            foreach (DataRow row in _dataSource.Rows)
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    string qqGroupName = Convert.ToString(row["QQGroupName"]);
                    string siteId = Convert.ToString(row["SiteId"]);
                    string adZoneId = Convert.ToString(row["AdZoneId"]);
                    if (!string.IsNullOrEmpty(siteId) || !string.IsNullOrEmpty(adZoneId))
                    {
                        if (string.IsNullOrEmpty(siteId))
                        {
                            throw new Exception(string.Format("群名称'{0}'的导购Id不允许为空", qqGroupName));
                        }
                        if (string.IsNullOrEmpty(adZoneId))
                        {
                            throw new Exception(string.Format("群名称'{0}'的推广位Id不允许为空", qqGroupName));
                        }
                        SiteAdZone siteAdZone = null;
                        if (!_qqGroupSiteAdZones.TryGetValue(qqGroupName, out siteAdZone))
                        {
                            siteAdZone = new SiteAdZone();
                            _qqGroupSiteAdZones.Add(qqGroupName, siteAdZone);
                        }
                        siteAdZone.SiteId = siteId;
                        siteAdZone.AdZoneId = adZoneId;
                    }
                }
                else
                {
                    string qqGroupName = Convert.ToString(row["QQGroupName", DataRowVersion.Original]);
                    _qqGroupSiteAdZones.Remove(qqGroupName);
                }
            }
        }
    }
}
