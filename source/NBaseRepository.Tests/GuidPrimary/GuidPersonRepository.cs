using NBaseRepository.EF.GuidPrimary;

namespace NBaseRepository.Tests.GuidPrimary
{
    using Microsoft.EntityFrameworkCore;

    internal class GuidPersonRepository : NBaseRepository<Person>
    {
        public GuidPersonRepository(DbContext context)
            : base(context)
        {
        }
    }
}
