using AiKid.Contracts;
using Base.Logic.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base.Entity;
using System.IO;
using AiKid.Common;
using MongHelp.AiKid.Helper;
using MongHelp.AiKid.Model;
using Newtonsoft.Json;
using Enpower.Services.Common;
using Newtonsoft.Json.Converters;
using System.Net.Http;
using System.Net;
using AiKid.Entity;

namespace AiKid.Logic
{
    public class OnLineService : FoundationServer, IOnLine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream obtainAll(ImpContext context)
        {
            MongOnLine mongOnLine = new MongOnLine(Constants.daname);
            bool onLine = true;
            if (!string.IsNullOrEmpty(context.json)) {
                //反序列化
                OnLineModel onLineModel = JsonConvert.DeserializeObject<OnLineModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                onLine = onLineModel.onLine;
            }
            return new ToStream().ToStreams(mongOnLine.obtainAll(onLine));
        }
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream checkExist(ImpContext context)
        {
            MongOnLine mongOnLine = new MongOnLine(Constants.daname);
            //反序列化
            OnLineModel onLineModel = JsonConvert.DeserializeObject<OnLineModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return new ToStream().ToStreams(mongOnLine.isExist(onLineModel));
        }
        /// <summary>
        /// 新增上线信息
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream addOnLine(ImpContext context)
        {
            MongOnLine mongOnLine = new MongOnLine(Constants.daname);
            MongWaitUp mongWaitUp = new MongWaitUp(Constants.daname);
            //反序列dd化
            OnLineModel onLineModel = JsonConvert.DeserializeObject<OnLineModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            if (string.IsNullOrEmpty(onLineModel.guid))
            {
                if (onLineModel.createDate.Year == 1)
                    onLineModel.createDate = DateTime.Now;
                onLineModel.guid = Guid.NewGuid().ToString();
                if (string.IsNullOrEmpty(onLineModel._id))
                    onLineModel._id = Guid.NewGuid().ToString();
                onLineModel.onLine = true;
                onLineModel.clickN = 0;
                mongOnLine.insert(onLineModel);
                mongWaitUp.delete(new WaitUpModel()
                {
                    _id = onLineModel._id
                });
                //微信小程序同步
                saveOnLine();
                //微博同步
                WeiBoHelper weiBoHelper = new WeiBoHelper();
                Dictionary<string, object> asy = new Dictionary<string, object>();
                string pic = onLineModel.pictiue.Replace("https://www.aikid360.com:8010/", "");
                pic = string.Format("{0}{1}", @"C:\web\akidImg\", pic);
                FileInfo file = new FileInfo(pic);
                if(file.Exists)
                    asy.Add("pic", file);
                string content = string.Format("{0}  详情请点击链接查看：https://www.aikid360.com/view.htm?{2}",
                    onLineModel.remark, onLineModel.origin, onLineModel.guid);
                asy.Add("status", content);
                weiBoHelper.send(asy);
                return new ToStream().ToStreams(mongWaitUp.obtainAll());
            }
            else
            {
                mongOnLine.update(onLineModel);
                //重新保存数据
                saveOnLine();
                return new ToStream().ToStreams(mongOnLine.obtainAll());
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Stream deleteOnLine(ImpContext context)
        {
            MongOnLine mongOnLine = new MongOnLine(Constants.daname);
            //反序列化
            OnLineModel onLineModel = JsonConvert.DeserializeObject<OnLineModel>(context.json.Replace("\0", ""), new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            mongOnLine.delete(onLineModel);
            string pic = onLineModel.pictiue.Replace("https://www.aikid360.com:8010/", "");
            pic = string.Format("{0}{1}", @"C:\web\akidImg\", pic);
            if (File.Exists(pic))
                File.Delete(pic);
            //重新保存数据
            saveOnLine();
            return new ToStream().ToStreams(mongOnLine.obtainAll());
        }
        /// <summary>
        /// 生产JSON格式的数据文档
        /// </summary>
        /// <returns></returns>
        private void saveOnLine() {
            //判断文件的存在
            if (File.Exists(Constants.wechatjson))
                File.Delete(Constants.wechatjson);
            else
                File.Create(Constants.wechatjson);
            MongOnLine mongOnLine = new MongOnLine(Constants.daname);
            List<OnLineModel> list = mongOnLine.obtainAll();
            IsoDateTimeConverter timeConverter = new Newtonsoft.Json.Converters.IsoDateTimeConverter();
            string dateTimeFormat = "yyyy'-'MM'-'dd";
            timeConverter.DateTimeFormat = dateTimeFormat;
            String json=JsonConvert.SerializeObject(list, timeConverter);
            saveBrand(list);
            System.IO.File.WriteAllText(Constants.wechatjson, json, Encoding.UTF8);
        }
        /// <summary>
        /// 写入品牌数据
        /// </summary>
        /// <param name="list"></param>
        private void saveBrand(List<OnLineModel> list) {
            if (File.Exists(Constants.wbrandjson))
                File.Delete(Constants.wbrandjson);
            else
                File.Create(Constants.wbrandjson);
            var orgins=list.GroupBy(p => new { p.origin })
              .Select(g => g.First())
              .ToList();
            List<string> orgin = (from q in orgins orderby q.origin select q.origin).ToList();
            List<string> shop = new List<string>();
            foreach (var key in orgin) {
                shop.Add("{\"name\":\""+ key + "\"}");
            }
            string shops =  "[" + string.Join(",", shop.ToArray()) + "]";
            System.IO.File.WriteAllText(Constants.wbrandjson, shops, Encoding.UTF8);
        }
    }
}
