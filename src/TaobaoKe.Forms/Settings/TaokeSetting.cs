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
        private SiteAdZone _defaultSiteAdZone = null;
        private Dictionary<string, SiteAdZone> _qqGroupSiteAdZones = null;

        public string Account { get; set; }
        public string Password { get; set; }
        
        public string PId { get; set; }

        public SiteAdZone DefaultSiteAdZone
        {
            get
            {
                if(_defaultSiteAdZone == null)
                    _defaultSiteAdZone = new SiteAdZone();
                return _defaultSiteAdZone;
            }
        }

        public Dictionary<string, SiteAdZone> QQGroupSiteAdZones
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
    }
}
