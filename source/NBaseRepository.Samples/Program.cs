// <copyright file="Program.cs" company="Michael Bradvica LLC">
// Copyright (c) Michael Bradvica LLC. All rights reserved.
// </copyright>

using System.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using NBaseRepository.Common;
using NBaseRepository.Samples.GuidPrimary.Animal;
using NBaseRepository.Samples.GuidPrimary.Person;

namespace NBaseRepository.Samples
{
    public class Program
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="args"></param>
        /// <returns>A <see cref="Task"/> representing the result of the asynchronous operation.</returns>
        public static async Task Main(string[] args)
        {
            var collection = new ServiceCollection();

            collection.AddScoped(_ => new SqlConnection("Data Source=(LocalDb)\\MSSqlLocalDB;Initial Catalog=NPD;Integrated Security=True"));

            collection.AddTransient<SqlBuilder<GuidPerson, Guid>, PersonSqlBuilder>();
            collection.AddTransient<SqlBuilder<GuidAnimal, Guid>, AnimalSqlBuilder>();

            collection.AddTransient<IPersonRepository, PersonRepository>();
            collection.AddTransient<IAnimalRepository, AnimalRepository>();

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
        }
    }
}