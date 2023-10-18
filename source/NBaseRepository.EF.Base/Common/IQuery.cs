// <copyright file="IQuery.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.EF.Base.Common
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// An interface that describe a class that represents a query object for type <see cref="TEntity"/>.
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
