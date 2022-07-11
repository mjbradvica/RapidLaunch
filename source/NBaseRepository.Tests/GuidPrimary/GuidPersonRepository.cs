namespace NBaseRepository.Tests.GuidPrimary
{
    using EF;
    using Microsoft.EntityFrameworkCore;

    internal class GuidPersonRepository : BaseGuidRepository<Person>
    {
        public GuidPersonRepository(DbContext context)
            : base(context)
        {
        }
    }
}
