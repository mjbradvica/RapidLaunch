// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Microsoft.Data.SqlClient;
using NMediation.Abstractions;
using RapidLaunch.Common;

namespace RapidLaunch.ADO.Common
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot, TId, TEvent> : RapidLaunchRepository<TRoot, TId, TEvent>
        where TRoot : class, IAggregateRoot<TId, TEvent>
        where TEvent : class
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TRoot, TId, TEvent}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IMediation"/> interface.</param>
        /// <param name="conversionFunc">A <see cref="Func{TResult}"/> to convert from a <see cref="SqlDataReader"/> to the root type.</param>
        protected RapidLaunchPublisherRepository(SqlConnection sqlConnection, IPublishingBus publishingBus, Func<SqlDataReader, TRoot> conversionFunc)
            : base(sqlConnection, conversionFunc)
        {
            _publishingBus = publishingBus;
        }

        /// <inheritdoc />
        protected override RapidLaunchStatus ExecuteCommand(Func<(string Command, IEnumerable<TRoot> Entities)> executionFunc, Action<int, IEnumerable<IAggregateRoot<TId, TEvent>>>? postOperationFunc = null)
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
        protected override async Task<RapidLaunchStatus> ExecuteCommandAsync(Func<(string Command, IEnumerable<TRoot> Entities)> executionFunc, CancellationToken cancellationToken, Func<int, IEnumerable<IAggregateRoot<TId, TEvent>>, Task>? postOperationFunc = null)
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
