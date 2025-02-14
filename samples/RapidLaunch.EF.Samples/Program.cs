﻿// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RapidLaunch.EF.Registration;
using RapidLaunch.EF.Samples.Airplanes;

namespace RapidLaunch.EF.Samples
{
    /// <summary>
    /// Samples entry class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sample entry method.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task Main()
        {
            var collection = new ServiceCollection();

            collection.AddRapidLaunch(Assembly.GetExecutingAssembly());

            collection.AddDbContext<DbContext, SampleContext>(builder => builder.UseSqlServer("Server=.\\SQLExpress;Database=RapidLaunch.Samples.EF;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True;TrustServerCertificate=true"));

            var provider = collection.BuildServiceProvider();

            var airplaneRepo = provider.GetRequiredService<IAirplaneRepository>();

            // await airplaneRepo.AddRootAsync(new Airplane(new AircraftType()));
            var airplanes = await airplaneRepo.GetAllEntitiesAsync();

            foreach (var airplane in airplanes)
            {
                Console.WriteLine(airplane);
            }
        }
    }
}
