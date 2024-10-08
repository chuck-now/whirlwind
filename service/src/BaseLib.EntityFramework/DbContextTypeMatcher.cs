using BaseLib.Domain.Uow;

namespace BaseLib.EntityFramework
{
    /// <summary>
    /// DbContextTypeMatcher
    /// </summary>
    public class DbContextTypeMatcher : DbContextTypeMatcher<BaseLibDbContext>
    {
        public DbContextTypeMatcher(ICurrentUnitOfWorkProvider currentUnitOfWorkProvider)
            : base(currentUnitOfWorkProvider)
        {

        }
    }
}