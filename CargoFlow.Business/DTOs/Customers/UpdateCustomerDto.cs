#nullable enable
namespace CargoFlow.Business.DTOs.Customers
{
    public sealed class UpdateCustomerDto
    {
        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required string Email { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
