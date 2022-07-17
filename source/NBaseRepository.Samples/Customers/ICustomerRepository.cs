namespace NBaseRepository.Samples.Customers
{
    using GuidPrimary;

    public interface ICustomerRepository :
        IAddEntityAsync<Customer>,
        IUpdateEntityAsync<Customer>,
        IGetAllEntitiesAsync<Customer>
    {
    }
}
