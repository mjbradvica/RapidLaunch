﻿// <copyright file="BaseIntegrationTest.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Base class for all integration tests.
    /// </summary>
    public abstract class BaseIntegrationTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        protected BaseIntegrationTest()
        {
            using (var context = new TestDbContext())
            {
                context.Set<TestEntity>().RemoveRange(context.Set<TestEntity>());

                context.SaveChanges();
            }
        }
    }
}
