using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Entity
{
    public class ErrorMessage
    {
        /// <summary>
        /// 唯一标识，Guid字符串
        /// </summary>
        public string id
        {
            get;
            set;
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime dateTime
        {
            get
            {
                return DateTime.Now;
            }
        }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string message
        {
            get;
            set;
        }
        /// <summary>
        /// 追踪栈道
        /// </summary>
        public string stackTrace
        {
            get;
            set;
        }
    }
}
