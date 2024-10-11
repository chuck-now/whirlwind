using Ayo.Core.Domain.Repositories.Manager;
using Ayo.Core.Domain.Manager;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Ayo.Core.Storage.Mongodb.Manager
{
    public class AccountRepository : MongodbRepositoryBase<Account>, IAccountRepository
    {
        public AccountRepository(MongodbDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }

        public override string CollectionName
        { get { return DbConsts.CollectionNames.AYO_MANAGER_ACOUNT; } }

        public async Task<(int, IList<Account>)> Query(string keyword, int pageIndex, int pageSize)
        {
            var conditions = new BsonDocument();

            if (keyword.IsNotNullOrEmpty())
            {
                conditions.AddRange(new BsonDocument { { "$or",new BsonArray() {
                 "name", new BsonDocument() { { "$regex", keyword } },
                 "email", new BsonDocument() { { "$regex", keyword } },
                 "mobilePhone", new BsonDocument() { { "$regex", keyword } }
                } } });
            }

            var count = await Collection.CountDocumentsAsync(conditions);

            var sort = new BsonDocument { { "createdAt", -1 } };

            var items = await Collection.Find(conditions).Sort(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();

            return (count.ToInt(), items);
        }

        public new async Task Update(Account account)
        {
            var query = Builders<Account>.Filter.Eq(x => x.Id, account.Id);
            var update = Builders<Account>.Update.Set(x => x.Name, account.Name)
                                                                             .Set(x => x.Email, account.Email)
                                                                             .Set(x => x.MobilePhone, account.MobilePhone)
                                                                             .Set(x => x.Password, account.Password)
                                                                             .Set(x => x.OperatorId, account.OperatorId)
                                                                             .Set(x => x.OperatorName, account.OperatorName)
                                                                             .Set(x => x.OperatorType, account.OperatorType)
                                                                             .Set(x => x.OperatorAt, DateTime.Now);
            await Collection.UpdateOneAsync(query, update);
        }

        public async Task DeleteById(Account account)
        {
            var query = Builders<Account>.Filter.Eq(x => x.Id, account.Id);
            var update = Builders<Account>.Update.Set(x => x.OperatorId, account.OperatorId)
                                                                              .Set(x => x.OperatorName, account.OperatorName)
                                                                              .Set(x => x.OperatorType, account.OperatorType)
                                                                              .Set(x => x.OperatorAt, DateTime.Now);
            await Collection.UpdateOneAsync(query, update);
        }
    }
}