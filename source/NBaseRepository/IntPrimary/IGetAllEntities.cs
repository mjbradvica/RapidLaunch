// <copyright file="IGetAllEntities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.IntPrimary
{
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IGetAllEntities<out TEntity> : IGetAllEntities<TEntity, int>
        where TEntity : IEntity
    {
    }
}