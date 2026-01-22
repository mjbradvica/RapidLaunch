// <copyright file="RapidLaunchStringPublisherTestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NMediation.Abstractions;
using RapidLaunch.Common;
using RapidLaunch.EF.StringPrimary;

namespace RapidLaunch.EF.Tests.StringPrimary
{
    /// <inheritdoc />
    public class RapidLaunchStringPublisherTestRepository : RapidLaunchPublisherRepository<TestStringEntity>
    {
        /// <inheritdoc />
        public RapidLaunchStringPublisherTestRepository(DbContext context, IPublishingBus<IOccurrence> publishingBus, Func<IQueryable<TestStringEntity>, IQueryable<TestStringEntity>>? includeFunc = null)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchStringPublisherTestRepository(DbContext context, IPublishingBus<IOccurrence> publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
