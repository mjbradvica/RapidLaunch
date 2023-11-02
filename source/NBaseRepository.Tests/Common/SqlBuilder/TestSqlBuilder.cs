// <copyright file="TestSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using NBaseRepository.Common;
using NBaseRepository.Tests.Common.GuidPrimary;

namespace NBaseRepository.Tests.Common.SqlBuilder
{
    /// <summary>
    /// SqlBuilder for testing.
    /// </summary>
    internal class TestSqlBuilder : SqlBuilder<Person, Guid>
    {
        /// <inheritdoc/>
        protected override Func<Person, IReadOnlyList<object>> EntityProperties { get; } =
            person => new List<object> { person.Id };

        /// <inheritdoc/>
        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<Person, Pet>();
    }
}
