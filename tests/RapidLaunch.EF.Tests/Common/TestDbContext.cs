// <copyright file="TestDbContext.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace RapidLaunch.EF.Tests.Common
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

            Entities = Set<TestEntity>();
            Relationships = Set<TestRelationship>();
        }

        /// <summary>
        /// Gets the test entity set.
        /// </summary>
        public DbSet<TestEntity> Entities { get; }

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
