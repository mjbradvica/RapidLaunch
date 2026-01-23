// <copyright file="BaseIntegrationTest.cs" company="Simplex Software LLC">
// Copyright (c) Simplex Software LLC. All rights reserved.
// </copyright>

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;

namespace RapidLaunch.Mongo.Tests.Helpers
{
    /// <summary>
    /// Base class for all integration tests.
    /// </summary>
    public abstract class BaseIntegrationTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseIntegrationTest"/> class.
        /// </summary>
        protected BaseIntegrationTest()
        {
            BsonSerializer.TryRegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            TestHelpers.ClearDatabase();
        }
    }
}
