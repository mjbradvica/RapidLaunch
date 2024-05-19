// <copyright file="TestDbContext.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Tests.GuidPrimary;
using RapidLaunch.EF.Tests.IntPrimary;

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
            Relationships = Set<TestRelationship>();
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
        /// Gets the test relationships.
        /// </summary>
        public DbSet<TestRelationship> Relationships { get; }

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
