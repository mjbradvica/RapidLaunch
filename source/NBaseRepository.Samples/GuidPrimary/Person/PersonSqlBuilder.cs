// <copyright file="PersonSqlBuilder.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    using NBaseRepository.Samples.GuidPrimary.Animal;
    using NBaseRepository.Common;
    using NBaseRepository.GuidPrimary;

    public class PersonSqlBuilder : GuidSqlBuilder<GuidPerson>
    {
        /// <inheritdoc/>
        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<GuidPerson, GuidAnimal>();

        /// <inheritdoc/>
        protected override Func<GuidPerson, IReadOnlyList<string>> EntityProperties { get; } = customer =>
            new List<string> { customer.Id.ToString(), customer.Name, customer.Age.ToString(), customer.GuidAnimal.Id.ToString() };
    }
}
