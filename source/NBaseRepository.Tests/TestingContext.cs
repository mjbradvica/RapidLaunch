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

        public DbSet<GuidPrimary.Person> GuidPersons { get; set; }

        public DbSet<IntPrimary.Person> IntPersons { get; set; }

        public DbSet<LongPrimary.Person> LongPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GuidPrimary.Person>().HasKey(guidPerson => guidPerson.Id);
            modelBuilder.Entity<IntPrimary.Person>().HasKey(intPerson => intPerson.Id);
            modelBuilder.Entity<LongPrimary.Person>().HasKey(longPerson => longPerson.Id);
        }
    }
}
