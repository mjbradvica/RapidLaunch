// <copyright file="SqlHelpers.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Linq.Expressions;

namespace NBaseRepository.Common
{
    /// <summary>
    /// A series of sql helpers to make writing sql statements easier.
    /// </summary>
    public static class SqlHelpers
    {
        /// <summary>
        /// Helper for an inner join. Mainly to eager load relationships.
        /// </summary>
        /// <typeparam name="TPrimary">The type of the primary entity.</typeparam>
        /// <typeparam name="TDependent">The type of the object to load alongside.</typeparam>
        /// <returns>An <see cref="string"/> that represents an sql join statement.</returns>
        public static string InnerJoin<TPrimary, TDependent>()
            where TDependent : class
            where TPrimary : class
        {
            return $"INNER JOIN dbo.{typeof(TDependent).Name} ON dbo.{typeof(TDependent).Name}.Id = dbo.{typeof(TPrimary).Name}.{typeof(TDependent).Name}Id";
        }

        /// <summary>
        /// Helper for an inner join. Mainly to eager load relationships.
        /// </summary>
        /// <typeparam name="TEntity">The type of the primary entity.</typeparam>
        /// <typeparam name="TKey">The type of the object ot load alongside.</typeparam>
        /// <param name="entity">Entity selector.</param>
        /// <param name="selector">A selector func.</param>
        /// <returns>An <see cref="string"/> that represents an sql join statement.</returns>
        public static string InnerJoin<TEntity, TKey>(this TEntity entity, Expression<Func<TEntity, TKey>> selector)
            where TEntity : class
            where TKey : class
        {
            return $"INNER JOIN dbo.{((MemberExpression)selector.Body).Member.Name} ON dbo.{((MemberExpression)selector.Body).Member.Name}.Id = dbo.{typeof(TEntity).Name}.{((MemberExpression)selector.Body).Member.Name}Id";
        }
    }
}
