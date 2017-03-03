using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaobaoKe.Common.Models;
using TaobaoKe.Core.Util;
using TaobaoKe.Forms.Settings;

namespace TaobaoKe.Forms
{
    public static class AlimamaAPI
    {
        private static readonly string Url_Guides = "http://pub.alimama.com/common/site/generalize/guideList.json?_tb_token_={0}&_input_charset=utf-8";
        private static readonly string Url_AdZones = "http://pub.alimama.com/common/adzone/adzoneManage.json?request_count=1&tab=3&toPage=1&perPageSize=40&gcid=8&_tb_token_={0}&_input_charset=utf-8";
        private static readonly string Url_PaymentDetails = "http://pub.alimama.com/report/getTbkPaymentDetails.json?startTime={1}&endTime={2}&payStatus={0}&queryType=1&toPage=1&perPageSize=&_tb_token_={3}&_input_charset=utf-8";
        private static readonly string Url_PaymentDetails_Report = "http://pub.alimama.com/report/getTbkPaymentDetails.json?queryType=1&payStatus={0}&DownloadID=DOWNLOAD_REPORT_INCOME_NEW&startTime={1}&endTime={2}";
        
        private static string _tbToken = null;
        private static string _cookie = null;
        private static string _memberId = null;
        private static Dictionary<string, AdZone> _adZones = null;

        public static string MemberId
        {
            get
            {
                return _memberId;
            }
        }

        public static Dictionary<string, AdZone> AdZones
        {
            get
            {
                if (_adZones == null)
                    _adZones = GetAdZones();
                return _adZones;
            }
        }

        public static List<Guide> GetGuides()
        {
            CheckLoginAlimama();
            try
            {
                List<Guide> result = new List<Guide>();
                string url = string.Format(Url_Guides, _tbToken);
                string rsp = HttpGet(url);
                JObject obj = JsonConvert.DeserializeObject<dynamic>(rsp);
                foreach (var item in obj["data"]["guideList"])
                {
                    string guideId = item.Value<string>("guideID");
                    string guideName = item.Value<string>("name");
                    result.Add(new Guide()
                    {
                        Id = guideId,
                        Name = guideName
                    });
                }
                return result;
            }
            catch
            {
                CleanTbToken();
                throw;
            }
        }

        public static void CleanTbToken()
        {
            _tbToken = null;
            _cookie = null;
            _memberId = null;
        }

        private static Dictionary<string, AdZone> GetAdZones()
        {
            CheckLoginAlimama();
            try
            {
                Dictionary<string, AdZone> result = new Dictionary<string, AdZone>();
                string url = string.Format(Url_AdZones, _tbToken);
                string rsp = HttpGet(url);
                JObject obj = JsonConvert.DeserializeObject<dynamic>(rsp);
                foreach (var item in obj["data"]["pagelist"])
                {
                    _memberId = item.Value<string>("memberid");
                    string adZoneId = item.Value<string>("adzoneid");
                    string adZoneName = item.Value<string>("name");
                    string siteId = item.Value<string>("siteid");
                    result.Add(adZoneId, new AdZone()
                    {
                        SiteId = siteId,
                        AdZoneId = adZoneId,
                        AdZoneName = adZoneName
                    });
                }
                return result;
            }
            catch
            {
                CleanTbToken();
                throw;
            }
        }

        public static string GetPId(string adZoneId)
        {
            if (string.IsNullOrEmpty(MemberId))
                throw new Exception("阿里妈妈会员Id为空");
            string siteId = AdZones[adZoneId].SiteId;
            if (string.IsNullOrEmpty(siteId))
                throw new Exception("阿里妈妈导购位为空");
            if (string.IsNullOrEmpty(adZoneId))
                throw new Exception("阿里妈妈推广位为空");
            return string.Format("{0}_{1}_{2}", MemberId, siteId, adZoneId);
        }

        public static List<Payment> QueryPaymentDetails(string payStatus, string startTime, string endTime)
        {            
            CheckLoginAlimama();
            try
            {
                List<Payment> result = new List<Payment>();
                string url = string.Format(Url_PaymentDetails, payStatus, startTime, endTime, _tbToken);
                string rsp = HttpGet(url);
                PaymentDetailsResponse rspObj = JsonConvert.DeserializeObject<PaymentDetailsResponse>(rsp);
                if (rspObj.data != null && rspObj.data.paymentList != null)
                    result = rspObj.data.paymentList;
                return result;
            }
            catch
            {
                CleanTbToken();
                throw;
            }
        }

        public static void ExportPaymentDetailsReport(string payStatus, string startTime, string endTime, string savePath)
        {          
            CheckLoginAlimama();
            try
            {
                List<Payment> result = new List<Payment>();
                string url = string.Format(Url_PaymentDetails_Report, payStatus, startTime, endTime);
                Dictionary<string, string> headers = new Dictionary<string, string>();
                headers.Add("Cookie", _cookie);
                WebRequestHelper.DownloadFile(savePath, url, headerDic: headers);
            }
            catch
            {
                CleanTbToken();
                throw;
            }
        }

        private static string HttpGet(string url)
        {
            CheckLoginAlimama();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Cookie", _cookie);
            return WebRequestHelper.Get(url, null, headers);
        }

        private static void CheckLoginAlimama()
        {
            if (!AlimamaLoggedOn())
            {
                LoginAlimama();
            }
        }

        private static bool AlimamaLoggedOn()
        {
            return !string.IsNullOrEmpty(_tbToken) && !string.IsNullOrEmpty(_cookie);
        }

        private static void LoginAlimama()
        {
            CheckTaokeSetting();
            FormAlimamaLogin formAlimamaLogin = new FormAlimamaLogin(GlobalSetting.Instance.TaokeSetting.Account, GlobalSetting.Instance.TaokeSetting.Password);
            if (formAlimamaLogin.ShowDialog() == DialogResult.OK)
            {
                _tbToken = formAlimamaLogin.TbToken;
                _cookie = formAlimamaLogin.Cookie;
            }
        }

        private static void CheckTaokeSetting()
        {
            if (string.IsNullOrEmpty(GlobalSetting.Instance.TaokeSetting.Account))
            {
                throw new Exception("淘宝帐号未设置，请检查淘客设置");
            }
            if (string.IsNullOrEmpty(GlobalSetting.Instance.TaokeSetting.Password))
            {
                throw new Exception("淘宝密码未设置，请检查淘客设置");
            }
        }
    }
}
