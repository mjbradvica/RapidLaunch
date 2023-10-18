// <copyright file="PersonSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Samples.GuidPrimary.Animal;
using NBaseRepository.Common;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    public class PersonSqlBuilder : GuidSqlBuilder<GuidPerson>
    {
        /// <inheritdoc/>
        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<GuidPerson, GuidAnimal>();

        /// <inheritdoc/>
        protected override Func<GuidPerson, IReadOnlyList<string>> EntityProperties { get; } = customer =>
            new List<string> { customer.Id.ToString(), customer.Name, customer.Age.ToString(), customer.GuidAnimal.Id.ToString() };
    }
}
