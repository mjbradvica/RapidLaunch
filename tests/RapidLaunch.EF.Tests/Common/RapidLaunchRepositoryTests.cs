// <copyright file="RapidLaunchRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;
using RapidLaunch.EF.GuidPrimary;
using RapidLaunch.EF.Tests.GuidPrimary;
using RapidLaunch.EF.Tests.Helpers;
using RapidLaunch.GuidPrimary;
using System.Linq.Expressions;

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
        public void RepoWithDefaultIncludeIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity { Relationship = new TestRelationship() }, new TestGuidEntity { Relationship = new TestRelationship() } });
            }

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var result = repo.GetAllRoots();

                Assert.HasCount(2, result);
                Assert.IsTrue(result.All(root => root.Relationship != null));
            }
        }

        /// <summary>
        /// Can add roots correctly.
        /// </summary>
        [TestMethod]
        public void AddEntitiesIsCorrect()
        {
            var roots = new List<TestGuidEntity>
            {
                new TestGuidEntity(),
                new TestGuidEntity(),
            };

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(roots);
            }

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var result = repo.GetAllRoots();

                Assert.HasCount(roots.Count, result);
            }
        }

        /// <summary>
        /// Can add roots async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AddEntitiesAsyncIsCorrect()
        {
            var roots = new List<TestGuidEntity>
            {
                new TestGuidEntity(),
                new TestGuidEntity(),
            };

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(roots, CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var result = await repo.GetAllRootsAsync(CancellationToken.None);

                Assert.HasCount(roots.Count, result);
            }
        }

        /// <summary>
        /// Can add an root correctly.
        /// </summary>
        [TestMethod]
        public void AddEntityIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoot(new TestGuidEntity());
            }

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var result = repo.GetAllRoots();

                Assert.HasCount(1, result);
            }
        }

        /// <summary>
        /// Can add a root async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task AddEntityAsyncIsCorrect()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootAsync(new TestGuidEntity(), CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var result = await repo.GetAllRootsAsync(CancellationToken.None);

                Assert.HasCount(1, result);
            }
        }

        /// <summary>
        /// Can delete roots is correct.
        /// </summary>
        [TestMethod]
        public void DeleteEntitiesIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var roots = repo.GetAllRoots();

                repo.DeleteRoots(roots);
            }

            List<TestGuidEntity> result;

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                result = repo.GetAllRoots();
            }

            Assert.IsEmpty(result);
        }

        /// <summary>
        /// Can delete roots is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DeleteEntitiesAsyncIsCorrect()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() }, CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var roots = await repo.GetAllRootsAsync(CancellationToken.None);

                await repo.DeleteRootsAsync(roots, CancellationToken.None);
            }

            List<TestGuidEntity> result;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                result = await repo.GetAllRootsAsync(CancellationToken.None);
            }

            Assert.IsEmpty(result);
        }

        /// <summary>
        /// Can delete an root correctly.
        /// </summary>
        [TestMethod]
        public void DeleteEntityIsCorrect()
        {
            var root = new TestGuidEntity();

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoot(root);
            }

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var toDelete = repo.GetRootById(root.Id);

                if (toDelete != null)
                {
                    repo.DeleteRoot(toDelete);
                }
            }

            List<TestGuidEntity> result;

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                result = repo.GetAllRoots();
            }

            Assert.IsEmpty(result);
        }

        /// <summary>
        /// Can delete an root async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task DeleteEntityAsyncIsCorrect()
        {
            var root = new TestGuidEntity();

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootAsync(root, CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var toDelete = await repo.GetRootByIdAsync(root.Id, CancellationToken.None);

                if (toDelete != null)
                {
                    await repo.DeleteRootAsync(toDelete, CancellationToken.None);
                }
            }

            List<TestGuidEntity> result;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                result = await repo.GetAllRootsAsync(CancellationToken.None);
            }

            Assert.IsEmpty(result);
        }

        /// <summary>
        /// Can get all roots correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = repo.GetAllRoots();
            }

            Assert.HasCount(2, results);
        }

        /// <summary>
        /// Can get all roots with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesWithIncludeFuncIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() }, new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = repo.GetAllEntities(queryable => queryable.Include(root => root.Relationship));
            }

            Assert.HasCount(2, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }

        /// <summary>
        /// Can get all roots async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetAllEntitiesAsyncIsCorrect()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() }, CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllRootsAsync(CancellationToken.None);
            }

            Assert.HasCount(2, results);
        }

        /// <summary>
        /// Can get all roots async with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetAllEntitiesWithIncludeFuncAsyncIsCorrect()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(
                    new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() }, new TestGuidEntity { Relationship = new TestRelationship() },
                },
                    CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllEntitiesAsync(queryable => queryable.Include(root => root.Relationship), CancellationToken.None);
            }

            Assert.HasCount(2, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }

        /// <summary>
        /// Can get roots lazy correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesLazyIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { new TestGuidEntity(), new TestGuidEntity() });
            }

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.GetAllRootsLazy();

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);

                var asList = results.ToList();

                Assert.HasCount(2, asList);
            }
        }

        /// <summary>
        /// Can get roots lazy with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetAllEntitiesLazyWithIncludeFuncIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                IEnumerable<TestGuidEntity> results = repo.GetAllEntitiesLazy(queryable => queryable.Include(root => root.Relationship));

                Assert.IsInstanceOfType<IQueryable<TestGuidEntity>>(results);

                var asList = results.ToList();

                Assert.IsTrue(asList.All(root => root.Relationship != null));
                Assert.HasCount(2, asList);
            }
        }

        /// <summary>
        /// Can get by id correctly.
        /// </summary>
        [TestMethod]
        public void GetByIdIsCorrect()
        {
            var root = new TestGuidEntity();
            var incorrect = new TestGuidEntity();

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { root, incorrect });
            }

            using (var context = new TestDbContext(ContextOptions))
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
        public void GetByIdWithIncludeFuncIsCorrect()
        {
            var root = new TestGuidEntity { Relationship = new TestRelationship() };
            var incorrect = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { root, incorrect });
            }

            using (var context = new TestDbContext(ContextOptions))
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
        public async Task GetByIdAsyncIsCorrectAsync()
        {
            var root = new TestGuidEntity();
            var incorrect = new TestGuidEntity();

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { root, incorrect }, CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var result = await repo.GetRootByIdAsync(root.Id, CancellationToken.None);

                Assert.AreEqual(root, result);
            }
        }

        /// <summary>
        /// Can get by id with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetByIdWithIncludeFuncAsyncIsCorrect()
        {
            var root = new TestGuidEntity { Relationship = new TestRelationship() };
            var incorrect = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { root, incorrect }, CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                var result = await repo.GetByIdAsync(root.Id, queryable => queryable.Include(testEntity => testEntity.Relationship), CancellationToken.None);

                Assert.AreEqual(root, result);
                Assert.IsNotNull(result?.Relationship);
            }
        }

        /// <summary>
        /// Can get roots by id correctly.
        /// </summary>
        [TestMethod]
        public void GetEntitiesByIdIsCorrect()
        {
            var first = new TestGuidEntity();
            var second = new TestGuidEntity();
            var third = new TestGuidEntity();

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = repo.GetRootsById(new List<Guid>
                {
                    first.Id,
                    second.Id,
                });
            }

            Assert.HasCount(2, results);
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can get roots by id with include func correctly.
        /// </summary>
        [TestMethod]
        public void GetEntitiesByIdWithIncludeFuncIsCorrect()
        {
            var first = new TestGuidEntity { Relationship = new TestRelationship() };
            var second = new TestGuidEntity { Relationship = new TestRelationship() };
            var third = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { first, second, third });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext(ContextOptions))
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

            Assert.HasCount(2, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can get roots by id async correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetEntitiesByIdAsyncIsCorrect()
        {
            var first = new TestGuidEntity();
            var second = new TestGuidEntity();
            var third = new TestGuidEntity();

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second, third }, CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = await repo.GetRootsByIdAsync(
                    new List<Guid>
                {
                    first.Id,
                    second.Id,
                },
                    CancellationToken.None);
            }

            Assert.HasCount(2, results);
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can get roots by id async with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task GetEntitiesByIdAsyncWithIncludeFuncIsCorrect()
        {
            var first = new TestGuidEntity { Relationship = new TestRelationship() };
            var second = new TestGuidEntity { Relationship = new TestRelationship() };
            var third = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second, third }, CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = await repo.GetEntitiesByIdAsync(
                    new List<Guid>
                    {
                        first.Id,
                        second.Id,
                    },
                    queryable => queryable.Include(root => root.Relationship),
                    CancellationToken.None);
            }

            Assert.HasCount(2, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
            Assert.IsTrue(results.Any(root => root.Id == first.Id));
            Assert.IsTrue(results.Any(root => root.Id == second.Id));
        }

        /// <summary>
        /// Can search roots correctly.
        /// </summary>
        [TestMethod]
        public void SearchEntitiesIsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
            };

            var second = new TestGuidEntity();

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext(ContextOptions))
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
        public void SearchEntitiesWithIncludeFuncIsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
                Relationship = new TestRelationship(),
            };

            var second = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { first, second });
            }

            List<TestGuidEntity> results;

            using (var context = new TestDbContext(ContextOptions))
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
        public async Task SearchEntitiesAsyncIsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
            };

            var second = new TestGuidEntity();

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second }, CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = await repo.SearchRootsAsync(new TestQuery(), CancellationToken.None);
            }

            Assert.AreEqual(first, results.Single());
        }

        /// <summary>
        /// Can search roots async with include func correctly.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task SearchEntitiesAsyncWithIncludeFuncIsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
                Relationship = new TestRelationship(),
            };

            var second = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                await repo.AddRootsAsync(new List<TestGuidEntity> { first, second }, CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = await repo.SearchEntitiesAsync(new TestQuery(), queryable => queryable.Include(root => root.Relationship), CancellationToken.None);
            }

            Assert.AreEqual(first, results.Single());
            Assert.IsNotNull(results.Single().Relationship);
        }

        /// <summary>
        /// Can search roots lazy correctly.
        /// </summary>
        [TestMethod]
        public void SearchEntitiesLazyIsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
            };

            var second = new TestGuidEntity();

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { first, second });
            }

            using (var context = new TestDbContext(ContextOptions))
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
        public void SearchEntitiesLazyWithIncludeFuncIsCorrect()
        {
            var first = new TestGuidEntity
            {
                Id = Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af"),
                Relationship = new TestRelationship(),
            };

            var second = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                repo.AddRoots(new List<TestGuidEntity> { first, second });
            }

            using (var context = new TestDbContext(ContextOptions))
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
        public void UpdateEntitiesIsCorrect()
        {
            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                repo.AddRoots(new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                });
            }

            using (var context = new TestDbContext(ContextOptions))
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

            using (var context = new TestDbContext(ContextOptions))
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
        public async Task UpdateEntitiesAsyncIsCorrect()
        {
            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                await repo.AddRootsAsync(
                    new List<TestGuidEntity>
                {
                    new TestGuidEntity { Relationship = new TestRelationship() },
                    new TestGuidEntity { Relationship = new TestRelationship() },
                },
                    CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var roots = await repo.GetAllRootsAsync(CancellationToken.None);

                foreach (var root in roots)
                {
                    root.Relationship = null;
                }

                await repo.UpdateRootsAsync(roots, CancellationToken.None);
            }

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                results = await repo.GetAllRootsAsync(CancellationToken.None);
            }

            Assert.IsTrue(results.All(root => root.Relationship == null));
        }

        /// <summary>
        /// Can update root correctly.
        /// </summary>
        [TestMethod]
        public void UpdateEntityIsCorrect()
        {
            var testEntity = new TestGuidEntity { Relationship = new TestRelationship() };

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                repo.AddRoot(testEntity);
            }

            using (var context = new TestDbContext(ContextOptions))
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

            using (var context = new TestDbContext(ContextOptions))
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
        public async Task UpdateEntityAsyncIsCorrect()
        {
            var testEntity = new TestGuidEntity { Relationship = new TestRelationship() };

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                await repo.AddRootAsync(testEntity, CancellationToken.None);
            }

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                var root = await repo.GetRootByIdAsync(testEntity.Id, CancellationToken.None);

                if (root != null)
                {
                    root.Relationship = null;

                    await repo.UpdateRootAsync(root, CancellationToken.None);
                }
            }

            TestGuidEntity? result;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context, queryable => queryable.Include(root => root.Relationship));

                result = await repo.GetRootByIdAsync(testEntity.Id, CancellationToken.None);
            }

            Assert.IsNull(result?.Relationship);
        }

        /// <summary>
        /// Exception handling is correct.
        /// </summary>
        [TestMethod]
        public void ExecuteCommandOnExceptionIsCorrect()
        {
            RapidLaunchStatus status;

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                status = repo.TestExceptionHandler(new TestGuidEntity());
            }

            Assert.IsTrue(status.IsFailure);

            List<TestGuidEntity> results;

            using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = repo.GetAllRoots();
            }

            Assert.IsEmpty(results);
        }

        /// <summary>
        /// Exception handling async is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous unit test.</returns>
        [TestMethod]
        public async Task ExecuteCommandAsyncOnExceptionIsCorrect()
        {
            RapidLaunchStatus status;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                status = await repo.TestExceptionHandlerAsync(new TestGuidEntity());
            }

            Assert.IsTrue(status.IsFailure);

            List<TestGuidEntity> results;

            await using (var context = new TestDbContext(ContextOptions))
            {
                var repo = new TestRepository(context);

                results = await repo.GetAllRootsAsync(CancellationToken.None);
            }

            Assert.IsEmpty(results);
        }

        /// <summary>
        /// Test query.
        /// </summary>
        private sealed class TestQuery : IQuery<TestGuidEntity>
        {
            /// <inheritdoc/>
            public Expression<Func<TestGuidEntity, bool>> SearchExpression => root => root.Id == Guid.Parse("75b974db-5203-49ed-9fb6-d066e71973af");
        }
    }
}
