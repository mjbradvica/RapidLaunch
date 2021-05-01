namespace NBaseRepository.Tests.LongPrimary
{
    using NBaseRepository.LongPrimary;

    public class LongPerson : ILongEntity
    {
        public LongPerson()
        {
            Id = 123;
        }

        public long Id { get; }
    }
}
