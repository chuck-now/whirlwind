using BaseLib.Domain.Entities;
using System;
using System.Collections.Generic;

namespace BaseLib.EntityFramework
{
    /// <summary>
    /// IDbContextEntityFinder
    /// </summary>
    public interface IDbContextEntityFinder
    {
        IEnumerable<EntityTypeInfo> GetEntityTypeInfos(Type dbContextType);
    }
}