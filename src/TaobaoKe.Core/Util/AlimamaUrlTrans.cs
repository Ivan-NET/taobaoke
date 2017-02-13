using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TaobaoKe.Core.Util
{
    public class AlimamaUrlTrans
    {
        private static readonly string urlTransAPI = "http://pub.alimama.com/urltrans/urltrans.json?siteid={0}&adzoneid={1}&promotionURL={2}&t={3}&pvid={4}&tbtoken={5}&inputcharset={6}";

        public static TransformResult Transform(TransformParam param, string cookies)
        {
            try
            {
                string url = string.Format(urlTransAPI, param.SiteId, param.AdZoneId, param.PromotionURL, param.T, param.PvId, param.TbToken, param.InputCharset);
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Cookie", cookies);
                string result = WebRequestHelper.Get(url, "", headers);
                JObject jsonResult = (JObject)JsonConvert.DeserializeObject(result);
                JObject data = (JObject)jsonResult.GetValue("data");
                return new TransformResult()
                {
                    SClick = data.Value<string>("sclick"),
                    TaoToken = data.Value<string>("taoToken"),
                    QRCodeUrl = data.Value<string>("qrCodeUrl"),
                    ShortLinkUrl = data.Value<string>("shortLinkUrl")
                };
            }
            catch (Exception e)
            {
                // TODO:Log
            }
            return null;
        }
    }

    public class TransformParam
    {
        public string SiteId { get; set; }
        public string AdZoneId { get; set; }
        public string PromotionURL { get; set; }
        public long T { get; set; }
        public string PvId { get; set; }
        public string TbToken { get; set; }
        public string InputCharset { get; set; }
    }

    public class TransformResult
    {
        public string SClick { get; set; }
        public string TaoToken { get; set; }
        public string QRCodeUrl { get; set; }
        public string ShortLinkUrl { get; set; }
    }
}
