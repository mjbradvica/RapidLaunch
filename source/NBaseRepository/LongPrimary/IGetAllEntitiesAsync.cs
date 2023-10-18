// <copyright file="IGetAllEntitiesAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.LongPrimary
{
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllEntitiesAsync<TEntity> : IGetAllEntitiesAsync<TEntity, long>
        where TEntity : IEntity
    {
    }
}
