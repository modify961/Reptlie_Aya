using MongHelp.AiKid.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongHelp.AiKid.Helper
{
    public class MongWaitUp:MongBase
    {
        /// <summary>
        /// 存储IP代理程序池的名字
        /// </summary>
        private const string _dbname = "wait_up";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseName"></param>
        public MongWaitUp(String baseName):base(baseName)
        {
            _mongoCollection = _mongoDatabase.GetCollection<Agenter>(_dbname);//选择集合，相当于表
            _mongodb.Connect();
        }
        /// <summary>
        /// 获取所有待上线的项目
        /// </summary>
        /// <returns></returns>
        public List<WaitUpModel> obtainAll()
        {
            List<WaitUpModel> agenters = new List<WaitUpModel>();
            foreach (var record in _mongoCollection.FindAllAs<Object>().ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                WaitUpModel waitUpModel = new WaitUpModel();
                agenters.Add(toEntity<WaitUpModel>(dictionary, waitUpModel));
            }
            return agenters;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="agenter"></param>
        public void delete(WaitUpModel waitUpModel)
        {
            IMongoQuery query = Query.EQ("_id", waitUpModel._id);
            _mongoCollection.Remove(query);
        }
        /// <summary>
        /// 根据指定的字段和指定的值删除数据
        /// </summary>
        /// <param name="agenter"></param>
        public void delete(string name,string val)
        {
            IMongoQuery query = Query.EQ(name, val);
            _mongoCollection.Remove(query);
        }
        /// <summary>
        /// 删除全部数据
        /// </summary>
        /// <param name="agenter"></param>
        public void delete()
        {
            _mongoCollection.RemoveAll();
        }
    }
}
