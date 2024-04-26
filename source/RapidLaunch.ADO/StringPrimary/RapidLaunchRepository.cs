// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using ClearDomain.StringPrimary;
using RapidLaunch.ADO.Common;

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
