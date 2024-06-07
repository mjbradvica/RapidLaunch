// <copyright file="TestRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
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
