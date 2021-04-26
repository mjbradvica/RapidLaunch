namespace NBaseRepository.Tests
{
    using Microsoft.EntityFrameworkCore;

    internal sealed class TestContext : DbContext
    {
        public TestContext()
            : base(new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PaserAirways.Routes;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {
            Database.EnsureCreated();
        }

        public DbSet<GuidPerson> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidPerson>().HasKey(x => x.Id);
        }
    }
}
