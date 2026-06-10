#nullable enable
using CargoFlow.DataAccess.Interfaces;
using CargoFlow.Entities;

namespace CargoFlow.DataAccess.Repositories
{
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        public ShipmentRepository(CargoFlowDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
