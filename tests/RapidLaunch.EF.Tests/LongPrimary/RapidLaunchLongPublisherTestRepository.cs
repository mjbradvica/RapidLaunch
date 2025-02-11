// <copyright file="RapidLaunchLongPublisherTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.LongPrimary;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <inheritdoc />
    public class RapidLaunchLongPublisherTestRepository : RapidLaunchPublisherRepository<TestLongEntity>
    {
        /// <inheritdoc />
        public RapidLaunchLongPublisherTestRepository(DbContext context, IPublishingBus publishingBus)
            : base(context, publishingBus)
        {
        }

        /// <inheritdoc />
        public RapidLaunchLongPublisherTestRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TestLongEntity>, IQueryable<TestLongEntity>>? includeFunc = null)
            : base(context, publishingBus, includeFunc)
        {
        }
    }
}
