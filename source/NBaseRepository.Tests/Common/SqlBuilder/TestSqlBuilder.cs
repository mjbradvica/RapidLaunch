// <copyright file="TestSqlBuilder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Tests.Common.SqlBuilder
{
    using System;
    using System.Collections.Generic;
    using NBaseRepository.Tests.Common.GuidPrimary;
    using NBaseRepository.Common;

    internal class TestSqlBuilder : SqlBuilder<Person, Guid>
    {
        /// <inheritdoc/>
        protected override Func<Person, IReadOnlyList<string>> EntityProperties { get; } =
            person => new List<string> { person.Id.ToString() };

        /// <inheritdoc/>
        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<Person, Pet>();
    }
}
