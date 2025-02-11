﻿// <copyright file="RapidLaunchRepositoryTests.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Collections.Generic;
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

            _repository.AddEntities(entities);

            var result = _repository.GetAllEntities();

            Assert.AreEqual(entities.Count, result.Count);
        }
    }
}
