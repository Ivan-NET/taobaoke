using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaobaoKe.Common.Models
{
    public class PaymentDetailsResponse
    {
        public PaymentDetails data { get; set; }
    }

    public class PaymentDetails
    {
        public List<Payment> paymentList { get; set; }
    }

    public class Payment
    {
        public string createTime { get; set; }
        public string shareRate { get; set; }
        public string earningTime { get; set; }
        public string bizType { get; set; }
        public string tkBizTag { get; set; }
        public string tk3rdPubShareFee { get; set; }
        public string tk3rdTypeStr { get; set; }
        public string auctionId { get; set; }
        public string auctionTitle { get; set; }
        public string auctionUrl { get; set; }
        public string tkShareRate { get; set; }
        public string payStatus { get; set; }
        public string exShopTitle { get; set; }
        public string realPayFeeString { get; set; }
        public string auctionNum { get; set; }
        public string payPrice { get; set; }
        public string taobaoTradeParentId { get; set; }
        public string exNickName { get; set; }
        public string tkShareRateToString { get; set; }
        public string tkPubShareFeeString { get; set; }
        public string feeString { get; set; }
        public string terminalType { get; set; }
        public string discountAndSubsidyToString { get; set; }
        public string finalDiscountToString { get; set; }
        public string exMemberId { get; set; }
        public string realPayFee { get; set; }
        public string totalAlipayFeeString { get; set; }
    }
}
