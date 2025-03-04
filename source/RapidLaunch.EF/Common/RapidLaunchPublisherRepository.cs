﻿// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Microsoft.EntityFrameworkCore;
using RapidLaunch.Common;

namespace RapidLaunch.EF.Common
{
    /// <summary>
    /// Base publishing repository for EF.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class RapidLaunchPublisherRepository<TRoot, TId> : RapidLaunchRepository<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TRoot,TId}"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> that will return a <see cref="IQueryable{T}"/> used to eagerly load related aggregateRoots.</param>
        protected RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus, Func<IQueryable<TRoot>, IQueryable<TRoot>>? includeFunc = null)
            : base(context, includeFunc)
        {
            _publishingBus = publishingBus;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TRoot,TId}"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        protected RapidLaunchPublisherRepository(DbContext context, IPublishingBus publishingBus)
            : base(context)
        {
            _publishingBus = publishingBus;
        }

        /// <inheritdoc />
        protected override RapidLaunchStatus ExecuteCommand(Func<(int RowCount, IEnumerable<TRoot> Entities)> executionFunc, Action<int, IEnumerable<IAggregateRoot<TId>>>? postOperationFunc = null)
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

        /// <inheritdoc/>
        protected override async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<Task<(int RowCount, IEnumerable<TRoot> Entities)>> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId>>, Task>? postOperationFunc = null)
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
