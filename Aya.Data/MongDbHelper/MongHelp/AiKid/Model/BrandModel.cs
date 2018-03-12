using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongHelp.AiKid.Model
{
    public class BrandModel
    {
        /// <summary>
        /// 唯一标记
        /// </summary>
        public string guid { set; get; }
        /// <summary>
        /// 国家
        /// </summary>
        public string conutry { set; get; }
        /// <summary>
        /// 品牌名称
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 品牌LOGO
        /// </summary>
        public string logo { set; get; }
        /// <summary>
        /// 品牌英文名称
        /// </summary>
        public string englishName { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { set; get; }
    }
}
