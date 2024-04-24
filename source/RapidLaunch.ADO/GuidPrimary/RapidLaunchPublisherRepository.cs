// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using ClearDomain.GuidPrimary;
using RapidLaunch.ADO.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TEntity> : RapidLaunchPublisherRepository<TEntity, Guid>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, Guid> sqlBuilder, IPublishingBus publishingBus, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, publishingBus, conversionFunc)
        {
        }
    }
}
