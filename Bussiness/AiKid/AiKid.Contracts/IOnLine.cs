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
    public interface IOnLine
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/addOnLine"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream addOnLine(ImpContext context);
        /// <summary>
        /// 获取全部的线上数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/obtainAll"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream obtainAll(ImpContext context);
        /// <summary>
        /// 删除checkExist
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/deleteOnLine"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream deleteOnLine(ImpContext context);
        /// <summary>
        /// 检查连接是否重复
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/checkExist"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream checkExist(ImpContext context);
    }
}
