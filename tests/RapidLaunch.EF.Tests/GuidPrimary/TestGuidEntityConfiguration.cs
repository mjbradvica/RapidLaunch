// <copyright file="TestGuidEntityConfiguration.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RapidLaunch.EF.Tests.GuidPrimary
{
    /// <summary>
    /// Test Entity configuration.
    /// </summary>
    public class TestGuidEntityConfiguration : IEntityTypeConfiguration<TestGuidEntity>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TestGuidEntity> builder)
        {
            builder.HasKey(root => root.Id);
            builder.HasOne(root => root.Relationship).WithMany();
        }
    }
}
