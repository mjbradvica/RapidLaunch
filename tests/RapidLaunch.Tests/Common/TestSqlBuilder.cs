// <copyright file="TestSqlBuilder.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using RapidLaunch.Common;

namespace RapidLaunch.Tests.Common
{
    /// <inheritdoc />
    public class TestSqlBuilder : SqlBuilder<TestEntity, Guid>
    {
        /// <inheritdoc />
        public TestSqlBuilder(string tableName)
            : base(tableName)
        {
        }

        /// <inheritdoc />
        public TestSqlBuilder()
        {
        }

        /// <inheritdoc />
        protected override Func<TestEntity, List<object>> EntityProperties { get; } = entity
            => new List<object> { entity.Id };

        /// <inheritdoc/>
        protected override string DefaultInclude => "IncludeStatement";
    }
}
