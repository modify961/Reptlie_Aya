using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Base.Entity;
using System.IO;
using Enpower.Services.Common;
using System.Data;
using Base.Common;
using System.Xml;
using System.Xml.Xsl;

namespace Base.Logic.Basis
{
    public class FoundationServer : Foundation
    {
        private Dictionary<string, Object> _factory;
        public FoundationServer()
        {
            _factory = new Dictionary<string, Object>();
        }
        #region  初始化接口
        /// <summary>
        /// 初始化接口
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream init(ImpContext context)
        {
            return new ToStream().ToStreams(context);
        }
        /// <summary>
        /// 可重写函数。
        /// 用于自定义对控件加载完成后对控件结构进行重新处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext initAfter(ImpContext context)
        {
            return context;
        }
        #endregion
        #region 数据加载接口
        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream loadDate(ImpContext context)
        {
            if (loadDateBefore(context))
            {
                context = loadDateIng(context);
                context = loadDateAfter(context);
            }
            return new ToStream().ToStreams(context);
        }
        /// <summary>
        /// 可重写函数。
        /// 用于数据加载之前对上下文进行调整，实现业务需求
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool loadDateBefore(ImpContext context)
        {
            return true;
        }
        /// <summary>
        /// 可重写函数。
        /// 用于修改数据加载过程。非特殊情况下不建议重写该方法
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext loadDateIng(ImpContext context)
        {
            return context;
        }
        /// <summary>
        /// 可重写函数
        /// 用于数据加载完成后的业务处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext loadDateAfter(ImpContext context)
        {
            return context;
        }
        #endregion
        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream delete(ImpContext context)
        {
            return new ToStream().ToStreams(context); ;
        }
        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext deleteIng(ImpContext context)
        {
            return context;
        }
        /// <summary>
        /// 删除之后
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext deleteAfter(ImpContext context)
        {
            return context;
        }
        /// <summary>
        /// 删除前处理，先查询出要删除的数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool deleteBefore(ImpContext context)
        {
           
            return true;
        }
        #endregion
        #region 添加数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream add(ImpContext context)
        {
            return new ToStream().ToStreams(context); ;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext addIng(ImpContext context)
        {
            return context;
        }
        /// <summary>
        /// 添加之后
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext addAfter(ImpContext context)
        {
            return context;
        }
        /// <summary>
        /// 添加前处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool addBefore(ImpContext context)
        {
           
            return true;
        }
        #endregion
        #region 更新数据
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream update(ImpContext context)
        {
            
            return new ToStream().ToStreams(context); ;
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext UpdateIng(ImpContext context)
        {
            
            return context;
        }
        /// <summary>
        /// 添加之后
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual ImpContext UpdateAfter(ImpContext context)
        {
            return context;
        }
        /// <summary>
        /// 添加前处理
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public virtual bool UpdateBefore(ImpContext context)
        {
            
            return true;
        }
        #endregion
    }
}
