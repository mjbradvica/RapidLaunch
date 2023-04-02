namespace NBaseRepository.Tests.Common.IntPrimary
{
    using NBaseRepository.IntPrimary;

    internal class Person : IEntity
    {
        public Person(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
