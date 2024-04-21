// <copyright file="SampleContext.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Samples.Airplanes;

namespace RapidLaunch.EF.Samples
{
    /// <inheritdoc />
    public sealed class SampleContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SampleContext"/> class.
        /// </summary>
        /// <param name="options">The options class.</param>
        public SampleContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();

            Airplanes = Set<Airplane>();
        }

        /// <summary>
        /// Gets the airplane set.
        /// </summary>
        public DbSet<Airplane> Airplanes { get; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
