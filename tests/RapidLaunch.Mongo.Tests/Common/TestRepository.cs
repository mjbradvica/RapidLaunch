// <copyright file="TestRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MongoDB.Driver;
using RapidLaunch.Mongo.Common;
using RapidLaunch.Mongo.Tests.GuidPrimary;

namespace RapidLaunch.Mongo.Tests.Common
{
    /// <inheritdoc />
    public class TestRepository : RapidLaunchRepository<TestGuidEntity, Guid>
    {
        /// <inheritdoc />
        public TestRepository(MongoClient mongoClient, string databaseName, string? collectionName = null, bool useTransactions = true)
            : base(mongoClient, databaseName, collectionName, useTransactions)
        {
        }
    }
}
