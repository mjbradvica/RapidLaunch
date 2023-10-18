// <copyright file="IAddEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.IntPrimary
{
    /// <summary>
    /// An interface that allows a class to add a single entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddEntity<in TEntity> : IAddEntity<TEntity, int>
        where TEntity : IEntity
    {
    }
}