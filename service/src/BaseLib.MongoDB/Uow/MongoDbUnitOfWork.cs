using MongoDB.Driver;
using BaseLib.Dependency;
using BaseLib.Domain.Uow;
using BaseLib.MongoDb.Configuration;
using System.Threading.Tasks;

namespace BaseLib.MongoDb.Uow
{
    /// <summary>
    /// 工作单元 TODO...
    /// </summary>
    public class MongoDbUnitOfWork : UnitOfWorkBase, ITransientDependency
    {
        public MongoDatabase Database { get; private set; }

        public MongoDbUnitOfWork(
            IConnectionStringResolver connectionStringResolver,
            IUnitOfWorkFilterExecuter filterExecuter,
            IUnitOfWorkDefaultOptions defaultOptions)
            : base(
                  connectionStringResolver,
                  defaultOptions,
                  filterExecuter)
        {
        }

        public override void SaveChanges()
        {
            //throw new System.NotImplementedException();
            return;
        }

        public override Task SaveChangesAsync()
        {
            //throw new System.NotImplementedException();
            return Task.FromResult(0);
        }

        protected override void CompleteUow()
        {
            //throw new System.NotImplementedException();
            return;
        }

        protected override Task CompleteUowAsync()
        {
            //throw new System.NotImplementedException();
            return Task.FromResult(0);
        }

        protected override void DisposeUow()
        {
            //throw new System.NotImplementedException();
            return;
        }
    }
}