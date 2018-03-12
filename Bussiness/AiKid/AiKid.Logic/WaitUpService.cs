using AiKid.Contracts;
using Base.Logic.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Entity;
using System.IO;
using Enpower.Services.Common;
using MongHelp.AiKid.Helper;
using AiKid.Common;
using Newtonsoft.Json;
using MongHelp.AiKid.Model;

namespace AiKid.Logic
{
    public class WaitUpService : FoundationServer, IWaitUp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream count(ImpContext context)
        {
            MongWaitUp mongWaitUp = new MongWaitUp(Constants.daname);
            return new ToStream().ToStreams(mongWaitUp.obtainAll().Count());
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream deleteWaitUp(ImpContext context)
        {

            MongWaitUp mongWaitUp = new MongWaitUp(Constants.daname);
            //反序列化
            WaitUpModel waitUpModel = JsonConvert.DeserializeObject<WaitUpModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            mongWaitUp.delete(waitUpModel);
            return new ToStream().ToStreams(mongWaitUp.obtainAll());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream obtainAll(ImpContext context)
        {
            MongWaitUp mongWaitUp = new MongWaitUp(Constants.daname);
            return new ToStream().ToStreams(mongWaitUp.obtainAll());
        }
    }
}
