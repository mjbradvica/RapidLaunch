// <copyright file="PersonSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;
using NBaseRepository.GuidPrimary;
using NBaseRepository.Samples.GuidPrimary.Animal;

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    public class PersonSqlBuilder : GuidSqlBuilder<GuidPerson>
    {
        /// <inheritdoc/>
        protected override string DefaultInclude { get; } = SqlHelpers.InnerJoin<GuidPerson, GuidAnimal>();

        /// <inheritdoc/>
        protected override Func<GuidPerson, IReadOnlyList<object>> EntityProperties { get; } = customer =>
            new List<object> { customer.Id, customer.Name, customer.Age, customer.GuidAnimal.Id };
    }
}
