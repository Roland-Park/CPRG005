using CPRG005.Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CPRG005.Final.Data
{
    public class MarinaDbContext : DbContext
    {
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Authorize> Authorizations { get; set; }
        public DbSet<Dock> Docks { get; set; }
        public DbSet<Lease> Leases { get; set; }
        public DbSet<LeaseType> LeaseTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Authorize> Slips { get; set; }
        public MarinaDbContext(DbContextOptions<MarinaDbContext> options) : base(options){ }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LeaseType>().HasData(
                new LeaseType() { Id = 1, Name = "Daily", StandardRateAmount = 20.00m },
                new LeaseType() { Id = 1, Name = "Weekly", StandardRateAmount = 80.00m },
                new LeaseType() { Id = 2, Name = "Monthly", StandardRateAmount = 200.00m },
                new LeaseType() { Id = 3, Name = "Yearly", StandardRateAmount = 2000.00m }
                );

            modelBuilder.Entity<Location>().HasData(
                new Location() { Id = 1, Name = "Inland Lake" },
                new Location() { Id = 2, Name = "San Diego" }
                );
        }
    }
}
