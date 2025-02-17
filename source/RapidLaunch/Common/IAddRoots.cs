// <copyright file="IAddRoots.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.Common
{
    /// <summary>
    /// An interface used to describe a class that can add multiple roots at one time.
    /// </summary>
    /// <typeparam name="TRoot">The type of the root.</typeparam>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public interface IAddRoots<in TRoot, TId>
        where TRoot : IAggregateRoot<TId>
    {
        /// <summary>
        /// Adds multiple roots to a collection.
        /// </summary>
        /// <param name="roots">A <see cref="IEnumerable{TRoot}"/> to be added.</param>
        /// <returns>The result contains the number of state entries written to the database.</returns>
        RapidLaunchStatus AddRoots(IEnumerable<TRoot> roots);
    }
}