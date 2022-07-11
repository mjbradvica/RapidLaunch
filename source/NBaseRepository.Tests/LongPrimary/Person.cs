namespace NBaseRepository.Tests.LongPrimary
{
    using NBaseRepository.LongPrimary;

    public class Person : IEntity
    {
        public Person()
        {
            Id = 123;
        }

        public long Id { get; }
    }
}
