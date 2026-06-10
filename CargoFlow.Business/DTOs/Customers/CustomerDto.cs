#nullable enable
using System;

namespace CargoFlow.Business.DTOs.Customers
{
    public sealed class CustomerDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateTime CreatedDate { get; set; }
    }
}
