using NBaseRepository.Int;

namespace NBaseRepository.Tests.IntPrimary
{
    public class IntPerson : IIntEntity
    {
        public IntPerson()
        {
            Id = 123;
        }

        public int Id { get; }
    }
}
