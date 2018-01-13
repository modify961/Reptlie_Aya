using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using Newtonsoft.Json.Converters;

namespace Enpower.Services.Common
{
    public class ToStream
    {
        /// <summary>
        /// 将一般泛型数据，转换成JSON字符串，用于服务向客户端传输
        /// </summary>
        /// <param name="list">数据列表</param>
        /// <returns></returns>
        public Stream ToStreams(List<object> list, string dateTimeFormat = "yyyy'-'MM'-'dd")
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.AutoFlush = true;
            IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = dateTimeFormat;
            sw.Write(JsonConvert.SerializeObject(list, timeConverter));
            ms.Position = 0;
            return ms;
        }
        /// <summary>
        /// 将字符串转换成STREAM
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public Stream ToStreams(string stream)
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.AutoFlush = true;
            sw.Write(stream);
            ms.Position = 0;
            return ms;
        }
        /// <summary>
        /// 将Object转换成STREAM
        /// </summary>
        /// <param name="bject"></param>
        /// <returns></returns>
        public Stream ToStreams(Object obj, string dateTimeFormat = "yyyy'-'MM'-'dd")
        {
            MemoryStream ms = new MemoryStream();
            StreamWriter sw = new StreamWriter(ms);
            sw.AutoFlush = true;
            IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            timeConverter.DateTimeFormat = dateTimeFormat;
            sw.Write(JsonConvert.SerializeObject(obj, timeConverter));
            ms.Position = 0;
            return ms;
        }
        /// <summary>
        /// 将二进制数据流转换为实体并返回
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="stream">二进制数据流</param>
        /// <returns>实体对象</returns>
        public T ToEntity<T>(Stream stream)
        {
            StreamReader streamReader = new StreamReader(stream);
            StreamWriter streamWriter = new StreamWriter(stream);
            char[] buffChar = new char[stream.Length];
            streamReader.Read(buffChar, 0, buffChar.Length);
            string buffString = new string(buffChar).ToString();
            T t = JsonConvert.DeserializeObject<T>(buffString.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return t;
        }
        /// <summary>
        /// 将二进制数据流转换为泛型并返回
        /// </summary>
        /// <typeparam name="T">实体类型</typeparam>
        /// <param name="stream">二进制数据流</param>
        /// <returns>泛型对象</returns>
        public List<T> ToList<T>(Stream stream)
        {
            StreamReader streamReader = new StreamReader(stream);
            StreamWriter streamWriter = new StreamWriter(stream);
            char[] buffChar = new char[stream.Length];
            streamReader.Read(buffChar, 0, buffChar.Length);
            string buffString = new string(buffChar).ToString();
            List<T> gridView = JsonConvert.DeserializeObject<List<T>>(buffString.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return gridView;
        }
    }
}
