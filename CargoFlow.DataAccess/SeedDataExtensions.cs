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

            // Seed customers independently
            await SeedCustomersAsync(context);

            // Seed shipments independently
            await SeedShipmentsAsync(context);
        }

        private static async Task SeedCustomersAsync(CargoFlowDbContext context)
        {
            var existingCustomerCount = await context.Customers.CountAsync();

            // If we have at least 8 customers, don't add more
            if (existingCustomerCount >= 8)
            {
                return;
            }

            var demoCustomers = new[]
            {
                new Customer { FirstName = "John", LastName = "Smith", Email = "john.smith@example.com", PhoneNumber = "+90-532-123-4501", CreatedDate = DateTime.UtcNow },
                new Customer { FirstName = "Sarah", LastName = "Johnson", Email = "sarah.johnson@example.com", PhoneNumber = "+90-532-123-4502", CreatedDate = DateTime.UtcNow },
                new Customer { FirstName = "Michael", LastName = "Chen", Email = "michael.chen@example.com", PhoneNumber = "+90-532-123-4503", CreatedDate = DateTime.UtcNow },
                new Customer { FirstName = "Emma", LastName = "Wilson", Email = "emma.wilson@example.com", PhoneNumber = "+90-532-123-4504", CreatedDate = DateTime.UtcNow },
                new Customer { FirstName = "David", LastName = "Martinez", Email = "david.martinez@example.com", PhoneNumber = "+90-532-123-4505", CreatedDate = DateTime.UtcNow },
                new Customer { FirstName = "Lisa", LastName = "Anderson", Email = "lisa.anderson@example.com", PhoneNumber = "+90-532-123-4506", CreatedDate = DateTime.UtcNow },
                new Customer { FirstName = "Robert", LastName = "Taylor", Email = "robert.taylor@example.com", PhoneNumber = "+90-532-123-4507", CreatedDate = DateTime.UtcNow },
                new Customer { FirstName = "Jennifer", LastName = "Brown", Email = "jennifer.brown@example.com", PhoneNumber = "+90-532-123-4508", CreatedDate = DateTime.UtcNow }
            };

            // Add only the customers we need to reach at least 8
            var customersToAdd = demoCustomers.Skip(existingCustomerCount).ToArray();
            if (customersToAdd.Length > 0)
            {
                await context.Customers.AddRangeAsync(customersToAdd);
                await context.SaveChangesAsync();
            }
        }

        private static async Task SeedShipmentsAsync(CargoFlowDbContext context)
        {
            var existingShipmentCount = await context.Shipments.CountAsync();
            var existingTrackingNumbers = await context.Shipments.Select(s => s.TrackingNumber).ToListAsync();

            // If we have at least 20 shipments, don't add more
            if (existingShipmentCount >= 20)
            {
                return;
            }

            // Turkish city pairs for realistic demo data
            var routes = new (string origin, string destination)[]
            {
                ("İstanbul", "Ankara"),
                ("Ankara", "İzmir"),
                ("İzmir", "Bursa"),
                ("Bursa", "Kocaeli"),
                ("Kocaeli", "İstanbul"),
                ("İstanbul", "Antalya"),
                ("Antalya", "Konya"),
                ("Konya", "Gaziantep"),
                ("Gaziantep", "Adana"),
                ("Adana", "Mersin"),
                ("Mersin", "İstanbul"),
                ("İstanbul", "Trabzon"),
                ("Ankara", "Diyarbakır"),
                ("İzmir", "Aydın"),
                ("Bursa", "Balıkesir"),
                ("Kocaeli", "Sakarya"),
                ("Antalya", "Alanya"),
                ("Konya", "Aksaray"),
                ("Gaziantep", "Mardin"),
                ("Adana", "Hatay")
            };

            var statuses = new[] { ShipmentStatus.Created, ShipmentStatus.InWarehouse, ShipmentStatus.InTransit, ShipmentStatus.Delivered, ShipmentStatus.Cancelled };
            var weights = new decimal[] { 50.0m, 100.5m, 150.25m, 200.0m, 275.75m, 320.5m, 85.0m, 110.25m, 160.0m, 225.0m };

            var newShipments = new List<Shipment>();
            var trackingNumber = 1;

            for (int i = existingShipmentCount; i < 20; i++)
            {
                // Find an unused tracking number
                string currentTracking;
                do
                {
                    currentTracking = $"CF-2026-{trackingNumber:D3}";
                    trackingNumber++;
                } while (existingTrackingNumbers.Contains(currentTracking));

                var route = routes[i % routes.Length];
                var status = statuses[i % statuses.Length];
                var weight = weights[i % weights.Length];
                var daysAgo = (i % 15) + 1;

                var shipment = new Shipment
                {
                    TrackingNumber = currentTracking,
                    Origin = route.origin,
                    Destination = route.destination,
                    Weight = weight,
                    Status = status,
                    CreatedDate = DateTime.UtcNow.AddDays(-daysAgo)
                };

                newShipments.Add(shipment);
                existingTrackingNumbers.Add(currentTracking);
            }

            if (newShipments.Count > 0)
            {
                await context.Shipments.AddRangeAsync(newShipments);
                await context.SaveChangesAsync();
            }
        }
    }
}
