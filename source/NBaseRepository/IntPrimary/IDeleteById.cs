// <copyright file="IDeleteById.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.IntPrimary
{
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="int"/>.
    /// </summary>
    public interface IDeleteById : IDeleteById<int>
    {
    }
}