// <copyright file="TestIntEntityConfiguration.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
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
            builder.HasKey(entity => entity.Id);
            builder.HasOne(entity => entity.TestRelationship).WithMany();
            builder.Property(entity => entity.Id).ValueGeneratedOnAdd();
        }
    }
}
