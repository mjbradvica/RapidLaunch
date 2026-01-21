// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using MongoDB.Driver;
using NMediation.Abstractions;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TRoot> : RapidLaunchRepository<TRoot, Guid, IOccurrence>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(MongoClient mongoClient, string databaseName, string? collectionName = null, bool useTransactions = true)
            : base(mongoClient, databaseName, collectionName, useTransactions)
        {
        }
    }
}
