namespace NBaseRepository.Samples.Customers
{
    using GuidPrimary;

    public class Customer : IEntity
    {
        public Customer(string name, int age)
            : this(Guid.NewGuid(), name, age)
        {
        }

        public Customer(Guid id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Guid Id { get; }

        public string Name { get; }

        public int Age { get; }

        public override string ToString()
        {
            return $"Id: {Id} Name: {Name} Age: {Age} \n";
        }
    }
}
