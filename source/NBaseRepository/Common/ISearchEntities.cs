namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface ISearchEntities<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity,TId}"/> that contains a query expression.</param>
        /// <returns>A <see cref="IReadOnlyList{TEntity}"/>.</returns>
        IReadOnlyList<TEntity> SearchEntities(IQuery<TEntity, TId> queryObject);

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> that accepts a customer include func for eager loading against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity,TId}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>A <see cref="IReadOnlyList{TEntity}"/>.</returns>
        IReadOnlyList<TEntity> SearchEntities(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}