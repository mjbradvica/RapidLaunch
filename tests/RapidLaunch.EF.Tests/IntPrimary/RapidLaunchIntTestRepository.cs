// <copyright file="RapidLaunchIntTestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.IntPrimary;

namespace RapidLaunch.EF.Tests.IntPrimary
{
    /// <inheritdoc />
    public class RapidLaunchIntTestRepository : RapidLaunchRepository<TestIntEntity>
    {
        /// <inheritdoc />
        public RapidLaunchIntTestRepository(DbContext context, Func<IQueryable<TestIntEntity>, IQueryable<TestIntEntity>>? includeFunc = null)
            : base(context, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchIntTestRepository(DbContext context)
            : base(context)
        {
        }
    }
}
