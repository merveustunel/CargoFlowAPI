#nullable enable
using CargoFlow.Entities;

namespace CargoFlow.Business.DTOs.Shipments
{
    public sealed class UpdateShipmentStatusDto
    {
        public ShipmentStatus Status { get; set; }
    }
}
