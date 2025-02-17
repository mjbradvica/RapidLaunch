// <copyright file="TestLongEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <summary>
    /// Test long root.
    /// </summary>
    public class TestLongEntity : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the test navigation property.
        /// </summary>
        public TestRelationship? Relationship { get; set; }
    }
}
