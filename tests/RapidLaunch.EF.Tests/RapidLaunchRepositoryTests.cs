// <copyright file="RapidLaunchRepositoryTests.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidLaunch.EF.GuidPrimary;
using RapidLaunch.EF.Tests.Common;

namespace RapidLaunch.EF.Tests
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchRepository{TEntity}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchRepositoryTests : BaseIntegrationTest
    {
        /// <summary>
        /// Can add entities correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AddEntities_IsCorrect()
        {
            var entities = new List<TestEntity>
            {
                new TestEntity(),
                new TestEntity(),
            };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(entities);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetAllEntitiesAsync();

                Assert.AreEqual(entities.Count, result.Count);
            }
        }
    }
}
