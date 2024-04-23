// <copyright file="AircraftTypeConfiguration.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RapidLaunch.EF.Samples.AircraftTypes
{
    /// <inheritdoc />
    public class AircraftTypeConfiguration : IEntityTypeConfiguration<AircraftType>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<AircraftType> builder)
        {
            builder.HasKey(x => x.Id);
        }
    }
}
