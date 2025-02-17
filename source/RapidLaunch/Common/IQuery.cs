// <copyright file="IQuery.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface that describe a class that represents a query object for the root.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IQuery<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        /// <summary>
        /// Gets an expression that will be used to perform filtering and/or joins.
        /// </summary>
        Expression<Func<TRoot, bool>> SearchExpression { get; }
    }
}
