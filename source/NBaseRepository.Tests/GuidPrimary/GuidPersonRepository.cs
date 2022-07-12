namespace NBaseRepository.Tests.GuidPrimary
{
    using Microsoft.EntityFrameworkCore;
    using NBaseRepository.EF.GuidPrimary;

    internal class GuidPersonRepository : NBaseRepository<Person>
    {
        public GuidPersonRepository(DbContext context)
            : base(context)
        {
        }
    }
}
