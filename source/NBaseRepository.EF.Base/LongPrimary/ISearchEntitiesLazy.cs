﻿namespace NBaseRepository.EF.Base.LongPrimary
{
    using Common;
    using NBaseRepository.LongPrimary;

    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/> lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface ISearchEntitiesLazy<TEntity> : ISearchEntitiesLazy<TEntity, long>
        where TEntity : IEntity
    {
    }
}