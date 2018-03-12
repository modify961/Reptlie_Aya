using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongHelp.AiKid.Model
{
    public class CountryModel
    {
        /// <summary>
        /// 唯一标记
        /// </summary>
        public string guid { set; get; }
        /// <summary>
        /// 国家
        /// </summary>
        public string name { set; get; }
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { set; get; }
        /// <summary>
        /// 备注
        /// </summary>
        public string remark { set; get; }
    }
}
