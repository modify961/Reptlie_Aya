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
    public class MongOnLine : MongBase
    {
        /// <summary>
        /// 存储IP代理程序池的名字
        /// </summary>
        private const string _dbname = "on_line";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseName"></param>
        public MongOnLine(String baseName) : base(baseName)
        {
            _mongoCollection = _mongoDatabase.GetCollection<Agenter>(_dbname);//选择集合，相当于表
            _mongodb.Connect();
        }
        /// <summary>
        /// 查询所有的在线或下线的奶粉活动信息
        /// </summary>
        /// <returns></returns>
        public List<OnLineModel> obtainAll(bool onLine=true)
        {
            List<OnLineModel> agenters = new List<OnLineModel>();
            IMongoQuery query = null;
            query = Query.And(Query.EQ("onLine", onLine));
            foreach (var record in _mongoCollection.FindAs<Object>(query).ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                OnLineModel onLineModel = new OnLineModel();
                agenters.Add(toEntity<OnLineModel>(dictionary, onLineModel));
            }
            return agenters;
        }
        /// <summary>
        /// 根据是否采集时间和是否推荐来读取数据列表
        /// </summary>
        /// <param name="dateTime">创建时间</param>
        /// <param name="recommend">是否推荐</param>
        /// <returns></returns>
        public List<OnLineModel> obtainAll(OnLineModel querys)
        {
            List<OnLineModel> agenters = new List<OnLineModel>();
            IMongoQuery query = null;
            query = Query.And(Query.EQ("onLine", true));
            if (querys != null) {
                if(!string.IsNullOrEmpty(querys.brand))
                    query = Query.And(Query.EQ("brand", querys.brand));
                if (!string.IsNullOrEmpty(querys.origin))
                    query = Query.And(Query.EQ("origin", querys.origin));
            }
            foreach (var record in _mongoCollection.FindAs<Object>(query).ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                OnLineModel onLineModel = new OnLineModel();
                agenters.Add(toEntity<OnLineModel>(dictionary, onLineModel));
            }
            return agenters;
        }
        /// <summary>
        /// 根据是否采集时间和是否推荐来读取数据列表
        /// </summary>
        /// <param name="dateTime">创建时间</param>
        /// <param name="recommend">是否推荐</param>
        /// <returns></returns>
        public List<OnLineModel> obtainRecommend()
        {
            List<OnLineModel> agenters = new List<OnLineModel>();
            IMongoQuery query = null;
            query = Query.And(Query.EQ("onLine", true),
                Query.EQ("recommend", true));
            foreach (var record in _mongoCollection.FindAs<Object>(query).ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                OnLineModel onLineModel = new OnLineModel();
                agenters.Add(toEntity<OnLineModel>(dictionary, onLineModel));
            }
            return agenters;
        }
        /// <summary>
        /// 录入一条数据
        /// </summary>
        /// <param name="brandModel"></param>
        /// <returns></returns>
        public int insert(OnLineModel onLineModel)
        {
            //判断是否存在重复项
            if (!isExist(onLineModel))
            {
                //增加8个小时
                onLineModel.createDate = onLineModel.createDate.AddHours(8);
                var state = _mongoCollection.Insert(onLineModel);
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 录入一条数据
        /// </summary>
        /// <param name="brandModel"></param>
        /// <returns></returns>
        public int update(OnLineModel onLineModel)
        {
            //先删除再添加
            delete(onLineModel);
            return insert(onLineModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agenter"></param>
        public void delete(OnLineModel onLineModel)
        {
            IMongoQuery query = Query.EQ("_id", onLineModel._id);
            _mongoCollection.Remove(query);
        }
        /// <summary>
        /// 判断数据是否重复,根据URL判断
        /// </summary>
        /// <param name="brandModel"></param>
        /// <returns>true:存在，false：不存在</returns>
        public bool isExist(OnLineModel onLineModel)
        {
            IMongoQuery query = null;// Query.EQ("name", brandModel.name);
            query = Query.And(
                Query.EQ("url", onLineModel.url)
            );
            object item = _mongoCollection.FindAs<Object>(query).FirstOrDefault();
            if (item != null)
            {
                return true;
            }
            return false;
        }
    }
}
