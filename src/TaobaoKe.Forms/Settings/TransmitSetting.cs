using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaobaoKe.Forms.Settings
{
    public class TransmitSetting
    {
        private int _transmitInterval = 1;
        private int _sleepInterval = 500;

        public string QQGroupLnkPath { get; set; }

        public int TransmitInterval
        {
            get
            {
                if (_transmitInterval == 0)
                    _transmitInterval = 1;
                return _transmitInterval;
            }
            set
            {
                _transmitInterval = value;
            }
        }

        public int SleepInterval
        {
            get
            {
                if (_sleepInterval == 0)
                    _sleepInterval = 500;
                return _sleepInterval;
            }
            set
            {
                _sleepInterval = value;
            }
        }
    }
}
