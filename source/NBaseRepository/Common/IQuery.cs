namespace NBaseRepository.Common
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TId"></typeparam>
    public interface IQuery<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        /// <summary>
        /// 
        /// </summary>
        Expression<Func<TEntity, bool>> SearchExpression { get; }
    }
}
