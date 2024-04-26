// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
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
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        protected RapidLaunchPublisherRepository(IPublishingBus publishingBus)
        {
            _publishingBus = publishingBus;
        }
    }
}
