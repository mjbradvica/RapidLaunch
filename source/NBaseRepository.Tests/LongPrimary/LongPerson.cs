using NBaseRepository.Long;

namespace NBaseRepository.Tests.LongPrimary
{
    public class LongPerson : ILongEntity
    {
        public LongPerson()
        {
            Id = 123;
        }

        public long Id { get; }
    }
}
