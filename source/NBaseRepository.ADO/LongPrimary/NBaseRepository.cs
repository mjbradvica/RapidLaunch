// <copyright file="NBaseRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using NBaseRepository.ADO.Common;
using NBaseRepository.Common;
using NBaseRepository.LongPrimary;

namespace NBaseRepository.ADO.LongPrimary
{
    /// <summary>
    /// A base class for entities with <see cref="long"/> keys.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="conversionFunc">A custom conversion func to create an entity from a <see cref="SqlDataReader"/> result set.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, long> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
