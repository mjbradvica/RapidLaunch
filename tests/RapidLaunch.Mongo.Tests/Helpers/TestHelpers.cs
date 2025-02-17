// <copyright file="TestHelpers.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MongoDB.Driver;
using RapidLaunch.Mongo.Tests.GuidPrimary;

namespace RapidLaunch.Mongo.Tests.Helpers
{
    /// <summary>
    /// Test helpers for mongo.
    /// </summary>
    public static class TestHelpers
    {
        /// <summary>
        /// Gets the Mongo connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string MongoConnectionString()
        {
            return "mongodb+srv://mjbradvica:82M5CPj70S6jUL3g@cluster0.anhunbz.mongodb.net/";
        }

        /// <summary>
        /// Clears all database entries.
        /// </summary>
        public static void ClearDatabase()
        {
            var client = new MongoClient(MongoConnectionString());

            client.GetDatabase("rapid_launch").GetCollection<TestGuidEntity>(nameof(TestGuidEntity))
                .DeleteMany(Builders<TestGuidEntity>.Filter.Empty);
        }
    }
}
