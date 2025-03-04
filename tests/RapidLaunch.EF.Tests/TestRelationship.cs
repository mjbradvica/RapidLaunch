﻿// <copyright file="TestRelationship.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace RapidLaunch.EF.Tests
{
    /// <summary>
    /// Test navigation property.
    /// </summary>
    public class TestRelationship : AggregateRoot
    {
        /// <summary>
        /// Returns an empty instance of the object.
        /// </summary>
        /// <returns>A <see cref="TestRelationship"/> instance.</returns>
        public static TestRelationship Empty()
        {
            return new TestRelationship();
        }
    }
}
