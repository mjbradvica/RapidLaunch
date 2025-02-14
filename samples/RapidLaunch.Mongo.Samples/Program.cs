// <copyright file="Program.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using RapidLaunch.Mongo.Samples.Airplanes;

namespace RapidLaunch.Mongo.Samples
{
    /// <summary>
    /// Sample entry class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Sample entry function.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        private static async Task Main()
        {
            if (BsonSerializer.LookupSerializer(typeof(GuidSerializer)) == null)
            {
                BsonSerializer.TryRegisterSerializer(new GuidSerializer());
            }

            if (!BsonClassMap.IsClassMapRegistered(typeof(Airplane)))
            {
                BsonClassMap.RegisterClassMap<Airplane>(map =>
                {
                    map.AutoMap();
                });
            }

            const string connectionString = "mongodb://localhost:27017";

            var client = new MongoClient(connectionString);

            var repo = new AirplaneRepository(client, "RapidLaunch");

            var airplanes = new List<Airplane>
            {
                new Airplane(),
                new Airplane(),
            };

            var result = await repo.AddRootsAsync(airplanes);
            var allAirplanes = await repo.GetAllEntitiesAsync();

            foreach (var airplane in allAirplanes)
            {
                Console.WriteLine(airplane);
            }
        }
    }
}
