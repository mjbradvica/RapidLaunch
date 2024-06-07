// <copyright file="RapidLaunchPublisherRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ClearDomain.Common;
using MongoDB.Driver;
using RapidLaunch.Common;

namespace RapidLaunch.Mongo.Common
{
    /// <inheritdoc />
    public class RapidLaunchPublisherRepository<TEntity, TId> : RapidLaunchRepository<TEntity, TId>
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="mongoClient">An instance of the <see cref="MongoClient"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        /// <param name="databaseName">The name of the database to use.</param>
        /// <param name="collectionName">Optional collection name.</param>
        public RapidLaunchPublisherRepository(MongoClient mongoClient, IPublishingBus publishingBus, string databaseName,  string? collectionName = null)
            : base(mongoClient, databaseName, collectionName)
        {
            _publishingBus = publishingBus;
        }

        /// <inheritdoc/>
        protected override RapidLaunchStatus ExecuteCommand(Func<IClientSessionHandle, (int RowCount, IEnumerable<TEntity> Entities)> executionFunc, Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = default)
        {
            return base.ExecuteCommand(executionFunc, (rowCount, aggregateRoots) =>
            {
                if (rowCount > 0)
                {
                    foreach (var aggregateRoot in aggregateRoots)
                    {
                        foreach (var domainEvent in aggregateRoot.DomainEvents)
                        {
                            _publishingBus.PublishDomainEvent(domainEvent).GetAwaiter().GetResult();
                        }
                    }
                }
            });
        }

        /// <inheritdoc />
        protected override async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<IClientSessionHandle, Task<(int RowCount, IEnumerable<TEntity> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = default)
        {
            return await base.ExecuteCommandAsync(executionFunc, cancellationToken, async (rowCount, aggregateRoots) =>
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
