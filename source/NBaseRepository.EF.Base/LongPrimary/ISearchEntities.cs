// <copyright file="ISearchEntities.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.LongPrimary
{
    using NBaseRepository.EF.Base.Common;
    using NBaseRepository.LongPrimary;

    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchEntities<TEntity> : ISearchEntities<TEntity, long>
        where TEntity : IEntity
    {
    }
}