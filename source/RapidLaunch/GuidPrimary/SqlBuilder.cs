// <copyright file="SqlBuilder.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.GuidPrimary
{
    /// <inheritdoc />
    public abstract class SqlBuilder<TEntity> : SqlBuilder<TEntity, Guid>
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
