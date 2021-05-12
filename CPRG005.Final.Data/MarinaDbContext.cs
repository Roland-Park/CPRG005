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
            modelBuilder.Entity<LeaseType>().HasData(
                new LeaseType() { Id = 1, Name = "Student", StandardRateAmount = 200.00m },
                new LeaseType() { Id = 2, Name = "Parent", StandardRateAmount = 200.00m },
                new LeaseType() { Id = 3, Name = "Tutor", StandardRateAmount = 200.00m },
                new LeaseType() { Id = 4, Name = "Admin", StandardRateAmount = 200.00m }
                );
        }
    }
}
