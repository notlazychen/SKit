using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SKit.Common.Utils
{
    public static class HttpUtils
    {
        public static string Get(string url, Dictionary<string, string> args)
        {
            var request = WebRequest.CreateHttp(ToQueryString(url, args));
            request.Method = WebRequestMethods.Http.Get;
            WebResponse response = null;            
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }

            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                string body = reader.ReadToEnd();
                return body;
            }
        }

        public static string ToQueryString(string url, Dictionary<string, string> args)
        {
            if (args != null)
            {
                string body = string.Join("&", args.Select(p => string.Format("{0}={1}", p.Key, p.Value)));
                return string.Format("{0}?{1}", url, body);
            }
            else
            {
                return url;
            }
        }
        
        public static string Post(string url, string content)
        {
            string postDataStr = content;//string.Join("&", form.Select(p => string.Format("{0}={1}", p.Key, p.Value)));
            var data = Encoding.UTF8.GetBytes(postDataStr);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 3000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            //request.CookieContainer = cookie;
            using (Stream myRequestStream = request.GetRequestStream())
            {
                myRequestStream.Write(data, 0, data.Length);
            }

            WebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException ex)
            {
                response = (HttpWebResponse)ex.Response;
            }

            using (Stream myResponseStream = response.GetResponseStream())
            using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8")))
            {
                string retString = myStreamReader.ReadToEnd();
                return retString;
            }
        }
    }
}
