using BaseLib.Domain.Repositories;

namespace BaseLib.EntityFramework.Repositories
{
    /// <summary>
    /// EfCoreAutoRepositoryTypes
    /// </summary>
    public static class EfCoreAutoRepositoryTypes
    {
        public static AutoRepositoryTypesAttribute Default { get; }

        static EfCoreAutoRepositoryTypes()
        {
            Default = new AutoRepositoryTypesAttribute(
                typeof(IRepository<>),
                typeof(IRepository<,>),
                typeof(EfCoreRepositoryBase<,>),
                typeof(EfCoreRepositoryBase<,,>)
            );
        }
    }
}