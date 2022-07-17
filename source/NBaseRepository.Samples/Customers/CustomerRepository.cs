namespace NBaseRepository.Samples.Customers
{
    using System.Data.SqlClient;
    using Common;
    using NBaseRepository.ADO.GuidPrimary;

    public class CustomerRepository : NBaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SqlConnection sqlConnection, SqlBuilder<Customer, Guid> sqlBuilder)
            : base(sqlConnection, sqlBuilder, reader => new Customer(reader.GetGuid(0), reader.GetString(1), reader.GetInt32(2)))
        {
        }
    }
}
