using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaobaoKe.Common.Models;

namespace TaobaoKe.Forms.Settings
{
    class TaokeSetting
    {
        private string _defaultAdZoneId = null;
        private Dictionary<string, string> _qqGroupAdZones = null;

        public string Account { get; set; }
        public string Password { get; set; }
        
        public string DefaultAdZoneId
        {
            get
            {
                return _defaultAdZoneId;
            }
            set
            {
                _defaultAdZoneId = value;
            }
        }

        public Dictionary<string, string> QQGroupAdZones
        {
            get
            {
                if (_qqGroupAdZones == null)
                {
                    _qqGroupAdZones = new Dictionary<string, string>();
                }
                return _qqGroupAdZones;
            }
            set { _qqGroupAdZones = value; }
        }
    }
}
