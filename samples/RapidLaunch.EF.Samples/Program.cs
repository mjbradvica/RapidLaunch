// <copyright file="Program.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using RapidLaunch.EF.Registration;

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
        public static void Main()
        {
            var collection = new ServiceCollection();

            collection.AddRapidLaunch(Assembly.GetExecutingAssembly());

            var provider = collection.BuildServiceProvider();
        }
    }
}
