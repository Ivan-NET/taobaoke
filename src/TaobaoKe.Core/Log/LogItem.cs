using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.Log
{
    public class LogItem
    {
        public int Id { get; set; }
        public byte Level { get; set; }
        public byte Type { get; set; }
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
    }

    public enum LogItemType : byte
    {
        Initialize = 0,
        System = 1,
        Monitor = 2,
    }
}
