#nullable enable
using System;

namespace CargoFlow.Entities
{
    public class Shipment : BaseEntity
    {
        public required string TrackingNumber { get; set; }

        public required string Origin { get; set; }

        public required string Destination { get; set; }

        public decimal Weight { get; set; }

        public ShipmentStatus Status { get; set; } = ShipmentStatus.Created;
    }
}
