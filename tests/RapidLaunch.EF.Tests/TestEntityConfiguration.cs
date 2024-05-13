// <copyright file="TestEntityConfiguration.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RapidLaunch.EF.Tests
{
    /// <summary>
    /// Test Entity configuration.
    /// </summary>
    public class TestEntityConfiguration : IEntityTypeConfiguration<TestEntity>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TestEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.HasOne(entity => entity.Relationship).WithMany();
        }
    }
}
