// <copyright file="RapidLaunchIntPublisherTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.IntPrimary;

namespace RapidLaunch.EF.Tests.IntPrimary
{
    /// <inheritdoc />
    public class RapidLaunchIntPublisherTestRepository : RapidLaunchPublisherRepository<TestIntEntity>
    {
        /// <inheritdoc />
        public RapidLaunchIntPublisherTestRepository(DbContext context, IPublishingBus publishingBus)
            : base(context, publishingBus)
        {
        }

        /// <inheritdoc />
        public RapidLaunchIntPublisherTestRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TestIntEntity>, IQueryable<TestIntEntity>>? includeFunc = null)
            : base(context, publishingBus, includeFunc)
        {
        }
    }
}
