// <copyright file="IDeleteEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteEntity<in TEntity> : IDeleteEntity<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}