// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using Microsoft.EntityFrameworkCore;
using NMediation.Abstractions;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, Guid, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TRoot>, IQueryable<TRoot>>? includeFunc = null)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
