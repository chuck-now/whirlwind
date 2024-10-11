using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Ayo.Core.Domain.Collect;
using Ayo.Core.Domain.Repositories.Collect;
using static Ayo.Core.GlobalConsts;

namespace Ayo.Core.Storage.Mongodb.Collect
{
    public class RobotRepository : MongodbRepositoryBase<Robot>, IRobotRepository
    {
        public RobotRepository(MongodbDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public override string CollectionName => DbConsts.CollectionNames.AYO_COLLECT_ROBOT;

        public new async Task<List<Robot>> GetAll()
        {
            var query = new BsonDocument() { { "operatorType", new BsonDocument() { { "$ne", "delete" } } } };

            //排序
            var sort = new BsonDocument()
            {
                { "operatorAt", -1 }
            };
            return await Collection.Find(query).Sort(sort).ToListAsync();
        }

        public async Task<long> UpdateInfo(Robot robot)
        {
            var query = Builders<Robot>.Filter.Eq(x => x.Id, robot.Id);
            var update = Builders<Robot>.Update.Set(x => x.Name, robot.Name)
                                                                           .Set(x => x.Description, robot.Description);
            var result = await Collection.UpdateOneAsync(query, update);
            return result.ModifiedCount;
        }

        public async Task<long> UpdateIsEnable(ObjectId Id, string isEnable)
        {
            var query = Builders<Robot>.Filter.Eq(x => x.Id, Id);
            var update = Builders<Robot>.Update.Set(x => x.IsEnable, isEnable);
            var result = await Collection.UpdateOneAsync(query, update);
            return result.ModifiedCount;
        }

        public async Task<long> UpdateOpInfo(ObjectId Id, string operatorId, string operatorName, string operatorType)
        {
            var query = Builders<Robot>.Filter.Eq(x => x.Id, Id);
            var update = Builders<Robot>.Update.Set(x => x.OperatorId, operatorId)
                                                                          .Set(x => x.OperatorName, operatorName)
                                                                          .Set(x => x.OperatorType, operatorType)
                                                                          .Set(x => x.OperatorAt, DateTime.Now);
            var result = await Collection.UpdateOneAsync(query, update);
            return result.ModifiedCount;
        }

        public async Task<long> IncTaskCount(ObjectId Id, int count)
        {
            var query = Builders<Robot>.Filter.Eq(x => x.Id, Id);
            var update = Builders<Robot>.Update.Inc(x => x.TaskCount, count);
            var result = await Collection.UpdateOneAsync(query, update);
            return result.ModifiedCount;
        }

        public async Task<long> DeleteById(ObjectId Id)
        {
            var query = Builders<Robot>.Filter.Eq(x => x.Id, Id);
            var update = Builders<Robot>.Update.Set(x => x.OperatorType, KnowOperatorType.DELETE);
            var result = await Collection.UpdateOneAsync(query, update);
            return result.ModifiedCount;
        }
    }
}