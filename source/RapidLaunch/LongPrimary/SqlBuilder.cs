// <copyright file="SqlBuilder.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.LongPrimary
{
    /// <inheritdoc />
    public abstract class SqlBuilder<TEntity> : SqlBuilder<TEntity, long>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected SqlBuilder(string tableName)
            : base(tableName)
        {
        }

        /// <inheritdoc />
        protected SqlBuilder()
        {
        }
    }
}
