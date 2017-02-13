using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.Util
{
    public static class DateUtil
    {
        public static long GetUnixTimestamp()
        {
            TimeSpan timeSpan = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(timeSpan.TotalSeconds);
        }
    }
}
