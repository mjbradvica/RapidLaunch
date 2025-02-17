// <copyright file="TestIntEntityConfiguration.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RapidLaunch.EF.Tests.IntPrimary
{
    /// <inheritdoc />
    public class TestIntEntityConfiguration : IEntityTypeConfiguration<TestIntEntity>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TestIntEntity> builder)
        {
            builder.HasKey(root => root.Id);
            builder.HasOne(root => root.Relationship).WithMany();
            builder.Property(root => root.Id).ValueGeneratedOnAdd();
        }
    }
}
