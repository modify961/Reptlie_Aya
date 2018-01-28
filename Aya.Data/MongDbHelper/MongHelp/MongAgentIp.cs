using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongHelp
{
    public class MongAgentIp:MongBase
    {
        /// <summary>
        /// 存储IP代理程序池的名字
        /// </summary>
        private const string _dbname = "ipList";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseName"></param>
        public MongAgentIp(String baseName):base(baseName)
        {
            _mongoCollection = _mongoDatabase.GetCollection<Agenter>("ipList");//选择集合，相当于表
            _mongodb.Connect();
        }
        /// <summary>
        /// 获取所有的代理IP
        /// </summary>
        /// <returns></returns>
        public  List<Agenter> obtainAll()
        {
            List<Agenter> agenters = new List<Agenter>();
            foreach (var record in _mongoCollection.FindAllAs<Object>().ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                agenters.Add(new Agenter()
                {
                    ip = dictionary["ip"].ToString(),
                    port = int.Parse(dictionary["port"].ToString()),
                    type = !dictionary.ContainsKey("type") ? "" : dictionary["type"].ToString(),
                    anonymous = !dictionary.ContainsKey("anonymous") ? "" : dictionary["anonymous"].ToString(),
                    createTime = DateTime.Parse(dictionary["createTime"].ToString()),
                    checkTime = DateTime.Parse(dictionary["checkTime"].ToString())
                });
            }
            return agenters;
        }
        /// <summary>
        ///分页查询代理IP地址
        /// </summary>
        /// <param name="start">起始条数</param>
        /// <param name="pageSize">分页大小</param>
        /// <returns></returns>
        public List<Agenter> obtainByPage(int start,int pageSize)
        {
            List<Agenter> agenters = new List<Agenter>();
            //_mongoCollection.FindAllAs<Object>().Skip< Object>(start).l
            foreach (var record in _mongoCollection.FindAllAs<Object>().ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                agenters.Add(new Agenter()
                {
                    ip = dictionary["ip"].ToString(),
                    port = int.Parse(dictionary["port"].ToString()),
                    type = !dictionary.ContainsKey("type") ? "" : dictionary["type"].ToString(),
                    anonymous = !dictionary.ContainsKey("anonymous") ? "" : dictionary["anonymous"].ToString(),
                    createTime = DateTime.Parse(dictionary["createTime"].ToString()),
                    checkTime = DateTime.Parse(dictionary["checkTime"].ToString())
                });
            }
            return agenters;
        }
        /// <summary>
        /// 根据IP查询代理
        /// </summary>
        /// <returns></returns>
        public  Agenter obtainByIp(String ip)
        {
            IMongoQuery query = Query.EQ("ip", ip);
            object item = _mongoCollection.FindAs<Object>(query).FirstOrDefault();
            if (item != null)
            {
                Dictionary<String, Object> dictionary = item.ToBsonDocument().ToDictionary();
                return new Agenter()
                {
                    ip = dictionary["ip"].ToString(),
                    port = int.Parse(dictionary["port"].ToString()),
                    type = dictionary["type"] == null ? "" : dictionary["type"].ToString(),
                    createTime = DateTime.Parse(dictionary["createTime"].ToString()),
                    checkTime = DateTime.Parse(dictionary["checkTime"].ToString())
                };
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agenter"></param>
        public  void delete(Agenter agenter)
        {
            IMongoQuery query = Query.EQ("ip", agenter.ip);
            _mongoCollection.Remove(query);
        }
    }
}
