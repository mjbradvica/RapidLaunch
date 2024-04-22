// <copyright file="Airplane.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace RapidLaunch.Mongo.Samples.Airplanes
{
    /// <summary>
    /// Sample persistence entity.
    /// </summary>
    public class Airplane : AggregateRoot
    {
        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}
