namespace NBaseRepository.Tests.IntPrimary
{
    using NBaseRepository.IntPrimary;

    public class IntPerson : IIntEntity
    {
        public IntPerson()
        {
            Id = 123;
        }

        public int Id { get; }
    }
}
