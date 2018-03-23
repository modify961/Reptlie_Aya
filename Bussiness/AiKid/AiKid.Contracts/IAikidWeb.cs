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
    public interface IAikidWeb
    {
        /// <summary>
        /// 获取所有的推荐信息数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/obtainRecommend"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream obtainRecommend(ImpContext context);
        /// <summary>
        /// 获取所有的品牌数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/obtainBrand"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream obtainBrand(ImpContext context);
        /// <summary>
        /// 获取所有的品牌数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/obtainBrandNo"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream obtainBrandNo(ImpContext context);
        /// <summary>
        /// 根据ID获取详细信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/obtainDetail"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream obtainDetail(ImpContext context);
    }
}
