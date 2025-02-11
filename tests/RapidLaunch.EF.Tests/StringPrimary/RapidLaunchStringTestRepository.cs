// <copyright file="RapidLaunchStringTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.StringPrimary;

namespace RapidLaunch.EF.Tests.StringPrimary
{
    /// <inheritdoc />
    public class RapidLaunchStringTestRepository : RapidLaunchRepository<TestStringEntity>
    {
        /// <inheritdoc />
        public RapidLaunchStringTestRepository(DbContext context, Func<IQueryable<TestStringEntity>, IQueryable<TestStringEntity>>? includeFunc = default)
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
