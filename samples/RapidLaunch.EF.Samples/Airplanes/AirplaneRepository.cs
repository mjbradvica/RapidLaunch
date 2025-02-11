// <copyright file="AirplaneRepository.cs" company="Wayne John Whistler LLC">
// Copyright (c) Wayne John Whistler LLC. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using RapidLaunch.EF.GuidPrimary;

namespace RapidLaunch.EF.Samples.Airplanes
{
	/// <summary>
	/// Persistence class for the <see cref="Airplane"/> class.
	/// </summary>
	public class AirplaneRepository : RapidLaunchRepository<Airplane>, IAirplaneRepository
    {
        private static readonly Func<IQueryable<Airplane>, IQueryable<Airplane>> IncludeFunc =
            airplanes => airplanes.Include(airplane => airplane.AircraftType);

        /// <summary>
        /// Initializes a new instance of the <see cref="AirplaneRepository"/> class.
        /// </summary>
        /// <param name="context">An instance of the <see cref="SampleContext"/> class.</param>
        public AirplaneRepository(DbContext context)
            : base(context, IncludeFunc)
        {
        }
    }
}
