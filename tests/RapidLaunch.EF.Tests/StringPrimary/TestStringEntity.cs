// <copyright file="TestStringEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;

namespace RapidLaunch.EF.Tests.StringPrimary
{
    /// <summary>
    /// Test string entity.
    /// </summary>
    public class TestStringEntity : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the test navigation property.
        /// </summary>
        public TestRelationship? Relationship { get; set; }
    }
}
