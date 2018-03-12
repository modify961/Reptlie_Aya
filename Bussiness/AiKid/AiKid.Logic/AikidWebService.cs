using AiKid.Contracts;
using Base.Logic.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Entity;
using System.IO;
using MongHelp.AiKid.Helper;
using AiKid.Common;
using Enpower.Services.Common;
using MongHelp.AiKid.Model;
using Newtonsoft.Json;

namespace AiKid.Logic
{
    /// <summary>
    /// 
    /// </summary>
    public class AikidWebService : FoundationServer, IAikidWeb
    {
        /// <summary>
        /// 获取所有的品牌数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream obtainBrand(ImpContext context)
        {
            MongBrand mongBrand = new MongBrand(Constants.daname);
            return new ToStream().ToStreams(mongBrand.obtainAll());
        }
        /// <summary>
        ///根据条件查询所需要的数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream obtainBrandNo(ImpContext context)
        {
            MongOnLine mongOnLine = new MongOnLine(Constants.daname);
            DateTime dateTime = DateTime.Now.AddDays(-4);
            //反序列化
            OnLineModel onLineModel = JsonConvert.DeserializeObject<OnLineModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            List<OnLineModel> list = mongOnLine.obtainAll( onLineModel);
            list = (from q in list orderby q.createDate  descending select q).ToList();
            return new ToStream().ToStreams(list);
        }

        /// <summary>
        /// 查询所有的推荐数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream obtainRecommend(ImpContext context)
        {
            MongOnLine mongOnLine = new MongOnLine(Constants.daname);
            List<OnLineModel> list = mongOnLine.obtainRecommend();
            list = (from q in list orderby q.createDate descending select q).ToList();
            return new ToStream().ToStreams(list);
        }
    }
}
