﻿using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace BaseLib.EntityFramework
{
    /// <summary>
    /// IDbContextResolver
    /// </summary>
    public interface IDbContextResolver
    {
        TDbContext Resolve<TDbContext>(string connectionString, DbConnection existingConnection) where TDbContext : DbContext;
    }
}