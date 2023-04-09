namespace NBaseRepository.Samples
{
    using System.Data.SqlClient;
    using Common;
    using GuidPrimary.Animal;
    using GuidPrimary.Person;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
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