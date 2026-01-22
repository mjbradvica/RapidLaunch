// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Microsoft.Data.SqlClient;
using NMediation.Abstractions;
using RapidLaunch.ADO.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, Guid, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(SqlConnection sqlConnection, IPublishingBus<IOccurrence> publishingBus, Func<SqlDataReader, TRoot> conversionFunc)
            : base(sqlConnection, publishingBus, conversionFunc)
        {
        }
    }
}
