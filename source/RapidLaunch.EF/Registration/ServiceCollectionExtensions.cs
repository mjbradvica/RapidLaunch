// <copyright file="ServiceCollectionExtensions.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RapidLaunch.Common;
using RapidLaunch.EF.Common;

namespace RapidLaunch.EF.Registration
{
    /// <summary>
    /// Extension methods to allow RapidLaunch to easier integrate into the DI container.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Registers RapidLaunch with the DI container.
        /// </summary>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/>.</param>
        /// <param name="assemblies">A <see cref="IEnumerable{T}"/> of <see cref="Assembly"/> to register from.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddRapidLaunch(this IServiceCollection services, params Assembly[] assemblies)
        {
            services.AddTransient<IPublishingBus, RapidLaunchPublisher>();

            foreach (var assembly in assemblies)
            {
                RegisterRepositories(services, assembly, typeof(RapidLaunchRepository<,>));
                RegisterRepositories(services, assembly, typeof(RapidLaunchPublisherRepository<,>));
                RegisterRapidLaunchHandlers(services, assembly);
            }

            return services;
        }

        /// <summary>
        /// Registers RapidLaunch with the DI container.
        /// </summary>
        /// <typeparam name="TPublishingBus">The type of the publishing bus.</typeparam>
        /// <param name="services">An instance of the <see cref="IServiceCollection"/>.</param>
        /// <param name="assemblies">A <see cref="IEnumerable{T}"/> of <see cref="Assembly"/> to register from.</param>
        /// <returns>The service collection.</returns>
        public static IServiceCollection AddRapidLaunch<TPublishingBus>(this IServiceCollection services, params Assembly[] assemblies)
            where TPublishingBus : class, IPublishingBus
        {
            services.AddTransient<IPublishingBus, TPublishingBus>();

            foreach (var assembly in assemblies)
            {
                RegisterRepositories(services, assembly, typeof(RapidLaunchRepository<,>));
                RegisterRepositories(services, assembly, typeof(RapidLaunchPublisherRepository<,>));
            }

            return services;
        }

        private static void RegisterRepositories(IServiceCollection services, Assembly assembly, Type baseType)
        {
            assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface)
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == baseType)
                .ToList()
                .ForEach(concreteType =>
                {
                    if (concreteType.BaseType != null)
                    {
                        services.AddTransient(
                            concreteType.GetInterfaces().First(interfaceType => !interfaceType.IsGenericType),
                            concreteType);
                    }
                });
        }

        private static void RegisterRapidLaunchHandlers(IServiceCollection services, Assembly assembly)
        {
            assembly.GetTypes()
                .Where(type => !type.IsAbstract && !type.IsInterface)
                .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType == typeof(IDomainEventHandler<>)))
                .ToList()
                .ForEach(concreteType =>
                {
                    services.AddTransient(concreteType, typeof(IDomainEventHandler<>));
                });
        }
    }
}
