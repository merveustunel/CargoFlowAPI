#nullable enable

namespace CargoFlow.Entities
{
    public class Vehicle : BaseEntity
    {
        public required string PlateNumber { get; set; }

        public required string Model { get; set; }

        public int Capacity { get; set; }
    }
}
