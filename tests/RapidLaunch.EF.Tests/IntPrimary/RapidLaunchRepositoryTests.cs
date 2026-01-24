// <copyright file="RapidLaunchRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.IntPrimary;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.IntPrimary
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
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new RapidLaunchIntTestRepository(context);

                await repo.AddRootAsync(new TestIntEntity(), CancellationToken.None);
            }

            List<TestIntEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new RapidLaunchIntTestRepository(context);

                results = await repo.GetAllRootsAsync(CancellationToken.None);
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
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new RapidLaunchIntTestRepository(context);

                await repo.AddRootAsync(new TestIntEntity { Relationship = new TestRelationship() }, CancellationToken.None);
            }

            List<TestIntEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new RapidLaunchIntTestRepository(context, queryable => queryable.Include(root => root.Relationship));

                results = await repo.GetAllRootsAsync(CancellationToken.None);
            }

            Assert.HasCount(1, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }
    }
}
