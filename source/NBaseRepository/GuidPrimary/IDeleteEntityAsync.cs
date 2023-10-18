// <copyright file="IDeleteEntityAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.GuidPrimary
{
    using System;
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can delete an entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IDeleteEntityAsync<in TEntity> : IDeleteEntityAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
