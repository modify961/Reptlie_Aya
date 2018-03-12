using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongHelp.AiKid.Model
{
    public class OnLineModel
    {
        /// <summary>
        /// 唯一标记
        /// </summary>
        public string guid { set; get; }
        /// <summary>
        /// ID
        /// </summary>
        public string _id { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 品牌
        /// </summary>
        public string brand { get; set; }
        /// <summary>
        /// 价格
        /// </summary>
        public string price { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string origin { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public string target { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string pictiue { get; set; }
        /// <summary>
        /// 直达URL
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 是否做为推荐项
        /// </summary>
        public bool recommend { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        public bool onLine { get; set; }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int clickN { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createDate { get; set; }
    }
}
