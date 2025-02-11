// <copyright file="IQuery.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface that describe a class that represents a query object for the entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IQuery<TEntity>
        where TEntity : class
    {
        /// <summary>
        /// Gets an expression that will be used to perform filtering and/or joins.
        /// </summary>
        Expression<Func<TEntity, bool>> SearchExpression { get; }
    }
}
