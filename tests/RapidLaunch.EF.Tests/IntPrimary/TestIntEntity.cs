// <copyright file="TestIntEntity.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;

namespace RapidLaunch.EF.Tests.IntPrimary
{
    /// <summary>
    /// Test int root.
    /// </summary>
    public class TestIntEntity : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the navigation property.
        /// </summary>
        public TestRelationship? Relationship { get; set; }
    }
}
