using AiKid.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AiKid.Common
{
    public class WeiBoHelper
    {
        /// <summary>
        /// 
        /// </summary>
        private HttpClient _httpclient=null;
        private string _write = "https://api.weibo.com/2/statuses/share.json";
        private string _tokenkey = "2.00HFmLvCTVchjC21ee08e698nwrnDD";
        public WeiBoHelper() {
            _httpclient = new HttpClient();
        }
        /// <summary>
        /// 发送微博消息
        /// </summary>
        public void send(Dictionary<string, object> asy)
        {
            asy.Add("access_token", _tokenkey);
            if (_write.StartsWith("https"))
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;
            HttpContent httpContent = null;
            if (asy.Count(p => p.Value.GetType() == typeof(byte[]) || p.Value.GetType() == typeof(System.IO.FileInfo)) > 0)
            {
                var content = new MultipartFormDataContent();

                foreach (var param in asy)
                {
                    var dataType = param.Value.GetType();
                    if (dataType == typeof(byte[])) //byte[]
                    {
                        content.Add(new ByteArrayContent((byte[])param.Value), param.Key, GetNonceString());
                    }
                    else if (dataType == typeof(MemoryFileContent)) //内存文件
                    {
                        var mcontent = (MemoryFileContent)param.Value;
                        content.Add(new ByteArrayContent(mcontent.Content), param.Key, mcontent.FileName);
                    }
                    else if (dataType == typeof(System.IO.FileInfo))    //本地文件
                    {
                        var file = (System.IO.FileInfo)param.Value;
                        content.Add(new ByteArrayContent(System.IO.File.ReadAllBytes(file.FullName)), param.Key, file.Name);
                    }
                    else
                    {
                        content.Add(new StringContent(string.Format("{0}", param.Value)), param.Key);
                    }
                }
                httpContent = content;
            }
            else
            {
                var content = new FormUrlEncodedContent(asy.ToDictionary(k => k.Key, v => string.Format("{0}", v.Value)));
                httpContent = content;
            }
            var result = _httpclient.PostAsync(_write, httpContent).Result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private string GetNonceString(int length = 8)
        {
            var sb = new StringBuilder();

            var rnd = new Random();
            for (var i = 0; i < length; i++)
            {

                sb.Append((char)rnd.Next(97, 123));

            }

            return sb.ToString();

        }
    }
}
