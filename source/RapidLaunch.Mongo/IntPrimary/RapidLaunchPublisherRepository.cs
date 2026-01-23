// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using MongoDB.Driver;
using NMediation.Abstractions;
using RapidLaunch.Common;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.IntPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, int, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(MongoClient mongoClient, IPublishingBus<IOccurrence> publishingBus, string databaseName, string? collectionName = null)
            : base(mongoClient, publishingBus, databaseName, collectionName)
        {
        }
    }
}
