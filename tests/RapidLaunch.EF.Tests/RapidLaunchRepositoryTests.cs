// <copyright file="RapidLaunchRepositoryTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        /// <summary>
        /// Can delete entities is correct.
        /// </summary>
        [TestMethod]
        public void DeleteEntities_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity> { new TestEntity(), new TestEntity() });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var entities = repo.GetAllEntities();

                repo.DeleteEntities(entities);
            }

            List<TestEntity> result;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = repo.GetAllEntities();
            }

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Can delete entities is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DeleteEntitiesAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestEntity> { new TestEntity(), new TestEntity() });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var entities = await repo.GetAllEntitiesAsync();

                await repo.DeleteEntitiesAsync(entities);
            }

            List<TestEntity> result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Can delete an entity correctly.
        /// </summary>
        [TestMethod]
        public void DeleteEntity_IsCorrect()
        {
            var entity = new TestEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntity(entity);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var toDelete = repo.GetById(entity.Id);

                if (toDelete != null)
                {
                    repo.DeleteEntity(toDelete);
                }
            }

            List<TestEntity> result;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = repo.GetAllEntities();
            }

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Can delete an entity async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DeleteEntityAsync_IsCorrect()
        {
            var entity = new TestEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntityAsync(entity);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var toDelete = await repo.GetByIdAsync(entity.Id);

                if (toDelete != null)
                {
                    await repo.DeleteEntityAsync(toDelete);
                }
            }

            List<TestEntity> result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Can get all entities is correct.
        /// </summary>
        [TestMethod]
        public void GetAllEntities_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity> { new TestEntity(), new TestEntity() });
            }

            List<TestEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetAllEntities();
            }

            Assert.AreEqual(2, results.Count);
        }

        /// <summary>
        /// Can get all entities with include func is correct.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesWithIncludeFunc_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity>
                {
                    new TestEntity { Relationship = new TestRelationship() }, new TestEntity { Relationship = new TestRelationship() },
                });
            }

            List<TestEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetAllEntities(queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
        }

        /// <summary>
        /// Can get all entities async is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetAllEntitiesAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestEntity> { new TestEntity(), new TestEntity() });
            }

            List<TestEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(2, results.Count);
        }

        /// <summary>
        /// Can get all entities async with include func is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetAllEntitiesWithIncludeFuncAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestEntity>
                {
                    new TestEntity { Relationship = new TestRelationship() }, new TestEntity { Relationship = new TestRelationship() },
                });
            }

            List<TestEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllEntitiesAsync(queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
        }

        /// <summary>
        /// Can get entities lazy is correct.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesLazy_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity> { new TestEntity(), new TestEntity() });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestEntity> results = repo.GetAllEntitiesLazy();

                Assert.IsInstanceOfType<IQueryable<TestEntity>>(results);

                var asList = results.ToList();

                Assert.AreEqual(2, asList.Count);
            }
        }

        /// <summary>
        /// Can get entities lazy with include func is correct.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesLazyWithIncludeFunc_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity>
                {
                    new TestEntity { Relationship = new TestRelationship() },
                    new TestEntity { Relationship = new TestRelationship() },
                });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestEntity> results = repo.GetAllEntitiesLazy(queryable => queryable.Include(entity => entity.Relationship));

                Assert.IsInstanceOfType<IQueryable<TestEntity>>(results);

                var asList = results.ToList();

                Assert.IsTrue(asList.All(entity => entity.Relationship != null));
                Assert.AreEqual(2, asList.Count);
            }
        }

        /// <summary>
        /// Can get by id is correct.
        /// </summary>
        [TestMethod]
        public void GetById_IsCorrect()
        {
            var entity = new TestEntity();
            var incorrect = new TestEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity> { entity, incorrect });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetById(entity.Id);

                Assert.AreEqual(entity, result);
            }
        }

        /// <summary>
        /// Can get by id with include func is correct.
        /// </summary>
        [TestMethod]
        public void GetByIdWithIncludeFunc_IsCorrect()
        {
            var entity = new TestEntity { Relationship = new TestRelationship() };
            var incorrect = new TestEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity> { entity, incorrect });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetById(entity.Id, queryable => queryable.Include(testEntity => testEntity.Relationship));

                Assert.AreEqual(entity, result);
                Assert.IsNotNull(result?.Relationship);
            }
        }

        /// <summary>
        /// Can get by id async is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetByIdAsync_IsCorrectAsync()
        {
            var entity = new TestEntity();
            var incorrect = new TestEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestEntity> { entity, incorrect });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetByIdAsync(entity.Id);

                Assert.AreEqual(entity, result);
            }
        }

        /// <summary>
        /// Can get by id with include func is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetByIdWithIncludeFuncAsync_IsCorrect()
        {
            var entity = new TestEntity { Relationship = new TestRelationship() };
            var incorrect = new TestEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestEntity> { entity, incorrect });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetByIdAsync(entity.Id, queryable => queryable.Include(testEntity => testEntity.Relationship));

                Assert.AreEqual(entity, result);
                Assert.IsNotNull(result?.Relationship);
            }
        }

        /// <summary>
        /// Can get entities by id is correct.
        /// </summary>
        [TestMethod]
        public void GetEntitiesById_IsCorrect()
        {
            var first = new TestEntity();
            var second = new TestEntity();
            var third = new TestEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity> { first, second, third });
            }

            List<TestEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetEntitiesById(new List<Guid>
                {
                    first.Id,
                    second.Id,
                });
            }

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(first, results.First());
            Assert.AreEqual(second, results.Last());
        }

        /// <summary>
        /// Can get entities by id with include func is correct.
        /// </summary>
        [TestMethod]
        public void GetEntitiesByIdWithIncludeFunc_IsCorrect()
        {
            var first = new TestEntity { Relationship = new TestRelationship() };
            var second = new TestEntity { Relationship = new TestRelationship() };
            var third = new TestEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestEntity> { first, second, third });
            }

            List<TestEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetEntitiesById(
                    new List<Guid>
                {
                    first.Id,
                    second.Id,
                },
                    queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
            Assert.AreEqual(first, results.First());
            Assert.AreEqual(second, results.Last());
        }

        /// <summary>
        /// Can get entities by id async is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetEntitiesByIdAsync_IsCorrect()
        {
            var first = new TestEntity();
            var second = new TestEntity();
            var third = new TestEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestEntity> { first, second, third });
            }

            List<TestEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetEntitiesByIdAsync(new List<Guid>
                {
                    first.Id,
                    second.Id,
                });
            }

            Assert.AreEqual(2, results.Count);
            Assert.AreEqual(first, results.First());
            Assert.AreEqual(second, results.Last());
        }

        /// <summary>
        /// Can get entities by id async with include func is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetEntitiesByIdAsyncWithIncludeFunc_IsCorrect()
        {
            var first = new TestEntity { Relationship = new TestRelationship() };
            var second = new TestEntity { Relationship = new TestRelationship() };
            var third = new TestEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestEntity> { first, second, third });
            }

            List<TestEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetEntitiesByIdAsync(
                    new List<Guid>
                    {
                        first.Id,
                        second.Id,
                    },
                    queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
            Assert.AreEqual(first, results.First());
            Assert.AreEqual(second, results.Last());
        }
    }
}
