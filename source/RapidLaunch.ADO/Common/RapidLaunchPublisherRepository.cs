// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.Common
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="sqlBuilder">An instance of the <see cref="SqlBuilder{TEntity,TId}"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        /// <param name="conversionFunc">A <see cref="Func{TResult}"/> to convert from a <see cref="SqlDataReader"/> to the entity type.</param>
        protected RapidLaunchPublisherRepository(SqlConnection sqlConnection, SqlBuilder<TEntity, TId> sqlBuilder, IPublishingBus publishingBus, Func<SqlDataReader, TEntity> conversionFunc)
            : base(sqlConnection, sqlBuilder, conversionFunc)
        {
            _publishingBus = publishingBus;
        }

        /// <inheritdoc />
        protected override RapidLaunchStatus ExecuteCommand(string command, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            return base.ExecuteCommand(command, (rowCount, aggregateRoots) =>
            {
                if (rowCount > 0)
                {
                    foreach (var aggregateRoot in aggregateRoots)
                    {
                        foreach (var domainEvent in aggregateRoot.DomainEvents)
                        {
                            _publishingBus.PublishDomainEvent(domainEvent).RunSynchronously();
                        }
                    }
                }

                return Task.CompletedTask;
            });
        }

        /// <inheritdoc />
        protected override Task<RapidLaunchStatus> ExecuteCommandAsync(string command, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            return base.ExecuteCommandAsync(command, cancellationToken, async (rowCount, aggregateRoots) =>
            {
                if (rowCount > 0)
                {
                    foreach (var aggregateRoot in aggregateRoots)
                    {
                        foreach (var domainEvent in aggregateRoot.DomainEvents)
                        {
                            await _publishingBus.PublishDomainEvent(domainEvent, cancellationToken);
                        }
                    }
                }
            });
        }
    }
}
