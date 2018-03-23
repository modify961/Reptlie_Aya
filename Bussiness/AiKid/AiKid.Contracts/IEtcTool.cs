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
    public interface IEtcTool
    {
        /// <summary>
        /// 保存访问数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/obtainRecommend"
        , BodyStyle = WebMessageBodyStyle.WrappedRequest
        , ResponseFormat = WebMessageFormat.Json
        , RequestFormat = WebMessageFormat.Json)]
        Stream recordVisit();
    }
}
