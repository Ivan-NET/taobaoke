using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TaobaoKe.Core.Log
{
    public class LogItem
    {
        public DateTime create_time;

        public int Id { get; set; }
        public byte Level { get; set; }
        public byte Type { get; set; }
        public DateTime CreateTime
        {
            get { return create_time; }
            set { create_time = value; }
        }
        public string Content { get; set; }
    }

    public enum LogItemType : byte
    {
        [DescriptionAttribute("初始化")]
        Initialize = 0,

        [DescriptionAttribute("系统")]
        System = 1,

        [DescriptionAttribute("接收")]
        Receive = 2,

        [DescriptionAttribute("转发")]
        Transmit = 3,

        [DescriptionAttribute("采集")]
        Monitor = 4
    }
}
