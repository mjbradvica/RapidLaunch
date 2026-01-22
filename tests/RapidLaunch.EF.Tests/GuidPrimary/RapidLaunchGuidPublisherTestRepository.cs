// <copyright file="RapidLaunchGuidPublisherTestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NMediation.Abstractions;
using RapidLaunch.Common;
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Tests.GuidPrimary
{
    /// <inheritdoc />
    public class RapidLaunchGuidPublisherTestRepository : RapidLaunchPublisherRepository<TestGuidEntity>
    {
        /// <inheritdoc />
        public RapidLaunchGuidPublisherTestRepository(DbContext context, IPublishingBus<IOccurrence> publishingBus, Func<IQueryable<TestGuidEntity>, IQueryable<TestGuidEntity>>? includeFunc = null)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchGuidPublisherTestRepository(DbContext context, IPublishingBus<IOccurrence> publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
