// <copyright file="SqlHelpers.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

namespace RapidLaunch.Common
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
        /// <returns>A <see cref="string"/> that represents a sql join statement.</returns>
        public static string InnerJoin<TPrimary, TDependent>()
            where TDependent : class
            where TPrimary : class
        {
            return $"INNER JOIN dbo.{typeof(TDependent).Name} ON dbo.{typeof(TDependent).Name}.Id = dbo.{typeof(TPrimary).Name}.{typeof(TDependent).Name}Id";
        }
    }
}
