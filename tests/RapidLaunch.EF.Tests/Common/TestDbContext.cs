// <copyright file="TestDbContext.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
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
        }

        /// <summary>
        /// Gets the test entity set.
        /// </summary>
        public DbSet<TestEntity> Entities { get; }

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
