// <copyright file="RapidLaunchPublisherRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Microsoft.Data.SqlClient;
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
