namespace NBaseRepository.Samples.Customers
{
    using GuidPrimary;

    public class CustomerSqlBuilder : GuidSqlBuilder<Customer>
    {
        public CustomerSqlBuilder()
            : base("dbo.Customers")
        {
        }

        protected override Func<Customer, IReadOnlyList<string>> EntityProperties { get; } = customer =>
            new List<string> { customer.Id.ToString(), customer.Name, customer.Age.ToString() };
    }
}
