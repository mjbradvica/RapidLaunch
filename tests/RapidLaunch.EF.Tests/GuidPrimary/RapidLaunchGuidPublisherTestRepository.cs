// <copyright file="RapidLaunchGuidPublisherTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Tests.GuidPrimary
{
    /// <inheritdoc />
    public class RapidLaunchGuidPublisherTestRepository : RapidLaunchPublisherRepository<TestEntity>
    {
        /// <inheritdoc />
        public RapidLaunchGuidPublisherTestRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TestEntity>, IQueryable<TestEntity>>? includeFunc = default)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchGuidPublisherTestRepository(DbContext context, IPublishingBus publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
