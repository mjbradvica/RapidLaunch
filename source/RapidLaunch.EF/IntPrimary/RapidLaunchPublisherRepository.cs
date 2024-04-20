// <copyright file="RapidLaunchPublisherRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using ClearDomain.IntPrimary;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.IntPrimary
{
    /// <inheritdoc />
    public class RapidLaunchPublisherRepository<TEntity> : RapidLaunchPublisherRepository<TEntity, int>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        public RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includeFunc = default)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
