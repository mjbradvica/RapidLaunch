// <copyright file="TestRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

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
    }
}
