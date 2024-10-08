using BaseLib.Dependency;
using BaseLib.Domain.Repositories;
using System;

namespace BaseLib.EntityFramework.Repositories
{
    /// <summary>
    /// IEfGenericRepositoryRegistrar
    /// </summary>
    public interface IEfGenericRepositoryRegistrar
    {
        void RegisterForDbContext(Type dbContextType, IIocManager iocManager, AutoRepositoryTypesAttribute defaultAutoRepositoryTypesAttribute);
    }
}