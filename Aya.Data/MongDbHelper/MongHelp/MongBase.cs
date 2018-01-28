using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongHelp
{
    public abstract class MongBase
    {
        protected  MongoDatabase _mongoDatabase;
        protected MongoCollection _mongoCollection;
        protected MongoServer _mongodb;
        /// <summary>
        /// 构造函数
        /// </summary>
        protected MongBase(String baseName)
        {
            if (_mongoDatabase == null)
            {
                var settings = new MongoServerSettings();
                settings.Server = new MongoServerAddress("47.96.146.22", 27017);
                settings.WriteConcern = WriteConcern.Acknowledged;
                _mongodb = new MongoServer(settings);
                _mongoDatabase = _mongodb.GetDatabase(baseName);//选择数据库名
            }
        }
    }
}
