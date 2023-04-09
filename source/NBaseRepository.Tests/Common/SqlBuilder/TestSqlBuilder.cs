namespace NBaseRepository.Tests.Common.SqlBuilder
{
    using System;
    using System.Collections.Generic;
    using GuidPrimary;
    using NBaseRepository.Common;

    internal class TestSqlBuilder : SqlBuilder<Person, Guid>
    {
        protected override Func<Person, IReadOnlyList<string>> EntityProperties { get; } =
            person => new List<string> { person.Id.ToString() };

        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<Person, Pet>();
    }
}
