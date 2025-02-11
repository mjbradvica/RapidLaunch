// <copyright file="RapidLaunchIntTestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.IntPrimary;

namespace RapidLaunch.EF.Tests.IntPrimary
{
    /// <inheritdoc />
    public class RapidLaunchIntTestRepository : RapidLaunchRepository<TestIntEntity>
    {
        /// <inheritdoc />
        public RapidLaunchIntTestRepository(DbContext context, Func<IQueryable<TestIntEntity>, IQueryable<TestIntEntity>>? includeFunc = default)
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
