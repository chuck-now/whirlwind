using Castle.MicroKernel.Resolvers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using BaseLib.Dependency;
using BaseLib.EntityFramework.Configuration;
using System;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace BaseLib.EntityFramework
{
    /// <summary>
    /// DefaultDbContextResolver
    /// </summary>
    public class DefaultDbContextResolver : IDbContextResolver, ITransientDependency
    {
        private static readonly MethodInfo CreateOptionsMethod = typeof(DefaultDbContextResolver).GetMethod("CreateOptions", BindingFlags.NonPublic | BindingFlags.Instance);

        private readonly IIocResolver _iocResolver;
        private readonly IDbContextTypeMatcher _dbContextTypeMatcher;

        public DefaultDbContextResolver(
            IIocResolver iocResolver,
            IDbContextTypeMatcher dbContextTypeMatcher)
        {
            _iocResolver = iocResolver;
            _dbContextTypeMatcher = dbContextTypeMatcher;
        }

        public TDbContext Resolve<TDbContext>(string connectionString, DbConnection existingConnection) where TDbContext : DbContext
        {
            var dbContextType = typeof(TDbContext);
            Type concreteType = null;
            var isAbstractDbContext = dbContextType.GetTypeInfo().IsAbstract;
            if (isAbstractDbContext)
            {
                concreteType = _dbContextTypeMatcher.GetConcreteType(dbContextType);
            }

            try
            {
                if (isAbstractDbContext)
                {
                    return (TDbContext)_iocResolver.Resolve(concreteType, new
                    {
                        options = CreateOptionsForType(concreteType, connectionString, existingConnection)
                    });
                }

                return _iocResolver.Resolve<TDbContext>(new
                {
                    options = CreateOptions<TDbContext>(connectionString, existingConnection)
                });
            }
            catch (DependencyResolverException ex)
            {
                var hasOptions = isAbstractDbContext ? HasOptions(concreteType) : HasOptions(dbContextType);
                if (!hasOptions)
                {
                    throw new AggregateException($"The parameter name of {dbContextType.Name}'s constructor must be 'options'", ex);
                }

                throw;
            }

            static bool HasOptions(Type contextType)
            {
                return contextType.GetConstructors().Any(ctor =>
                {
                    var parameters = ctor.GetParameters();
                    return parameters.Length == 1 && parameters.FirstOrDefault()?.Name == "options";
                });
            }
        }

        private object CreateOptionsForType(Type dbContextType, string connectionString, DbConnection existingConnection)
        {
            return CreateOptionsMethod.MakeGenericMethod(dbContextType).Invoke(this, new object[] { connectionString, existingConnection });
        }

        protected virtual DbContextOptions<TDbContext> CreateOptions<TDbContext>(string connectionString, DbConnection existingConnection) where TDbContext : DbContext
        {
            if (_iocResolver.IsRegistered<IBaseLibDbContextConfigurer<TDbContext>>())
            {
                var configuration = new BaseLibDbContextConfiguration<TDbContext>(connectionString, existingConnection);
                ReplaceServices(configuration);

                using (var configurer = _iocResolver.ResolveAsDisposable<IBaseLibDbContextConfigurer<TDbContext>>())
                {
                    configurer.Object.Configure(configuration);
                }

                return configuration.DbContextOptions.Options;
            }

            if (_iocResolver.IsRegistered<DbContextOptions<TDbContext>>())
            {
                return _iocResolver.Resolve<DbContextOptions<TDbContext>>();
            }

            throw new BaseLibException($"Could not resolve DbContextOptions for {typeof(TDbContext).AssemblyQualifiedName}.");
        }

        protected virtual void ReplaceServices<TDbContext>(BaseLibDbContextConfiguration<TDbContext> configuration) where TDbContext : DbContext
        {
            configuration.DbContextOptions.ReplaceService<IEntityMaterializerSource, BaseLibEntityMaterializerSource>();
        }
    }
}