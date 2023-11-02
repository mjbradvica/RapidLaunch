// <copyright file="NBaseRepository.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using NBaseRepository.ADO.Common;
using NBaseRepository.Common;
using NBaseRepository.IntPrimary;

namespace NBaseRepository.ADO.IntPrimary
{
    /// <summary>
    /// A base class for entities with an <see cref="int"/> key.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class NBaseRepository<TEntity> : NBaseCoreRepository<TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NBaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> base class.</param>
        /// <param name="conversionFunc">A custom conversion func to create an entity from a <see cref="SqlDataReader"/> result set.</param>
        protected NBaseRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, int> sqlBuilder, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
        }
    }
}
