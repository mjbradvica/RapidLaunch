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

        protected override string DefaultInclude { get; } = "INNER JOIN dbo.Pets ON dbo.Person.Id = dbo.Pet.PersonId";
    }
}
