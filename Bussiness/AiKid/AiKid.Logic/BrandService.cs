using AiKid.Contracts;
using Base.Logic.Basis;
using System;
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
    public class BrandService : FoundationServer, IBrand
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream obtainAll(ImpContext context)
        {
            MongBrand mongBrand = new MongBrand(Constants.daname);
            return new ToStream().ToStreams(mongBrand.obtainAll());
        }
        /// <summary>
        /// 添加品牌信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream deleteBrand(ImpContext context)
        {
            MongBrand mongBrand = new MongBrand(Constants.daname);
            //反序列化
            BrandModel brandModel = JsonConvert.DeserializeObject<BrandModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            mongBrand.delete(brandModel);
            return new ToStream().ToStreams(mongBrand.obtainAll());
        }
        /// <summary>
        /// 添加品牌信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream addBrand(ImpContext context)
        {
            MongBrand mongBrand = new MongBrand(Constants.daname);
            //反序列化
            BrandModel brandModel = JsonConvert.DeserializeObject<BrandModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            if (string.IsNullOrEmpty(brandModel.guid))
            {
                brandModel.guid = Guid.NewGuid().ToString();
                mongBrand.insert(brandModel);
            }
            else {
                mongBrand.update(brandModel);
            }
            
            return new ToStream().ToStreams(mongBrand.obtainAll());
        }
    }
}
