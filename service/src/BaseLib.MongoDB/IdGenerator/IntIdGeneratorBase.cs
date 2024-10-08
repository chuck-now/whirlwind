using MongoDB.Bson.Serialization;

namespace BaseLib.MongoDb.IdGenerator
{
    public abstract class IntIdGeneratorBase : IIdGenerator
    {
        protected IntIdGeneratorBase()
        {
        }

        public object GenerateId(object container, object document)
        {
            //throw new NotImplementedException();
            return new object();
        }

        public bool IsEmpty(object id)
        {
            //throw new NotImplementedException();
            return false;
        }
    }
}