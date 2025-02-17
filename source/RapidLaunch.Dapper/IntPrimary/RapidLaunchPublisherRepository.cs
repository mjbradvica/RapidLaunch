// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using Microsoft.Data.SqlClient;
using RapidLaunch.Common;
using RapidLaunch.Dapper.Common;

namespace RapidLaunch.Dapper.IntPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, int>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(SqlConnection connection, IPublishingBus publishingBus)
            : base(connection, publishingBus)
        {
        }
    }
}
