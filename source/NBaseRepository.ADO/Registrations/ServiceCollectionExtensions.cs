// <copyright file="ServiceCollectionExtensions.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NBaseRepository.ADO.GuidPrimary;
using NBaseRepository.Common;

namespace NBaseRepository.ADO.Registrations
{
    /// <summary>
    /// Methods for registering NBaseRepository.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all dependencies for NBaseRepository to the service collection.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/> interface.</param>
        /// <param name="connectionString">A connection string to an sql database.</param>
        /// <param name="assemblies">The assemblies to register in.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddNBaseRepository(this IServiceCollection services, string connectionString, params Assembly[] assemblies)
        {
            services.AddScoped(_ => new SqlConnection(connectionString));

            foreach (var assembly in assemblies)
            {
                var toreg = assembly.GetTypes()
                    .Where(type => !type.IsAbstract && !type.IsInterface)
                    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.BaseType != null && type.BaseType.BaseType.GetGenericTypeDefinition() == typeof(SqlBuilder<,>))
                    .ToList();

                toreg.ForEach(implementationType =>
                    {
                        if (implementationType.BaseType != null && implementationType.BaseType.BaseType != null)
                        {
                            services.AddTransient(implementationType.BaseType.BaseType, implementationType);
                        }
                    });

                RegisterRepositories(services, assembly, typeof(NBaseRepository<>));
            }

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services, Assembly assembly, Type baseType)
        {
            assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface)
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == baseType)
                .ToList()
                .ForEach(implementationType =>
                {
                    if (implementationType.BaseType != null)
                    {
                        services.AddTransient(implementationType.GetInterfaces().First(x => !x.IsGenericType), implementationType);
                    }
                });
        }
    }
}
