// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using Microsoft.Data.SqlClient;
using NMediation.Abstractions;
using RapidLaunch.Common;
using RapidLaunch.Dapper.Common;

namespace RapidLaunch.Dapper.StringPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, string, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(SqlConnection connection, IPublishingBus<IOccurrence> publishingBus)
            : base(connection, publishingBus)
        {
        }
    }
}
