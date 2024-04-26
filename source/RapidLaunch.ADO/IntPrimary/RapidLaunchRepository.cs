// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using ClearDomain.IntPrimary;
using RapidLaunch.ADO.Common;

namespace RapidLaunch.ADO.IntPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, int>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
