// <copyright file="RapidLaunchRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
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

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity { Relationship = new TestRelationship() }, new TestGuidEntity { Relationship = new TestRelationship() } });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var result = repo.GetAllRoots();

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

                repo.AddRoots(entities);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetAllRoots();

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

                await repo.AddRootsAsync(entities);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetAllRootsAsync();

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

                repo.AddRoot(new TestGuidEntity());
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetAllRoots();

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

                await repo.AddRootAsync(new TestGuidEntity());
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetAllRootsAsync();

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

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var entities = repo.GetAllRoots();

                repo.DeleteRoots(entities);
            }

            List<TestGuidEntity> result;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = repo.GetAllRoots();
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

                await repo.AddRootsAsync(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var entities = await repo.GetAllRootsAsync();

                await repo.DeleteRootsAsync(entities);
            }

            List<TestGuidEntity> result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = await repo.GetAllRootsAsync();
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

                repo.AddRoot(entity);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var toDelete = repo.GetById(entity.Id);

                if (toDelete != null)
                {
                    repo.DeleteRoot(toDelete);
                }
            }

            List<TestGuidEntity> result;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = repo.GetAllRoots();
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

                await repo.AddRootAsync(entity);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var toDelete = await repo.GetRootByIdAsync(entity.Id);

                if (toDelete != null)
                {
                    await repo.DeleteRootAsync(toDelete);
                }
            }

            List<TestGuidEntity> result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                result = await repo.GetAllRootsAsync();
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

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetAllRoots();
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

                repo.AddRoots(new List<TestGuidEntity>
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

                await repo.AddRootsAsync(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllRootsAsync();
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

                await repo.AddRootsAsync(new List<TestGuidEntity>
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

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.GetAllRootsLazy();

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

                repo.AddRoots(new List<TestGuidEntity>
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

                repo.AddRoots(new List<TestGuidEntity> { entity, incorrect });
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

                repo.AddRoots(new List<TestGuidEntity> { entity, incorrect });
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

                await repo.AddRootsAsync(new List<TestGuidEntity> { entity, incorrect });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetRootByIdAsync(entity.Id);

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

                await repo.AddRootsAsync(new List<TestGuidEntity> { entity, incorrect });
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

                repo.AddRoots(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.GetRootsById(new List<Guid>
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

                repo.AddRoots(new List<TestGuidEntity> { first, second, third });
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

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.GetRootsByIdAsync(new List<Guid>
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

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second, third });
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

                repo.AddRoots(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = repo.SearchRoots(new TestQuery());
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

                repo.AddRoots(new List<TestGuidEntity> { first, second });
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

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                results = await repo.SearchRootsAsync(new TestQuery());
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

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second });
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

                repo.AddRoots(new List<TestGuidEntity> { first, second });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.SearchRootsLazy(new TestQuery());

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

                repo.AddRoots(new List<TestGuidEntity> { first, second });
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

                repo.AddRoots(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entities = repo.GetAllRoots();

                foreach (var entity in entities)
                {
                    entity.Relationship = null;
                }

                repo.UpdateRoots(entities);
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                results = repo.GetAllRoots();
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

                await repo.AddRootsAsync(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entities = await repo.GetAllRootsAsync();

                foreach (var entity in entities)
                {
                    entity.Relationship = null;
                }

                await repo.UpdateRootsAsync(entities);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                results = await repo.GetAllRootsAsync();
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

                repo.AddRoot(testEntity);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entity = repo.GetById(testEntity.Id);

                if (entity != null)
                {
                    entity.Relationship = null;

                    repo.UpdateRoot(entity);
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

                await repo.AddRootAsync(testEntity);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                var entity = await repo.GetRootByIdAsync(testEntity.Id);

                if (entity != null)
                {
                    entity.Relationship = null;

                    await repo.UpdateRootAsync(entity);
                }
            }

            TestGuidEntity? result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(entity => entity.Relationship));

                result = await repo.GetRootByIdAsync(testEntity.Id);
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

                results = repo.GetAllRoots();
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

                results = await repo.GetAllRootsAsync();
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
