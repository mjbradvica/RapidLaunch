// <copyright file="TestDbContext.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Tests.GuidPrimary;
using RapidLaunch.EF.Tests.IntPrimary;
using RapidLaunch.EF.Tests.LongPrimary;
using RapidLaunch.EF.Tests.StringPrimary;

namespace RapidLaunch.EF.Tests.Helpers
{
    /// <summary>
    /// Test db context.
    /// </summary>
    internal sealed class TestDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestDbContext"/> class.
        /// </summary>
        public TestDbContext()
        {
            Database.EnsureCreated();

            GuidEntities = Set<TestGuidEntity>();
            IntEntities = Set<TestIntEntity>();
            LongEntities = Set<TestLongEntity>();
            StringEntities = Set<TestStringEntity>();
        }

        /// <summary>
        /// Gets the test guid entity set.
        /// </summary>
        public DbSet<TestGuidEntity> GuidEntities { get; }

        /// <summary>
        /// Gets the test int entity set.
        /// </summary>
        public DbSet<TestIntEntity> IntEntities { get; }

        /// <summary>
        /// Gets the test long entity set.
        /// </summary>
        public DbSet<TestLongEntity> LongEntities { get; }

        /// <summary>
        /// Gets the test string entity set.
        /// </summary>
        public DbSet<TestStringEntity> StringEntities { get; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(TestHelpers.ConnectionString());
        }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
