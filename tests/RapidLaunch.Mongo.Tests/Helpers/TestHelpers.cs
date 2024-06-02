// <copyright file="TestHelpers.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

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
            return "mongodb://localhost:27017";
        }
    }
}
