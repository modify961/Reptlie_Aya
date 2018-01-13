using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using Base.Common.RouteMessage;
using System.Net;

namespace Base.Common.Error
{
    /// <summary>
    /// 创建：李经纬
    /// 作用：处理服务调用是产生的错误，将错误记录日志并返回值请求端
    /// </summary>
    public class DispatcherError : IErrorHandler
    {
        private readonly Func<Exception, object> _errorinfo;
        private readonly Func<Exception, bool> _handlerror;
        /// <summary>
        /// 处理借口调度之间的错误信息
        /// 根据需要对错误记录日志及返回错误信息
        /// </summary>
        /// <param name="errorInfo"></param>
        /// <param name="handlError"></param>
        public DispatcherError(Func<Exception, object> errorInfo, Func<Exception, bool> handlError)
        {
            this._errorinfo = errorInfo;
            this._handlerror = handlError;
        }
        #region IErrorHandler 成员
        public bool HandleError(Exception error)
        {
            if (_handlerror == null)
                return false;
            return this._handlerror(error);
        }
        /// <summary>
        /// 
        /// WebOperationContext：获取当前Http的上下文进行检测，这里用来检测和http交互的数据格式
        /// WebBodyFormatMessageProperty：获取或设置Web Message的编码格式，本方法只用到了Json及XML
        /// HttpStatusCode：服务器状态码，这里设置为BadRequest：400错误
        /// </summary>
        /// <param name="error"></param>
        /// <param name="version"></param>
        /// <param name="fault"></param>
        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            bool isJson =  true;
            WebOperationContext current = WebOperationContext.Current;
            if (current != null && current.OutgoingResponse != null && current.OutgoingResponse.Format.HasValue)
            {
                isJson = (WebMessageFormat)current.OutgoingResponse.Format.Value == WebMessageFormat.Json;
            }
            object errorInfo = this._errorinfo == null ? null : this._errorinfo(error);
            Responses responses = new Responses(errorInfo, isJson);
            fault = Message.CreateMessage(version, string.Empty, (BodyWriter)responses);
            WebBodyFormatMessageProperty property = new WebBodyFormatMessageProperty(isJson ? WebContentFormat.Json : WebContentFormat.Xml);
            fault.Properties["WebBodyFormatMessageProperty"] = property;
            if (isJson)
                current.OutgoingResponse.ContentType = "application/json";
            current.OutgoingResponse.StatusCode = HttpStatusCode.BadRequest;
        }
        #endregion
    }
}
