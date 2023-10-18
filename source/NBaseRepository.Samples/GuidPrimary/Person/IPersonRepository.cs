// <copyright file="IPersonRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    using NBaseRepository.GuidPrimary;

    public interface IPersonRepository :
        IAddEntityAsync<GuidPerson>,
        IUpdateEntityAsync<GuidPerson>,
        IGetAllEntitiesAsync<GuidPerson>
    {
    }
}
