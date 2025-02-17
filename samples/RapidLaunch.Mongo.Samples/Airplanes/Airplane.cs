// <copyright file="Airplane.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace RapidLaunch.Mongo.Samples.Airplanes
{
    /// <summary>
    /// Sample persistence root.
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
