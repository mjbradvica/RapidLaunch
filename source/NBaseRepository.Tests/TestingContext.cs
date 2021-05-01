namespace NBaseRepository.Tests
{
    using GuidPrimary;
    using IntPrimary;
    using LongPrimary;
    using Microsoft.EntityFrameworkCore;

    public sealed class TestingContext : DbContext
    {
        public TestingContext()
            : base(new DbContextOptionsBuilder().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PaserAirways.Routes;Trusted_Connection=True;MultipleActiveResultSets=true").Options)
        {
            Database.EnsureCreated();
        }

        public DbSet<GuidPerson> GuidPersons { get; set; }

        public DbSet<IntPerson> IntPersons { get; set; }

        public DbSet<LongPerson> LongPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidPerson>().HasKey(guidPerson => guidPerson.Id);
            modelBuilder.Entity<IntPerson>().HasKey(intPerson => intPerson.Id);
            modelBuilder.Entity<LongPerson>().HasKey(longPerson => longPerson.Id);
        }
    }
}
