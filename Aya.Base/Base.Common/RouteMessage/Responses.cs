using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Channels;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;

namespace Base.Common.RouteMessage
{
    /// <summary>
    /// 修改WCF返回数据的内容
    /// 重写BodyWriter的OnWriteBodyContents方法，修改返回的主题内容数据
    /// </summary>
    public class Responses : BodyWriter
    {
        private object _errordetails;
        private XmlObjectSerializer _serializer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="erorDetails"></param>
        /// <param name="isJson"></param>
        public Responses(object erorDetails, bool isJson)
            : base(true)
        {
            _errordetails = erorDetails;
            Type type = _errordetails.GetType();
            if (isJson)
                _serializer = new DataContractJsonSerializer(type);
            else
                _serializer = new DataContractSerializer(type);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="writer"></param>
        protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
        {
            _serializer.WriteObject(writer, _errordetails);
        }
    }
}
