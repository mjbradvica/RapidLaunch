// <copyright file="IEntity.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.LongPrimary
{
    /// <summary>
    /// An interface used to describe a class that has an Id of type <see cref="long"/>.
    /// </summary>
    public interface IEntity : IEntity<long>
    {
    }
}
