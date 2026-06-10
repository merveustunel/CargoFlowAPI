#nullable enable

namespace CargoFlow.Entities
{
    public class Driver : BaseEntity
    {
        public required string FullName { get; set; }

        public required string LicenseNumber { get; set; }
    }
}
