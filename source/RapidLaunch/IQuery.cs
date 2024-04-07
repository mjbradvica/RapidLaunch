// <copyright file="IQuery.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq.Expressions;

namespace RapidLaunch
{
    /// <summary>
    /// An interface that describe a class that represents a query object for the entity.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public interface IQuery<TEntity>
    {
        /// <summary>
        /// Gets an expression that will be used to perform filtering and/or joins.
        /// </summary>
        Expression<Func<TEntity, bool>> SearchExpression { get; }
    }
}
