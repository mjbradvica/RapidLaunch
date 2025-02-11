// <copyright file="RapidLaunchStringPublisherTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.StringPrimary;

namespace RapidLaunch.EF.Tests.StringPrimary
{
    /// <inheritdoc />
    public class RapidLaunchStringPublisherTestRepository : RapidLaunchPublisherRepository<TestStringEntity>
    {
        /// <inheritdoc />
        public RapidLaunchStringPublisherTestRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TestStringEntity>, IQueryable<TestStringEntity>>? includeFunc = default)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchStringPublisherTestRepository(DbContext context, IPublishingBus publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
