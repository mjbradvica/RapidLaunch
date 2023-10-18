// <copyright file="IntSqlBuilder.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.IntPrimary
{
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
        /// <param name="tableName"></param>
        protected IntSqlBuilder(string tableName)
            : base(tableName)
        {
        }
    }
}
