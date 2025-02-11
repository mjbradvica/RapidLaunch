// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using Microsoft.Data.SqlClient;
using RapidLaunch.ADO.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.StringPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, string>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, string> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
