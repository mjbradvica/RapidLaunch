// <copyright file="IDeleteById.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace NBaseRepository.LongPrimary
{
    using NBaseRepository.Common;

    /// <summary>
    /// An interface used to describe a class that can delete an entity by <see cref="long"/>.
    /// </summary>
    public interface IDeleteById : IDeleteById<long>
    {
    }
}