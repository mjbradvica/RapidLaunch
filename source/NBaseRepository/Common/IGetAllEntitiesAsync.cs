namespace NBaseRepository.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// An interface used to describe a class that can retrieve all entities of type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IGetAllEntitiesAsync<TEntity, TId, TIn, TOut>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from a collection.
        /// </summary>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="IReadOnlyList{TEntity}"/>.</returns>
        Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Retrieves all entities of type <see cref="TEntity"/> from a collection that accepts a custom include func for eager loading.
        /// </summary>
        /// <param name="includeFunc">An include func used for eager loading.</param>
        /// <param name="cancellationToken">A <see cref="CancellationToken"/>.</param>
        /// <returns>A <see cref="Task"/> of <see cref="IReadOnlyList{TEntity}"/>.</returns>
        Task<IReadOnlyList<TEntity>> GetAllEntitiesAsync(Func<TIn, TOut> includeFunc, CancellationToken cancellationToken);
    }
}
