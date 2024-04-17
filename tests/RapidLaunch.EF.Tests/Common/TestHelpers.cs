// <copyright file="TestHelpers.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;

namespace RapidLaunch.EF.Tests.Common
{
    /// <summary>
    /// Utilities for tests.
    /// </summary>
    internal static class TestHelpers
    {
        /// <summary>
        /// Clears all test tables.
        /// </summary>
        public static void ClearDatabase()
        {
        }

        /// <summary>
        /// Gets the db connection string.
        /// </summary>
        /// <returns>The correct connection string.</returns>
        public static string ConnectionString()
        {
            return Environment.GetEnvironmentVariable("TEST_CONNECTION_STRING") ??
                   "Server=.\\SQLExpress;Database=RapidLaunch.Tests;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true";
        }

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
