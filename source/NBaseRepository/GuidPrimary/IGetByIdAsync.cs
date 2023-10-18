// <copyright file="IGetByIdAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using NBaseRepository.Common;

namespace NBaseRepository.GuidPrimary
{
    public interface IGetByIdAsync<TEntity> : IGetByIdAsync<TEntity, Guid>
        where TEntity : IEntity
    {
    }
}
