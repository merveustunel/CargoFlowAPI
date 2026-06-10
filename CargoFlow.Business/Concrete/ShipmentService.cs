#nullable enable
using CargoFlow.Business.Abstract;
using CargoFlow.Business.DTOs.Shipments;
using CargoFlow.DataAccess.Interfaces;
using CargoFlow.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CargoFlow.Business.Concrete
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<IEnumerable<ShipmentDto>> GetAllAsync()
        {
            var shipments = await _shipmentRepository.GetAllAsync();
            return shipments.Select(MapToDto);
        }

        public async Task<ShipmentDto?> GetByIdAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);
            return shipment is null ? null : MapToDto(shipment);
        }

        public async Task<ShipmentDto> CreateAsync(CreateShipmentDto createShipmentDto)
        {
            ValidateCreateShipment(createShipmentDto);

            var shipment = new Shipment
            {
                TrackingNumber = createShipmentDto.TrackingNumber.Trim(),
                Origin = createShipmentDto.Origin.Trim(),
                Destination = createShipmentDto.Destination.Trim(),
                Weight = createShipmentDto.Weight,
                Status = ShipmentStatus.Created,
                CreatedDate = DateTime.UtcNow
            };

            var addedShipment = await _shipmentRepository.AddAsync(shipment);
            return MapToDto(addedShipment);
        }

        public async Task<ShipmentDto> UpdateAsync(int id, UpdateShipmentDto updateShipmentDto)
        {
            ValidateUpdateShipment(updateShipmentDto);

            var existingShipment = await _shipmentRepository.GetByIdAsync(id);
            if (existingShipment is null)
            {
                throw new KeyNotFoundException($"Shipment with id {id} was not found.");
            }

            existingShipment.TrackingNumber = updateShipmentDto.TrackingNumber.Trim();
            existingShipment.Origin = updateShipmentDto.Origin.Trim();
            existingShipment.Destination = updateShipmentDto.Destination.Trim();
            existingShipment.Weight = updateShipmentDto.Weight;

            await _shipmentRepository.UpdateAsync(existingShipment);
            return MapToDto(existingShipment);
        }

        public async Task DeleteAsync(int id)
        {
            var existingShipment = await _shipmentRepository.GetByIdAsync(id);
            if (existingShipment is null)
            {
                throw new KeyNotFoundException($"Shipment with id {id} was not found.");
            }

            await _shipmentRepository.DeleteAsync(existingShipment);
        }

        private static void ValidateCreateShipment(CreateShipmentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TrackingNumber))
            {
                throw new ArgumentException("Shipment tracking number is required.", nameof(dto.TrackingNumber));
            }

            if (string.IsNullOrWhiteSpace(dto.Origin))
            {
                throw new ArgumentException("Shipment origin is required.", nameof(dto.Origin));
            }

            if (string.IsNullOrWhiteSpace(dto.Destination))
            {
                throw new ArgumentException("Shipment destination is required.", nameof(dto.Destination));
            }

            if (dto.Weight <= 0)
            {
                throw new ArgumentException("Shipment weight must be greater than zero.", nameof(dto.Weight));
            }
        }

        private static void ValidateUpdateShipment(UpdateShipmentDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.TrackingNumber))
            {
                throw new ArgumentException("Shipment tracking number is required.", nameof(dto.TrackingNumber));
            }

            if (string.IsNullOrWhiteSpace(dto.Origin))
            {
                throw new ArgumentException("Shipment origin is required.", nameof(dto.Origin));
            }

            if (string.IsNullOrWhiteSpace(dto.Destination))
            {
                throw new ArgumentException("Shipment destination is required.", nameof(dto.Destination));
            }

            if (dto.Weight <= 0)
            {
                throw new ArgumentException("Shipment weight must be greater than zero.", nameof(dto.Weight));
            }
        }

        private static ShipmentDto MapToDto(Shipment shipment)
        {
            return new ShipmentDto
            {
                Id = shipment.Id,
                TrackingNumber = shipment.TrackingNumber,
                Origin = shipment.Origin,
                Destination = shipment.Destination,
                Weight = shipment.Weight,
                Status = shipment.Status,
                CreatedDate = shipment.CreatedDate
            };
        }
    }
}
