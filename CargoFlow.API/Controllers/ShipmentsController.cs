#nullable enable
using CargoFlow.Business.Abstract;
using CargoFlow.Business.DTOs.Shipments;
using Microsoft.AspNetCore.Mvc;

namespace CargoFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;

        public ShipmentsController(IShipmentService shipmentService)
        {
            _shipmentService = shipmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentDto>>> GetAll()
        {
            var shipments = await _shipmentService.GetAllAsync();
            return Ok(shipments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentDto>> GetById(int id)
        {
            var shipment = await _shipmentService.GetByIdAsync(id);
            if (shipment is null)
            {
                return NotFound();
            }

            return Ok(shipment);
        }

        [HttpGet("tracking/{trackingNumber}")]
        public async Task<ActionResult<ShipmentTrackingDto>> GetByTrackingNumber(string trackingNumber)
        {
            var shipment = await _shipmentService.GetByTrackingNumberAsync(trackingNumber);
            if (shipment is null)
            {
                return NotFound();
            }

            return Ok(shipment);
        }

        [HttpPost]
        public async Task<ActionResult<ShipmentDto>> Create(CreateShipmentDto createShipmentDto)
        {
            var createdShipment = await _shipmentService.CreateAsync(createShipmentDto);
            return CreatedAtAction(nameof(GetById), new { id = createdShipment.Id }, createdShipment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ShipmentDto>> Update(int id, UpdateShipmentDto updateShipmentDto)
        {
            try
            {
                var updatedShipment = await _shipmentService.UpdateAsync(id, updateShipmentDto);
                return Ok(updatedShipment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPatch("{id}/status")]
        public async Task<ActionResult<ShipmentDto>> UpdateStatus(int id, UpdateShipmentStatusDto statusDto)
        {
            try
            {
                var updatedShipment = await _shipmentService.UpdateStatusAsync(id, statusDto);
                return Ok(updatedShipment);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _shipmentService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
