// <copyright file="AircraftType.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;

namespace RapidLaunch.EF.Samples.AircraftTypes
{
    /// <summary>
    /// Sample root for aircraft types.
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
