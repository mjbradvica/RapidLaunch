﻿// <copyright file="TestGuidEntity.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace RapidLaunch.EF.Tests.GuidPrimary
{
    /// <summary>
    /// Test aggregate root.
    /// </summary>
    public class TestGuidEntity : AggregateRoot
    {
        /// <summary>
        /// Gets or sets the navigation property.
        /// </summary>
        public TestRelationship? Relationship { get; set; }

        /// <summary>
        /// Adds a domain event to collection.
        /// </summary>
        public void AddEvent()
        {
            AppendDomainEvent(new TestNotification());
        }
    }
}
