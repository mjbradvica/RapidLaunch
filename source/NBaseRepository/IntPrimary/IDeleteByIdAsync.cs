// <copyright file="IDeleteByIdAsync.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using NBaseRepository.Common;

namespace NBaseRepository.IntPrimary
{
    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="int"/>.
    /// </summary>
    public interface IDeleteByIdAsync : IDeleteByIdAsync<int>
    {
    }
}
