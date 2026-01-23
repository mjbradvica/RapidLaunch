// <copyright file="RapidLaunchPublisherRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NMediation.Abstractions;
using NMediation.Dependencies;
using RapidLaunch.Common;
using RapidLaunch.EF.LongPrimary;
using RapidLaunch.EF.Tests.Helpers;
using System.Reflection;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchPublisherRepository{TRoot}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchPublisherRepositoryTests : BaseIntegrationTest
    {
        private readonly RapidLaunchPublisher _publisher;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepositoryTests"/> class.
        /// </summary>
        public RapidLaunchPublisherRepositoryTests()
        {
            var collection = new ServiceCollection();

            collection.AddNMediation(Assembly.GetExecutingAssembly());

            var provider = collection.BuildServiceProvider();

            var mediation = provider.GetRequiredService<IMediation>();

            _publisher = new RapidLaunchPublisher(mediation);
        }

        /// <summary>
        /// Default constructor is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task DefaultConstructorIsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongPublisherTestRepository(context, _publisher);

                await repo.AddRootAsync(new TestLongEntity());
            }

            List<TestLongEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongPublisherTestRepository(context, _publisher);

                results = await repo.GetAllRootsAsync();
            }

            Assert.HasCount(1, results);
        }

        /// <summary>
        /// Include constructor is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task IncludeConstructorIsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongPublisherTestRepository(context, _publisher, queryable => queryable.Include(root => root.Relationship));

                await repo.AddRootAsync(new TestLongEntity { Relationship = new TestRelationship() });
            }

            List<TestLongEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchLongPublisherTestRepository(context, _publisher, queryable => queryable.Include(root => root.Relationship));

                results = await repo.GetAllRootsAsync();
            }

            Assert.HasCount(1, results);
            Assert.IsTrue(results.All(root => root.Relationship != null));
        }
    }
}
