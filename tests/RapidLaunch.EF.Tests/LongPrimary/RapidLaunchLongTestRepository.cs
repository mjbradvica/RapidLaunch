// <copyright file="RapidLaunchLongTestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.LongPrimary;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <inheritdoc />
    public class RapidLaunchLongTestRepository : RapidLaunchRepository<TestLongEntity>
    {
        /// <inheritdoc />
        public RapidLaunchLongTestRepository(DbContext context, Func<IQueryable<TestLongEntity>, IQueryable<TestLongEntity>>? includeFunc = null)
            : base(context, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchLongTestRepository(DbContext context)
            : base(context)
        {
        }
    }
}
