// <copyright file="TestPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NMediation.Abstractions;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;
using RapidLaunch.EF.Tests.GuidPrimary;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Test publisher repository.
    /// </summary>
    public class TestPublisherRepository : RapidLaunchPublisherRepository<TestGuidEntity, Guid, IOccurrence>
    {
        /// <inheritdoc />
        public TestPublisherRepository(DbContext context, IPublishingBus<IOccurrence> publishingBus, Func<IQueryable<TestGuidEntity>, IQueryable<TestGuidEntity>>? includeFunc = null)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        public TestPublisherRepository(DbContext context, IPublishingBus<IOccurrence> publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
