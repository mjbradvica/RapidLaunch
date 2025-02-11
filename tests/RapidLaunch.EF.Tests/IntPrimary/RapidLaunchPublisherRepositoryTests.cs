// <copyright file="RapidLaunchPublisherRepositoryTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RapidLaunch.Common;
using RapidLaunch.EF.IntPrimary;
using RapidLaunch.EF.Tests.Helpers;

namespace RapidLaunch.EF.Tests.IntPrimary
{
	/// <summary>
	/// Tests for the <see cref="RapidLaunchPublisherRepository{TEntity}"/> class.
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

            _publisher = new RapidLaunchPublisher(collection.BuildServiceProvider());
        }

        /// <summary>
        /// Default constructor is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task DefaultConstructor_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntPublisherTestRepository(context, _publisher);

                await repo.AddEntityAsync(new TestIntEntity());
            }

            List<TestIntEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntPublisherTestRepository(context, _publisher);

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(1, results.Count);
        }

        /// <summary>
        /// Include constructor is correct.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        [TestMethod]
        public async Task IncludeConstructor_IsCorrect()
        {
            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntPublisherTestRepository(context, _publisher, queryable => queryable.Include(entity => entity.Relationship));

                await repo.AddEntityAsync(new TestIntEntity { Relationship = new TestRelationship() });
            }

            List<TestIntEntity> results;

            await using (var context = new TestDbContext())
            {
                var repo = new RapidLaunchIntPublisherTestRepository(context, _publisher, queryable => queryable.Include(entity => entity.Relationship));

                results = await repo.GetAllEntitiesAsync();
            }

            Assert.AreEqual(1, results.Count);
            Assert.IsTrue(results.All(entity => entity.Relationship != null));
        }
    }
}
