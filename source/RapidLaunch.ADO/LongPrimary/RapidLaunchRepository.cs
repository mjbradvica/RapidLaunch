// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using ClearDomain.LongPrimary;
using RapidLaunch.ADO.Common;

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
