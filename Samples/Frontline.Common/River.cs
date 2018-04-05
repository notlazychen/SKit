using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Frontline.Common
{
    public static class River
    {
        public static string ToQueryString(this IEnumerable<KeyValuePair<string, string>> map, string url)
        {
            StringBuilder sb = new StringBuilder(url.TrimEnd('?'));
            bool isFirst = true;
            foreach (var item in map)
            {
                if (isFirst)
                {
                    isFirst = false;
                    sb.AppendFormat("?{0}={1}", item.Key, item.Value);
                }
                else
                {
                    sb.AppendFormat("&{0}={1}", item.Key, item.Value);
                }
            }
            return sb.ToString();
        }

        public static string ToFormString(this IEnumerable<KeyValuePair<string, string>> map)
        {
            return string.Join("&", map.Select(x => x.Key + "=" + x.Value));
        }

        //public static async Task<string> PostAsync(string url, string body)
        //{
        //    WebRequest request = WebRequest.CreateHttp(url);
        //    request.Method = WebRequestMethods.Http.Post;
        //    using (var stream = request.GetRequestStream())
        //    {
        //        var data = Encoding.UTF8.GetBytes(body);
        //        await stream.WriteAsync(data, 0, data.Length);
        //        using (WebResponse response = await request.GetResponseAsync())
        //        {
        //            using (var bufferStream = response.GetResponseStream())
        //            {
        //                if (bufferStream == null)
        //                    return null;
        //                using (var reader = new StreamReader(bufferStream))
        //                {
        //                    return reader.ReadToEnd();
        //                }
        //            }
        //        }
        //    }
        //}

        public static string Post(string url, string body, string desKey, int waitTime = 0)
        {
            WebRequest request = WebRequest.CreateHttp(url);
            if (waitTime != 0)
            {
                request.Timeout = waitTime;
            }
            request.Method = WebRequestMethods.Http.Post;
            using (var stream = request.GetRequestStream())
            {
                if (body != null)
                {
                    byte[] data = DES.Encrypt(body, desKey);
                    stream.Write(data, 0, data.Length);
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
                using (var bufferStream = response.GetResponseStream())
                {
                    if (bufferStream == null)
                        return null;
                    using (var reader = new StreamReader(bufferStream))
                    {
                        return reader.ReadToEnd();
                    }
                }

            }
        }
    }
}
