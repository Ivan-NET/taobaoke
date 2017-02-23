using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Common.Models
{
    public class QQMessage
    {
        public string Message { get; set; }

        public long fromGroup { get; set; }

        public long fromQQ { get; set; }

        public string fromAnonymous { get; set; }

        public override string ToString()
        {
            return string.Format("来源:{0},消息:{1}", fromGroup, Message);
        }
    }
}
