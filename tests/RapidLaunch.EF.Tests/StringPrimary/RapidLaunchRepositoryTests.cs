// <copyright file="RapidLaunchRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidLaunch.EF.StringPrimary;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.StringPrimary
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
                var repo = new RapidLaunchStringTestRepository(context);

                await repo.AddRootAsync(new TestStringEntity());
            }

            List<TestStringEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchStringTestRepository(context);

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
                var repo = new RapidLaunchStringTestRepository(context);

                await repo.AddRootAsync(new TestStringEntity { Relationship = new TestRelationship() });
            }

            List<TestStringEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchStringTestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
        }
    }
}
