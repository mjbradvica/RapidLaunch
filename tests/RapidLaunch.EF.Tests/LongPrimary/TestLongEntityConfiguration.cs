// <copyright file="TestLongEntityConfiguration.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <inheritdoc />
    public class TestLongEntityConfiguration : IEntityTypeConfiguration<TestLongEntity>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TestLongEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.HasOne(entity => entity.Relationship).WithMany();
            builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        }
    }
}
