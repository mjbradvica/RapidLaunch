// <copyright file="AircraftTypeConfiguration.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
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
