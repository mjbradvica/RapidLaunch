﻿// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.StringPrimary
{
    /// <inheritdoc />
    public class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, string>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        public RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TRoot>, IQueryable<TRoot>>? includeFunc = null)
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
