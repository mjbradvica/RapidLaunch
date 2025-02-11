// <copyright file="TestGuidEntityConfiguration.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
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
            builder.HasKey(entity => entity.Id);
            builder.HasOne(entity => entity.Relationship).WithMany();
        }
    }
}
