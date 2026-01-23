// <copyright file="RapidLaunchRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidLaunch.EF.LongPrimary;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchRepository{TRoot}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchRepositoryTests : BaseIntegrationTest
    {
        /// <summary>
        /// Default constructor is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DefaultConstructorIsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongTestRepository(context);

                await repo.AddRootAsync(new TestLongEntity());
            }

            List<TestLongEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongTestRepository(context);

                results = await repo.GetAllRootsAsync();
            }

            Assert.HasCount(1, results);
        }

        /// <summary>
        /// Include func is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task IncludeFuncIsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongTestRepository(context);

                await repo.AddRootAsync(new TestLongEntity { Relationship = new TestRelationship() });
            }

            List<TestLongEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongTestRepository(context, queryable => queryable.Include(root => root.Relationship));

                results = await repo.GetAllRootsAsync();
            }

            Assert.HasCount(1, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }
    }
}
