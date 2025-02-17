// <copyright file="AirplaneRepository.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MongoDB.Driver;
using RapidLaunch.Mongo.Common;

namespace RapidLaunch.Mongo.Samples.Airplanes
{
    /// <inheritdoc />
    public class AirplaneRepository : RapidLaunchRepository<Airplane, Guid>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AirplaneRepository"/> class.
        /// </summary>
        /// <param name="mongoClient">Instance of the <see cref="MongoClient"/> class.</param>
        /// <param name="databaseName">The database name to use.</param>
        public AirplaneRepository(MongoClient mongoClient, string databaseName)
            : base(mongoClient, databaseName)
        {
        }
    }
}
