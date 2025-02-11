// <copyright file="RapidLaunchPublisherRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Microsoft.Data.SqlClient;
using RapidLaunch.Common;

namespace RapidLaunch.Dapper.Common
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="connection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> class.</param>
        /// <param name="executionFunc">The synchronous execution func.</param>
        /// <param name="asyncExecutionFunc">The asynchronous execution func.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        protected RapidLaunchPublisherRepository(
            SqlConnection connection,
            SqlBuilder<TEntity, TId> sqlBuilder,
            Func<SqlConnection, string, IEnumerable<TEntity>> executionFunc,
            Func<SqlConnection, string, Task<IEnumerable<TEntity>>> asyncExecutionFunc,
            IPublishingBus publishingBus)
            : base(connection, sqlBuilder, executionFunc, asyncExecutionFunc)
        {
            _publishingBus = publishingBus;
        }
    }
}
