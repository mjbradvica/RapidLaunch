// <copyright file="TestDbContext.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Tests.GuidPrimary;
using RapidLaunch.EF.Tests.IntPrimary;
using RapidLaunch.EF.Tests.LongPrimary;
using RapidLaunch.EF.Tests.StringPrimary;
using System.Reflection;

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
        /// <param name="options">An instance of the <see cref="DbContextOptions"/> class.</param>
        public TestDbContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();

            GuidEntities = Set<TestGuidEntity>();
            IntEntities = Set<TestIntEntity>();
            LongEntities = Set<TestLongEntity>();
            StringEntities = Set<TestStringEntity>();
        }

        /// <summary>
        /// Gets the test guid root set.
        /// </summary>
        public DbSet<TestGuidEntity> GuidEntities { get; }

        /// <summary>
        /// Gets the test int root set.
        /// </summary>
        public DbSet<TestIntEntity> IntEntities { get; }

        /// <summary>
        /// Gets the test long root set.
        /// </summary>
        public DbSet<TestLongEntity> LongEntities { get; }

        /// <summary>
        /// Gets the test string root set.
        /// </summary>
        public DbSet<TestStringEntity> StringEntities { get; }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //    optionsBuilder.UseSqlServer(TestHelpers.ConnectionString());
        // }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
