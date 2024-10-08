using Microsoft.EntityFrameworkCore;
using BaseLib.Domain.Uow;
using System;

namespace BaseLib.EntityFramework.Uow
{
    /// <summary>
    /// UnitOfWorkExtensions
    /// </summary>
    public static class UnitOfWorkExtensions
    {
        public static TDbContext GetDbContext<TDbContext>(this IActiveUnitOfWork unitOfWork, string name = null) where TDbContext : DbContext
        {
            if (unitOfWork == null)
            {
                throw new ArgumentNullException("unitOfWork");
            }
            if (!(unitOfWork is EfCoreUnitOfWork))
            {
                throw new ArgumentException("unitOfWork is not type of " + typeof(EfCoreUnitOfWork).FullName, "unitOfWork");
            }
            return (unitOfWork as EfCoreUnitOfWork).GetOrCreateDbContext<TDbContext>(name);
        }
    }
}