using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
//using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
//using System.ServiceModel.Channels;
using System.Text;
using System.Web;
//using Microsoft.Owin;

namespace TaobaoKe.Core.Util
{
    public delegate void ResponseAction(WebResponse response);

    public class WebRequestHelper
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage =
            "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";

        public static string Get(string url)
        {
            return Get(url, null, null);
        }

        public static string RandomBoundary()
        {
            return String.Format("----------{0:N}", Guid.NewGuid());
        }

        public static long GetContentLength(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);// HttpWebRequest.CreateHttp(url);
            return request.GetResponse().ContentLength;
        }

        public static string Get(string url, string contentType, Dictionary<string, string> headerDic)
        {
            using (WebResponse response = GetWebResponse(url, contentType, headerDic))
            {
                return GetResponseText(response);
            }
        }

        public static string Delete(string url, string contentType, Dictionary<string, string> headerDic)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "DELETE";
            if (!string.IsNullOrEmpty(contentType))
                webRequest.ContentType = contentType;
            PrepareRequestHeaders(webRequest, headerDic);
            WebResponse webResponse = webRequest.GetResponse();
            return GetResponseText(webResponse);
        }

        public static string Put(string url, string contentType,string body, Dictionary<string, string> headers)
        {
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "PUT";
            if (!string.IsNullOrEmpty(contentType))
                webRequest.ContentType = contentType;
            PrepareRequestHeaders(webRequest,headers);
            using (StreamWriter sw = new StreamWriter(webRequest.GetRequestStream()))
            {
                sw.Write(body);
                sw.Flush();
            }
            return GetResponseText(webRequest.GetResponse());
        }

        public static void Get(string url, string contentType, Dictionary<string, string> headerDic, ResponseAction action)
        {
            using (WebResponse response = GetWebResponse(url, contentType, headerDic))
            {
                action(response);
            }
        }

        public static WebResponse GetWebResponse(string url, string contentType = "", Dictionary<string, string> headerDic = null)
        {
            //支持HTTPS
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            WebRequest request = WebRequest.Create(url);
            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }
            if (headerDic != null)
            {
                foreach (KeyValuePair<string, string> pair in headerDic)
                {
                    request.Headers.Add(pair.Key, pair.Value);
                }
            }
            return request.GetResponse();
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain,
            SslPolicyErrors errors)
        {
            // Always accept
            return true; //总是接受
        }

        public static string Post(string url, string contentType, string postData, Dictionary<string, string> headerDic = null, bool getResponseText = false)
        {
            using (WebResponse response = PostWebResponse(url, contentType, postData, headerDic))
            {
                if (getResponseText)
                    return GetResponseText(response);
                else
                    return string.Empty;
            }
        }

        public static void Post(string url, string contentType, string postData, Dictionary<string, string> headerDic, ResponseAction action)
        {
            using (WebResponse response = PostWebResponse(url, contentType, postData, headerDic))
            {
                action(response);
            }
        }

        private static WebResponse PostWebResponse(string url, string contentType, string postData, Dictionary<string, string> headerDic = null)
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = Encoding.UTF8.GetBytes(postData).Length;
            if (!string.IsNullOrEmpty(contentType))
            {
                request.ContentType = contentType;
            }
            if (headerDic != null)
            {
                foreach (KeyValuePair<string, string> pair in headerDic)
                {
                    request.Headers.Add(pair.Key, pair.Value);
                }
            }
            using (StreamWriter streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(postData);
                streamWriter.Flush();
                return request.GetResponse();
            }
        }

        public static string Post(string url, NameValueCollection formData = null, bool getResponseText = false)
        {
            using (WebResponse response = PostWebResponse(url, formData))
            {
                if (getResponseText)
                    return GetResponseText(response);
                else
                    return string.Empty;
            }
        }

        private static WebResponse PostWebResponse(string url, NameValueCollection formData = null)
        {
            string boundary = RandomBoundary();
            WebRequest webRequest = WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "multipart/form-data; boundary=" + boundary;

            using (Stream postDataStream = new System.IO.MemoryStream())
            {

                //adding form data
                string formDataHeaderTemplate = Environment.NewLine + "--" + boundary + Environment.NewLine +
                    "Content-Disposition: form-data; name=\"{0}\";" + Environment.NewLine + Environment.NewLine + "{1}";

                if (formData != null && formData.Keys.Count > 0)
                {
                    foreach (string key in formData.Keys)
                    {
                        byte[] formItemBytes = System.Text.Encoding.UTF8.GetBytes(string.Format(formDataHeaderTemplate, key, formData[key]));
                        postDataStream.Write(formItemBytes, 0, formItemBytes.Length);
                    }
                }
                webRequest.ContentLength = postDataStream.Length;
                using (Stream reqStream = webRequest.GetRequestStream())
                {
                    postDataStream.Position = 0;

                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    while ((bytesRead = postDataStream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        reqStream.Write(buffer, 0, bytesRead);
                    }
                    postDataStream.Close();
                    reqStream.Close();
                }
            }
            return webRequest.GetResponse();
        }

        public static string GetResponseText(WebResponse response)
        {
            string responseText = string.Empty;
            if (response != null)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        using (StreamReader streamReader = new StreamReader(stream, Encoding.UTF8))
                        {
                            responseText = streamReader.ReadToEnd();
                        }
                    }
                }
            }
            return responseText;
        }

        public static void DownloadFile(string url, string saveFilePath)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            //request.Credentials = new NetworkCredential(userId, password);
            using (System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse())
            {
                using (System.IO.Stream responseStream = response.GetResponseStream())
                {
                    using (System.IO.Stream fileStream = new System.IO.FileStream(saveFilePath, System.IO.FileMode.Create))
                    {
                        byte[] by = new byte[100 * 1024];
                        int osize = responseStream.Read(by, 0, (int)by.Length);
                        while (osize > 0)
                        {
                            fileStream.Write(by, 0, osize);
                            osize = responseStream.Read(by, 0, (int)by.Length);
                        }

                    }
                }
            }
            request.Abort();
        }

        public static bool IsUrlAvailable(string url)
        {
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
            try
            {
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public static string GetClientIp(HttpRequestMessage request)
        //{
        //    // Web-hosting
        //    if (request.Properties.ContainsKey(HttpContext))
        //    {
        //        HttpContextWrapper ctx =
        //            (HttpContextWrapper)request.Properties[HttpContext];
        //        if (ctx != null)
        //        {
        //            return ctx.Request.UserHostAddress;
        //        }
        //    }

        //    // Self-hosting
        //    if (request.Properties.ContainsKey(RemoteEndpointMessage))
        //    {
        //        RemoteEndpointMessageProperty remoteEndpoint =
        //            (RemoteEndpointMessageProperty)request.Properties[RemoteEndpointMessage];
        //        if (remoteEndpoint != null)
        //        {
        //            return remoteEndpoint.Address;
        //        }
        //    }

        //    // Self-hosting using Owin
        //    if (request.Properties.ContainsKey(OwinContext))
        //    {
        //        OwinContext owinContext = (OwinContext)request.Properties[OwinContext];
        //        if (owinContext != null)
        //        {
        //            return owinContext.Request.RemoteIpAddress;
        //        }
        //    }

        //    return string.Empty;
        //}


        public static void PrepareRequestHeaders(WebRequest webRequest, Dictionary<string, string> requestHeaders)
        {
            if (requestHeaders != null)
            {
                foreach (var item in requestHeaders)
                {
                    webRequest.Headers.Add(item.Key, item.Value);
                }
            }
        }
    }

    public class RequestContentType
    {
        public static string ApplicationJson = "application/json";
    }
}