using AiKid.Contracts;
using Base.Logic.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace AiKid.Logic
{
    /// <summary>
    /// 站长工具接口
    /// </summary>
    public class EtcToolService : FoundationServer, IEtcTool
    {
        /// <summary>
        /// 获取网站访问数据
        /// </summary>
        /// <returns></returns>
        public Stream recordVisit()
        {
            List<string> list=HttpContext.Current.Request.ServerVariables.AllKeys.ToList();
            return null;
        }
    }
}
