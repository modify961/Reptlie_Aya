using MongHelp.AiKid.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongHelp.AiKid.Helper
{
    public class MongCountry : MongBase
    {
        /// <summary>
        /// 存储IP代理程序池的名字
        /// </summary>
        private const string _dbname = "country";
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="baseName"></param>
        public MongCountry(String baseName):base(baseName)
        {
            _mongoCollection = _mongoDatabase.GetCollection<Agenter>(_dbname);//选择集合，相当于表
            _mongodb.Connect();
        }
        /// <summary>
        /// 获取所有的国家信息
        /// </summary>
        /// <returns></returns>
        public List<CountryModel> obtainAll()
        {
            List<CountryModel> agenters = new List<CountryModel>();
            foreach (var record in _mongoCollection.FindAllAs<Object>().ToList())
            {
                Dictionary<String, Object> dictionary = record.ToBsonDocument().ToDictionary();
                CountryModel waitUpModel = new CountryModel();
                agenters.Add(toEntity<CountryModel>(dictionary, waitUpModel));
            }
            return agenters;
        }
    }
}
