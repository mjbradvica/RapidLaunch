// <copyright file="RapidLaunchPublisherRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

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
    }
}
