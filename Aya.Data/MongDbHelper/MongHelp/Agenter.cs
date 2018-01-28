using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongHelp
{
    public class Agenter
    {
        /// <summary>
        /// 
        /// </summary>
        public ObjectId _id;
        /// <summary>
        /// IP地址
        /// </summary>
        public String ip { set; get; }
        /// <summary>
        /// 端口号
        /// </summary>
        public int port { set; get; }
        /// <summary>
        /// http 或者 https
        /// </summary>
        public String type { set; get; }
        /// <summary>
        /// 高匿  透明 普匿
        /// </summary>
        public String anonymous { set; get; }
        /// <summary>
        /// 存活时间（分钟）
        /// </summary>
        public int survibal { set; get; }
        /// <summary>
        /// 是否可用
        /// </summary>
        public bool usable { set; get; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { set; get; }
        /// <summary>
        /// 上次检查时间
        /// </summary>
        public DateTime checkTime { set; get; }
    }
}
