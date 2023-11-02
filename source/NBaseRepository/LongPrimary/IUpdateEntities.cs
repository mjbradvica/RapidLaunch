// <copyright file="IUpdateEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An interface used to describe a class that can update a range of entities.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateEntities<in TEntity> : IUpdateEntities<TEntity, long>
        where TEntity : IEntity
    {
    }
}