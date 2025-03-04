﻿// <copyright file="IGetAllRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all roots.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllRoots<TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves all roots of type from a collection.
        /// </summary>
        /// <returns>An of <see cref="List{TRoot}"/>.</returns>
        List<TRoot> GetAllRoots();
    }
}