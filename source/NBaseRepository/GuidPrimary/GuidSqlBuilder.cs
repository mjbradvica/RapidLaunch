// <copyright file="GuidSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    /// <summary>
    /// An abstract base class for sql builders with <see cref="Guid"/> keys.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class GuidSqlBuilder<TEntity> : SqlBuilder<TEntity, Guid>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GuidSqlBuilder{TEntity}"/> class.
        /// </summary>
        protected GuidSqlBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuidSqlBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="tableName">The name of the table if different from the entity name.</param>
        protected GuidSqlBuilder(string tableName)
            : base(tableName)
        {
        }
    }
}
