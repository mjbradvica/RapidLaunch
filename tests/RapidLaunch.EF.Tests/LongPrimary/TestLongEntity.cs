// <copyright file="TestLongEntity.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;

namespace RapidLaunch.EF.Tests.LongPrimary
{
    /// <summary>
    /// Test long entity.
    /// </summary>
    public class TestLongEntity : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the test navigation property.
        /// </summary>
        public TestRelationship? Relationship { get; set; }
    }
}
