// <copyright file="RapidLaunchPublisher.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using NMediation.Abstractions;

namespace RapidLaunch.Common
{
    /// <inheritdoc />
    public class RapidLaunchPublisher : IPublishingBus<IOccurrence>
    {
        private readonly IMediation _mediation;

        /// <summary>
        /// Initializes a new instance of the <see cref="RapidLaunchPublisher"/> class.
        /// </summary>
        /// <param name="mediation">An instance of the <see cref="IMediation"/> interface.</param>
        public RapidLaunchPublisher(IMediation mediation)
        {
            _mediation = mediation;
        }

        /// <inheritdoc/>
        public async Task PublishDomainEvent(IOccurrence domainEvent, CancellationToken cancellationToken = default)
        {
            await _mediation.Publish(domainEvent, cancellationToken);
        }
    }
}
