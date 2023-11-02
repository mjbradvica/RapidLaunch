// <copyright file="ISearchEntities.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.EF.Base.Common;
using NBaseRepository.IntPrimary;

namespace NBaseRepository.EF.Base.IntPrimary
{
    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchEntities<TEntity> : ISearchEntities<TEntity, int>
        where TEntity : IEntity
    {
    }
}