// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using Microsoft.Data.SqlClient;
using RapidLaunch.ADO.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.StringPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, string>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(SqlConnection sqlConnection, IPublishingBus publishingBus, Func<SqlDataReader, TRoot> conversionFunc)
            : base(sqlConnection, publishingBus, conversionFunc)
        {
        }
    }
}
