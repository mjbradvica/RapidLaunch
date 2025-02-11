// <copyright file="RapidLaunchGuidPublisherTestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Tests.GuidPrimary
{
    /// <inheritdoc />
    public class RapidLaunchGuidPublisherTestRepository : RapidLaunchPublisherRepository<TestGuidEntity>
    {
        /// <inheritdoc />
        public RapidLaunchGuidPublisherTestRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TestGuidEntity>, IQueryable<TestGuidEntity>>? includeFunc = default)
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
