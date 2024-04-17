// <copyright file="RapidLaunchPublisherRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using ClearDomain.GuidPrimary;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TEntity> : RapidLaunchPublisherRepository<TEntity, Guid>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
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
