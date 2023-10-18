// <copyright file="IGetById.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve a single entity of type <see cref="TEntity"/> by an Id of type <see cref="TId"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetById<out TEntity, in TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Retrieves an <see cref="TEntity"/> from a collection by Id.
        /// </summary>
        /// <param name="id">The Id of type <see cref="TId"/>.</param>
        /// <returns>An object of type <see cref="TEntity"/>.</returns>
        TEntity GetById(TId id);
    }
}