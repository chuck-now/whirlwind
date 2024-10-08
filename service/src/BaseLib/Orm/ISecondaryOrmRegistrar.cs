using BaseLib.Dependency;
using BaseLib.Domain.Repositories;

namespace BaseLib.Orm
{
    /// <summary>
    /// ISecondaryOrmRegistrar
    /// </summary>
    public interface ISecondaryOrmRegistrar
    {
        string OrmContextKey { get; }

        void RegisterRepositories(IIocManager iocManager, AutoRepositoryTypesAttribute defaultRepositoryTypes);
    }
}