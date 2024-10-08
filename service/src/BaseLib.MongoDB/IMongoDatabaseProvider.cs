using MongoDB.Driver;

namespace BaseLib.MongoDb
{
    /// <summary>
    /// IMongoDatabaseProvider
    /// </summary>
    public interface IMongoDatabaseProvider
    {
        IMongoClient Client { get; }

        IMongoDatabase Database { get; }
    }
}