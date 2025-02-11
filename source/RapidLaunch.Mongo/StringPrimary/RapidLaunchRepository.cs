﻿// <copyright file="RapidLaunchRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using MongoDB.Driver;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.StringPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, string>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(MongoClient mongoClient, string databaseName, string? collectionName = null, bool useTransactions = true)
            : base(mongoClient, databaseName, collectionName, useTransactions)
        {
        }
    }
}
