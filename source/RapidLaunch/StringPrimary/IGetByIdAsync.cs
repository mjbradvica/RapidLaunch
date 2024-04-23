// <copyright file="IGetByIdAsync.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.StringPrimary;
using RapidLaunch.Common;

namespace RapidLaunch.StringPrimary
{
    /// <inheritdoc />
    public interface IGetByIdAsync<TEntity> : IGetByIdAsync<TEntity, string>
        where TEntity : IAggregateRoot
    {
    }
}
