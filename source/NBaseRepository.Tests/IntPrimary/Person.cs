namespace NBaseRepository.Tests.IntPrimary
{
    using NBaseRepository.IntPrimary;

    public class Person : IEntity
    {
        public Person()
        {
            Id = 123;
        }

        public int Id { get; }
    }
}
