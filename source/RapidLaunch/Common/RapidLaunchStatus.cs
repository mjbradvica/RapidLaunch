// <copyright file="RapidLaunchStatus.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

namespace RapidLaunch.Common
{
    /// <summary>
    /// Status class to indicate the result of a persistence operation.
    /// </summary>
    public class RapidLaunchStatus
    {
        private RapidLaunchStatus(bool isFailure, Exception exception, int rowCount)
        {
            IsFailure = isFailure;
            Exception = exception;
            RowCount = rowCount;
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
        /// Gets the rows touched by the operation.
        /// </summary>
        public int RowCount { get; }

        /// <summary>
        /// Returns a <see cref="RapidLaunchStatus"/> with a success value.
        /// </summary>
        /// <param name="rowCount">The number of rows affected by the operation.</param>
        /// <returns>A new instance of a <see cref="RapidLaunchStatus"/>.</returns>
        public static RapidLaunchStatus Success(int rowCount)
        {
            return new RapidLaunchStatus(false, new EmptyException(), rowCount);
        }

        /// <summary>
        /// Returns a <see cref="RapidLaunchStatus"/> with a failed value.
        /// </summary>
        /// <param name="exception">The <see cref="Exception"/> returned the operation.</param>
        /// <returns>A new instance of a <see cref="RapidLaunchStatus"/>.</returns>
        public static RapidLaunchStatus Failed(Exception exception)
        {
            const int failedRows = 0;

            return new RapidLaunchStatus(true, exception, failedRows);
        }
    }
}
