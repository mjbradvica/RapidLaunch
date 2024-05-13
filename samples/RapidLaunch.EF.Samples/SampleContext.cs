// <copyright file="SampleContext.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.Samples.AircraftTypes;
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
            AircraftTypes = Set<AircraftType>();
        }

        /// <summary>
        /// Gets the airplane set.
        /// </summary>
        public DbSet<Airplane> Airplanes { get; }

        /// <summary>
        /// Gets the aircraft types set.
        /// </summary>
        public DbSet<AircraftType> AircraftTypes { get; }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
