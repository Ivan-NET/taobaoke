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
        private Dictionary<string, string> _qqGroupAdZones;

        public FormAdZonesSetting(string qqGroupLinkPath, Dictionary<string, string> qqGroupAdZones)
        {
            _qqGroupLinkPath = qqGroupLinkPath;
            _qqGroupAdZones = qqGroupAdZones;
            if (!Directory.Exists(_qqGroupLinkPath))
            {
                throw new Exception("群快捷方式路径不存在");
            }
            InitializeComponent();
            InitializeControl();
        }

        private void InitializeControl()
        {
            AdZone[] adzones = new AdZone[AlimamaAPI.AdZones.Count];
            AlimamaAPI.AdZones.Values.CopyTo(adzones, 0);
            colAdZoneId.DataSource = adzones;
            colAdZoneId.ValueMember = "AdZoneId";
            colAdZoneId.DisplayMember = "AdZoneName";
            _dataSource = new DataTable("Master");
            _dataSource.Columns.Add("QQGroupName", typeof(string));
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
                string adZoneId = GetAdZoneId(qqGroupName);
                DataRow newRow = _dataSource.NewRow();
                newRow["QQGroupName"] = qqGroupName;
                newRow["AdZoneId"] = adZoneId;
                _dataSource.Rows.Add(newRow);
            }
            _dataSource.AcceptChanges();
        }

        private string GetAdZoneId(string qqGroupName)
        {
            string result = null;
            _qqGroupAdZones.TryGetValue(qqGroupName, out result);
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
                    string adZoneId = Convert.ToString(row["AdZoneId"]);
                    if (!string.IsNullOrEmpty(adZoneId))
                    {
                        _qqGroupAdZones[qqGroupName] = adZoneId;
                    }
                }
                else
                {
                    string qqGroupName = Convert.ToString(row["QQGroupName", DataRowVersion.Original]);
                    _qqGroupAdZones.Remove(qqGroupName);
                }
            }
        }
    }
}
