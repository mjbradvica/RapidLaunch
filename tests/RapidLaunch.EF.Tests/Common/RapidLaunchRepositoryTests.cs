﻿// <copyright file="RapidLaunchRepositoryTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidLaunch.Common;
using RapidLaunch.EF.GuidPrimary;
using RapidLaunch.EF.Tests.GuidPrimary;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchRepository{TEntity}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchRepositoryTests : BaseIntegrationTest
    {
        /// <summary>
        /// Can query with default include statement correctly.
        /// </summary>
        [TestMethod]
        public void Repo_WithDefaultInclude_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { new TestGuidEntity { Relationship = new TestRelationship() }, new TestGuidEntity { Relationship = new TestRelationship() } });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var result = repo.GetAllEntities();

                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.All(entity => entity.Relationship != null));
            }
        }

        /// <summary>
        /// Can add entities correctly.
        /// </summary>
        [TestMethod]
        public void AddEntities_IsCorrect()
        {
            var entities = new List<TestGuidEntity>
            {
                new TestGuidEntity(),
                new TestGuidEntity(),
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
            var entities = new List<TestGuidEntity>
            {
                new TestGuidEntity(),
                new TestGuidEntity(),
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

                repo.AddEntity(new TestGuidEntity());
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

                await repo.AddEntityAsync(new TestGuidEntity());
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

                repo.AddEntities(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var entities = repo.GetAllEntities();

                repo.DeleteEntities(entities);
            }

            List<TestGuidEntity> result;

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

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var entities = await repo.GetAllEntitiesAsync();

                await repo.DeleteEntitiesAsync(entities);
            }

            List<TestGuidEntity> result;

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
            var entity = new TestGuidEntity();

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

            List<TestGuidEntity> result;

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
            var entity = new TestGuidEntity();

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

            List<TestGuidEntity> result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Can get all entities correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntities_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetAllEntities();
            }

            Assert.AreEqual(2, results.Count);
        }

        /// <summary>
        /// Can get all entities with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesWithIncludeFunc_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() }, new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetAllEntities(queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
        }

        /// <summary>
        /// Can get all entities async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetAllEntitiesAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(2, results.Count);
        }

        /// <summary>
        /// Can get all entities async with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetAllEntitiesWithIncludeFuncAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() }, new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllEntitiesAsync(queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
        }

        /// <summary>
        /// Can get entities lazy correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesLazy_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.GetAllEntitiesLazy();

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);

                var asList = results.ToList();

                Assert.AreEqual(2, asList.Count);
            }
        }

        /// <summary>
        /// Can get entities lazy with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesLazyWithIncludeFunc_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.GetAllEntitiesLazy(queryable => queryable.Include(entity => entity.Relationship));

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);

                var asList = results.ToList();

                Assert.IsTrue(asList.All(entity => entity.Relationship != null));
                Assert.AreEqual(2, asList.Count);
            }
        }

        /// <summary>
        /// Can get by id correctly.
        /// </summary>
        [TestMethod]
        public void GetById_IsCorrect()
        {
            var entity = new TestGuidEntity();
            var incorrect = new TestGuidEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { entity, incorrect });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetById(entity.Id);

                Assert.AreEqual(entity, result);
            }
        }

        /// <summary>
        /// Can get by id with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetByIdWithIncludeFunc_IsCorrect()
        {
            var entity = new TestGuidEntity { Relationship = new TestRelationship() };
            var incorrect = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { entity, incorrect });
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
        /// Can get by id async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetByIdAsync_IsCorrectAsync()
        {
            var entity = new TestGuidEntity();
            var incorrect = new TestGuidEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { entity, incorrect });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetByIdAsync(entity.Id);

                Assert.AreEqual(entity, result);
            }
        }

        /// <summary>
        /// Can get by id with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetByIdWithIncludeFuncAsync_IsCorrect()
        {
            var entity = new TestGuidEntity { Relationship = new TestRelationship() };
            var incorrect = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { entity, incorrect });
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
        /// Can get entities by id correctly.
        /// </summary>
        [TestMethod]
        public void GetEntitiesById_IsCorrect()
        {
            var first = new TestGuidEntity();
            var second = new TestGuidEntity();
            var third = new TestGuidEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

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
            Assert.IsTrue(results.Any(entity => entity.Id == first.Id));
            Assert.IsTrue(results.Any(entity => entity.Id == second.Id));
        }

        /// <summary>
        /// Can get entities by id with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetEntitiesByIdWithIncludeFunc_IsCorrect()
        {
            var first = new TestGuidEntity { Relationship = new TestRelationship() };
            var second = new TestGuidEntity { Relationship = new TestRelationship() };
            var third = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

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
            Assert.IsTrue(results.Any(entity => entity.Id == first.Id));
            Assert.IsTrue(results.Any(entity => entity.Id == second.Id));
        }

        /// <summary>
        /// Can get entities by id async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetEntitiesByIdAsync_IsCorrect()
        {
            var first = new TestGuidEntity();
            var second = new TestGuidEntity();
            var third = new TestGuidEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

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
            Assert.IsTrue(results.Any(entity => entity.Id == first.Id));
            Assert.IsTrue(results.Any(entity => entity.Id == second.Id));
        }

        /// <summary>
        /// Can get entities by id async with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetEntitiesByIdAsyncWithIncludeFunc_IsCorrect()
        {
            var first = new TestGuidEntity { Relationship = new TestRelationship() };
            var second = new TestGuidEntity { Relationship = new TestRelationship() };
            var third = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

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
            Assert.IsTrue(results.Any(entity => entity.Id == first.Id));
            Assert.IsTrue(results.Any(entity => entity.Id == second.Id));
        }

        /// <summary>
        /// Can search entities correctly.
        /// </summary>
        [TestMethod]
        public void SearchEntities_IsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
            };

            var second = new TestGuidEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.SearchEntities(new TestQuery());
            }

            Assert.AreEqual(first, results.Single());
        }

        /// <summary>
        /// Can search entities with include func correctly.
        /// </summary>
        [TestMethod]
        public void SearchEntitiesWithIncludeFunc_IsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
                Relationship = new TestRelationship(),
            };

            var second = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.SearchEntities(new TestQuery(), queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(first, results.Single());
            Assert.IsNotNull(results.Single().Relationship);
        }

        /// <summary>
        /// Can search entities async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task SearchEntitiesAsync_IsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
            };

            var second = new TestGuidEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.SearchEntitiesAsync(new TestQuery());
            }

            Assert.AreEqual(first, results.Single());
        }

        /// <summary>
        /// Can search entities async with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task SearchEntitiesAsyncWithIncludeFunc_IsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
                Relationship = new TestRelationship(),
            };

            var second = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddEntitiesAsync(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.SearchEntitiesAsync(new TestQuery(), queryable => queryable.Include(entity => entity.Relationship));
            }

            Assert.AreEqual(first, results.Single());
            Assert.IsNotNull(results.Single().Relationship);
        }

        /// <summary>
        /// Can search entities lazy correctly.
        /// </summary>
        [TestMethod]
        public void SearchEntitiesLazy_IsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
            };

            var second = new TestGuidEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { first, second });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.SearchEntitiesLazy(new TestQuery());

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);

                Assert.AreEqual(first, results.Single());
            }
        }

        /// <summary>
        /// Can search entities lazy with include func correctly.
        /// </summary>
        [TestMethod]
        public void SearchEntitiesLazyWithIncludeFunc_IsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
                Relationship = new TestRelationship(),
            };

            var second = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddEntities(new List<TestGuidEntity> { first, second });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.SearchEntitiesLazy(new TestQuery(), queryable => queryable.Include(entity => entity.Relationship));

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);
                Assert.AreEqual(first, results.Single());
                Assert.IsNotNull(results.Single().Relationship);
            }
        }

        /// <summary>
        /// Can update entities correctly.
        /// </summary>
        [TestMethod]
        public void UpdateEntities_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                repo.AddEntities(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entities = repo.GetAllEntities();

                foreach (var entity in entities)
                {
                    entity.Relationship = null;
                }

                repo.UpdateEntities(entities);
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                results = repo.GetAllEntities();
            }

            Assert.IsTrue(results.All(entity => entity.Relationship == null));
        }

        /// <summary>
        /// Can update entities async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UpdateEntitiesAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                await repo.AddEntitiesAsync(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entities = await repo.GetAllEntitiesAsync();

                foreach (var entity in entities)
                {
                    entity.Relationship = null;
                }

                await repo.UpdateEntitiesAsync(entities);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.IsTrue(results.All(entity => entity.Relationship == null));
        }

        /// <summary>
        /// Can update entity correctly.
        /// </summary>
        [TestMethod]
        public void UpdateEntity_IsCorrect()
        {
            var testEntity = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                repo.AddEntity(testEntity);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entity = repo.GetById(testEntity.Id);

                if (entity != null)
                {
                    entity.Relationship = null;

                    repo.UpdateEntity(entity);
                }
            }

            TestGuidEntity? result;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                result = repo.GetById(testEntity.Id);
            }

            Assert.IsNull(result?.Relationship);
        }

        /// <summary>
        /// Can update entity async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UpdateEntityAsync_IsCorrect()
        {
            var testEntity = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                await repo.AddEntityAsync(testEntity);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entity = await repo.GetByIdAsync(testEntity.Id);

                if (entity != null)
                {
                    entity.Relationship = null;

                    await repo.UpdateEntityAsync(entity);
                }
            }

            TestGuidEntity? result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                result = await repo.GetByIdAsync(testEntity.Id);
            }

            Assert.IsNull(result?.Relationship);
        }

        /// <summary>
        /// Exception handling is correct.
        /// </summary>
        [TestMethod]
        public void ExecuteCommand_OnException_IsCorrect()
        {
            RapidLaunchStatus status;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                status = repo.TestExceptionHandler(new TestGuidEntity());
            }

            Assert.IsTrue(status.IsFailure);

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetAllEntities();
            }

            Assert.AreEqual(0, results.Count);
        }

        /// <summary>
        /// Exception handling async is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteCommandAsync_OnException_IsCorrect()
        {
            RapidLaunchStatus status;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                status = await repo.TestExceptionHandlerAsync(new TestGuidEntity());
            }

            Assert.IsTrue(status.IsFailure);

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(0, results.Count);
        }

        /// <summary>
        /// Test query.
        /// </summary>
        internal class TestQuery : IQuery<TestGuidEntity>
        {
            /// <inheritdoc/>
            public Expression<Func<TestGuidEntity, bool>> SearchExpression => entity => entity.Id == Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af");
        }
    }
}
