// <copyright file="RapidLaunchRepositoryTests.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using RapidLaunch.Mongo.Common;
using RapidLaunch.Mongo.Tests.GuidPrimary;
using RapidLaunch.Mongo.Tests.Helpers;

namespace RapidLaunch.Mongo.Tests.Common
{
    /// <summary>
    /// Tests for the <see cref="RapidLaunchRepository{TEntity,TId}"/> class.
    /// </summary>
    [TestClass]
    public class RapidLaunchRepositoryTests : BaseIntegrationTest
    {
        private readonly TestRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchRepositoryTests"/> class.
        /// </summary>
        public RapidLaunchRepositoryTests()
        {
            var client = new MongoClient(TestHelpers.MongoConnectionString());
            _repository = new TestRepository(client, "rapid_launch", nameof(TestGuidEntity));
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

            _repository.AddRoots(entities);

            var result = _repository.GetAllEntities();

            Assert.AreEqual(entities.Count, result.Count);
        }
    }
}
