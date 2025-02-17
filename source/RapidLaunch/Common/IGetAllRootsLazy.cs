// <copyright file="IGetAllRootsLazy.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can retrieve all roots lazily.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IGetAllRootsLazy<out TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Retrieves all roots from a collection that may still be queried against.
        /// </summary>
        /// <returns>An <see cref="IEnumerable{TRoot}"/>.</returns>
        IQueryable<TRoot> GetAllRootsLazy();
    }
}
