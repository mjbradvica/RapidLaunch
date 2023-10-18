// <copyright file="IUpdateEntitiesAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.GuidPrimary
{
    using System;
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can update a range of entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IUpdateEntitiesAsync<in TEntity> : IUpdateEntitiesAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
