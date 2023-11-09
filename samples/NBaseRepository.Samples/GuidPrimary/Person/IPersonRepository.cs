// <copyright file="IPersonRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.GuidPrimary;

namespace NBaseRepository.Samples.GuidPrimary.Person
{
    /// <summary>
    /// Sample repository interface.
    /// </summary>
    public interface IPersonRepository :
        IAddEntityAsync<GuidPerson>,
        IUpdateEntityAsync<GuidPerson>,
        IGetAllEntitiesAsync<GuidPerson>,
        IGetByIdAsync<GuidPerson>,
        IDeleteByIdAsync
    {
    }
}
