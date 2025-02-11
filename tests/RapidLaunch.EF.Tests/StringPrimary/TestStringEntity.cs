// <copyright file="TestStringEntity.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
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
