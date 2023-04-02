namespace NBaseRepository.Tests.Common.LongPrimary
{
    using NBaseRepository.LongPrimary;

    internal class Person : IEntity
    {
        public Person(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}
