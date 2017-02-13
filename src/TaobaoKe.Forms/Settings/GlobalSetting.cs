using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaobaoKe.Core;
using TaobaoKe.Util;

namespace TaobaoKe.Forms.Settings
{
    class GlobalSetting
    {
        static GlobalSetting _instance;
        MonitorSetting _monitorSetting;
        TransmitSetting _transmitSetting;
        TaokeSetting _taokeSetting;

        private GlobalSetting()
        {
        }

        public static GlobalSetting Instance
        {
            get
            {
                if (_instance == null)
                {
                    Load();
                    if (_instance == null)
                    {
                        _instance = new GlobalSetting();
                    }
                }
                return _instance;
            }
        }

        private static void Load()
        {
            if (File.Exists(Constants.ConfigFilePath))
            {
                using (StreamReader sr = new StreamReader(Constants.ConfigFilePath))
                {
                    string encryptedConfig = sr.ReadToEnd();
                    string config = SecurityUtil.DecryptKeyFieldValue(encryptedConfig);
                    _instance = JsonConvert.DeserializeObject<GlobalSetting>(config);
                }
            }
        }

        public MonitorSetting MonitorSetting
        {
            get
            {
                if (_monitorSetting == null)
                    _monitorSetting = new MonitorSetting();
                return _monitorSetting;
            }
        }

        public TransmitSetting TransmitSetting
        {
            get
            {
                if (_transmitSetting == null)
                    _transmitSetting = new TransmitSetting();
                return _transmitSetting;
            }
        }

        public TaokeSetting TaokeSetting
        {
            get
            {
                if (_taokeSetting == null)
                    _taokeSetting = new TaokeSetting();
                return _taokeSetting;
            }
        }

        public void Save()
        {
            string config = JsonConvert.SerializeObject(this);
            string encryptedConfig = SecurityUtil.EncryptKeyFieldValue(config);
            using (StreamWriter sw = new StreamWriter(Constants.ConfigFilePath))
            {
                sw.Write(encryptedConfig);
            }
        }
    }
}
