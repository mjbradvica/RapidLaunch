// <copyright file="AircraftType.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace RapidLaunch.EF.Samples.AircraftTypes
{
    /// <summary>
    /// Sample entity for aircraft types.
    /// </summary>
    public class AircraftType : AggregateRoot
    {
        /// <summary>
        /// Returns an empty aircraft type.
        /// </summary>
        /// <returns>A new instance of an empty <see cref="AircraftType"/>.</returns>
        public static AircraftType Empty()
        {
            return new AircraftType();
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Id: {Id}";
        }
    }
}
