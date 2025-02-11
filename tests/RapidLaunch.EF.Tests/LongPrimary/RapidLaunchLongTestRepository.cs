// <copyright file="RapidLaunchLongTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.LongPrimary;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <inheritdoc />
    public class RapidLaunchLongTestRepository : RapidLaunchRepository<TestLongEntity>
    {
        /// <inheritdoc />
        public RapidLaunchLongTestRepository(DbContext context, Func<IQueryable<TestLongEntity>, IQueryable<TestLongEntity>>? includeFunc = default)
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
