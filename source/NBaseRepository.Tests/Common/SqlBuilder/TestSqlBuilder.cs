// <copyright file="TestSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using NBaseRepository.Tests.Common.GuidPrimary;
using NBaseRepository.Common;

namespace NBaseRepository.Tests.Common.SqlBuilder
{
    internal class TestSqlBuilder : SqlBuilder<Person, Guid>
    {
        /// <inheritdoc/>
        protected override Func<Person, IReadOnlyList<string>> EntityProperties { get; } =
            person => new List<string> { person.Id.ToString() };

        /// <inheritdoc/>
        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<Person, Pet>();
    }
}
