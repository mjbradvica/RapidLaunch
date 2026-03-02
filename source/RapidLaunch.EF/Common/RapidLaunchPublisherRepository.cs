// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
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
    /// <typeparam name="TEvent">The type of the domain event.</typeparam>
    public abstract class RapidLaunchPublisherRepository<TRoot, TId, TEvent> : RapidLaunchRepository<TRoot, TId, TEvent>
        where TRoot : class, IAggregateRoot<TId, TEvent>
        where TEvent : class
    {
        private readonly IPublishingBus<TEvent> _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TRoot, TId, TEvent}"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus{TEvent}"/> interface.</param>
        /// <param name="includeFunc">A <see cref="Func{TResult}"/> that will return a <see cref="IQueryable{T}"/> used to eagerly load related aggregateRoots.</param>
        protected RapidLaunchPublisherRepository(DbContext context, IPublishingBus<TEvent> publishingBus, Func<IQueryable<TRoot>, IQueryable<TRoot>>? includeFunc = null)
            : base(context, includeFunc)
        {
            _publishingBus = publishingBus;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TRoot, TId, TEvent}"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="DbContext"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus{TEvent}"/> interface.</param>
        protected RapidLaunchPublisherRepository(DbContext context, IPublishingBus<TEvent> publishingBus)
            : base(context)
        {
            _publishingBus = publishingBus;
        }

        /// <inheritdoc />
        protected override RapidLaunchStatus ExecuteCommand(Action<DbSet<TRoot>> executionFunction, IEnumerable<TRoot> roots, Action<int, IEnumerable<IAggregateRoot<TId, TEvent>>>? postOperationFunc = null)
        {
            return base.ExecuteCommand(executionFunction, roots, (rowCount, aggregateRoots) =>
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
        protected override async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<DbSet<TRoot>, Task> executionFunc, IEnumerable<TRoot> roots, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId, TEvent>>, Task>? postOperationFunc = null)
        {
            return await base.ExecuteCommandAsync(executionFunc, roots, cancellationToken, async (rowCount, aggregateRoots) =>
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
