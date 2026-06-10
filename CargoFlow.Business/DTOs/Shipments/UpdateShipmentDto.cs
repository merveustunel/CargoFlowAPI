#nullable enable
namespace CargoFlow.Business.DTOs.Shipments
{
    public sealed class UpdateShipmentDto
    {
        public required string TrackingNumber { get; set; }

        public required string Origin { get; set; }

        public required string Destination { get; set; }

        public decimal Weight { get; set; }
    }
}
