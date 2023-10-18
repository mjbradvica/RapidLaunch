// <copyright file="IDeleteEntitiesAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.IntPrimary
{
    /// <summary>
    /// An interface used to describe a class that can delete multiple entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteEntitiesAsync<in TEntity> : IDeleteEntitiesAsync<TEntity, int>
        where TEntity : IEntity
    {
    }
}
