// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.IntPrimary;
using MongoDB.Driver;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.IntPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TRoot> : RapidLaunchRepository<TRoot, int>
        where TRoot : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(MongoClient mongoClient, string databaseName, string? collectionName = null, bool useTransactions = true)
            : base(mongoClient, databaseName, collectionName, useTransactions)
        {
        }
    }
}
