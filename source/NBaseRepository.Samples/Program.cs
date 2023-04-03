namespace NBaseRepository.Samples
{
    using System.Data.SqlClient;
    using Common;
    using Customers;
    using Microsoft.Extensions.DependencyInjection;

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var collection = new ServiceCollection();

            collection.AddScoped(_ => new SqlConnection("Data Source=(LocalDb)\\MSSqlLocalDB;Initial Catalog=NBaseRepositorySample;Integrated Security=True"));
            collection.AddTransient<SqlBuilder<Customer, Guid>, CustomerSqlBuilder>();
            collection.AddTransient<ICustomerRepository, CustomerRepository>();

            var serviceProvider = collection.BuildServiceProvider();

            var customerRepository = serviceProvider.GetRequiredService<ICustomerRepository>();

            //var allCustomers = await customerRepository.GetAllEntitiesAsync();

            //foreach (var customer in allCustomers)
            //{
            //    Console.WriteLine(customer);
            //}

            var newCustomer = new Customer(Guid.NewGuid(), "Mickey", 160);

            await customerRepository.AddEntityAsync(newCustomer);

            // var updateCustomer = await customerRepository.UpdateEntityAsync(newCustomer);

            var allCustomers = await customerRepository.GetAllEntitiesAsync();

            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}