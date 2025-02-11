// <copyright file="TestHelpers.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

namespace RapidLaunch.EF.Tests.Helpers
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
            using (var context = new TestDbContext())
            {
                context.GuidEntities.RemoveRange(context.GuidEntities);
                context.IntEntities.RemoveRange(context.IntEntities);
                context.LongEntities.RemoveRange(context.LongEntities);
                context.StringEntities.RemoveRange(context.StringEntities);

                context.SaveChanges();
            }
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
    }
}
