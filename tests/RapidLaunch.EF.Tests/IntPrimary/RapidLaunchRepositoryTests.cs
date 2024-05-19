// <copyright file="RapidLaunchRepositoryTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidLaunch.EF.IntPrimary;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.IntPrimary
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchRepository{TEntity}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchRepositoryTests : BaseIntegrationTest
    {
        /// <summary>
        /// Default constructor is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DefaultConstructor_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntTestRepository(context);

                await repo.AddEntityAsync(new TestIntEntity());
            }

            List<TestIntEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntTestRepository(context);

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(1, results.Count);
        }

        /// <summary>
        /// Include func is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task IncludeFunc_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntTestRepository(context);

                await repo.AddEntityAsync(new TestIntEntity { TestRelationship = new TestRelationship() });
            }

            List<TestIntEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntTestRepository(context, queryable => queryable.Include(entity => entity.TestRelationship));

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.All(entity => entity.TestRelationship != null));
        }
    }
}
