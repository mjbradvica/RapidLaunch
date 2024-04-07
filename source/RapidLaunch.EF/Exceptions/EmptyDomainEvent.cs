// <copyright file="EmptyDomainEvent.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.Common;

namespace RapidLaunch.EF.Exceptions
{
    /// <summary>
    /// Empty <see cref="IDomainEvent"/> used to avoid initial nullable value.
    /// </summary>
    internal class EmptyDomainEvent : IDomainEvent
    {
    }
}
