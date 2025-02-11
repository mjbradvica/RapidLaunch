// <copyright file="Airplane.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using ClearDomain.GuidPrimary;
using RapidLaunch.EF.Samples.AircraftTypes;

namespace RapidLaunch.EF.Samples.Airplanes
{
    /// <summary>
    /// Sample entity for rapid launch.
    /// </summary>
    public class Airplane : AggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Airplane"/> class.
        /// </summary>
        /// <param name="aircraftType">The <see cref="AircraftType"/> for the plane.</param>
        public Airplane(AircraftType aircraftType)
        {
            AircraftType = aircraftType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Airplane"/> class.
        /// </summary>
        public Airplane()
        {
            AircraftType = AircraftType.Empty();
        }

        /// <summary>
        /// Gets the aircraft type.
        /// </summary>
        public AircraftType AircraftType { get; }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"Id: {Id} - AircraftType: {AircraftType}";
        }
    }
}
