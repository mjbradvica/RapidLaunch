// <copyright file="RapidLaunchGuidTestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Tests.GuidPrimary
{
    /// <summary>
    /// Test class for guid primary.
    /// </summary>
    public class RapidLaunchGuidTestRepository : RapidLaunchRepository<TestGuidEntity>
    {
        /// <inheritdoc />
        public RapidLaunchGuidTestRepository(DbContext context, Func<IQueryable<TestGuidEntity>, IQueryable<TestGuidEntity>>? includeFunc = default)
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
