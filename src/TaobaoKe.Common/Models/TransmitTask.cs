using System;

namespace TaobaoKe.Common.Models
{
    public class TransmitTask
    {
        private DateTime create_time;
        private decimal commission_rate;
        private DateTime transmit_time;

        public int Id { get; set; }

        public string Content { get; set; }

        public string From { get; set; }

        public decimal CommissionRate
        {
            get { return commission_rate; }
            set { commission_rate = value; }
        }

        public string Coupon { get; set; }

        public DateTime CreateTime
        {
            get { return create_time; }
            set { create_time = value; }
        }

        public byte Status { get; set; }

        public DateTime TransmitTime
        {
            get { return transmit_time; }
            set { transmit_time = value; }
        }

        public int Priority { get; set; }
    }
}
