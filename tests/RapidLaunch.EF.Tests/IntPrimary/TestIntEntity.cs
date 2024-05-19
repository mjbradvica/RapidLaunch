// <copyright file="TestIntEntity.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;

namespace RapidLaunch.EF.Tests.IntPrimary
{
    /// <summary>
    /// Test int entity.
    /// </summary>
    public class TestIntEntity : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the navigation property.
        /// </summary>
        public TestRelationship? TestRelationship { get; set; }
    }
}
