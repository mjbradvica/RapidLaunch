// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.LongPrimary;
using MongoDB.Driver;
using RapidLaunch.Common;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.LongPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, long>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(MongoClient mongoClient, IPublishingBus publishingBus, string databaseName, string? collectionName = null, bool useTransactions = true)
            : base(mongoClient, publishingBus, databaseName, collectionName, useTransactions)
        {
        }
    }
}
