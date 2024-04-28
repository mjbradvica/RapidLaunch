// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using ClearDomain.Common;
using RapidLaunch.Common;

namespace RapidLaunch.Dapper.Common
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TModel, TEntity, TId> : RapidLaunchRepository<TModel, TEntity, TId>
        where TModel : class
        where TEntity : class, IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TModel, TEntity, TId}"/> class.
        /// </summary>
        /// <param name="sqlConnection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        /// <param name="mappingFunc">A <see cref="Func{TResult}"/> to map a result set to the entity.</param>
        protected RapidLaunchPublisherRepository(SqlConnection sqlConnection, IPublishingBus publishingBus, Func<TModel, TEntity> mappingFunc)
            : base(sqlConnection, mappingFunc)
        {
            _publishingBus = publishingBus;
        }
    }
}
