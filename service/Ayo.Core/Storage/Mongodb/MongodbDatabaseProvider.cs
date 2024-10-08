using MongoDB.Driver;
using System.Collections.Generic;
using BaseLib;
using BaseLib.MongoDb;
using Ayo.Core.Configuration;

namespace Ayo.Core.Storage.Mongodb
{
    public class MongodbDatabaseProvider : IMongoDatabaseProvider
    {
        public MongodbDatabaseProvider()
        {
            var options = BaseLibEngine.Instance.Resolve<StorageOptions>();

            var settings = new MongoClientSettings();
            var servers = new List<MongoServerAddress>();
            options.MongoServers.ForEach(x =>
            {
                servers.Add(new MongoServerAddress(x.Host, x.Port));
            });
            settings.Servers = servers;
            if (options.MongoUsername.IsNotNullOrEmpty())
            {
                settings.Credential = MongoCredential.CreateCredential("admin", options.MongoUsername, options.MongoPassword);
            }

            if (options.MongoConnectionMode.ToLower() == "replicaset")
            {
                settings.ConnectionMode = ConnectionMode.ReplicaSet;
                settings.ReadPreference = new ReadPreference(ReadPreferenceMode.SecondaryPreferred);
            }

            Client = new MongoClient(settings);

            Database = Client.GetDatabase(options.MongoDbName);
        }

        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }
    }
}