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

            collection.AddScoped(_ => new SqlConnection("Data Source=(LocalDb)\\MSSqlLocalDB;Initial Catalog=NPredicateBuilderTest;Integrated Security=True"));
            collection.AddTransient<SqlBuilder<Customer, Guid>, CustomerSqlBuilder>();
            collection.AddTransient<ICustomerRepository, CustomerRepository>();

            var serviceProvider = collection.BuildServiceProvider();

            var customerRepository = serviceProvider.GetRequiredService<ICustomerRepository>();

            //var allCustomers = await customerRepository.GetAllEntitiesAsync();

            //foreach (var customer in allCustomers)
            //{
            //    Console.WriteLine(customer);
            //}

            var newCustomer = new Customer(Guid.Parse("88732EE1-8DD5-4E49-BA55-57BDE7510409"), "Mickey", 160);

            var updateCustomer = await customerRepository.UpdateEntityAsync(newCustomer);

            var allCustomers = await customerRepository.GetAllEntitiesAsync();

            foreach (var customer in allCustomers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}