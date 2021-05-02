namespace NBaseRepository.Common
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// An interface that describe a class that represents a query object for type <see cref="TEntity"/>.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <typeparam name="TId">The type of the Id.</typeparam>
    public interface IQuery<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// Gets an expression that will be used to perform filtering and/or joins.
        /// </summary>
        Expression<Func<TEntity, bool>> SearchExpression { get; }
    }
}
