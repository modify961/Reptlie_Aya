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
    /// <summary>
    /// 
    /// </summary>
    public class MongBrand : MongBase
    {
        /// <summary>
        /// 存储IP代理程序池的名字
        /// </summary>
        private const string _dbname = "brand";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseName"></param>
        public MongBrand(String baseName):base(baseName)
        {
            _mongoCollection = _mongoDatabase.GetCollection<Agenter>(_dbname);//选择集合，相当于表
            _mongodb.Connect();
        }
        /// <summary>
        /// 所有品牌信息
        /// </summary>
        /// <returns></returns>
        public List<BrandModel> obtainAll()
        {
            List<BrandModel> agenters = new List<BrandModel>();
            foreach (var record in _mongoCollection.FindAllAs<Object>().ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                BrandModel waitUpModel = new BrandModel();
                agenters.Add(toEntity<BrandModel>(dictionary, waitUpModel));
            }
            return agenters;
        }
        /// <summary>
        /// 录入一条数据
        /// </summary>
        /// <param name="brandModel"></param>
        /// <returns></returns>
        public int insert(BrandModel brandModel)
        {
            //判断是否存在重复项
            if (!isExist(brandModel)) {
                var state = _mongoCollection.Insert(brandModel);
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 录入一条数据
        /// </summary>
        /// <param name="brandModel"></param>
        /// <returns></returns>
        public int update(BrandModel brandModel)
        {
            //先删除再添加
            delete(brandModel);
            return insert(brandModel);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="agenter"></param>
        public void delete(BrandModel brandModel)
        {
            IMongoQuery query = Query.EQ("guid", brandModel.guid);
            _mongoCollection.Remove(query);
        }
        /// <summary>
        /// 判断数据是个重复
        /// </summary>
        /// <param name="brandModel"></param>
        /// <returns>true:存在，false：不存在</returns>
        private bool isExist(BrandModel brandModel)
        {
            IMongoQuery query = null;// Query.EQ("name", brandModel.name);
            query = Query.And(
                Query.EQ("name", brandModel.name),
                Query.EQ("conutry", brandModel.conutry)
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
