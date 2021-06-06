using CPRG005.Final.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
                new LeaseType() { Id = 1, Name = "Daily", StandardRateAmount = 25.50m },
                new LeaseType() { Id = 2, Name = "Weekly", StandardRateAmount = 145.50m },
                new LeaseType() { Id = 3, Name = "Monthly", StandardRateAmount = 500.00m },
                new LeaseType() { Id = 4, Name = "Yearly", StandardRateAmount = 5000.00m }
                );

            modelBuilder.Entity<Location>().HasData(
                new Location() { Id = 1, Name = "Inland Lake" },
                new Location() { Id = 2, Name = "San Diego" }
                );

            modelBuilder.Entity<Dock>().HasData(
                new Dock() { Id = 1, LocationId = 1, Name = "Dock A", HasWaterService = true, HasElectricService = true},
                new Dock() { Id = 2, LocationId = 1, Name = "Dock B", HasWaterService = true, HasElectricService = false},
                new Dock() { Id = 3, LocationId = 2, Name = "Dock C", HasWaterService = false, HasElectricService = false }
                );

            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(8, 16, 1, 10, 1)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(8, 18, 1, 10, 11)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(8, 20, 1, 10, 21)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 22, 1, 10, 31)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 24, 1, 10, 41)
                );

            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(8, 16, 2, 10, 51)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(8, 18, 2, 10, 61)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(8, 20, 2, 10, 71)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 22, 2, 10, 81)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 24, 2, 10, 91)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 26, 2, 10, 101)
                );

            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 22, 3, 10, 111)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 24, 3, 10, 121)
                );
            modelBuilder.Entity<Slip>().HasData(
                CreateSlips(10, 28, 3, 10, 131)
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { Id = 1, FirstName = "John", LastName = "Doe", Phone = "555-545-1212", City = "Phoenix" }
                );

            modelBuilder.Entity<Authorize>().HasData(
                new Authorize() { Id = 1, UserName = "jdoe", Password = "10000.z2GCnoFXWCmurPJfIBlFZg==.6m4/OO/bkctGxXSjFJt+fdVRTHvh+LVVb4aVM+WF8zk=", CustomerId = 1 }
                );

            modelBuilder.Entity<Lease>().HasData(
                new Lease() { Id = 1, StartDate = new DateTime(2007, 12, 9), EndDate = new DateTime(2008, 12, 9), SlipId = 3, CustomerId = 1, LeaseTypeId = 4 }
                );
        }

        private List<Slip>CreateSlips(int w, int l, int dockId, int count, int startingId)
        {
            var slips = new List<Slip>();
            for(int i = startingId; i < count + startingId; i++)
            {
                slips.Add(new Slip() { Id = i, Width = w, Length = l, DockId = dockId });
            }

            return slips;
        }
    }
}
