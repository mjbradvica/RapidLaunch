// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using MongoDB.Driver;
using RapidLaunch.Common;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.StringPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TEntity> : RapidLaunchPublisherRepository<TEntity, string>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(MongoClient mongoClient, IPublishingBus publishingBus, string databaseName, string? collectionName = null)
            : base(mongoClient, publishingBus, databaseName, collectionName)
        {
        }
    }
}
