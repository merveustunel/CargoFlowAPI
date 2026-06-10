#nullable enable

namespace CargoFlow.Business.DTOs.Dashboard
{
    public sealed class DashboardDto
    {
        public int TotalShipments { get; set; }

        public int DeliveredShipments { get; set; }

        public int InTransitShipments { get; set; }

        public int CancelledShipments { get; set; }

        public int TotalCustomers { get; set; }
    }
}
