// <copyright file="RapidLaunchStatus.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;

namespace RapidLaunch
{
    /// <summary>
    /// Status class to indicate the result of a persistence operation.
    /// </summary>
    public class RapidLaunchStatus
    {
        private RapidLaunchStatus(bool isFailure, Exception exception)
        {
            IsFailure = isFailure;
            Exception = exception;
        }

        /// <summary>
        /// Gets a value indicating whether the operation failed.
        /// </summary>
        public bool IsFailure { get; }

        /// <summary>
        /// Gets the exception in the event of a isFailure.
        /// </summary>
        public Exception Exception { get; }

        /// <summary>
        /// Returns a <see cref="RapidLaunchStatus"/> with a success value.
        /// </summary>
        /// <returns>A new instance of a <see cref="RapidLaunchStatus"/>.</returns>
        public static RapidLaunchStatus Success()
        {
            return new RapidLaunchStatus(false, new EmptyException());
        }

        /// <summary>
        /// Returns a <see cref="RapidLaunchStatus"/> with a failed value.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> returned the operation.</param>
        /// <returns>A new instance of a <see cref="RapidLaunchStatus"/>.</returns>
        public static RapidLaunchStatus Failed(Exception exception)
        {
            return new RapidLaunchStatus(true, exception);
        }
    }
}
