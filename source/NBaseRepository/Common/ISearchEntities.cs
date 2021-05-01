namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

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
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IReadOnlyList{TEntity}"/>.</returns>
        Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, CancellationToken cancellationToken);

        /// <summary>
        /// Performs a series of filters and/or joins on a <see cref="TEntity"/> that accepts a customer include func for eager loading against a collection.
        /// </summary>
        /// <param name="queryObject">A <see cref="IQuery{TEntity,TId}"/> that contains a query expression.</param>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of type <see cref="IReadOnlyList{TEntity}"/>.</returns>
        Task<IReadOnlyList<TEntity>> SearchEntities(IQuery<TEntity, TId> queryObject, Func<IQueryable<TEntity>, IQueryable<TEntity>> includeFunc, CancellationToken cancellationToken);
    }
}
