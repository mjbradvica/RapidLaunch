﻿// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using MongoDB.Driver;
using RapidLaunch.Common;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot> : RapidLaunchPublisherRepository<TRoot, Guid>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchPublisherRepository(MongoClient mongoClient, IPublishingBus publishingBus, string databaseName, string? collectionName = null, bool useTransactions = true)
            : base(mongoClient, publishingBus, databaseName, collectionName, useTransactions)
        {
        }
    }
}
