// <copyright file="LongSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An abstract base class for sql builders with <see cref="long"/> keys.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class LongSqlBuilder<TEntity> : SqlBuilder<TEntity, long>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LongSqlBuilder{TEntity}"/> class.
        /// </summary>
        protected LongSqlBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LongSqlBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="tableName">The name of the table if different from the entity name.</param>
        protected LongSqlBuilder(string tableName)
        : base(tableName)
        {
        }
    }
}
