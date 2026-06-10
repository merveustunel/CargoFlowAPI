#nullable enable
using System;
using CargoFlow.Entities;

namespace CargoFlow.Business.DTOs.Shipments
{
    public sealed class ShipmentDto
    {
        public int Id { get; set; }

        public string TrackingNumber { get; set; } = null!;

        public string Origin { get; set; } = null!;

        public string Destination { get; set; } = null!;

        public decimal Weight { get; set; }

        public ShipmentStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
