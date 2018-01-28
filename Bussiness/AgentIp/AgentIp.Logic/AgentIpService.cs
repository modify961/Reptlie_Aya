using AgentIp.Contracts;
using Base.Logic.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.Entity;
using System.IO;
using MongHelp;
using Enpower.Services.Common;

namespace AgentIp.Logic
{
    public class AgentIpService : FoundationServer, IAgentIp
    {
        /// <summary>
        /// 获取当前代理IP的数量
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream count(ImpContext context)
        {
            MongAgentIp mongAgentIp = new MongAgentIp("AgentIp");
            return new ToStream().ToStreams(mongAgentIp.obtainAll().Count());
        }
        /// <summary>
        /// 获取代理池中的全部数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream obtainAll(ImpContext context)
        {
            MongAgentIp mongAgentIp = new MongAgentIp("AgentIp");
            return new ToStream().ToStreams(mongAgentIp.obtainAll());
        }
    }
}
