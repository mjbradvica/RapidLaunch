namespace NBaseRepository.Tests.GuidPrimary
{
    using EF;
    using Microsoft.EntityFrameworkCore;
    using NBaseRepository.EF.GuidPrimary;

    internal class GuidPersonRepository : BaseGuidRepository<Person>
    {
        public GuidPersonRepository(DbContext context)
            : base(context)
        {
        }
    }
}
