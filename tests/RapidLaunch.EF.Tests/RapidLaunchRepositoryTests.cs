// <copyright file="RapidLaunchRepositoryTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
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
        /// Can add entities correctly.
        /// </summary>
        [TestMethod]
        public void AddEntities_IsCorrect()
        {
            var entities = new List<TestEntity>
            {
                new TestEntity(),
                new TestEntity(),
            };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(entities);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetAllEntities();

                Assert.AreEqual(entities.Count, result.Count);
            }
        }

        /// <summary>
        /// Can add entities async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AddEntitiesAsync_IsCorrect()
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

        /// <summary>
        /// Can add an entity correctly.
        /// </summary>
        [TestMethod]
        public void AddEntity_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntity(new TestEntity());
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetAllEntities();

                Assert.AreEqual(1, result.Count);
            }
        }

        /// <summary>
        /// Can add an entity async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AddEntityAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntityAsync(new TestEntity());
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetAllEntitiesAsync();

                Assert.AreEqual(1, result.Count);
            }
        }
    }
}
