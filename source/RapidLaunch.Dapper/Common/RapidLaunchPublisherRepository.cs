﻿// <copyright file="RapidLaunchPublisherRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;
using Microsoft.Data.SqlClient;
using RapidLaunch.Common;

namespace RapidLaunch.Dapper.Common
{
    /// <inheritdoc />
    public abstract class RapidLaunchPublisherRepository<TRoot, TId> : RapidLaunchRepository<TRoot, TId>
        where TRoot : class, IAggregateRoot<TId>
    {
        private readonly IPublishingBus _publishingBus;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisherRepository{TEntity, TId}"/> class.
        /// </summary>
        /// <param name="connection">An instance of the <see cref="SqlConnection"/> class.</param>
        /// <param name="publishingBus">An instance of the <see cref="IPublishingBus"/> interface.</param>
        protected RapidLaunchPublisherRepository(
            SqlConnection connection,
            IPublishingBus publishingBus)
            : base(connection)
        {
            _publishingBus = publishingBus;
        }
    }
}
