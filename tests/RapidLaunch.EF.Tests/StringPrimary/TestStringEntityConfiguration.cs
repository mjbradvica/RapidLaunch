// <copyright file="TestStringEntityConfiguration.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RapidLaunch.EF.Tests.StringPrimary
{
    /// <inheritdoc />
    public class TestStringEntityConfiguration : IEntityTypeConfiguration<TestStringEntity>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<TestStringEntity> builder)
        {
            builder.HasKey(entity => entity.Id);
            builder.HasOne(entity => entity.Relationship).WithMany();
        }
    }
}
