// <copyright file="IUpdateEntities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.LongPrimary
{
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can update a range of entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateEntities<in TEntity> : IUpdateEntities<TEntity, long>
        where TEntity : IEntity
    {
    }
}