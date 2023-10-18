// <copyright file="IAddEntityAsync.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.GuidPrimary
{
    using System;
    using NBaseRepository.Common;

    /// <summary>
    /// An interface that allows a class to add a single entity of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IAddEntityAsync<in TEntity> : IAddEntityAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
