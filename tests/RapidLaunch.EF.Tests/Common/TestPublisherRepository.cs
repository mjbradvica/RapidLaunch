﻿// <copyright file="TestPublisherRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;
using RapidLaunch.EF.Tests.GuidPrimary;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Test publisher repository.
    /// </summary>
    public class TestPublisherRepository : RapidLaunchPublisherRepository<TestGuidEntity, Guid>
    {
        /// <inheritdoc />
        public TestPublisherRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TestGuidEntity>, IQueryable<TestGuidEntity>>? includeFunc = default)
            : base(context, publishingBus, includeFunc)
        {
        }

        /// <inheritdoc />
        public TestPublisherRepository(DbContext context, IPublishingBus publishingBus)
            : base(context, publishingBus)
        {
        }
    }
}
