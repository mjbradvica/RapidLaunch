// <copyright file="TestSqlBuilder.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

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
