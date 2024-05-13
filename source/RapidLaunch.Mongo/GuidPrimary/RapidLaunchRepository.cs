// <copyright file="RapidLaunchRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.GuidPrimary;
using MongoDB.Driver;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.GuidPrimary
{
    /// <inheritdoc />
    public abstract class RapidLaunchRepository<TEntity> : RapidLaunchRepository<TEntity, Guid>
        where TEntity : class, IAggregateRoot
    {
        /// <inheritdoc />
        protected RapidLaunchRepository(MongoClient mongoClient, string databaseName, string? collectionName = null)
            : base(mongoClient, databaseName, collectionName)
        {
        }
    }
}
