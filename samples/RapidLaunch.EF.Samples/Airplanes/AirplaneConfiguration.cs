// <copyright file="AirplaneConfiguration.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RapidLaunch.EF.Samples.Airplanes
{
    /// <inheritdoc />
    public class AirplaneConfiguration : IEntityTypeConfiguration<Airplane>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Airplane> builder)
        {
            builder.HasKey(airplane => airplane.Id);

            builder
                .HasOne(airplane => airplane.AircraftType)
                .WithMany();
        }
    }
}
