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
            builder.HasKey(root => root.Id);
            builder.HasOne(root => root.Relationship).WithMany();
            builder.Property(root => root.Id).ValueGeneratedOnAdd();
        }
    }
}
