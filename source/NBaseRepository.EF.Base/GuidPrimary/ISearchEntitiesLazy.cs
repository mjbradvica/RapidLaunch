// <copyright file="ISearchEntitiesLazy.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.EF.Base.Common;
using NBaseRepository.GuidPrimary;

namespace NBaseRepository.EF.Base.GuidPrimary
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
