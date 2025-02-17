// <copyright file="RapidLaunchStringTestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.StringPrimary;

namespace RapidLaunch.EF.Tests.StringPrimary
{
    /// <inheritdoc />
    public class RapidLaunchStringTestRepository : RapidLaunchRepository<TestStringEntity>
    {
        /// <inheritdoc />
        public RapidLaunchStringTestRepository(DbContext context, Func<IQueryable<TestStringEntity>, IQueryable<TestStringEntity>>? includeFunc = null)
            : base(context, includeFunc)
        {
        }

        /// <inheritdoc />
        public RapidLaunchStringTestRepository(DbContext context)
            : base(context)
        {
        }
    }
}
