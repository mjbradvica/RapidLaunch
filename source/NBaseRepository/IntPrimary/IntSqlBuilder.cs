// <copyright file="IntSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.IntPrimary
{
    /// <summary>
    /// A base sql builder class for entities with <see cref="int"/> keys.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity.</typeparam>
    public abstract class IntSqlBuilder<TEntity> : SqlBuilder<TEntity, int>
        where TEntity : IEntity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntSqlBuilder{TEntity}"/> class.
        /// </summary>
        protected IntSqlBuilder()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IntSqlBuilder{TEntity}"/> class.
        /// </summary>
        /// <param name="tableName">The name of the table if different from the entity name.</param>
        protected IntSqlBuilder(string tableName)
            : base(tableName)
        {
        }
    }
}
