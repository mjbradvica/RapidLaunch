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
using RapidLaunch.GuidPrimary;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchRepository{TRoot}"/> class.
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
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var result = repo.GetAllRoots();

                Assert.AreEqual(2, result.Count);
                Assert.IsTrue(result.All(root => root.Relationship != null));
            }
        }

        /// <summary>
        /// Can add roots correctly.
        /// </summary>
        [TestMethod]
        public void AddEntities_IsCorrect()
        {
            var roots = new List<TestGuidEntity>
            {
                new TestGuidEntity(),
                new TestGuidEntity(),
            };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddRoots(roots);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetAllRoots();

                Assert.AreEqual(roots.Count, result.Count);
            }
        }

        /// <summary>
        /// Can add roots async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AddEntitiesAsync_IsCorrect()
        {
            var roots = new List<TestGuidEntity>
            {
                new TestGuidEntity(),
                new TestGuidEntity(),
            };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(roots);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetAllRootsAsync();

                Assert.AreEqual(roots.Count, result.Count);
            }
        }

        /// <summary>
        /// Can add an root correctly.
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
        /// Can add an root async correctly.
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
        /// Can delete roots is correct.
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

                var roots = repo.GetAllRoots();

                repo.DeleteRoots(roots);
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
        /// Can delete roots is correct.
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

                var roots = await repo.GetAllRootsAsync();

                await repo.DeleteRootsAsync(roots);
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
        /// Can delete an root correctly.
        /// </summary>
        [TestMethod]
        public void DeleteEntity_IsCorrect()
        {
            var root = new TestGuidEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddRoot(root);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var toDelete = repo.GetRootById(root.Id);

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
        /// Can delete an root async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DeleteEntityAsync_IsCorrect()
        {
            var root = new TestGuidEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddRootAsync(root);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var toDelete = await repo.GetRootByIdAsync(root.Id);

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
        /// Can get all roots correctly.
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
        /// Can get all roots with include func correctly.
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

                results = repo.GetAllEntities(queryable => queryable.Include(root => root.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }

        /// <summary>
        /// Can get all roots async correctly.
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
        /// Can get all roots async with include func correctly.
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

                results = await repo.GetAllEntitiesAsync(queryable => queryable.Include(root => root.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }

        /// <summary>
        /// Can get roots lazy correctly.
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
        /// Can get roots lazy with include func correctly.
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

                IEnumerable<TestGuidEntity> results = repo.GetAllEntitiesLazy(queryable => queryable.Include(root => root.Relationship));

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);

                var asList = results.ToList();

                Assert.IsTrue(asList.All(root => root.Relationship != null));
                Assert.AreEqual(2, asList.Count);
            }
        }

        /// <summary>
        /// Can get by id correctly.
        /// </summary>
        [TestMethod]
        public void GetById_IsCorrect()
        {
            var root = new TestGuidEntity();
            var incorrect = new TestGuidEntity();

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { root, incorrect });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetRootById(root.Id);

                Assert.AreEqual(root, result);
            }
        }

        /// <summary>
        /// Can get by id with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetByIdWithIncludeFunc_IsCorrect()
        {
            var root = new TestGuidEntity { Relationship = new TestRelationship() };
            var incorrect = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { root, incorrect });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = repo.GetById(root.Id, queryable => queryable.Include(testEntity => testEntity.Relationship));

                Assert.AreEqual(root, result);
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
            var root = new TestGuidEntity();
            var incorrect = new TestGuidEntity();

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { root, incorrect });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetRootByIdAsync(root.Id);

                Assert.AreEqual(root, result);
            }
        }

        /// <summary>
        /// Can get by id with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetByIdWithIncludeFuncAsync_IsCorrect()
        {
            var root = new TestGuidEntity { Relationship = new TestRelationship() };
            var incorrect = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { root, incorrect });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context);

                var result = await repo.GetByIdAsync(root.Id, queryable => queryable.Include(testEntity => testEntity.Relationship));

                Assert.AreEqual(root, result);
                Assert.IsNotNull(result?.Relationship);
            }
        }

        /// <summary>
        /// Can get roots by id correctly.
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
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can get roots by id with include func correctly.
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
                    queryable => queryable.Include(root => root.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(root => root.Relationship != null));
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can get roots by id async correctly.
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
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can get roots by id async with include func correctly.
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
                    queryable => queryable.Include(root => root.Relationship));
            }

            Assert.AreEqual(2, results.Count);
            Assert.IsTrue(results.All(root => root.Relationship != null));
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can search roots correctly.
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
        /// Can search roots with include func correctly.
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

                results = repo.SearchEntities(new TestQuery(), queryable => queryable.Include(root => root.Relationship));
            }

            Assert.AreEqual(first, results.Single());
            Assert.IsNotNull(results.Single().Relationship);
        }

        /// <summary>
        /// Can search roots async correctly.
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
        /// Can search roots async with include func correctly.
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

                results = await repo.SearchEntitiesAsync(new TestQuery(), queryable => queryable.Include(root => root.Relationship));
            }

            Assert.AreEqual(first, results.Single());
            Assert.IsNotNull(results.Single().Relationship);
        }

        /// <summary>
        /// Can search roots lazy correctly.
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
        /// Can search roots lazy with include func correctly.
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

                IEnumerable<TestGuidEntity> results = repo.SearchEntitiesLazy(new TestQuery(), queryable => queryable.Include(root => root.Relationship));

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);
                Assert.AreEqual(first, results.Single());
                Assert.IsNotNull(results.Single().Relationship);
            }
        }

        /// <summary>
        /// Can update roots correctly.
        /// </summary>
        [TestMethod]
        public void UpdateEntities_IsCorrect()
        {
            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                repo.AddRoots(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var roots = repo.GetAllRoots();

                foreach (var root in roots)
                {
                    root.Relationship = null;
                }

                repo.UpdateRoots(roots);
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                results = repo.GetAllRoots();
            }

            Assert.IsTrue(results.All(root => root.Relationship == null));
        }

        /// <summary>
        /// Can update roots async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UpdateEntitiesAsync_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                await repo.AddRootsAsync(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var roots = await repo.GetAllRootsAsync();

                foreach (var root in roots)
                {
                    root.Relationship = null;
                }

                await repo.UpdateRootsAsync(roots);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                results = await repo.GetAllRootsAsync();
            }

            Assert.IsTrue(results.All(root => root.Relationship == null));
        }

        /// <summary>
        /// Can update root correctly.
        /// </summary>
        [TestMethod]
        public void UpdateEntity_IsCorrect()
        {
            var testEntity = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                repo.AddRoot(testEntity);
            }

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var root = repo.GetRootById(testEntity.Id);

                if (root != null)
                {
                    root.Relationship = null;

                    repo.UpdateRoot(root);
                }
            }

            TestGuidEntity? result;

            using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                result = repo.GetRootById(testEntity.Id);
            }

            Assert.IsNull(result?.Relationship);
        }

        /// <summary>
        /// Can update root async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task UpdateEntityAsync_IsCorrect()
        {
            var testEntity = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                await repo.AddRootAsync(testEntity);
            }

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var root = await repo.GetRootByIdAsync(testEntity.Id);

                if (root != null)
                {
                    root.Relationship = null;

                    await repo.UpdateRootAsync(root);
                }
            }

            TestGuidEntity? result;

            await using (var context = new TestDbContext())
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

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
        private class TestQuery : IQuery<TestGuidEntity>
        {
            /// <inheritdoc/>
            public Expression<Func<TestGuidEntity, bool>> SearchExpression => root => root.Id == Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af");
        }
    }
}
