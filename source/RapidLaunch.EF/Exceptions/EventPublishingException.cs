// <copyright file="EventPublishingException.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using ClearDomain.Common;

namespace RapidLaunch.EF.Exceptions
{
    /// <summary>
    /// An exception thrown when a <see cref="IDomainEvent"/> fails to publish.
    /// </summary>
    public class EventPublishingException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventPublishingException"/> class.
        /// </summary>
        /// <param name="exception">The exception throw during the operation.</param>
        /// <param name="domainEvent">The domain event being published when the exception was thrown.</param>
        public EventPublishingException(Exception exception, IDomainEvent domainEvent)
            : base("An error occurred during the publishing of an event. Did you have a handler registered?", exception)
        {
            DomainEvent = domainEvent;
        }

        /// <summary>
        /// Gets the <see cref="IDomainEvent"/> on which the exception occurred at.
        /// </summary>
        public IDomainEvent DomainEvent { get; }
    }
}
