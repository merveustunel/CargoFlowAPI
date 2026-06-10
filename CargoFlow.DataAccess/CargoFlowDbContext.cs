#nullable enable
using CargoFlow.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoFlow.DataAccess
{
    public class CargoFlowDbContext : DbContext
    {
        public CargoFlowDbContext(DbContextOptions<CargoFlowDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Shipment> Shipments { get; set; } = null!;

        public DbSet<Driver> Drivers { get; set; } = null!;

        public DbSet<Vehicle> Vehicles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Shipment>().ToTable("Shipments");
            modelBuilder.Entity<Driver>().ToTable("Drivers");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");

            // Configure basic relationships using shadow foreign keys so entities remain clean.
            modelBuilder.Entity<Shipment>()
                .HasOne<Customer>()
                .WithMany()
                .HasForeignKey("CustomerId")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Shipment>()
                .HasOne<Driver>()
                .WithMany()
                .HasForeignKey("DriverId")
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Shipment>()
                .HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey("VehicleId")
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
