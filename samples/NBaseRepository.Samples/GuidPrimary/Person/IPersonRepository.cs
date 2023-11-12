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
        /// <summary>
        /// Returns all people by name.
        /// </summary>
        /// <param name="name">The name fo query against.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task<IReadOnlyList<GuidPerson>> GetAllByName(string name);
    }
}
