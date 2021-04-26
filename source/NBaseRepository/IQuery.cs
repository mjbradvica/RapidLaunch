namespace NBaseRepository
{
    using System;
    using System.Linq.Expressions;

    public interface IQuery<TEntity, TId>
        where TEntity : IEntity<TId>
    {
        Expression<Func<TEntity, bool>> SearchExpression { get; }
    }
}
