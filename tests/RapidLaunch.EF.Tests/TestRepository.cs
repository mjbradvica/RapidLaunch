// <copyright file="TestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Tests
{
    /// <summary>
    /// Test repository.
    /// </summary>
    public class TestRepository : RapidLaunchRepository<TestEntity>
    {
        /// <inheritdoc />
        public TestRepository(DbContext context)
            : base(context)
        {
        }

        /// <inheritdoc />
        public TestRepository(DbContext context, Func<IQueryable<TestEntity>, IQueryable<TestEntity>> includeFunc)
            : base(context, includeFunc)
        {
        }
    }
}
