// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using Microsoft.Data.SqlClient;
using RapidLaunch.ADO.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.LongPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, long>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
