// <copyright file="RapidLaunchGuidTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Tests.GuidPrimary
{
    /// <summary>
    /// Test class for guid primary.
    /// </summary>
    public class RapidLaunchGuidTestRepository : RapidLaunchRepository<TestEntity>
    {
        /// <inheritdoc />
        public RapidLaunchGuidTestRepository(DbContext context, Func<IQueryable<TestEntity>, IQueryable<TestEntity>>? includeFunc = default)
            : base(context, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchGuidTestRepository(DbContext context)
            : base(context)
        {
        }
    }
}
