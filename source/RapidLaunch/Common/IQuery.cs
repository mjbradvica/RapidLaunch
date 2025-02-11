// <copyright file="IQuery.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace RapidLaunch.Common
{
	/// <summary>
	/// An interface that describe a class that represents a query object for the entity.
	/// </summary>
	/// <typeparam name="TRoot">The type of the entity.</typeparam>
	public interface IQuery<TRoot>
        where TRoot : class
    {
        /// <summary>
        /// Gets an expression that will be used to perform filtering and/or joins.
        /// </summary>
        Expression<Func<TRoot, bool>> SearchExpression { get; }
    }
}
