namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// An interface used to describe a class that can perform basic filters and/or joins for type <see cref="TEntity"/> lazily.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface ISearchEntitiesLazy<TEntity, TId>
        where TEntity : IEntity<TId>
        where TId : struct
    {
        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against a collection that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject);

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> against a collection that accepts a customer include func that has not been executed.
        /// </summary>
        /// <param name="queryObject">A query object of type <see cref="IQuery{TEntity}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <returns>An <see cref="IEnumerable{TEntity}"/>.</returns>
        IEnumerable<TEntity> SearchEntitiesLazy(IQuery<TEntity> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc);
    }
}
