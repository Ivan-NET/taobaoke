using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Common.Models
{
    public class TwoInOneLink
    {
        private String ROOT_URL = "https://uland.taobao.com/coupon/edetail";
        private String activityId;
        private String pid;
        private String itemId;
        private String src;
        private String dx;

        public TwoInOneLink()
        {
        }

        public TwoInOneLink(String activityId, String pid, String itemId, String src, String dx)
        {
            this.activityId = activityId;
            this.pid = pid;
            this.itemId = itemId;
            this.src = src;
            this.dx = dx;
        }

        public string GenerateLink()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(ROOT_URL).Append("?")
                    .Append("activityId=").Append(this.activityId).Append("&")
                    .Append("pid=").Append(this.pid).Append("&")
                    .Append("itemId=").Append(this.itemId).Append("&")
                    .Append("src=").Append(this.src).Append("&")
                    .Append("dx=").Append(this.dx);
            return sb.ToString();
        }
    }
}
