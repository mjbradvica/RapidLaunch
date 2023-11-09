// <copyright file="Program.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using NBaseRepository.ADO.Registrations;
using NBaseRepository.Samples.GuidPrimary.Animal;
using NBaseRepository.Samples.GuidPrimary.Person;

namespace NBaseRepository.Samples
{
    /// <summary>
    /// Sample application main entry point.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main entry point for the sample application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var collection = new ServiceCollection();

            collection.AddNBaseRepository(
                "Data Source=(LocalDb)\\MSSqlLocalDB;Initial Catalog=NBaseRepository.Samples;Integrated Security=True",
                Assembly.GetExecutingAssembly());

            var serviceProvider = collection.BuildServiceProvider();

            var animalRepository = serviceProvider.GetRequiredService<IAnimalRepository>();
            var customerRepository = serviceProvider.GetRequiredService<IPersonRepository>();

            var animal = new GuidAnimal("Billy Bob");

            // await animalRepository.AddEntityAsync(animal);
            var customer = new GuidPerson("Mike", 32, animal);

            // await customerRepository.AddEntityAsync(customer);
            var customers = await customerRepository.GetAllEntitiesAsync();

            foreach (var person in customers)
            {
                Console.WriteLine(person);
            }

            var custom = await customerRepository.GetByIdAsync(Guid.Parse("073C2C9D-16F6-43F6-85FD-6450FCAD53CC"));

            var resultSet = await customerRepository.DeleteByIdAsync(Guid.Parse("073C2C9D-16F6-43F6-85FD-6450FCAD53CC"));

            Console.WriteLine(resultSet);
        }
    }
}