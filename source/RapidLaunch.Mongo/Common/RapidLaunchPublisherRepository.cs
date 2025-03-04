﻿// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using MongoDB.Driver;
using RapidLaunch.Common;

namespace RapidLaunch.Mongo.Common
{
    /// <inheritdoc />
    public class RapidLaunchPublisherRepository<TRoot, TId> : RapidLaunchRepository<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TRoot, TId}"/> class.
        /// </summary>
        /// <param name="mongoClient">An instance of the <see cref="MongoClient"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        /// <param name="databaseName">The name of the database to use.</param>
        /// <param name="collectionName">Optional collection name.</param>
        /// <param name="useTransactions">A flag to toggle transactions on and off.</param>
        public RapidLaunchPublisherRepository(MongoClient mongoClient, IPublishingBus publishingBus, string databaseName, string? collectionName = null, bool useTransactions = true)
            : base(mongoClient, databaseName, collectionName, useTransactions)
        {
            _publishingBus = publishingBus;
        }

        /// <inheritdoc/>
        protected override RapidLaunchStatus ExecuteCommand(Func<IClientSessionHandle, (int RowCount, IEnumerable<TRoot> Entities)> executionFunc, Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = null)
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
        protected override async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<IClientSessionHandle, Task<(int RowCount, IEnumerable<TRoot> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = null)
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
