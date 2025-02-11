﻿// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using Microsoft.Data.SqlClient;
using RapidLaunch.ADO.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.IntPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TEntity> : RapidLaunchPublisherRepository<TEntity, int>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(SqlConnection sqlConnection, IPublishingBus publishingBus, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, publishingBus, conversionFunc)
        {
        }
    }
}
