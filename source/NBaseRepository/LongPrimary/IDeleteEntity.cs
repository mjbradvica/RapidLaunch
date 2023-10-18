// <copyright file="IDeleteEntity.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.LongPrimary
{
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can delete an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteEntity<in TEntity> : IDeleteEntity<TEntity, long>
        where TEntity : IEntity
    {
    }
}