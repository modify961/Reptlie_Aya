using Base.Entity;
using Base.Logic.Basis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AgentIp.Contracts
{
    [ServiceContract]
    public interface IAgentIp
    {
        [WebInvoke(UriTemplate = "/init"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream init(ImpContext context);
        [WebInvoke(UriTemplate = "/loadDate"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream loadDate(ImpContext context);
        [WebInvoke(UriTemplate = "/delete"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream delete(ImpContext context);
        [WebInvoke(UriTemplate = "/add"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream add(ImpContext context);
        [WebInvoke(UriTemplate = "/update"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream update(ImpContext context);
        /// <summary>
        /// 获取当前代理IP的数量
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/count"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream count(ImpContext context);
        /// <summary>
        /// 获取全部的IP
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/obtainAll"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream obtainAll(ImpContext context);
    }
}
