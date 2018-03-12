using Base.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace AiKid.Contracts
{
    [ServiceContract]
    public interface IWaitUp
    {
        /// <summary>
        /// 初始化页面
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/init"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream init(ImpContext context);
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/loadDate"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream loadDate(ImpContext context);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/delete"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream delete(ImpContext context);
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/add"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream add(ImpContext context);
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
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
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/deleteWaitUp"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream deleteWaitUp(ImpContext context);
    }
}
