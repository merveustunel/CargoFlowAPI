#nullable enable
using CargoFlow.Business.DTOs.Shipments;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CargoFlow.Business.Abstract
{
    public interface IShipmentService
    {
        Task<IEnumerable<ShipmentDto>> GetAllAsync();

        Task<ShipmentDto?> GetByIdAsync(int id);

        Task<ShipmentTrackingDto?> GetByTrackingNumberAsync(string trackingNumber);

        Task<ShipmentDto> CreateAsync(CreateShipmentDto createShipmentDto);

        Task<ShipmentDto> UpdateAsync(int id, UpdateShipmentDto updateShipmentDto);

        Task<ShipmentDto> UpdateStatusAsync(int id, UpdateShipmentStatusDto statusDto);

        Task DeleteAsync(int id);
    }
}
