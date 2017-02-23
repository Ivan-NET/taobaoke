using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace TaobaoKe.Core.Util
{
    public class ShortUrlConvert
    {
        private static readonly string ROOT_URL = "http://api.t.sina.com.cn/short_url/shorten.json";//"http://gzbusnow.duapp.com/surl/surl_proxy.php";

        public static string Convert(string url, string source)
        {
            string result = url;
            StringBuilder sb = new StringBuilder();
            try
            {
                sb.Append(ROOT_URL).Append("?")
                        .Append("source=").Append(source).Append("&")
                        .Append("url_long=").Append(HttpUtility.UrlEncode(url, Encoding.UTF8));
                string response = WebRequestHelper.Get(sb.ToString());
                JArray obj = (JArray)JsonConvert.DeserializeObject(response);
                result = obj[0]["url_short"].Value<string>();
            }
            catch (Exception e)
            {
                throw new Exception("Short Url Convert Failed.", e);
            }
            return result;
        }
    }
}
