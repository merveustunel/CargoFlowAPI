#nullable enable
using CargoFlow.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoFlow.DataAccess
{
    public static class SeedDataExtensions
    {
        public static async Task SeedDevelopmentDataAsync(this CargoFlowDbContext context)
        {
            // Apply pending migrations
            await context.Database.MigrateAsync();

            // Check if data already exists
            if (await context.Customers.AnyAsync() || await context.Shipments.AnyAsync())
            {
                return;
            }

            // Seed customers
            var customers = new[]
            {
                new Customer
                {
                    FirstName = "John",
                    LastName = "Smith",
                    Email = "john.smith@example.com",
                    PhoneNumber = "+1-555-0101",
                    CreatedDate = DateTime.UtcNow
                },
                new Customer
                {
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    Email = "sarah.johnson@example.com",
                    PhoneNumber = "+1-555-0102",
                    CreatedDate = DateTime.UtcNow
                },
                new Customer
                {
                    FirstName = "Michael",
                    LastName = "Chen",
                    Email = "michael.chen@example.com",
                    PhoneNumber = "+1-555-0103",
                    CreatedDate = DateTime.UtcNow
                },
                new Customer
                {
                    FirstName = "Emma",
                    LastName = "Wilson",
                    Email = "emma.wilson@example.com",
                    PhoneNumber = "+1-555-0104",
                    CreatedDate = DateTime.UtcNow
                },
                new Customer
                {
                    FirstName = "David",
                    LastName = "Martinez",
                    Email = "david.martinez@example.com",
                    PhoneNumber = "+1-555-0105",
                    CreatedDate = DateTime.UtcNow
                }
            };

            await context.Customers.AddRangeAsync(customers);
            await context.SaveChangesAsync();

            // Seed shipments
            var shipments = new[]
            {
                new Shipment
                {
                    TrackingNumber = "SHP-2026-001",
                    Origin = "New York, NY",
                    Destination = "Los Angeles, CA",
                    Weight = 150.5m,
                    Status = ShipmentStatus.InTransit,
                    CreatedDate = DateTime.UtcNow.AddDays(-5)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-002",
                    Origin = "Chicago, IL",
                    Destination = "Houston, TX",
                    Weight = 225.0m,
                    Status = ShipmentStatus.Delivered,
                    CreatedDate = DateTime.UtcNow.AddDays(-10)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-003",
                    Origin = "Boston, MA",
                    Destination = "Miami, FL",
                    Weight = 85.25m,
                    Status = ShipmentStatus.InWarehouse,
                    CreatedDate = DateTime.UtcNow.AddDays(-2)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-004",
                    Origin = "Seattle, WA",
                    Destination = "San Francisco, CA",
                    Weight = 320.75m,
                    Status = ShipmentStatus.InTransit,
                    CreatedDate = DateTime.UtcNow.AddDays(-3)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-005",
                    Origin = "Denver, CO",
                    Destination = "Phoenix, AZ",
                    Weight = 110.0m,
                    Status = ShipmentStatus.Created,
                    CreatedDate = DateTime.UtcNow
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-006",
                    Origin = "Atlanta, GA",
                    Destination = "Nashville, TN",
                    Weight = 275.50m,
                    Status = ShipmentStatus.Delivered,
                    CreatedDate = DateTime.UtcNow.AddDays(-15)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-007",
                    Origin = "Philadelphia, PA",
                    Destination = "Washington, DC",
                    Weight = 95.0m,
                    Status = ShipmentStatus.InTransit,
                    CreatedDate = DateTime.UtcNow.AddDays(-4)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-008",
                    Origin = "Dallas, TX",
                    Destination = "Austin, TX",
                    Weight = 160.0m,
                    Status = ShipmentStatus.Cancelled,
                    CreatedDate = DateTime.UtcNow.AddDays(-7)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-009",
                    Origin = "Minneapolis, MN",
                    Destination = "Milwaukee, WI",
                    Weight = 200.25m,
                    Status = ShipmentStatus.InWarehouse,
                    CreatedDate = DateTime.UtcNow.AddDays(-1)
                },
                new Shipment
                {
                    TrackingNumber = "SHP-2026-010",
                    Origin = "San Diego, CA",
                    Destination = "Las Vegas, NV",
                    Weight = 135.75m,
                    Status = ShipmentStatus.Delivered,
                    CreatedDate = DateTime.UtcNow.AddDays(-12)
                }
            };

            await context.Shipments.AddRangeAsync(shipments);
            await context.SaveChangesAsync();
        }
    }
}
