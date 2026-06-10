#nullable enable
using CargoFlow.Business.Abstract;
using CargoFlow.Business.DTOs.Dashboard;
using CargoFlow.DataAccess.Interfaces;
using CargoFlow.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace CargoFlow.Business.Concrete
{
    public class DashboardService : IDashboardService
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly ICustomerRepository _customerRepository;

        public DashboardService(
            IShipmentRepository shipmentRepository,
            ICustomerRepository customerRepository)
        {
            _shipmentRepository = shipmentRepository;
            _customerRepository = customerRepository;
        }

        public async Task<DashboardDto> GetDashboardAsync()
        {
            var shipments = await _shipmentRepository.GetAllAsync();
            var customers = await _customerRepository.GetAllAsync();

            var totalShipments = shipments.Count();
            var deliveredShipments = shipments.Count(x => x.Status == ShipmentStatus.Delivered);
            var inTransitShipments = shipments.Count(x => x.Status == ShipmentStatus.InTransit);
            var cancelledShipments = shipments.Count(x => x.Status == ShipmentStatus.Cancelled);
            var totalCustomers = customers.Count();

            return new DashboardDto
            {
                TotalShipments = totalShipments,
                DeliveredShipments = deliveredShipments,
                InTransitShipments = inTransitShipments,
                CancelledShipments = cancelledShipments,
                TotalCustomers = totalCustomers
            };
        }
    }
}
