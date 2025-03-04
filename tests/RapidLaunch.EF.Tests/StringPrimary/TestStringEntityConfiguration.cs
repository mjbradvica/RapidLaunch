﻿// <copyright file="TestStringEntityConfiguration.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
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
            builder.HasKey(root => root.Id);
            builder.HasOne(root => root.Relationship).WithMany();
        }
    }
}
